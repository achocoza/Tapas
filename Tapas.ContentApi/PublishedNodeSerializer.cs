using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umbraco.interfaces;
using Umbraco.Core.Models;

namespace Tapas
{

    public class Serializer
    {
        private JsonSerializer jsonSerializer;
        private PublishedNodeSerializer publishedNodeSerializer;
        public Serializer(bool traverseChildren = false, bool excludeProtected = true, bool onlyIncludeNameIdAndUrl = false, params JsonConverter[] additionalConverters)
        {
            jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings());
            publishedNodeSerializer = new PublishedNodeSerializer(traverseChildren, excludeProtected, onlyIncludeNameIdAndUrl);
            jsonSerializer.Converters.Add(publishedNodeSerializer);

            foreach (var converter in additionalConverters) jsonSerializer.Converters.Add(converter);
        }
        public JObject AsJObject(IPublishedContent node)
        {
            return publishedNodeSerializer.CreateJObject(node, jsonSerializer);
        }
        public JArray AsJArray(IEnumerable<IPublishedContent> nodes)
        {
            return publishedNodeSerializer.CreateJArray(nodes, jsonSerializer);
        }
    }

    public class HtmlStringSerializer : JsonConverter
    {
        public HtmlStringSerializer()
        {
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(System.Web.Mvc.MvcHtmlString).IsAssignableFrom(objectType) || typeof(System.Web.HtmlString).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
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


            obj.Add("Id", JToken.FromObject(node.Id));
            obj.Add("Name", JToken.FromObject(node.Name));
            obj.Add("Url", JToken.FromObject(node.Url));

            var isVisible = true;
            if (node.GetProperty("umbracoNaviHide") != null && (bool)node.GetProperty("umbracoNaviHide").Value) isVisible = false;

            obj.Add("Visible", JToken.FromObject(isVisible));

            if (!onlyIncludeNameIdAndUrl)
            {
                obj.Add("CreateDate", JToken.FromObject(node.CreateDate));
                obj.Add("CreatorId", JToken.FromObject(node.CreatorId));
                obj.Add("Level", JToken.FromObject(node.Level));
                obj.Add("DocumentTypeAlias", JToken.FromObject(node.DocumentTypeAlias));
                var parentId = (node.Parent == null) ? -1 : node.Parent.Id;
                obj.Add("ParentId", parentId);
                obj.Add("Path", JToken.FromObject(node.Path));
                obj.Add("SortOrder", JToken.FromObject(node.SortOrder));
                obj.Add("TemplateId", JToken.FromObject(node.TemplateId));
                obj.Add("UpdateDate", JToken.FromObject(node.UpdateDate));
                obj.Add("UrlName", JToken.FromObject(node.UrlName));
                obj.Add("Version", JToken.FromObject(node.Version));
                obj.Add("WriterId", JToken.FromObject(node.WriterId));
                obj.Add("WriterName", JToken.FromObject(node.WriterName));

                var properties = node.Properties.Select(p => new { p.PropertyTypeAlias, Value = p.Value }).ToDictionary(k => k.PropertyTypeAlias, k => (k.Value == null) ? null : JToken.FromObject(k.Value, serializer));
                obj.Add("Properties", JToken.FromObject(properties, serializer));
            }

            if (traverseChildren)
                obj.Add("Children", JToken.FromObject(node.Children, serializer));
            else if (!onlyIncludeNameIdAndUrl)
                obj.Add("ChildIds", JToken.FromObject(node.Children.Select(t => t.Id)));

            return obj;

        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null) return;

            var obj = CreateJObject((IPublishedContent)value, serializer);

            //var val = (IPublishedContent)value;


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
