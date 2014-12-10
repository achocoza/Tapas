using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapas;

namespace Tapas
{
    public class RemoteContent
    {
        string remoteRootUrl;
        string remoteContentUrl;

        public RemoteContent(string remoteRootUrl, string remoteContentUrl = "/")
        {
            this.remoteRootUrl = remoteRootUrl;
            this.remoteContentUrl = remoteContentUrl;
        }
        public List<PortableNode> GetRemoteContent(string url)
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(remoteRootUrl + "/umbraco/tapas/content/getdescendantsorself?url=" + url);
                return JsonConvert.DeserializeObject<List<PortableNode>>(json);
            }
        }
    }
}
