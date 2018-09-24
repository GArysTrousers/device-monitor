using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Device_Monitor
{
    public partial class FormDisplay : Form
    {
        public string output;

        public FormDisplay()
        {
            InitializeComponent();
        }

        private void FormDisplay_Load(object sender, EventArgs e)
        {
            Model.SetForm(this);
        }

        public void UpdateDevice(int deviceNum, String text)
        {
            listDevices.Items[deviceNum] = text;
        }

        private void heartbeat_Tick(object sender, EventArgs e)
        {
            foreach(Device d in Model.devices)
            {
                d.PingDevice();
            }
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            try
            {
                var newDevice = new Device(txtIP.Text);
                Model.AddDevice(txtIP.Text);
                listDevices.Items.Add(String.Format("{0} - Waiting", txtIP.Text));
            }
            catch (FormatException E)
            {
                MessageBox.Show("There was an error parsing that IP address:\n" + E.Message);
            }
        }

        public void PingDevice(Device device)
        {
            var ping = new Ping();
            ping.PingCompleted += (pingSender, eventArgs) =>
            {
                if (eventArgs.Reply.Status == IPStatus.Success)
                {
                    output = string.Format("Address: {0}\n", eventArgs.Reply.Address.ToString());
                    output += string.Format("RoundTrip time: {0}\n", eventArgs.Reply.RoundtripTime);
                    txtOutput.Text = output;
                }
                else if (eventArgs.Reply.Status == IPStatus.BadDestination)
                {
                    txtOutput.Text = eventArgs.Reply.Status.ToString();
                }
                else
                {
                    //Console.WriteLine(reply.Status);
                    txtOutput.Text = eventArgs.Reply.Status.ToString();
                }
            };
            ping.SendAsync(device.ip, 1);
        }

        private void btnTestEmail_Click(object sender, EventArgs e)
        {
            Model.Email(new Device("10.139.208.123"));
        }
    }
}
