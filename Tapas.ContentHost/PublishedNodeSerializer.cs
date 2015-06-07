using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umbraco.interfaces;
using Umbraco.Core.Models;

namespace Tapas
{

    public class PublishedNodeSerializer : JsonConverter
    {
        private bool traverseChildren;
        private bool excludeProtected;
        private bool onlyIncludeNameIdAndUrl;
        private Func<IPublishedContent, bool> hasAccess;
        public PublishedNodeSerializer(bool traverseChildren = false, bool excludeProtected = true, bool onlyIncludeNameIdAndUrl = false)
        {
            this.traverseChildren = traverseChildren;
            this.excludeProtected = excludeProtected;
            this.onlyIncludeNameIdAndUrl = onlyIncludeNameIdAndUrl;
            if (excludeProtected)
                hasAccess = new Func<IPublishedContent, bool>(n => (new Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)).MemberHasAccess(n.Id, n.Path));
            else
                hasAccess = new Func<IPublishedContent, bool>(n => true);

        }
        public JArray CreateJArray(IEnumerable<IPublishedContent> nodes, JsonSerializer serializer)
        {
            return JArray.FromObject(nodes, serializer);
        }
        public JObject CreateJObject(IPublishedContent node, JsonSerializer serializer)
        {

            var obj = new JObject();
            if (!hasAccess(node)) return obj;

            var serializableNode = new SerializableNode(node,traverseChildren);
            return JObject.FromObject(serializableNode);


        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null) return;

            var obj = CreateJObject((IPublishedContent)value, serializer);

            obj.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IPublishedContent).IsAssignableFrom(objectType);
        }

    }
}
