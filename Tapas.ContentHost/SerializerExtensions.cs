using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapas.Helpers;
using Umbraco.Core.Models;

namespace Tapas
{
    public static class SerializerExtensions
    {
        public static JObject AsJObject(this IPublishedContent node, bool traverse = false, bool excludeProtected = true, bool minimal = false)
        {
            if (node == null) return null;
            var serializer = new TapasSerializer(traverse, excludeProtected, minimal);
            return JObject.FromObject(node, serializer);
        }
        public static string AsJson(this IPublishedContent node, bool traverse = false, bool excludeProtected = true, bool minimal = false)
        {
            if (node == null) return "";
            return JsonConvert.SerializeObject(node, new PublishedNodeSerializer(traverse, excludeProtected, minimal), new HtmlStringSerializer());
        }

        public static JArray AsJArray(this IEnumerable<IPublishedContent> node, bool traverse = false, bool excludeProtected = true, bool minimal = false)
        {
            if (node == null) return null;
            var serializer = new TapasSerializer(traverse, excludeProtected, minimal);
            return JArray.FromObject(node, serializer);
        }

        public static string AsJson(this IEnumerable<IPublishedContent> node, bool traverse = false, bool excludeProtected = true, bool minimal = false)
        {
            if (node == null) return "";
            return JsonConvert.SerializeObject(node, new PublishedNodeSerializer(traverse, excludeProtected, minimal), new HtmlStringSerializer());
        }


    }

}