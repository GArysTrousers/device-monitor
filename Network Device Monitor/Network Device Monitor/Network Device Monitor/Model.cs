using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Device_Monitor
{
    public class Model
    {
        public static string saveFileName = "Data.json";
        public static string logFileName = "Log.txt";

        public static int emailErrorLimit = 6;
        public static string emailSubject = "There is a Device Down";
        public static MailMan mailMan;

        public static List<Device> devices = new List<Device>();
        public static FormDisplay Display;

        public static void SetForm(FormDisplay form)
        {
            Display = form;
        }

        public static void AddDevice(string name, string ip)
        {
            Device newDevice = new Device(name, ip);
            devices.Add(newDevice);
        }

        public static void UpdateDevice(Device device)
        {
            try
            {
                Display.UpdateDevice(devices.IndexOf(device), device.output);
            }
            catch { } //will throw if device deleted
        }

        public static void SendOutput(string message)
        {
            try
            {
                Display.SendOutput(message);
            }
            catch { }
        }

        public static void Log(string message)
        {
            File.AppendAllText(logFileName, string.Format("{0} - {1}", DateTime.Now, message));
        }

        public static void Email(Device device)
        {
            if (mailMan != null)
            {
                String body = String.Format("Name: {0}\nIP: {1}", device.name, device.ip);

                mailMan.Send(emailSubject, body);
            }
        }
    }
}
