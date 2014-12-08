using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace Tapas.Helpers
{
    public static class JsonSerializer
    {
        public static string AsJson(this IPublishedContent node, bool traverse = false, bool excludeProtected = true, bool minimal = false)
        {
            if (node == null) return "";
            return JsonConvert.SerializeObject(node, new PublishedNodeSerializer(traverse, excludeProtected, minimal), new HtmlStringSerializer());
        }
        public static string AsJson(this IEnumerable<IPublishedContent> node, bool traverse = false, bool excludeProtected = true, bool minimal = false)
        {
            if (node == null) return "";
            return JsonConvert.SerializeObject(node, new PublishedNodeSerializer(traverse, excludeProtected, minimal), new HtmlStringSerializer());
        }
    }

}
