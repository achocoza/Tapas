using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas.LuceneClient
{
    public class LucenePortableNodeWalker : IPortableNodeWalker
    {
        public PortableNode Parent(PortableNode node)
        {
            return Search.FindById(node.ParentId);
        }
        public List<PortableNode> Children(PortableNode node)
        {
            return Search.FindByParentId(node.Id);
        }
        public List<PortableNode> Siblings(PortableNode node)
        {
            return Search.FindByParentId(node.ParentId);
        }
    }
}
