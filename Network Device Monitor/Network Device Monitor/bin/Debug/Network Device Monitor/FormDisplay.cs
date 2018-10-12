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
            LoadSettings();
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
                var newDevice = new Device(txtName.Text, txtIP.Text);
                Model.AddDevice(txtName.Text, txtIP.Text);
                listDevices.Items.Add(String.Format("{0,12} - {1,-15} : Waiting", 
                    Device.GetTruncatedString(txtName.Text, 12), txtIP.Text));
                txtName.Text = "";
                txtName.Focus();
            }
            catch (FormatException E)
            {
                SendOutput("There was an error parsing that IP address:\n");
                Debug.WriteLine(E);
            }
        }

        private void mbtnPreferences_Click(object sender, EventArgs e)
        {

        }

        private void mbtnEmail_Click(object sender, EventArgs e)
        {
            var emailSettings = new FormEmailSettings();
            emailSettings.ShowDialog();
        }

        private void mbtnLoad_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void mbtnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnRemoveDevice_Click(object sender, EventArgs e)
        {
            Model.devices.RemoveAt(listDevices.SelectedIndex);
            listDevices.Items.RemoveAt(listDevices.SelectedIndex);
        }

        public void ClearAndUpdateDevices()
        {
            listDevices.Items.Clear();
            foreach (var d in Model.devices)
            {
                listDevices.Items.Add(d.output);
            }
        }

        public void SendOutput(string message)
        {
            txtOutput.Text += message + "\n";
        }

        public void LoadSettings()
        {
            try
            {
                string json;

                using (System.IO.StreamReader file =
                    new System.IO.StreamReader(Model.saveFileName))
                {
                    json = file.ReadToEnd();
                }

                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new IPAddressConverter());
                settings.Formatting = Formatting.Indented;

                var model = JsonConvert.DeserializeObject<ModelSave>(json, settings);

                model.LoadDataIntoModel();
                ClearAndUpdateDevices();

                SendOutput("File Loaded: " + Model.saveFileName);
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.ToString());
            }
        }

        public void SaveSettings()
        {
            try
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new IPAddressConverter());
                settings.Formatting = Formatting.Indented;

                var model = new ModelSave();
                model.FillData();
                var json = JsonConvert.SerializeObject(model, settings);
                Debug.WriteLine(json);

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(Model.saveFileName))
                {
                    file.WriteLine(json);
                }
                SendOutput("File Saved: " + Model.saveFileName);
            }
            catch (Exception E)
            {
                Debug.WriteLine(E);
            }
        }

    }


    
}
