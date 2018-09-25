using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Device_Monitor
{
    public class Model
    {
        public static int emailErrorLimit = 6;
        public static MailMan mailMan;

        public static List<Device> devices = new List<Device>();
        public static FormDisplay Display;

        public static void SetForm(FormDisplay form)
        {
            Display = form;
        }

        public static void AddDevice(String IP)
        {
            Device newDevice = new Device(IP);
            devices.Add(newDevice);
        }

        public static void UpdateDevice(Device device)
        {
            try
            {
                Display.UpdateDevice(devices.IndexOf(device), device.output);
            }
            catch { } //if there is a ping request for a deleted device, it will throw
        }

        public static void Email(Device device)
        {
            if (mailMan != null)
            {
                String subject = "There is a Device Down at OSC";
                String body = String.Format("Device IP: {0}", device.ip);

                mailMan.Send(subject, body);
            }
        }
    }
}
