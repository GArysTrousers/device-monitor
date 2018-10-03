using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Network_Device_Monitor
{
    public class MailMan
    {
        public SmtpClient client;
        public string emailFrom;
        public string emailPassword;
        public List<string> emailTo = new List<string>();

        public MailMan(string emailFrom, string emailPassword, string host, int port)
        {
            this.emailFrom = emailFrom;
            this.emailPassword = emailPassword;

            client = new SmtpClient();
            client.Port = port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(emailFrom, emailPassword);
            client.Host = host;
            client.EnableSsl = true;
        }

        public void UpdateSettings(string emailFrom, string emailPassword, string host, int port)
        {
            this.emailFrom = emailFrom;
            this.emailPassword = emailPassword;
            client.Port = port;
            client.Credentials = new System.Net.NetworkCredential(emailFrom, emailPassword);
            client.Host = host;

        }

        public void SetEmailTo(string emailToUnparsed)
        {
            emailTo.Clear();

            string newEmailTo = Regex.Replace(emailToUnparsed, @"^\s*^|$\s*\z", "");
            foreach (string s in newEmailTo.Split('\n'))
                if (s != "")
                    emailTo.Add(s);
        }

        public void Send(string subject, string body)
        {
            try
            {
                foreach (string email in emailTo)
                {
                    MailMessage mail = new MailMessage(emailFrom, email);
                    mail.Subject = subject;
                    mail.Body = body;
                    client.Send(mail);
                    Model.SendOutput(string.Format("Email sent at {0}", DateTime.Now));
                }
            }
            catch (Exception E)
            {
                Model.SendOutput(string.Format("Email failed to send at {0}", DateTime.Now));
                Debug.WriteLine(E);
            }
        }
    }
}
