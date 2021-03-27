using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace AFTHY
{
	class RobotHandler
	{
		public bool Moving { get; private set; }

		static readonly byte WRITE_START = (byte)0x11;
		static readonly byte WRITE_STOP = (byte)0x7f;

		readonly SerialPort sp;
		public RobotHandler(string port) {
			sp = new SerialPort(port);
			sp.BaudRate = 115200;
			msg = new byte[]{
				 WRITE_START,
				 0,
				 0,
				 WRITE_STOP
			};

			sp.Open();
		}

		public void Dispose()
		{
			if (sp.IsOpen)
				sp.Close();

			sp.Dispose();
		}

		private byte[] msg;
		public void setData(short speed) {
			if (Moving) return;
			//Console.WriteLine(speed);
			msg[1] = (byte)(speed >> 8);
			msg[2] = (byte)(speed);

			sp.Write(msg, 0, 4);
			Thread.Sleep(15);

			while (sp.BytesToRead > 0) {
				string postBack = sp.ReadExisting();
				Moving = postBack == "0";
				Console.WriteLine(postBack);
				
            }
		}


		~RobotHandler() {
			if (sp.IsOpen) {
				this.setData(0);
				sp.Close();
			}

			sp.Dispose();
		}

		public static string[] getAllAvailablePorts()
		{
			return SerialPort.GetPortNames();
		}
	}
}
