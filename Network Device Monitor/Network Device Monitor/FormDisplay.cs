using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

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
                listDevices.Items.Add(String.Format("{0,16} : Waiting", txtIP.Text));
            }
            catch (FormatException E)
            {
                MessageBox.Show("There was an error parsing that IP address:\n" + E.Message);
            }
        }

        private void mbtnEmail_Click(object sender, EventArgs e)
        {
            var emailSettings = new FormEmailSettings();
            emailSettings.ShowDialog();
        }

        private void mbtnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //open file and read from it
                string json = "{}";

                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new IPAddressConverter());
                settings.Formatting = Formatting.Indented;

                var modelSave = JsonConvert.DeserializeObject<ModelSave>(json, settings);
            }
        }

        private void mbtnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new IPAddressConverter());
                settings.Formatting = Formatting.Indented;

                var json = JsonConvert.SerializeObject(new ModelSave(), settings);
                Debug.WriteLine(json);

                //Open file and write to it
            }
        }

        private void btnRemoveDevice_Click(object sender, EventArgs e)
        {
            Model.devices.RemoveAt(listDevices.SelectedIndex);
            listDevices.Items.RemoveAt(listDevices.SelectedIndex);
        }
    }


    
}
