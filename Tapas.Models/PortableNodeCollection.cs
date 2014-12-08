using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas
{
    public class PortableNodeCollection
    {
        public List<PortableNode> PortableNodes { get; set; }
        public PortableNodeCollection()
        {
            PortableNodes = new List<PortableNode>();
        }
        public void AddOrUpdate(PortableNode portableNode)
        {
            var existingNode = PortableNodes.SingleOrDefault(p => p.Id == portableNode.Id);

            portableNode.PortableNodeCollection = this;
            if (existingNode != null) existingNode = portableNode;
            else PortableNodes.Add(portableNode);
        }
    }
}
