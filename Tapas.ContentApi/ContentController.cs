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
using System.IO;

namespace Tapas
{

    [PluginController("Tapas"), IsBackOffice]
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

        private void dumpNode(int nodeId, string rootPath, bool asYaml)
        {
            var n = Umbraco.TypedContent(nodeId);
            
            var relativeFileName = n.Url.TrimEnd('/');

            if (relativeFileName == "/" || relativeFileName == "") relativeFileName = "_index";

            var fileName = rootPath + "/" + relativeFileName;

            try
            {

                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fileName));
            }
            catch (Exception)
            {

            }

            var contents = n.AsJson();

            if (asYaml)
            {
                var s = new YamlDotNet.Serialization.Serializer();
                var sw = new StringWriter();
                var jobject = JsonConvert.DeserializeObject(contents);
                s.Serialize(sw, jobject);

                contents = s.ToString();
                System.IO.File.WriteAllText(fileName + ".yaml", contents);
            }
            else
            {
                System.IO.File.WriteAllText(fileName + ".json", contents);
            }

            

            foreach (var c in n.Children)
            {
                dumpNode(c.Id, rootPath, asYaml);
            }

        }

        public void GetDumpToDisk(int? id = -1, bool asYaml = true)
        {
            var json = GetNode(id);
            var defaultPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Tapas/ContentDump/");

            dumpNode(id ?? -1, defaultPath, asYaml);
        }
        public void GetDumpToDisk(string url, bool asYaml = true)
        {
            GetDumpToDisk(umbraco.uQuery.GetNodeIdByUrl(url));
        }

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
            return umbracoWeb.PublishedContentExtensions.Ancestors(Umbraco.TypedContent(id ?? -1)).AsJson();
        }
        public string GetAncestors(string url)
        {
            return GetAncestors(umbraco.uQuery.GetNodeIdByUrl(url));
        }
        public string GetDescendantsOrSelf(int? id = -1)
        {
            return umbracoWeb.PublishedContentExtensions.DescendantsOrSelf(Umbraco.TypedContent(id ?? -1)).AsJson();
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
