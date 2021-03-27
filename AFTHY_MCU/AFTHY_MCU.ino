 #include <Servo.h>
 int servoPin = 10; // connect servo to pin 10
Servo myServo = Servo();

void setup(void) {
  myServo.attach(servoPin);
  Serial.begin(9600); // begin serial monitor
  myServo.write(90);
}

void loop(void) {
    myServo.write(0);
    Serial.println("going to the left!");
    delay(2000);
    myServo.write(180);
    delay(2000);
}
