using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umbraco.interfaces;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;
using Umbraco;
using uweb = Umbraco.Web;
using Newtonsoft.Json;

namespace Tapas
{
    public static class Serializer
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

    [PluginController("PublishedContent")]
    public class NodeController : UmbracoApiController
    {

        public string GetNode(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).AsJson();
        }
        public string GetNode(string url)
        {
            return GetNode(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public string GetParent(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).Parent.AsJson();
        }
        public string GetParent(string url)
        {
            return GetParent(umbraco.uQuery.GetNodeIdByUrl(url));
        }
    }
    [PluginController("PublishedContent")]
    public class NodesController : UmbracoApiController
    {

        public string GetChildren(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).Children.AsJson();
        }
        public string GetChildren(string url)
        {
            return GetChildren(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public string GetTree(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).AsJson(true);
        }
        public string GetTree(string url)
        {
            return GetTree(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public string GetNavigationTree(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).AsJson(true, minimal: true);
        }
        public string GetNavigationTree(string url)
        {
            return GetNavigationTree(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public string GetAncestors(int? id = -1)
        {
            return uweb.PublishedContentExtensions.Ancestors(Umbraco.TypedContent(id ?? -1)).AsJson();
        }
        public string GetAncestors(string url)
        {
            return GetAncestors(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public string GetDescendantsOrSelf(int? id = -1)
        {
            return uweb.PublishedContentExtensions.DescendantsOrSelf(Umbraco.TypedContent(id ?? -1)).AsJson();
        }
        public string GetDescendantsOrSelf(string url)
        {
            return GetDescendantsOrSelf(umbraco.uQuery.GetNodeIdByUrl(url));
        }
    }

    //[PluginController("PublishedContent")]
    //public class NavigationController : UmbracoApiController
    //{
    //    public object GetTree(int? id = 0)
    //    {
    //        var node = umbraco.uQuery.GetNode(id ?? 0);
    //        return contentHelpers.NodeNavigation((IPublishedContent)node);
    //    }
    //    public object GetTree(string path)
    //    {
    //        var node = umbraco.uQuery.GetNodeByUrl(path);
    //        return contentHelpers.NodeNavigation((IPublishedContent)node);
    //    }
    //    public object GetTreeFlattened(int? id = 0)
    //    {
    //        var node = umbraco.uQuery.GetNode(id ?? 0);
    //        return contentHelpers.NodeNavigationFlat((IPublishedContent)node);
    //    }

    //}

}
