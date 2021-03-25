#include <Arduino.h>
#include "definitions.h"

void setup()
{
	Serial.begin(SERIAL_BAUD);
}

void loop()
{
	static int serialData = 0;
	static int8_t direction = 0;
	static uint8_t speed = 0;
	if (Serial.available())
	{
		static int read_int;
		read_int = Serial.read();
		direction = read_int & 0x80 ? 1 : -1;
		speed = read_int & 0x7F;
	}

	cli();
}