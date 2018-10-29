// ATmega 328/328p code
//Guardar configurações das tolbas em Mb.R[11], Mb.R[12], Mb.R[13]
//Guardar peso já processado em Mb.R[51], Mb.[52], Mb.R[53]
//Guardar pesos instantâneos em Mb.R[54], Mb.R[55], Mb.R[56]
//Guardar numero de sacos feitos em Mb.R[61], Mb.R[62], Mb.R[63]
//Function codes 1(read coils), 3(read registers), 5(write coil), 6(write register)
//signed int Mb.R[0 to 125] and bool Mb.C[0 to 128] -> MB_N_R MB_N_C
//Port 502 (defined in Mudbus.h) -> MB_PORT

#include <SoftwareSerial.h>
#include <Lpf.h>
#include "HX711.h"
#include <SPI.h>
#include  <Ethernet.h>
#include <M0dbus.h>
#include <SimpleTimer.h>

//3 celulas de carga
#define DOUT1  2
#define CLK1  3
#define DOUT2  4
#define CLK2  5
#define DOUT3  6
#define CLK3  7

//Atuadores (IN na placa)
#define OUT1 9              //tolba 1 alimentador
#define OUT2 10             //tolba 1 tampa
#define OUT3 14             //tolba 2 alimentador (A4)
#define OUT4 15             //tolba 2 tampa (A5)
#define OUT5 19             //tolba 3 alimentador
#define OUT6 18             //tolba 3 tampa

#define samples      50     //definir numero de amostras na media para tare inicial
#define BANDWIDTH_HZ 10     // largura de banda do output do filtro
#define offdelay     1000   //tempo de intervalo entre atuaon() e atuaoff()
#define espdelay     10000  //Mudar este valor (ms) para mudar frequencia de atualizaçao da base de dados

float  peso1 = 0;
float  peso2 = 0;
float  peso3 = 0;
float units1 = 0;
float units2 = 0;
float units3 = 0;
long offset1 = 0;
long offset2 = 0;
long offset3 = 0;
float filtrado1 = 0;
float filtrado2 = 0;
float filtrado3 = 0;
int32_t guarda1 = 0 ;
int32_t guarda2 = 0 ;
int32_t guarda3 = 0 ;
int conta1 = 0;
int conta2 = 0;
int conta3 = 0;
long media = 0;
long media2 = 0;
long media3 = 0;
int data[samples];
int data2[samples];
int data3[samples];
String stringtot; 
uint8_t count = 0;
uint8_t countt = 0;
//Credenciais de Rede
uint8_t mac[]     =  { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
uint8_t ip[]      = { 192, 168, 1, 177 };
uint8_t gateway[] = { 192, 168, 1, 1 };
uint8_t subnet[]  = { 255, 255, 255, 0 };

Mudbus Mb;                                  //construtor MODBUS

SoftwareSerial ESPCOM(A6, 1);               // RX | TX -> Rx atribuido a ADC6 -> não faz nada
LPF lpf31(BANDWIDTH_HZ, IS_BANDWIDTH_HZ);   //construtores de filtros
LPF lpf32(BANDWIDTH_HZ, IS_BANDWIDTH_HZ);
LPF lpf33(BANDWIDTH_HZ, IS_BANDWIDTH_HZ);

HX711 scale(DOUT1, CLK1);                   //Scales constructors
HX711 scalee(DOUT2, CLK2);
HX711 scaleee(DOUT3, CLK3);

SimpleTimer timer;                          //Construtor timer -> suporta varias instancias

void setup() {  /////  SETUP  ////
  Ethernet.begin(mac, ip, gateway, subnet);//configurações da rede
  delay(50);
  pinosconfig();                           //configurar pinos de atuaçao como digital outputs
  ESPCOM.begin(115200);                    // Start the software serial for communication with the ESP8266
  timer.setInterval(espdelay, espsend); 

  //Holding Registers
  Mb.R[54] = 0;                             //peso instantâneo na tolba 1
  Mb.R[55] = 0;                             //peso instantâneo na tolba 2
  Mb.R[56] = 0;                             //peso instantâneo na tolba 3

  // valores de configuraçao das tolbas(g) -> 30Kg = max
  Mb.R[11] = 30000;
  Mb.R[12] = 30000;
  Mb.R[13] = 30000;

  //valores totais pesados em cada linha desde o ultimo iniciar da máquina (Kg)
  Mb.R[51] = 0;
  Mb.R[52] = 0;
  Mb.R[53] = 0;

  //numero de sacos embalados 
  Mb.R[61] = 0;
  Mb.R[62] = 0;
  Mb.R[63] = 0;

  //declives de correção para peso -> chamados na função gram()
  Mb.R[101] = 1;
  Mb.R[102] = 1;
  Mb.R[103] = 1;

  //atuadores (coils)
  Mb.C[1] = 0;                                //flag to send values to ESP
  Mb.C[2] = 0;                                // Start/Stop flag1. (If==1) linha 1 começa a atuar
  Mb.C[3] = 0;                                // Start/Stop flag2. (If==1) linha 2 começa a atuar
  Mb.C[4] = 0;                                // Start/Stop flag3. (If==1) linha 3 começa a atuar

  //para fazer debug, se necessário
  Mb.C[11] = 0;                               //linha 1 - alimentador
  Mb.C[12] = 0;                               //linha 1 - tampa
  Mb.C[21] = 0;                               //linha 2 - alimentador
  Mb.C[22] = 0;                               //linha 2 - tampa
  Mb.C[31] = 0;                               //linha 3 - alimentador
  Mb.C[32] = 0;                               //linha 3 - tampa
  Mb.C[100] = 0;                              // tare flag

}
void loop()  ////  LOOP  ////
{
  timer.run();                               //Tratar dos temporizadores
  Mb.Run();                                  //Tratar de processos ModBus
    
  //Ler Celulas de carga
  units1 = scale.read();
  units2 = scalee.read();
  units3 = scaleee.read();

  //corrigir valor para peso
  peso1 = gram(units1, offset1, Mb.R[101]);
  peso2 = gram(units2, offset2, Mb.R[102]);
  peso3 = gram(units3, offset3, Mb.R[103]);

  //filtrar valores
  filtrado1 = lpf31.NextValue(peso1);
  filtrado2 = lpf32.NextValue(peso2);
  filtrado3 = lpf33.NextValue(peso3);

  //Atualizar pesos instantâneos em variáveis ModBus (int16)
  Mb.R[54] = filtrado1;
  Mb.R[55] = filtrado2;
  Mb.R[56] = filtrado3;

  //Para nao mostrar valores negativos (tirar isto numa fase inicial para testar e  corrigir offset)
  if (Mb.R[54] < 0) Mb.R[54] = 0;
  if (Mb.R[55] < 0) Mb.R[55] = 0;
  if (Mb.R[56] < 0) Mb.R[56] = 0;

  //Atuar saídas se necessário
  if ((filtrado1 >= Mb.R[11]) && (Mb.C[2] == 1)) { //passou o limite desejado -> atuar 1 vez durante 1 segundo na respetiva linha
    conta1++;
    if (conta1 < 2) {                              //if conta1==1...
      guarda1 = filtrado1;
      atuaon1();
      timer.setTimeout(offdelay, atuaoff1);        //chamar funcao para desativar 1 vez passado 1 segundo
    }
  }

  if ((filtrado2 >= Mb.R[12]) && (Mb.C[3] == 1)) { //passou o limite desejado -> atuar durante 1 segundo na resdpetiva linha
    conta2++;
    if (conta2 < 2) {                              //if conta1==1...
      guarda2 = filtrado2;
      atuaon2();
      timer.setTimeout(offdelay, atuaoff2);        //chamar funcao para desativar 1 vez passado 1 segundo
    }
  }

  if ((filtrado3 >= Mb.R[13]) && (Mb.C[4] == 1)) { //passou o limite desejado -> atuar durante 1 segundo na resdpetiva linha
    conta3++;
    if (conta3 < 2) { //if conta1==1...
      guarda3 = filtrado3;
      atuaon3();
      timer.setTimeout(offdelay, atuaoff3);        //chamar funcao para desativar 1 vez passado 1 segundo
    }
  }

  if (millis() > 4000 & millis() < 5000) {         //fazer tare automático ao iniciar baseado numa leitura apenas
    count++;
    if (count == 1) {
      offset1 = units1;
      offset2 = units2;
      offset3 = units3;
    }
  }

  if (Mb.C[100] == 1) {                           //If tare button -> tare com base na media de [samples] valores
    countt++;
    media = movavg(units1, data, 100);
    media2 = movavg(units2, data2, 100);
    media3 = movavg(units3, data3, 100);
    if (countt > 101) {
      offset1 = media;
      offset2 = media2;
      offset3 = media3;
      countt = 0;
      Mb.C[100] = 0; //reset tare flag
    }
  }

}   //END

//// Functions ////
void espsend() {                  //Enviar valores pesados "Hoje" para ESP8266 porta Serie
  Mb.C[1] = 1;
  stringtot = String(Mb.R[51]) + " " + String(Mb.R[52]) + " " + String(Mb.R[53]) + "\n"; //String a enviar para a ESP
  ESPCOM.print(stringtot);
  Mb.C[1] = 0;
}

void pinosconfig() {
  pinMode(OUT1, OUTPUT);           //Digital OUT1 (In)
  pinMode(OUT2, OUTPUT);           //Digital OUT2 (In)
  pinMode(OUT3, OUTPUT);           //Digital OUT3 (In)
  pinMode(OUT4, OUTPUT);           //Digital OUT4 (In)
  pinMode(OUT5, OUTPUT);           //Digital OUT5 (In) (anterior ADC6)
  pinMode(OUT6, OUTPUT);           //Digital OUT6 (In) (anterior ADC7)
  pinMode(0, OUTPUT);              //Pino 0 não é usado. Mas estava HIGH por ser RX default
  digitalWrite(0, LOW);
}

//Ativar saidas (coils) linha 1
void atuaon1() {
  digitalWrite(OUT1, HIGH);        //Parar alimentador 1
  digitalWrite(OUT2, HIGH);        //Abrir tampa 1
  Mb.C[11] = 1;                    //linha 1 - alimentador -> necesssário ativar GPIO correspondente
  Mb.C[12] = 1;                    //linha 1 - tampa
  Mb.R[51] += guarda1 / 1000;      // atualizar total pesado na linha 1 (casas decimais sao ignoradas)
  Mb.R[61] += 1;                   //mais 1 saco embalado
  lpf31.Reset(0);                  //Reset peso instantaneo linha 1
}

//Ativar saidas (coils) linha 2
void atuaon2() {
  digitalWrite(OUT3, HIGH);        //Parar alimentador 2
  digitalWrite(OUT4, HIGH);        //Abrir tampa 2
  Mb.C[21] = 1;                    //linha 2- alimentador
  Mb.C[22] = 1;                    //linha 2 - tampa
  Mb.R[52] += guarda2 / 1000;      // atualizar total pesado na linha 2 (casas decimais sao ignoradas)
  Mb.R[62] += 1;                   //mais 1 saco embalado
  lpf32.Reset(0);                  //Reset filter 3
}

//Ativar saidas (coils) linha 3
void atuaon3() {
  digitalWrite(OUT5, LOW);          //Parar alimentador 3
  digitalWrite(OUT6, LOW);          //Abrir tampa 3
  Mb.C[31] = 1;                     //linha 3 - alimentador
  Mb.C[32] = 1;                     //linha 3 - tampa
  Mb.R[53] += filtrado3 / 1000;     // atualizar total pesado na linha 3 (casas decimais sao ignoradas)
  Mb.R[63] += 1;                    //mais 1 saco embalado
  lpf33.Reset(0);                   //Reset filter 3
}

//desatuar saídas linha 1
void atuaoff1() {
  digitalWrite(OUT1, LOW);          //Parar alimentador 1
  digitalWrite(OUT2, LOW);          //Fechar tampa 1
  Mb.C[11] = 0;                     //linha 1 - alimentador
  Mb.C[12] = 0;                     //linha 1 - tampa
  conta1 = 0;                       //reset flag
  lpf33.Reset(0);                   //Reset filter 3
}

//desatuar saídas linha 2
void atuaoff2() {
  digitalWrite(OUT3, LOW);          //Parar alimentador 3
  digitalWrite(OUT4, LOW);          //Fechar tampa 3
  Mb.C[21] = 0;                     //linha 2 - alimentador
  Mb.C[22] = 0;                     //linha 2 - tampa
  conta2 = 0;                       //Reset flag
  lpf33.Reset(0);                   //Reset filter 3
}

//desatuar saídas linha 3
void atuaoff3() {
  digitalWrite(OUT5, HIGH);         //Parar alimentador 3
  digitalWrite(OUT6, HIGH);         //Fechar tampa 3
  Mb.C[31] = 0;                     //linha 3 - alimentador
  Mb.C[32] = 0;                     //linha 3 - tampa
  conta3 = 0;                       //reset flag
  lpf33.Reset(0);                   //Reset filter 3
}

//correção para peso
float gram(float val, float b, int m) {
  float x = (val - b) / m;          //equaçao da reta
  return x;
}

// filtro de media -> moving average
long movavg(float leitura, int data[], int len)
{
  long sum = 0;
  long output = 0;
  int maximo = 0;
  int minimo = 0;
  //shift array 1 byte to the left
  for (uint8_t j = 0; j < len - 1; j++)
  {
    data[j] = data[j + 1];
    sum += data[j];
  }
  data[len - 1] = leitura; //new value
  sum += leitura; //add new value to sum

  //Retirar outliers max e min
  maximo = maxValue(data, len);
  minimo = minValue(data, len);

  sum = sum - maximo - minimo;
  output = sum / (len - 2); //average
  return output;
}

//Retorna valor maximo de array, analisando len casas
int maxValue (int data[], int len) {
  int mxm = 0;
  mxm = data[0];
  for (uint8_t i = 0; i < len; i++) {
    if (data[i] > mxm) {
      mxm = data[i];
    }
  }
  return mxm;

};

//Retorna valor minimo de array, analisando len casas
int minValue (int data[], int len) {
  int  mn = data[0];
  for (uint8_t i = 0; i < len; i++) {
    if (data[i] < mn) {
      mn = data[i];
    }
  }
  return mn;
};

