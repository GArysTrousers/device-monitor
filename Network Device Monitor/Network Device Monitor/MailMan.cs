using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Network_Device_Monitor
{
    public class MailMan
    {
        public SmtpClient client;
        public String emailFrom;
        public String password;
        public List<String> emailTo;

        public MailMan(String emailFrom, String emailPassword, String host, int port)
        {
            this.emailFrom = emailFrom;
            this.password = emailPassword;

            client = new SmtpClient();
            client.Port = port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(emailFrom, emailPassword);
            client.Host = host;
            client.EnableSsl = true;
        }

        public void UpdateSettings(String emailFrom, String emailPassword, String host, int port)
        {
            this.emailFrom = emailFrom;
            this.password = emailPassword;
            client.Port = port;
            client.Credentials = new System.Net.NetworkCredential(emailFrom, emailPassword);
            client.Host = host;

        }

        public void SetEmailTo(String EmailToUnparsed)
        {

        }

        public void Send(String subject, String body)
        {
            try
            {
                foreach (String email in emailTo)
                {
                    MailMessage mail = new MailMessage(emailFrom, email);
                    client.Send(mail);
                }
            }
            catch (Exception E)
            {
                //MessageBox.Show(String.Format("{0}", E));
            }
        }
    }
}
