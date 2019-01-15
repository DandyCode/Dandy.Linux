using System;
using System.Collections.Generic;
using System.Text;
using Dandy.Linux.Udev;

namespace UsbUdevExample
{
    public class EventProvider
    {
        public delegate void MessageReceivedEventHandler(object sender, UdevMessageReceivedEventArgs args);

        /// <summary>
        /// Срабатывает при изменении сообщения.
        /// </summary>
        public event MessageReceivedEventHandler MessageReceived;


        private NotificationModel _model;

        const string BlockTag = "block";
        const string BlockUsbTag = "usb";
        const string DeviceTypeTag = "usb-device";

        public EventProvider()
        {
            _model = new NotificationModel();
        }

        public void Hook()
        {
            while (true) {

                try {
                    using (var udev = new Context()) {
                        using (var monitor = new Monitor(udev)) {
                            monitor.Blocking = true;
                            //monitor.AddMatchTag("systemd");
                            monitor.AddMatchSubsystem(BlockTag);
                            monitor.AddMatchSubsystem(BlockUsbTag, DeviceTypeTag);

                            monitor.EnableReceiving();
                            using (var device = monitor.TryReceiveDevice()) {
                                if (device.IsInitialized) {

                                    _model.ActionType = device.Action;
                                    _model.DeviceName = device.DevNode;
                                    _model.SybSystem = device.Subsystem; // "scsi_device"
                                    _model.DeviceType = device.DevType; //usb_interface
                                    OnMessageReceived(new UdevMessageReceivedEventArgs(_model));
                                }
                            }
                        }
                    }
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Raises the message received event.
        /// </summary>
        /// <param name="args">Arguments.</param>
        protected virtual void OnMessageReceived(UdevMessageReceivedEventArgs args)
        {
            MessageReceived?.Invoke(this, args);
        }
    }
}
