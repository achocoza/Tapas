using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas
{
    public class ConnectedNodeCollection
    {
        public RemoteContent RemoteContent { get; private set; }

        PortableNodeCollection portableNodeCollection;

        public ConnectedNodeCollection(string remoteRootUrl, string remoteContentUrl = "/")
        {
            RemoteContent = new RemoteContent(remoteRootUrl, remoteContentUrl);
            refreshNodeCollection("/");
        }

        public List<PortableNode> Nodes()
        {
            return portableNodeCollection.PortableNodes;
        }
        private void refreshNodeCollection(string url)
        {
            portableNodeCollection = new PortableNodeCollection();
            foreach (var p in RemoteContent.GetRemoteContent(url))
            {
                portableNodeCollection.AddOrUpdate(p);
            }
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
