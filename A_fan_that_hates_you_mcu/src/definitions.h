#include <Arduino.h>
#ifndef DEFINITIONS_H
#define DEFINITIONS_H

#define SERIAL_BAUD 115200
// Inline definition to interpolate 7bit speed to delta T for the
// square waive width;
#define BIT_7_TO_SERVO_SPEED (x)(x / 127) * 600;

#endif //DEFINITIONS_H