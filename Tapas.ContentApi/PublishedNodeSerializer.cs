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
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null) return;

            var val = (IPublishedContent)value;
            if (!hasAccess(val)) return;

            var obj = new JObject();
            obj.Add("Id", JToken.FromObject(val.Id));
            obj.Add("Name", JToken.FromObject(val.Name));
            obj.Add("Url", JToken.FromObject(val.Url));

            var isVisible = true;
            if (val.GetProperty("umbNaviHide") != null && (bool)val.GetProperty("umbNaviHide").Value) isVisible = false;

            obj.Add("Visible", JToken.FromObject(isVisible));

            if (!onlyIncludeNameIdAndUrl)
            {
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
                obj.Add("UrlName", JToken.FromObject(val.UrlName));
                obj.Add("Version", JToken.FromObject(val.Version));
                obj.Add("WriterId", JToken.FromObject(val.WriterId));
                obj.Add("WriterName", JToken.FromObject(val.WriterName));

                var properties = val.Properties.Select(p => new { p.PropertyTypeAlias, Value = p.Value }).ToDictionary(k => k.PropertyTypeAlias, k => (k.Value == null) ? null : JToken.FromObject(k.Value, serializer));
                obj.Add("Properties", JToken.FromObject(properties, serializer));
            }
            
            if (traverseChildren)
                obj.Add("Children", JToken.FromObject(val.Children, serializer));
            else if (!onlyIncludeNameIdAndUrl)
                obj.Add("ChildIds", JToken.FromObject(val.Children.Select(t => t.Id)));

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
