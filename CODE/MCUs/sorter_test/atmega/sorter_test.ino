//Cada vez que deteta a presença de taça com fruto, retorna m�dia das leituras efetuadas
// precis�o diminui com a velocidade

#include <Lpf.h>  //Livraria de Filtros
#include "HX711.h"  //Livraria HX711

//1 celula de carga
#define DOUT1  SDA
#define CLK1  SCL

#define samples 100   //definir numero de amostras na media. Nota: O maximo e minimo sao retirados
#define BANDWIDTH_HZ 40             // 3-dB bandwidth of the filter

float  peso1 = 0;
float units1 = 0;
float offset1 = 0;
int32_t count = 0;
long filtrado1 = 0;
int gramas = 0;
long offset = 0;
int countini = 0;
long thresh = 110000; // valor minimo de um fruto a ser pesado -> programa contabiliza apenas valores acima deste

long dataini[samples] = {};
long data[] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
unsigned long media = 0;
unsigned long mediaold = 0;
int vazias = 0;
int cheias = 0;
unsigned long tottacas = 0;

//Filter constructor
LPF lpf(BANDWIDTH_HZ, IS_BANDWIDTH_HZ);      //Create a Low Pass Filter - it's default cascade is 1 and initialization is 0.0.  To change it, call Reset with an initialValue.

// scale constructor
HX711 scale(DOUT1, CLK1);


void setup() {		////  SETUP  ////
  Serial.begin(115200);
  Serial.println("Inicio...");
}

void loop() {		////  LOOP  ////
  units1 = scale.read();
  filtrado1 = lpf.NextValue(units1);
  while (millis() < 500) { //tare automatico -> iniciar a m�quina com ta�a em cima da celula
    countini++;
    offset = movavg(units1, dataini, samples);
    if (countini > samples + 3) {
      Serial.println(offset);
      delay(50);
    }
  }

  // Serial.print(units1); Serial.print(","); Serial.println(filtrado1);// Serial.print(","); Serial.print(filtrado2); Serial.print(","); Serial.println(filtrado3);

  insertarray(filtrado1, data, 20);
  if (passoutaca(data, 20)) vazias += 1; //contar taca vazia
  media = detectlastpeak(data, 20, thresh);
  gramas = gram(media, offset, 222);
  if ((media != 0) && (media != mediaold)) { //apenas envia quando deteta uma nova media
    mediaold = media;
    Serial.print("media:  "); Serial.println(gramas);
    cheias = cheias + 1;
  }
  tottacas = cheias + vazias;
  //if tottacas= numero maximo de tacas na maquina -> cheias =0; vazias=0; tottacas=0 ou criar outra variavel
}

////  FUNCTIONS  ////

//modifica array data, introduzindo ultima leitura
void insertarray(float leitura, long data[], uint8_t len)
{
  //shift array 1 byte to the left
  for (int j = 0; j < len - 1; j++)
  {
    data[j] = data[j + 1];
  }
  data[len - 1] = leitura; //new value
}

//retorna valor maximo de um array data, analisando len casas
unsigned long maxValue (long data[], uint8_t len) {
  unsigned long mxm = 0;
  mxm = data[0];
  for (uint8_t i = 0; i < len; i++) {
    if ((data[i] > mxm) && (data[i] != '\0') && (data[i] >= 0)) {
      mxm = data[i];
    }
  }
  return mxm;
}

//retorna valor minimo de um array data, analisando len casas
unsigned long minValue (long data[], uint8_t len) {
  unsigned long  mn = data[0];
  for (uint8_t i = 0; i < len; i++) {
    if ((data[i] < mn) && (data[i] != '\0') && (data[i] >= 0)) {
      mn = data[i];
    }
  }
  return mn;
}

//deteta ultimo pico e retorna media ou retorna 0 se estiver a fazer a media -> ou seja ainda nao saiu fruto de cima
long detectlastpeak(long data[], uint8_t len, long thresh) {
  long thresh2 = thresh / 4.4;
  unsigned long soma = 0;
  uint8_t b = 0;
  uint8_t muda = 0;
  long out = 0;
  long datat[30] = {};
  long maximo = 0;
  long minimo = 0;
  for (uint8_t i = 0; i < len; i++) { //para o array de valores
    if (data[i] > thresh) {
      if (data[i - 1] - data[i] < thresh2) {
        //if (b<20) else guardar por cima dos valores j� adquiridos
        soma = soma + data[i];
        datat[b] = data[i];   //concatenar valores uteis (ultimo fruto) em nova matriz
        if (b < 30) { //se b=30 come�a a preencher array de valores uteis, do inicio
          b = b + 1;
        } else {
          b = 0;
        }
      }
    } else {
      if ((soma != 0) && (data[len - 1] < thresh) && (data[len - 2] > thresh)) {
        Serial.println("datat");
        for (int k = 0; k < b; k++)Serial.println(datat[k]);
        muda = muda + 1;; //detetar ponto minimo da amostra
        maximo = maxValue(datat, b);
        minimo = minValue(datat, b);
        if (b > 2) {      //pelo menos 3 valores retirados
          out = (soma - minimo - maximo) / (b - 2); //fazer media do ultimo pico e retirar max e min
        }
        else { // b=1|2
          out = (soma) / b; //fazer media do ultimo pico
        }
        soma = 0;
        b = 0;
        //long datat[20] = {}; //reset array de picos
        memset(datat, '\0', sizeof datat);
      }
    }
  }
  return out;
}

//corre��o da leitura para peso
long gram(long val, long b, int m) {
  long x = (val - b) / m; //equa�ao da reta
  return x;
}

//filtro de media
long movavg(long leitura, long data[], uint8_t len)
{
  long sum = 0;
  long output = 0;
  long maximo = 0;
  long minimo = 0;

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

bool passoutaca(long data[], uint8_t len) {
  bool vazia;
  if ((data[len - 1] < 77600) && (data[len - 2] > 77600) && (data[len - 3] > 77600)) {
    vazia = 1;
  } else {
    vazia = 0;
  }
  return vazia;
}

