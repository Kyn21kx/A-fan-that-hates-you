using System;
using System.IO.Ports;

public class RobotManager
{

    private readonly SerialPort comPort;

    public RobotManager(String portName)
    {
        comPort = new SerialPort(portName);
    }
}
