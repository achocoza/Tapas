using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace Tapas
{
    [PluginController("TapasDump")]
    public class ContentDumpController : UmbracoAuthorizedApiController
    {
        private void dumpNode(int nodeId, string rootPath)
        {
            var n = Umbraco.TypedContent(nodeId);

            var relativeFileName = n.Url.TrimEnd('/');

            if (relativeFileName == "/" || relativeFileName == "") relativeFileName = "_index.json";
            else relativeFileName += ".json";


            var fileName = rootPath + "/" + relativeFileName;

            try
            {

                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fileName));
            }
            catch (Exception)
            {

            }

            System.IO.File.WriteAllText(fileName, JsonConvert.SerializeObject(n, Formatting.Indented));

            foreach (var c in n.Children)
            {
                dumpNode(c.Id, rootPath);
            }

        }

        public void GetDumpToDisk(int? id = -1)
        {
            var defaultPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Tapas/ContentDump/");
            dumpNode(id ?? -1, defaultPath);
        }
        public void GetDumpToDisk(string url)
        {
            GetDumpToDisk(umbraco.uQuery.GetNodeIdByUrl(url));
        }
    }

}
