// arduino code
//Guardar pesos de cada linha em Mb.R[11], Mb.R[12], Mb.R[13]
//Function codes 1(read coils), 3(read registers), 5(write coil), 6(write register)
//signed int Mb.R[0 to 125] and bool Mb.C[0 to 128] MB_N_R MB_N_C
//Port 502 (defined in Mudbus.h) MB_PORT
//Registos MODBUS apenas a nível informativo. Para atuar saídas é necessário chamar GPIO necessário

#include <SoftwareSerial.h>
#include <Lpf.h>  //Livraria de Filtros
#include "HX711.h"  //Livraria HX711
#include <SPI.h>    //Para comunicacao MODBUS atraves de ENCJ
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
//#define numscale 3 //descomentar para 3 HX711

#define samples 4   //definir numero de amostras na media. Nota: O maximo e minimo sao retirados
#define BANDWIDTH_HZ          3.0     // 3-dB bandwidth of the filter


float  peso1 = 0;
float  peso2 = 0;
float  peso3 = 0;
float units1 = 0;
float units2 = 0;
float units3 = 0;
float offset1 = 0;
float offset2 = 0;
float offset3 = 0;
float filtrado1 = 0;
float filtrado2 = 0;
float filtrado3 = 0;
int total1 = 0;
int total2 = 0;
int total3 = 0;
int32_t lotes1 = 0;
int32_t lotes2 = 0;
int32_t lotes3 = 0;
String stringtot;
int32_t count = 0;
float media = 0;
float data[samples];

Mudbus Mb;  //construtor MODBUS

SoftwareSerial ESPCOM(0, 1); // RX | TX
LPF lpf31(BANDWIDTH_HZ, IS_BANDWIDTH_HZ, 3); //Create a three cascade LPF
LPF lpf32(BANDWIDTH_HZ, IS_BANDWIDTH_HZ, 3); //Create a three cascade LPF
LPF lpf33(BANDWIDTH_HZ, IS_BANDWIDTH_HZ, 3); //Create a three cascade LPF

HX711 scale(DOUT1, CLK1);   //Scales constructors
HX711 scalee(DOUT2, CLK2);
HX711 scaleee(DOUT3, CLK3);

SimpleTimer timer; //Create a timer -> suporta varias instancias

void setup() {   //////////////////////////////////////////////  SETUP  ///////////////////////////////////
  uint8_t mac[]     =  { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
  uint8_t ip[]      = { 192, 168, 1, 177 };
  uint8_t gateway[] = { 192, 168, 1, 1 };
  uint8_t subnet[]  = { 255, 255, 255, 0 };
  Ethernet.begin(mac, ip, gateway, subnet);

  //Registers
  Mb.R[1] = 0; //peso instantâneo na tolba 1
  Mb.R[2] = 0; //peso instantâneo na tolba 2
  Mb.R[3] = 0; //peso instantâneo na tolba 3

  Mb.R[11] = 30000;   //Initialize weights at max value
  Mb.R[12] = 30000;
  Mb.R[13] = 30000;

  //atuadores (coils)
  Mb.C[1] = 0; //flag to send values to ESP
  Mb.C[11] = 0; //linha 1 - alimentador
  Mb.C[12] = 0; ////linha 1 - tampa
  Mb.C[21] = 0; //linha 2 - alimentador
  Mb.C[22] = 0; //linha 2 - tampa
  Mb.C[31] = 0; //linha 3 - alimentador
  Mb.C[32] = 0; //linha 3 - tampa
  ESPCOM.begin(115200);     // Start the software serial for communication with the ESP8266
  timer.setInterval(10000, espsend); //Mudar este valor (ms) para mudar frequencia de atualizaçao da base de dados

}

void loop()  //////////////////////////////////////////////  LOOP  ///////////////////////////////////
{
  timer.run();
  Mb.Run(); //Update the values of Mb.R and Mb.C every loop cycle

  units1 = scale.read(); //Ler Celulas de carga
  units2 = scalee.read();
  units3 = scaleee.read();
  //Para nao dar valores negativos
  if (units1 < 0) units1 = 0;
  if (units2 < 0) units2 = 0;
  if (units3 < 0) units3 = 0;
  
  //corrigir valor para peso
  peso1 = gram(units1, -17100, 77) - offset1; 
  peso2 = gram(units2, -17100, 77) - offset2;
  peso3 = gram(units3, -17100, 77) - offset3;
  filtrado1 = lpf31.NextValue(peso1);       //filtrar valores
  filtrado2 = lpf32.NextValue(peso2);
  filtrado3 = lpf33.NextValue(peso3);

  //store total values in MODBUS variables (int) if line is not stopped
  if (Mb.C[11] == 0) Mb.R[1] += filtrado1;
  if (Mb.C[12] == 0) Mb.R[2] += filtrado2;
  if (Mb.C[13] == 0) Mb.R[3] += filtrado3;

  if (Mb.R[1] >= Mb.R[11]) { //passou o limite desejado -> atuar durante 1 segundo na resdpetiva linha
    Mb.R[1] = 0; //Reset peso instantaneo linha 1
    //Ativar saidas (coils)
    Mb.C[11] = 1; //linha 1 - alimentador -> necesssário ativar GPIO correspondente
    Mb.C[12] = 1; //linha 1 - tampa
    timer.setTimeout(1000, atuaoff1); //chamar funcao para desativar 1 vez passado 1 segundo
  }

  if (Mb.R[2] >= Mb.R[12]) { //passou o limite desejado -> atuar durante 1 segundo na resdpetiva linha
    Mb.R[2] = 0; //Reset peso instantaneo linha 2
    //Ativar saidas (coils)
    Mb.C[21] = 1; //linha 2- alimentador
    Mb.C[22] = 1; //linha 2 - tampa
    timer.setTimeout(1000, atuaoff2); //chamar funcao para desativar 1 vez passado 1 segundo
  }
  if (Mb.R[3] >= Mb.R[13]) { //passou o limite desejado -> atuar durante 1 segundo na resdpetiva linha
    Mb.R[3] = 0; //Reset peso instantaneo linha 1
    //Ativar saidas (coils)
    Mb.C[31] = 1; //linha 3 - alimentador
    Mb.C[32] = 1; //linha 3 - tampa
    timer.setTimeout(1000, atuaoff3); //chamar funcao para desativar 1 vez passado 1 segundo
  }

  if (millis() > 4000 & millis() < 5000) {  //fazer tare automático ao iniciar
    count++;
    if (count == 1) {
      offset1 = peso1;
      offset2 = peso2;
      offset3 = peso3;
    }
  }

  //Enviar valores para ESP porta Serie
  if (Mb.C[1] == 1) {
    stringtot = String(filtrado1, 2) + " " + String(filtrado2, 2) + " " + String(filtrado3, 2) + "\n"; //String a enviar para a ESP
    ESPCOM.print(stringtot);
    Mb.C[1] = 0; //reset flag
  }
}

/////////////////////////////////////////////////////////// Functions //////////////////////////////////////
void espsend() {
  Mb.C[1] = 1; //set flag
}

void atuaoff1() { //desatuar saídas linha 1
  Mb.C[11] = 0; //linha 1 - alimentador
  Mb.C[12] = 0; ////linha 1 - tampa
}
void atuaoff2() { //deswatuar saídas linha 2
  Mb.C[21] = 0; //linha 2 - alimentador
  Mb.C[22] = 0; ////linha 2 - tampa
}
void atuaoff3() { //deswatuar saídas linha 3
  Mb.C[31] = 0; //linha 3 - alimentador
  Mb.C[32] = 0; ////linha 3 - tampa
}

float gram(float val, float b, float m) {
  float x = (val - b) / m; //equaçao da reta
  return x;
}
