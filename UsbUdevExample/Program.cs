using System;

namespace UsbUdevExample
{
	internal class Program
	{
		private static void Main(string[] args)
		{

			Console.WriteLine("udev Action test");

			var eventProvider = new EventProvider();

			eventProvider.MessageReceived += (s, a) => Console.WriteLine($"{a.Action}\n{a.Device}");

			eventProvider.Hook(); // Hook udev monitor 

			Console.ReadLine();
		}
	}
}
