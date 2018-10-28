/*ESP code
  At� 3 leituras diferentes separadas por espa�os e a acabar com line feed "\n" */

#include <SoftwareSerial.h>
#include <ESP8266WiFi.h>

#define debug 1;  //comentar para n�o haver comunica��o s�rie pela porta mini-USB

//credenciais da rede
const char* ssid     = "default";
const char* password = "";
const int httpPort = 80;  //Apache esta na porta 80
const char* host = "192.168.1.37";  //ip do servidor
const char* streamId   = "....................";
const char* privateKey = "....................";

//STRINGS DE ACESSO NO SETUP PARA INICIAR NOVA LINHA NA TABELA
String url = "/mcm/insertonce.php"; //ficheiro a aceder pela ESP que cria uma nova linha na tabela de pesos. Efetua 1 vez ao ligar a m�quina
String url2 = String("POST ") + url + " HTTP/1.1\r\n" +  "Host: " + host + "\r\n" +  "Connection: close\r\n\r\n";

int space = 0;

SoftwareSerial NodeMCU(D7, D8); // RX/TX

void setup() {   ///// SETUP /////
#ifdef debug
  Serial.begin(115200);
  Serial.print("Inicializando");
#endif
  delay(100);
  NodeMCU.begin(115200);
  delay(100);
  pinMode(D7, INPUT);
  pinMode(D8, OUTPUT);

  WiFiClient client;
  WiFi.begin(ssid, password);               //ligar � rede
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
#ifdef debug
  Serial.print("Connecting to ");
  Serial.println(ssid);
  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
#endif

#ifdef debug                              // Confirmar se h� conex�o
  if (!client.connect(host, httpPort)) {
    Serial.println("connection failed");
  }
#endif

  //Enviar pedido de acesso
  client.print(url2);                     // CRIAR NOVA LINHA SQL
  client.stop();

#ifdef debug
  Serial.print("Requesting URL: ");
  Serial.print(url2);
#endif
  delay(1000);
}

void loop() {  ///// LOOP ////

  //Clear variables
  space = 0;
  String content1 = "\0";
  String content2 = "\0";
  String content3 = "\0";
  char character;
  delay(100);

  while (NodeMCU.available() == 0) {
    Serial.print(","); delay(100);   //wait for arduino msg
  }
  while (NodeMCU.available() && character != 10) {      //10=Line feed ASCII
    character = NodeMCU.read();
    if (isWhitespace(character)) space += 1;
    if (space == 0)      content1.concat(character);
    if (space == 1)      content2.concat(character);
    if (space == 2)      content3.concat(character);
  }
  content1.trim();                                      //eliminar espa�os
  content2.trim();                                      //eliminar espa�os
  content3.trim();                                      //eliminar espa�os

  NodeMCU.flush();                                      //empty buffer
  Serial.flush();                                       //empty buffer

#ifdef debug
  if (content1 != "") {
    Serial.print(content1 + " ");
    Serial.print(content2 + " ");
    Serial.println(content3);
  }
#endif

  //Insert Arduino values SQL
  String urll = "/mcm/logpeso.php/?peso1=" + content1 + "&peso2=" + content2 + "&peso3=" + content3; //ficheiro a aceder pela ESP que esta na pasta htdocs do xampp
  String urll2 = String("POST ") + urll + " HTTP/1.1\r\n" +  "Host: " + host + "\r\n" +  "Connection: close\r\n\r\n";
  WiFiClient client2;
  if (!client2.connect(host, httpPort)) {
#ifdef debug
    Serial.println("connection failed");
#endif
    return;
  }
  client2.print(urll2);                             // Enviar o pedido ao servidor

#ifdef debug
  while (client2.available()) {
    String line = client2.readStringUntil('\r');    // Read all the lines of the reply from server and print them to Serial
    Serial.print(line);
  }
  Serial.print("Requesting URL: ");
  Serial.print(urll2);
#endif

  client2.stop();
  delay(100);
}
