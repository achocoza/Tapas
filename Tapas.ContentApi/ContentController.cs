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

    [PluginController("PublishedContent")]
    public class NodeController : UmbracoApiController
    {

        public object GetNode(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).AsJObject();
        }
        public object GetNode(string url)
        {
            return GetNode(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public object GetParent(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).Parent.AsJObject();
        }
        public object GetParent(string url)
        {
            return GetParent(umbraco.uQuery.GetNodeIdByUrl(url));
        }
    }
    [PluginController("PublishedContent")]
    public class NodesController : UmbracoApiController
    {

        public object GetChildren(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).Children.AsJArray();
        }
        public object GetChildren(string url)
        {
            return GetChildren(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public object GetTree(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).AsJObject(true);
        }
        public object GetTree(string url)
        {
            return GetTree(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public object GetNavigationTree(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).AsJObject(true, minimal: true);
        }
        public object GetNavigationTree(string url)
        {
            return GetNavigationTree(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public object GetAncestors(int? id = -1)
        {
            return uweb.PublishedContentExtensions.Ancestors(Umbraco.TypedContent(id ?? -1)).AsJArray();
        }
        public object GetAncestors(string url)
        {
            return GetAncestors(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public object GetDescendantsOrSelf(int? id = -1)
        {
            return uweb.PublishedContentExtensions.DescendantsOrSelf(Umbraco.TypedContent(id ?? -1)).AsJArray();
        }
        public object GetDescendantsOrSelf(string url)
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
