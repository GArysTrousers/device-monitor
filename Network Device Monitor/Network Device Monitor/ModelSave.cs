using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Network_Device_Monitor
{
    public class ModelSave
    {
        public int emailErrorLimit;
        public MailMan mailMan;
        public List<Device> devices;

        public ModelSave()
        {
            emailErrorLimit = Model.emailErrorLimit;
            mailMan = Model.mailMan;
            devices = Model.devices;
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
