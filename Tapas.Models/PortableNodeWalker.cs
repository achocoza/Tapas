using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas
{
    public interface IPortableNodeWalker
    {
        PortableNode Parent(PortableNode node);
        List<PortableNode> Children(PortableNode node);
        List<PortableNode> Siblings(PortableNode node);
    }
}
