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
                chbEnableEmail.Checked = Model.emailEnabled;
                txtEmailFrom.Text = Model.mailMan.emailFrom;
                txtPassword.Text = Model.mailMan.emailPassword;
                txtHost.Text = Model.mailMan.client.Host;
                txtPort.Text = Model.mailMan.client.Port.ToString();
                txtSubjectLine.Text = Model.emailSubject;
                foreach (string s in Model.mailMan.emailTo)
                    txtEmailTo.Text += s + "\n";
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
                Model.emailEnabled = chbEnableEmail.Checked;
                int port = Convert.ToInt32(txtPort.Text);
                Model.mailMan = new MailMan(txtEmailFrom.Text,
                    txtPassword.Text, txtHost.Text, port);
                Model.mailMan.SetEmailTo(txtEmailTo.Text);
                Model.emailSubject = txtSubjectLine.Text;
            }
            else
            {
                Model.emailEnabled = chbEnableEmail.Checked;
                int port = Convert.ToInt32(txtPort.Text);
                Model.mailMan.UpdateSettings(txtEmailFrom.Text,
                    txtPassword.Text, txtHost.Text, port);
                Model.mailMan.SetEmailTo(txtEmailTo.Text);
                Model.emailSubject = txtSubjectLine.Text;
            }
        }
    }
}
