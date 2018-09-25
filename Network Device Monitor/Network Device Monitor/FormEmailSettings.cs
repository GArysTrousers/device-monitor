using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Device_Monitor
{
    public partial class FormEmailSettings : Form
    {
        public FormEmailSettings()
        {
            InitializeComponent();
        }

        private void Email_Settings_Load(object sender, EventArgs e)
        {
            if (Model.mailMan != null)
            {
                txtEmailFrom.Text = Model.mailMan.emailFrom;
                txtPassword.Text = Model.mailMan.password;
                txtHost.Text = Model.mailMan.client.Host;
                txtPort.Text = Model.mailMan.client.Port.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
                Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("There was an error saving\n" + E);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
                Model.mailMan.Send("Test", "This is a test from the Device Monitor.");
                Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("There was an error\n" + E);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Save()
        {
            if (Model.mailMan == null)
            {
                int port = Convert.ToInt32(txtPort.Text);
                Model.mailMan = new MailMan(txtEmailFrom.Text,
                    txtPassword.Text, txtHost.Text, port);
                Model.mailMan.SetEmailTo(txtEmailTo.Text);
            }
            else
            {
                int port = Convert.ToInt32(txtPort.Text);
                Model.mailMan.UpdateSettings(txtEmailFrom.Text,
                    txtPassword.Text, txtHost.Text, port);
                Model.mailMan.SetEmailTo(txtEmailTo.Text);
            }
        }
    }
}
