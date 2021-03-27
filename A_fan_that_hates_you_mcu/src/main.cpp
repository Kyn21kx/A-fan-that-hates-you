#include <Arduino.h>
#include "definitions.h"
#include "decay.h"

Servo motor;
uint8_t state = 0;
uint16_t speed;

void setup()
{
	//pinMode(CONTROL_PIN, OUTPUT);
	Serial.begin(SERIAL_BAUD);
	Serial.println("INITIATING SERVO CONTROL");
	motor.attach(CONTROL_PIN);
	motor.writeMicroseconds(1500);
	speed = 0;
}

char str[32];
void loop()
{
	static unsigned char read_stop;
	static int16_t value;
	if (Serial.available() > 0)
		if (Serial.read() == START_BYTE)
			if (Serial.available() == 3)
			{
				value = (Serial.read() << 8) | (Serial.read() & 0xFF);

				if (Serial.read() == STOP_BYTE)
				{
					//sprintf(str, "Setting speed to %d\0", value);
					speed = value;
					Serial.println(speed);
					motor.writeMicroseconds(1500 + speed);
					delay(200);
					//delayMicroseconds(100);
				} else {
					while (Serial.available() > 0)
						Serial.read();
				}
			} else {
				while(Serial.available() > 0)
					Serial.read();
			}
	else {
		motor.writeMicroseconds(1500);
		delay(200);
	}

	delay(10);
}