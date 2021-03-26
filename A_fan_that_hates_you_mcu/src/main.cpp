#include <Arduino.h>

#include "definitions.h"
#include "decay.h"

void setup()
{
	pinMode(CONTROL_PIN, OUTPUT);
	Serial.begin(SERIAL_BAUD);
	Serial.println("INITIATING SERVO CONTROL");

	set_interrupts();

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
					sprintf(str, "Setting speed to %d\0", value);
					Serial.print(str);
				} else {
					while (Serial.available() > 0)
						Serial.read();
				}
			} else {
				while(Serial.available() > 0)
					Serial.read();
			}

	delay(10);
}
