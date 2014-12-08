using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapas;

namespace Tapas.MvcClient
{
    public class ContentService
    {
        public static ContentService Current { get; private set; }

        string remoteUrl;
        PortableNodeCollection portableNodeCollection;

        public ContentService(string remoteUrl, string url = "/")
        {
            this.remoteUrl = remoteUrl;
            LoadContent("/");
        }
        public void LoadContent(string url)
        {
            using (var webClient = new System.Net.WebClient())
            {
                portableNodeCollection = new PortableNodeCollection();
                var json = webClient.DownloadString(remoteUrl + "/umbraco/tapas/content/getdescendantsorself?url=" + url);
                var des = JsonConvert.DeserializeObject<List<PortableNode>>(json);
                foreach (var p in des)
                {
                    portableNodeCollection.AddOrUpdate(p);
                }
            }
        }
        public static void InitializeCurrent(string remoteUrl)
        {
            Current = new ContentService(remoteUrl);
        }
        public PortableNode ContentByUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) url = "/";
            if (!url.StartsWith("/")) url = "/" + url;

            return portableNodeCollection.PortableNodes.SingleOrDefault(t => t.Url == url);
        }
        public PortableNode ContentById(int id)
        {            
            return portableNodeCollection.PortableNodes.SingleOrDefault(t => t.Id == id);
        }
    }
}
