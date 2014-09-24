using umbraco.NodeFactory;
using System.Linq;
using umbraco;
using System.Collections.Generic;
using umbraco.interfaces;
using System;
using Umbraco.Core.Models;
using Umbraco;

namespace Tapas
{
    public class ContentHelpers
    {

        public Umbraco.Web.UmbracoHelper CurrentUmbracoHelper()
        {
            return new Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current);
        }
        public IEnumerable<JsonFriendlyNode> Children(IPublishedContent node)
        {
            return node.Children.Select(n => TapasNode(n));
        }
        public JsonFriendlyNode Parent(IPublishedContent node)
        {
            return TapasNode(node.Parent);
        }
        //public IEnumerable<JsonFriendlyNode> Ancestors(IPublishedContent node)
        //{
        //    //return node.GetAncestorNodes().Select(n => NodeProperties(n));
        //}
        public JsonFriendlyNode DescendantsAndSelf(IPublishedContent node)
        {
            return TapasNode(node, true);
        }
        public List<JsonFriendlyNode> DescendantsAndSelfFlat(IPublishedContent node)
        {
            var nodes = new List<JsonFriendlyNode>();

            if (node == null || !CurrentUmbracoHelper().MemberHasAccess(node.Id, node.Path)) return nodes;

            nodes.Add(TapasNode(node, false));
            foreach (var child in node.Children)
            {
                nodes.AddRange(DescendantsAndSelfFlat(child));
            }
            return nodes;

        }

        public IEnumerable<JsonFriendlyNode> Flatten(JsonFriendlyNode node)
        {
            var jsonNodes = new List<JsonFriendlyNode>();
            jsonNodes.Add(node);
            foreach (var child in node.ChildrenNodes)
            {
                jsonNodes.Add(child);
                jsonNodes.AddRange(Flatten(child));
            }
            return jsonNodes;
        }

        public IEnumerable<JsonFriendlyNode> Flatten(IEnumerable<JsonFriendlyNode> nodes)
        {
            var jsonNodes = (List<JsonFriendlyNode>)nodes;
            foreach (var node in nodes)
            {
                jsonNodes.Add(node);
                foreach (var child in node.ChildrenNodes)
                {
                    jsonNodes.Add(child);
                    jsonNodes.AddRange(Flatten(child));
                }
            }
            return jsonNodes;
        }

        public IEnumerable<JsonFriendlyNode> TapasNodes(IEnumerable<IPublishedContent> nodes)
        {
            var jsonNodes = new List<JsonFriendlyNode>();
            foreach (var node in nodes)
            {
                var jsonFriendly = TapasNode(node, true);
                if (jsonFriendly != null) jsonNodes.Add(jsonFriendly);
            }
            return jsonNodes;
        }
        public JsonFriendlyNode TapasNode(IPublishedContent node, bool traverseChildren = false)
        {

            if (node == null || !CurrentUmbracoHelper().MemberHasAccess(node.Id, node.Path)) return null;

            return new JsonFriendlyNode
            {
                Id = node.Id,
                CreateDate = node.CreateDate,
                CreatorName = node.CreatorName,
                Level = node.Level,
                Name = node.Name,
                DocumentTypeAlias = node.DocumentTypeAlias,
                ParentId = (node.Parent != null) ? node.Parent.Id : -1,
                Path = node.Path,
                SortOrder = node.SortOrder,
                TemplateId = node.TemplateId,
                UpdateDate = node.UpdateDate,
                Url = node.Url,
                UrlName = node.UrlName,
                Version = node.Version,
                WriterId = node.WriterId,
                WriterName = node.WriterName,
                Properties = node.Properties.Select(p => new { p.PropertyTypeAlias, Value = p.Value }).ToDictionary(k => k.PropertyTypeAlias, k => k.Value),
                ChildrenIds = node.Children.Select(n => n.Id),
                ChildrenNodes = (traverseChildren) ? node.Children.Select(n => TapasNode(n, traverseChildren)) : null

            };

        }
        public bool NodeVisible(IPublishedContent node)
        {
            if (node.GetProperty("umbracoNaviHide") != null) return !(bool)node.GetProperty("umbracoNaviHide").Value;
            if (node.GetProperty("visible") != null) return (bool)node.GetProperty("visible").Value;
            return false;


        }
        public JsonFriendlyNodeNavigation NodeNavigation(IPublishedContent node)
        {

            if (!CurrentUmbracoHelper().MemberHasAccess(node.Id, node.Path)) return null;

            return new JsonFriendlyNodeNavigation
            {

                Url = node.Url,
                Name = node.Name,
                Visible = NodeVisible(node),
                Id = node.Id,
                UrlName = node.UrlName,
                Children = node.Children.Select(n => NodeNavigation(n))
            };
        }
        public IEnumerable<JsonFriendlyNodeNavigation> NodeNavigationFlat(IPublishedContent node)
        {
            var nodes = new List<JsonFriendlyNodeNavigation>();

            if (!(CurrentUmbracoHelper().MemberHasAccess(node.Id, node.Path))) return nodes;

            nodes.Add(NodeNavigation(node));
            foreach (var child in node.Children)
            {
                nodes.AddRange(NodeNavigationFlat(child));
            }
            return nodes;
        }
    }
}