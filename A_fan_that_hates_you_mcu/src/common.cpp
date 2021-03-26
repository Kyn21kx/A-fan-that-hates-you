#include "definitions.h"

volatile int16_t speed = 0;

void set_interrupts()
{
	TCCR1A = 0;
	TCCR1B = 0;
	TCNT1 = 0;
	OCR1A = (20000 * 2);
	TCCR1B = (1 << WGM12);
	TCCR1B |= (1 << CS11);
	TIMSK1 |= (1 << OCIE0A);
	sei();
}

static uint8_t state;
ISR(TIMER1_COMPA_vect)
{
	static int _decay = get_decay();

	speed *= _decay;

	if (!state)
	{
		OCR1A = ((1500 + speed) * 2);
		digitalWrite(CONTROL_PIN, HIGH);
		state = 1;
	}
	else
	{
		OCR1A = ((18500 - speed) * 2);
		digitalWrite(CONTROL_PIN, LOW);
		state = 0;
		_decay = get_decay();
	}
}