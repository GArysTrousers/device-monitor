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
    public class Device
    {
        public IPAddress ip;
        public String output;
        public int consecErrors = 0;

        public Device(String ip)
        {
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
                Model.Email(this);
        }

        public void PingDevice()
        {
            var ping = new Ping();
            ping.PingCompleted += (pingSender, eventArgs) =>
            {
                if (eventArgs.Reply.Status == IPStatus.Success)
                {
                    output = string.Format("{0,16} : Connected - Ping: {1}ms", 
                        ip, eventArgs.Reply.RoundtripTime);
                    consecErrors = 0;
                }
                else
                {
                    ConnectionError();
                    output = string.Format("{0,16} : Connection Attempts Failed {1}", 
                        ip, consecErrors);
                }
                Log(output);
                Model.UpdateDevice(this);
            };
            ping.SendAsync(ip, 1);
        }
    }
}
