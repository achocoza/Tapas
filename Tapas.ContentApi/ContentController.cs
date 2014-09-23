using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace Tapas
{
    [PluginController("PublishedContent")]
    public class NodeController : UmbracoApiController
    {
        public object GetNode(int? id=0)
        {            
            var node = umbraco.uQuery.GetNode(id??0);
            return ContentHelpers.NodeProperties(node);
        }
        public object GetNode(string path)
        {
            var node = umbraco.uQuery.GetNodeByUrl(path);
            return ContentHelpers.NodeProperties(node);
        }
        public object GetParent(int? id = 0)
        {
            var node = umbraco.uQuery.GetNode(id ?? 0);
            return ContentHelpers.Parent(node);
        }
        public object GetParent(string path)
        {
            var node = umbraco.uQuery.GetNodeByUrl(path);
            return ContentHelpers.Parent(node);
        }
    }
    [PluginController("PublishedContent")]
    public class NodesController : UmbracoApiController
    {
        public object GetChildren(int? id = 0)
        {
            var node = umbraco.uQuery.GetNode(id ?? 0);
            return ContentHelpers.Children(node);
        }
        public object GetChildren(string path)
        {
            var node = umbraco.uQuery.GetNodeByUrl(path);
            return ContentHelpers.Children(node);
        }
        public object GetAncestors(int? id = 0)
        {
            var node = umbraco.uQuery.GetNode(id ?? 0);
            return ContentHelpers.Ancestors(node);
        }
        public object GetAncestors(string path)
        {
            var node = umbraco.uQuery.GetNodeByUrl(path);
            return ContentHelpers.Ancestors(node);
        }
        public object GetDescendantsAndSelf(int? id = 0)
        {
            var node = umbraco.uQuery.GetNode(id ?? 0);
            return ContentHelpers.DescendantsAndSelf(node);
        }
        public object GetDescendantsAndSelfFlattened(int? id = 0)
        {
            var node = umbraco.uQuery.GetNode(id ?? 0);
            return ContentHelpers.DescendantsAndSelfFlat(node);
        }
        public object GetDescendantsAndSelf(string path)
        {
            var node = umbraco.uQuery.GetNodeByUrl(path);
            return ContentHelpers.DescendantsAndSelf(node);
        }
        public object GetDescendantsAndSelfFlattened(string path)
        {
            var node = umbraco.uQuery.GetNodeByUrl(path);
            return ContentHelpers.DescendantsAndSelfFlat(node);
        }
    }

    [PluginController("PublishedContent")]
    public class NavigationController : UmbracoApiController
    {
        public object GetTree(int? id = 0)
        {
            var node = umbraco.uQuery.GetNode(id ?? 0);
            return ContentHelpers.NodeNavigation(node);
        }
        public object GetTree(string path)
        {
            var node = umbraco.uQuery.GetNodeByUrl(path);
            return ContentHelpers.NodeNavigation(node);
        }
        public object GetTreeFlattened(int? id = 0)
        {
            var node = umbraco.uQuery.GetNode(id ?? 0);
            return ContentHelpers.NodeNavigationFlat(node);
        }
        
    }

}
