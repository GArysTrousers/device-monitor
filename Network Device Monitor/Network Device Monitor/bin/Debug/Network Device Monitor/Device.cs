using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Network_Device_Monitor
{
    [Serializable]
    public class Device
    {
        public string name;
        public IPAddress ip;
        public string output;
        public int consecErrors = 0;

        public Device(string name, string ip)
        {
            this.name = name;
            this.ip = IPAddress.Parse(ip);
        }

        public void Log(string log)
        {
            Debug.WriteLine(log);
        }

        public void ConnectionError()
        {
            consecErrors += 1;
            if (consecErrors == Model.emailErrorLimit)
            {
                string error = string.Format("{0}({1}) went down at {2}", name, ip, DateTime.Now);
                Model.SendOutput(error);
                Model.Log(error);
                Model.Email(this);
            }
        }

        public void PingDevice()
        {
            var ping = new Ping();
            ping.PingCompleted += (pingSender, eventArgs) =>
            {
                if (eventArgs.Reply.Status == IPStatus.Success)
                {
                    output = string.Format("{0,12} - {1,-15} : Connected - Ping: {2}ms",
                        GetTruncatedString(name, 12), ip, eventArgs.Reply.RoundtripTime);
                    consecErrors = 0;
                }
                else
                {
                    ConnectionError();
                    output = string.Format("{0,12} - {1,-15} : Connection Attempts Failed {2}",
                        GetTruncatedString(name, 12), ip, consecErrors);
                }
                Log(output);
                Model.UpdateDevice(this);
            };
            try
            {
                ping.SendAsync(ip, 1);
            }
            catch
            {

            }
        }

        public static string GetTruncatedString(string str, int length)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            return str.Substring(0, Math.Min(str.Length, length));
        }
    }
}
