void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

int command = 0;
int count, time, calib = 0;
unsigned int data = 0;

void loop() {
  if (Serial.available() > 0)
  {
    String myString = Serial.readString();

    int arg1 = myString.indexOf(';');
    int arg2 = myString.indexOf(';', arg1 + 1);
    int arg3 = myString.indexOf(';', arg2 + 1);

    String sample_count = myString.substring(0, arg1);
    String sample_time = myString.substring(arg1 + 1, arg2);
    String calibration = myString.substring(arg2 + 1, arg3);

    count = sample_count.toInt();
    time = sample_time.toInt();
    calib = calibration.toInt();

    if (count == 0 & time == 0)
    {
      command = 0;
      Serial.println(-1);
    }
    else
    {
      command = 1;
    }
  }

  if (command == 1)
  {
    data = 0;
    for (int i = 0; i < count; i++)
    {
      data = data + analogRead(0);
      delay(time);
    }
    Serial.println(data);
    if(calib == 1) command = 0;
  }
}
