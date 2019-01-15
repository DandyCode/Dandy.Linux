using System;
using System.Collections.Generic;
using System.Text;

namespace UsbUdevExample
{
    public class NotificationModel
    {
        public string ActionType { get; set; }
        public string DeviceName { get; set; }
        public string SysName { get; set; }
        public string SybSystem { get; set; }
        public string DeviceType { get; set; }

        public IEnumerable<string> DevLinks { get; set; }
    }
}
