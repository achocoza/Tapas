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
using umbracoWeb = Umbraco.Web;
using Newtonsoft.Json;
using Tapas.Helpers;
using Umbraco.Web.Models.ContentEditing;
using Umbraco.Core.Persistence.DatabaseModelDefinitions;
using AutoMapper;
using Newtonsoft.Json.Linq;

namespace Tapas
{

    [PluginController("Tapas")]
    public class ContentController : UmbracoApiController
    {

        public PagedResult<ContentItemBasic<ContentPropertyBasic, IContent>> GetDocumentsPaged(int id,
            int pageNumber = 0,
            int pageSize = 0,
            string orderBy = "SortOrder",
            Direction orderDirection = Direction.Ascending,
            string filter = "")
        {

            int totalChildren;
            IContent[] children;

            if (pageNumber > 0 && pageSize > 0)
            {
                children = Services.ContentService.GetPagedChildren(id, (pageNumber - 1), pageSize, out totalChildren, orderBy, orderDirection, filter).ToArray();
            }
            else
            {
                children = Services.ContentService.GetChildren(id).ToArray();
                totalChildren = children.Length;
            }

            if (totalChildren == 0)
            {
                return new PagedResult<ContentItemBasic<ContentPropertyBasic, IContent>>(0, 0, 0);
            }

            var pagedResult = new PagedResult<ContentItemBasic<ContentPropertyBasic, IContent>>(totalChildren, pageNumber, pageSize);
            pagedResult.Items = children.Select(Mapper.Map<IContent, ContentItemBasic<ContentPropertyBasic, IContent>>);

            return pagedResult;
        }

        public object GetNode(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).AsJObject(false);
        }
        public object GetNode(string url)
        {
            return GetNode(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public object GetParent(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).Parent.AsJObject(false);
        }
        public object GetParent(string url)
        {
            return GetParent(umbraco.uQuery.GetNodeIdByUrl(url));
        }

        public object GetChildren(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).Children.Select(t => t.AsJObject(false));
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
        public string GetNavigationTree(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).AsJson(true, minimal: true);
        }
        public string GetNavigationTree(string url)
        {
            return GetNavigationTree(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public object GetAncestors(int? id = -1)
        {
            return umbracoWeb.PublishedContentExtensions.Ancestors(Umbraco.TypedContent(id ?? -1)).AsJArray(false);
        }
        public object GetAncestors(string url)
        {
            return GetAncestors(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public object GetDescendantsOrSelf(int? id = -1)
        {
            return umbracoWeb.PublishedContentExtensions.DescendantsOrSelf(Umbraco.TypedContent(id ?? -1)).AsJArray(false);
        }
        public object GetDescendantsOrSelf(string url)
        {
            return GetDescendantsOrSelf(umbraco.uQuery.GetNodeIdByUrl(url));
        }

        public object GetTreeSafe(int? id = -1)
        {
            return Umbraco.TypedContent(id ?? -1).AsJObject(true);
        }
        public object GetTreeSafe(string url)
        {
            return GetTreeSafe(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        //public object GetDescendantsOrSelfSafe(int? id = -1)
        //{
        //    return umbracoWeb.PublishedContentExtensions.DescendantsOrSelf(Umbraco.TypedContent(id ?? -1)).AsJArray(false);
        //}
        //public object GetDescendantsOrSelfSafe(string url)
        //{
        //    return GetDescendantsOrSelfSafe(umbraco.uQuery.GetNodeIdByUrl(url));
        //}

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
