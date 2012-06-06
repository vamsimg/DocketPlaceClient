using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;

namespace Redirector
{
	class Program
	{
		public static void Main(String[] args)
		{

			String pipedText = "";
			bool isKeyAvailable;

			try
			{
				isKeyAvailable = System.Console.KeyAvailable;
			}
			catch (InvalidOperationException expected)
			{
				pipedText = System.Console.In.ReadToEnd();
			}
			pipedText = pipedText.Replace("\n\n\n\n\n\n\n\n", "");
			//do something with pipedText or the args
			// Instantiate the communications
			// port with some basic settings
			SerialPort port = new SerialPort(
			  args[0], 9600, Parity.None, 8, StopBits.One);

			// Open the port for communications
			port.Open();

			// Write a string
			port.Write(pipedText);

			// Close the port
			port.Close();
		}
	}
}
