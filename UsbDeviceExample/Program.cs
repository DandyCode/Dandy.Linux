using System;
using Dandy.Linux.Udev;

namespace UsbDeviceExample
{
	internal class Program
	{
		private const string BlockTag = "block";
		private const string BlockUsbTag = "usb";
		private const string DeviceTypeTag = "usb-device";

		private static void Main(string[] args)
		{
			// Device creating through monitor
			while (true)
			{
				try
				{
					using (var udev = new Context())
					{
						using (var monitor = new Monitor(udev))
						{
							monitor.Blocking = true;
							//monitor.AddMatchTag("systemd");
							monitor.AddMatchSubsystem(BlockTag);
							monitor.AddMatchSubsystem(BlockUsbTag, DeviceTypeTag);

							monitor.EnableReceiving();
							using (var d = monitor.TryReceiveDevice())
							{
								if (d.IsInitialized)
								{
									Console.WriteLine(d.Action);    // Add - Remove - Change Actions
									Console.WriteLine(d.DevNode);   // device name, f.e /dev/sda1;
									Console.WriteLine(d.Subsystem); // "scsi_device"
									Console.WriteLine(d.DevType);   //usb_interface
								}
							}
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
		}
	}
}
