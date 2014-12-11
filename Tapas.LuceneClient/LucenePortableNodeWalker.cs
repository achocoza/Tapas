using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas.LuceneClient
{
    public class PortableNodeLucene : IPortableNodeManager
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

        public PortableNode GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PortableNode GetByUrl(string url)
        {
            throw new NotImplementedException();
        }

        public List<PortableNode> GetByTypeAlias(string typeAlias)
        {
            throw new NotImplementedException();
        }

        public void Add(PortableNode node)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id, bool throwExceptionIfItsAlreadyMissing = false)
        {
            throw new NotImplementedException();
        }

        public void Add(List<PortableNode> portableNodes)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
