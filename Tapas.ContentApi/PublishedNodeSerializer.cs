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
    public class PublishedNodeSerializer : JsonConverter
    {
        private bool traverseChildren;
        private bool excludeProtected;
        private Func<IPublishedContent, bool> hasAccess;
        public PublishedNodeSerializer(bool traverseChildren = false, bool excludeProtected = true)
        {
            this.traverseChildren = traverseChildren;
            this.excludeProtected = excludeProtected;
            if (excludeProtected)
                hasAccess = new Func<IPublishedContent, bool>(n => (new Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)).MemberHasAccess(n.Id, n.Path));
            else
                hasAccess = new Func<IPublishedContent, bool>(n => true);

        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null) return;

            var val = (IPublishedContent)value;
            if (!hasAccess(val)) return;

            var obj = new JObject();
            obj.Add("Name", JToken.FromObject(val.Name));
            obj.Add("Id", JToken.FromObject(val.Id));
            obj.Add("CreateDate", JToken.FromObject(val.CreateDate));
            obj.Add("CreatorId", JToken.FromObject(val.CreatorId));
            obj.Add("Level", JToken.FromObject(val.Level));
            obj.Add("DocumentTypeAlias", JToken.FromObject(val.DocumentTypeAlias));
            var parentId = (val.Parent == null) ? -1 : val.Parent.Id;
            obj.Add("ParentId", parentId);
            obj.Add("Path", JToken.FromObject(val.Path));
            obj.Add("SortOrder", JToken.FromObject(val.SortOrder));
            obj.Add("TemplateId", JToken.FromObject(val.TemplateId));
            obj.Add("UpdateDate", JToken.FromObject(val.UpdateDate));
            obj.Add("Url", JToken.FromObject(val.Url));
            obj.Add("UrlName", JToken.FromObject(val.UrlName));
            obj.Add("Version", JToken.FromObject(val.Version));
            obj.Add("WriterId", JToken.FromObject(val.WriterId));
            obj.Add("WriterName", JToken.FromObject(val.WriterName));
            if (traverseChildren)
                obj.Add("Children", JToken.FromObject(val.Children, serializer));
            else
                obj.Add("ChildIds", JToken.FromObject(val.Children.Select(t => t.Id)));

            var properties = val.Properties.Select(p => new { p.PropertyTypeAlias, Value = p.Value }).ToDictionary(k => k.PropertyTypeAlias, k => k.Value);
            obj.Add("Properties", JToken.FromObject(properties, serializer));

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
