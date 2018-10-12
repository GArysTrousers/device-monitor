using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Network_Device_Monitor
{
    public class ModelSave
    {
        public bool emailEnabled = false;
        public int pinginterval = 10000;
        public int emailErrorLimit;
        public List<Device> devices;

        public string emailFrom;
        public string emailPassword;
        public List<string> emailTo;
        public string host;
        public int port;

        public ModelSave()
        {
            
        }

        public void FillData()
        {
            emailEnabled = Model.emailEnabled;
            pinginterval = Model.pinginterval;
            emailErrorLimit = Model.emailErrorLimit;
            devices = DeepClone(Model.devices);
            if (Model.mailMan != null)
            {
                emailFrom = Model.mailMan.emailFrom;
                emailPassword = Model.mailMan.emailPassword;
                emailTo = Model.mailMan.emailTo;
                host = Model.mailMan.client.Host;
                port = Model.mailMan.client.Port;
            }
        }

        public void LoadDataIntoModel()
        {
            Model.emailEnabled = emailEnabled;
            Model.pinginterval = pinginterval;
            Model.emailErrorLimit = emailErrorLimit;
            Model.devices = devices;
            if (emailFrom != null)
            {
                Model.mailMan = new MailMan(emailFrom, emailPassword, host, port);
                Model.mailMan.emailTo = emailTo;
            }
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
    }

    public class IPAddressConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IPAddress));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return IPAddress.Parse((string)reader.Value);
        }
    }
}
