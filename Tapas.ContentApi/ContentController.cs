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
        protected ContentHelpers contentHelpers;
        public NodeController()
        {
            contentHelpers = new ContentHelpers();
        }

        public object GetNode(int? id = 0)
        {
            return JsonConvert.SerializeObject(Umbraco.TypedContent(id ?? -1),new PublishedNodeSerializer(false));
        }
        public object GetNode(string url)
        {
            return GetNode(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public JsonFriendlyNode GetParent(int? id = 0)
        {
            return contentHelpers.TapasNode(Umbraco.TypedContent(id ?? 0).Parent);
        }
        public JsonFriendlyNode GetParent(string url)
        {
            return GetParent(umbraco.uQuery.GetNodeIdByUrl(url));
        }
    }
    [PluginController("PublishedContent")]
    public class NodesController : UmbracoApiController
    {
        protected ContentHelpers contentHelpers;
        public NodesController()
        {
            contentHelpers = new ContentHelpers();
        }


        public IEnumerable<JsonFriendlyNode> GetChildren(int? id = 0)
        {
            return contentHelpers.TapasNodes(Umbraco.TypedContent(id ?? 0).Children);
        }
        public IEnumerable<JsonFriendlyNode> GetChildren(string url)
        {
            return GetChildren(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public IEnumerable<JsonFriendlyNode> GetAncestors(int? id = 0)
        {
            return contentHelpers.TapasNodes(uweb.PublishedContentExtensions.Ancestors(Umbraco.TypedContent(id ?? 0)));
        }
        public IEnumerable<JsonFriendlyNode> GetAncestors(string url)
        {
            return GetAncestors(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public IEnumerable<JsonFriendlyNode> GetDescendantsOrSelf(int? id = 0)
        {
            return contentHelpers.TapasNodes(uweb.PublishedContentExtensions.DescendantsOrSelf(Umbraco.TypedContent(id ?? 0)));
        }
        public IEnumerable<JsonFriendlyNode> GetDescendantsOrSelf(string url)
        {
            return GetDescendantsOrSelf(umbraco.uQuery.GetNodeIdByUrl(url));
        }
    }

    [PluginController("PublishedContent")]
    public class NavigationController : UmbracoApiController
    {
        protected ContentHelpers contentHelpers;
        public NavigationController()
        {
            contentHelpers = new ContentHelpers();
        }


        public object GetTree(int? id = 0)
        {
            var node = umbraco.uQuery.GetNode(id ?? 0);
            return contentHelpers.NodeNavigation((IPublishedContent)node);
        }
        public object GetTree(string path)
        {
            var node = umbraco.uQuery.GetNodeByUrl(path);
            return contentHelpers.NodeNavigation((IPublishedContent)node);
        }
        public object GetTreeFlattened(int? id = 0)
        {
            var node = umbraco.uQuery.GetNode(id ?? 0);
            return contentHelpers.NodeNavigationFlat((IPublishedContent)node);
        }

    }

}
