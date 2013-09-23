using umbraco.NodeFactory;
using System.Linq;
using umbraco;

namespace Tapas
{
    public class ContentHelpers
    {
        public static object Children(Node node)
        {
            return node.ChildrenAsList.Select(n => NodeProperties(n as Node));
        }
        public static object Parent(Node node)
        {
            return NodeProperties(node.Parent as Node);
        }
        public static object Ancestors(Node node)
        {
            return node.GetAncestorNodes().Select(n => NodeProperties(n));
        }
        public static object DescendantsAndSelf(Node node)
        {
            return NodeProperties(node, true);
        }
        public static object NodeProperties(Node node, bool traverseChildren = false)
        {
            return
            new
            {
                node.Id,
                node.Level,
                node.NiceUrl,
                node.Name,
                node.SortOrder,
                node.UrlName,
                node.NodeTypeAlias,
                node.CreatorName,
                Template = node.template,
                /*Template = template.Alias,*/
                Properties = node.PropertiesAsList.Select(p => new { p.Alias, Value = p.Value }).ToDictionary(k => k.Alias, k => k.Value),
                node.CreateDate,
                node.UpdateDate,
                ParentId = (node.Parent != null) ? node.Parent.Id : -1,
                Children = (traverseChildren) ? node.ChildrenAsList.Select(n => NodeProperties(n as Node, traverseChildren)) : node.ChildrenAsList.Select(n => n.Id as object) 
            };
        }
        public static bool NodeVisible(Node node)
        {
            if (node.HasProperty("umbracoNaviHide")) return !node.GetProperty<bool>("umbracoNaviHide");
            if (node.HasProperty("visible")) return node.GetProperty<bool>("visible");
            return false;


        }
        public static object NodeNavigation(Node node)
        {
            return
            new
            {
                node.NiceUrl,
                node.Name,
                Visible = NodeVisible(node),
                node.Id,
                node.UrlName,
                Children = node.ChildrenAsList.Select(n => NodeNavigation(n as Node))
            };
        }

        internal static object NodeNavigationFlat(Node node)
        {
            throw new System.NotImplementedException();
        }
    }
}