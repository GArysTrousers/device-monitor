using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Windows.Forms;

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

        public void Log()
        {

        }

        public void ConnectionError()
        {
            consecErrors += 1;
            if (consecErrors == Model.EmailErrorLimit)
                Model.Email(this);
        }

        public void PingDevice()
        {
            var ping = new Ping();
            ping.PingCompleted += (pingSender, eventArgs) =>
            {
                if (eventArgs.Reply.Status == IPStatus.Success)
                {
                    output = string.Format("Address: {0}\n", eventArgs.Reply.Address.ToString());
                    output += string.Format("RoundTrip time: {0}\n", eventArgs.Reply.RoundtripTime);
                    consecErrors = 0;
                }
                else if (eventArgs.Reply.Status == IPStatus.BadDestination)
                {
                    output = "Connection Failed";
                }
                else
                {
                    output = "Connection Failed";
                }
                Log();
                Model.UpdateDevice(this);
            };
            ping.SendAsync(ip, 1);
        }
    }
}
