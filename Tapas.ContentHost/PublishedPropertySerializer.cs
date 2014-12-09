using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace Tapas
{
    public class PublishedPropertySerializer : JsonConverter
    {
        public PublishedPropertySerializer()
        {
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IPublishedProperty).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var serializableNode = new SerializableProperty((IPublishedProperty)value);
            var obj = JObject.FromObject(serializableNode, serializer);
            obj.WriteTo(writer);
        }
    }

}
