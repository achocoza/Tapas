using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas
{
    public interface IPortableNodeManager
    {
        PortableNode Parent(PortableNode node);
        List<PortableNode> Children(PortableNode node);
        List<PortableNode> Siblings(PortableNode node);

        PortableNode GetById(int id);
        PortableNode GetByUrl(string url);
        List<PortableNode> GetByTypeAlias(string typeAlias);

        void Add(PortableNode node);
        void Delete(int id, bool throwExceptionIfItsAlreadyMissing = false);
        void Add(List<PortableNode> portableNodes);
        
        void DeleteAll();
        void Dispose();

    }
}
