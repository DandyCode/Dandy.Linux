using System;
using System.Collections.Generic;
using System.Text;

namespace UsbUdevExample
{
    public sealed class UdevMessageReceivedEventArgs
    {
        public readonly string Device;

        public readonly string Action;

        public readonly string SysName;

        public readonly string DeviceType;

        /// <summary>
        /// .ctor
        /// </summary>
        public UdevMessageReceivedEventArgs()
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="model"></param>
        public UdevMessageReceivedEventArgs(NotificationModel model)
        {
            Device = model.DeviceName;
            Action = model.ActionType;
            SysName = model.SysName;
            DeviceType = model.DeviceType;
        }
    }
}
