#ifndef DEFINITIONS_H
#define DEFINITIONS_H
#include <Arduino.h>
#include <Servo.h>
#include "decay.h"

#define START_BYTE 0x11
#define STOP_BYTE 0x7F

#define CONTROL_PIN 10
#define SERIAL_BAUD 115200
#define NEUTRAL_POS 1500

//extern volatile int16_t speed;
extern uint8_t state;
extern void set_interrupts();

#define SET_INTERRUPT_TIME(x) (OCR1A = (x * 2))

#endif //DEFINITIONS_H
