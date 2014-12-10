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
            return ContentService.GetById(node.ParentId);
        }
        public List<PortableNode> Children(PortableNode node)
        {
            return ContentService.GetByParentId(node.Id);
        }
        public List<PortableNode> Siblings(PortableNode node)
        {
            return ContentService.GetByParentId(node.ParentId);
        }
    }
}
