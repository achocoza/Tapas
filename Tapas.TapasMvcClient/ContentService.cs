using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapas.Models;

namespace Tapas.TapasMvcClient
{
    public class ContentService
    {
        string remoteUrl;
        PortableNodeCollection portableNodeCollection;
        public ContentService(string remoteUrl)
        {
            this.remoteUrl = remoteUrl;
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
        public PortableNode ContentByUrl(string url)
        {
            return portableNodeCollection.PortableNodes.SingleOrDefault(t => t.Url == url);
        }
        public PortableNode ContentById(int id)
        {
            return portableNodeCollection.PortableNodes.SingleOrDefault(t => t.Id == id);
        }
    }
}
