using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas
{
    public class WebClient
    {
        string remoteRootUrl;

        public WebClient(string remoteRootUrl)
        {
            this.remoteRootUrl = remoteRootUrl;
        }
        public List<PortableNode> DescendantsOrSelf(string url)
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(remoteRootUrl + "/umbraco/tapas/content/getdescendantsorself?url=" + url);
                return JsonConvert.DeserializeObject<List<PortableNode>>(json);
            }
        }
        public PortableNode Tree(string url)
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(remoteRootUrl + "/umbraco/tapas/content/gettree?url=" + url);
                return JsonConvert.DeserializeObject<PortableNode>(json);
            }
        }
        public PortableNode Node(string url)
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(remoteRootUrl + "/umbraco/tapas/content/getnode?url=" + url);
                return JsonConvert.DeserializeObject<PortableNode>(json);
            }
        }
    }

}
