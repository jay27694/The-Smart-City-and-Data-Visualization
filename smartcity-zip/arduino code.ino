#include <SFE_BMP180.h>
#include <Wire.h>
#include <dht.h>
#include <BH1750FVI.h>

// You will need to create an SFE_BMP180 object, here called "pressure":

SFE_BMP180 pressure;
//A5 scl
//A4 sda

dht DHT;
//digital pin 5
//vcc 5v
#define DHT11_PIN 5

//lm393 fire
#define ANALOG_SENSOR_PIN  A0 
#define DIGITAL_SENSOR_PIN 3
#define LEDPIN    13

//rain1
#define ANALOG_SENSOR_PIN_Rain  A1 
#define DIGITAL_SENSOR_PIN_Rain 2

//rain2
#define ANALOG_SENSOR_PIN_Rain2  A3 
#define DIGITAL_SENSOR_PIN_Rain2 12


//bh1750
/*VCC >>> 3.3V
  SDA >>> A4 
  SCL >>> A5
  addr >> A3
  Gnd >>>Gnd*/
BH1750FVI LightSensor;


void setup()
{
  pinMode(13,OUTPUT);
  Serial.begin(9600);
  LightSensor.begin();
  LightSensor.SetAddress(Device_Address_L); //Address 0x23
  LightSensor.SetMode(Continuous_H_resolution_Mode);
  while(1)
  {
  if (pressure.begin())
    break;
  }
  
}

String doubleToString(double input,int decimalPlaces)
{
  if(decimalPlaces!=0)
   {
  String string = String((int)(input*pow(10,decimalPlaces)));
    if(abs(input)<1)
      {
        if(input>0)
        string = "0"+string;
    else if(input<0)
        string = string.substring(0,1)+"0"+string.substring(1);
      }
      return string.substring(0,string.length()-decimalPlaces)+"."+string.substring(string.length()-decimalPlaces);
   }
   else 
   {
  return String((int)input);
    }
}

String integrated;
int val;
void loop()
{
  //BMP180 pressure temp
  char status;
  double T,P;
  String flame,rain,rain2;
  String TempStoreAsString,PressureStoreAsString,HumidityStoreAsString="X";
  
  status = pressure.startTemperature();
  if (status != 0)
  {
  
    delay(status);

    status = pressure.getTemperature(T);
    if (status != 0)
    {
     
      //Serial.print("temperature: ");
      TempStoreAsString = doubleToString(T,2);
      //Serial.print(TempStoreAsString+"|"); 
    

      status = pressure.startPressure(3);
      if (status != 0)
      {
      
        delay(status);
        status = pressure.getPressure(P,T);
        if (status != 0)
        {
         //Serial.print("absolute pressure: ");
         PressureStoreAsString = doubleToString(P*0.0295333727,2);
         // Serial.print(PressureStoreAsString);          
        }
        else PressureStoreAsString="X";
      }
      else PressureStoreAsString="X";
    }
    else TempStoreAsString="X";
  }
  else  TempStoreAsString="X";
  
  //DHT11 humidity
  
  int chk = DHT.read11(DHT11_PIN);
  switch (chk)
  {
    case DHTLIB_OK:  
		//Serial.print("OK,\t"); 
		break;
    case DHTLIB_ERROR_CHECKSUM: 
		//Serial.print("Checksum error,\t"); 
		break;
    case DHTLIB_ERROR_TIMEOUT: 
		//Serial.print("Time out error,\t"); 
		break;
    default: 
		//Serial.print("Unknown error,\t"); 
		break;
  }
  
    HumidityStoreAsString = doubleToString(DHT.humidity,2);
  
  
  //lm393 flame detector
  int  switch_state;  /* Holds the last digital value */
  switch_state = digitalRead(DIGITAL_SENSOR_PIN);  
  if (switch_state == LOW)
  {
    //digitalWrite(LEDPIN, HIGH);
    //Serial.println("Digital Signal ON ");
    flame="1";
  }  
  else
  {
     flame="0";
   // digitalWrite(LEDPIN, LOW);
  }
  
  //Rain detector1
  int  switch_state_Rain;  /* Holds the last digital value */
  switch_state_Rain = digitalRead(DIGITAL_SENSOR_PIN_Rain);  
  if (switch_state_Rain == LOW)
  {
    //digitalWrite(LEDPIN, HIGH);
    //Serial.println("Digital Signal ON ");
    rain="1";
  }  
  else
  {
     rain="0;
    //digitalWrite(LEDPIN, LOW);
  }
  
  //Rain detector2
  int  switch_state_Rain2;  /* Holds the last digital value */
  switch_state_Rain2 = digitalRead(DIGITAL_SENSOR_PIN_Rain2);  
  if (switch_state_Rain2 == LOW)
  {
    //digitalWrite(LEDPIN, HIGH);
    //Serial.println("Digital Signal ON ");
    rain2='1';
  }  
  else
  {
     rain2='0';
    //digitalWrite(LEDPIN, LOW);
  }
  
  

 //bh1750
 uint16_t lux = LightSensor.GetLightIntensity();// Get Lux value

  if(Serial.available())
  {
   val = Serial.read() - '0';
  
  if(val==1)
  {
    digitalWrite(13,HIGH);
  }
   else if(val==0)
  {
    digitalWrite(13,LOW);
  }
  }
  integrated=TempStoreAsString+"|"+PressureStoreAsString+"|"+HumidityStoreAsString+"|"+flame+"|"+rain+"|"+rain2+"|"+lux;

  Serial.println(integrated);
  
  delay(200);  // Pause for 1 seconds.
}
