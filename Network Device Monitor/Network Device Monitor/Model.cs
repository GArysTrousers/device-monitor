using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Device_Monitor
{
    public static class Model
    {
        public static int EmailErrorLimit = 6;
        public static String 
            EmailFrom = "device.monitor.mail@gmail.com",
            EmailTo = "lee.ben.b@edumail.vic.gov.au";

        public static List<Device> devices = new List<Device>();
        public static FormDisplay Display;

        public static void SetForm(FormDisplay form)
        {
            Display = form;
        }

        public static void AddDevice(String IP)
        {
            Device newDevice = new Device(IP);
            devices.Add(newDevice);
        }

        public static void UpdateDevice(Device device)
        {
            Display.UpdateDevice(devices.IndexOf(device), device.output);
        }

        public static void Email(Device device)
        {
            try
            {
                MailMessage mail = new MailMessage(EmailFrom, EmailTo);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(EmailFrom, "Password");
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                mail.Subject = "There is a Device Down at OSC";
                mail.Body = String.Format("Device IP: {0}", device.ip);

                client.Send(mail);
                MessageBox.Show("Test Email Sent");
            }
            catch (Exception E)
            {
                //MessageBox.Show(String.Format("{0}", E));
            }
            
        }
    }
}
