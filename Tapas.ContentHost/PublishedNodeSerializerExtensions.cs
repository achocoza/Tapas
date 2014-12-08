using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace Tapas
{
    public static class PublishedNodeSerializerExtensions
    {
        public static object AsJObject(this IPublishedContent node, bool traverse = false, bool excludeProtected = true, bool minimal = false)
        {
            if (node == null) return null;
            var serializer = new Serializer(traverse, excludeProtected, minimal, new HtmlStringSerializer());
            return serializer.AsJObject(node);
        }
        public static object AsJArray(this IEnumerable<IPublishedContent> nodes, bool traverse = false, bool excludeProtected = true, bool minimal = false)
        {

            if (nodes == null) return null;
            var serializer = new Serializer(traverse, excludeProtected, minimal, new HtmlStringSerializer());
            return serializer.AsJArray(nodes);
        }


    }

}
