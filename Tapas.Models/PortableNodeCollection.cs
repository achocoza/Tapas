using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas
{
    public class PortableNodeCollection : IPortableNodeWalker
    {
        public List<PortableNode> PortableNodes { get; set; }
        public PortableNodeCollection()
        {
            PortableNodes = new List<PortableNode>();
        }
        public void AddOrUpdate(PortableNode portableNode)
        {
            var existingNode = PortableNodes.SingleOrDefault(p => p.Id == portableNode.Id);

            portableNode.PortableNodeWalker = this;
            if (existingNode != null) existingNode = portableNode;
            else PortableNodes.Add(portableNode);
        }
        public PortableNode Parent(PortableNode node)
        {
            return PortableNodes.SingleOrDefault(n => n.Id == node.ParentId);
        }

        public List<PortableNode> Children(PortableNode node)
        {
            return PortableNodes.Where(n => n.ParentId == node.Id).OrderBy(n => n.SortOrder).ToList();
        }

        public List<PortableNode> Siblings(PortableNode node)
        {
            return PortableNodes.Where(n => n.ParentId == node.ParentId).OrderBy(n => n.SortOrder).ToList();
        }
    }
}
