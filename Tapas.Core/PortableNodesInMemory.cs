using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas
{
    public class PortableNodesInMemory : IPortableNodeManager
    {
        public List<PortableNode> PortableNodes { get; set; }
        public PortableNodesInMemory()
        {
            PortableNodes = new List<PortableNode>();
        }
        public void AddOrUpdate(PortableNode portableNode)
        {
            var existingNode = PortableNodes.SingleOrDefault(p => p.Id == portableNode.Id);

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

        public PortableNode GetById(int id)
        {
            return PortableNodes.SingleOrDefault(p => p.Id == id);
        }

        public PortableNode GetByUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) url = "/";
            if (!url.StartsWith("/")) url = "/" + url;

            return PortableNodes.SingleOrDefault(p => p.Url == url);
        }

        public List<PortableNode> GetByTypeAlias(string typeAlias)
        {
            return PortableNodes.Where(p => p.DocumentTypeAlias == typeAlias).ToList();
        }
        
        public void Add(PortableNode node)
        {
            Delete(node.Id);
            PortableNodes.Add(node);
        }

        public void Delete(int id, bool throwExceptionIfItsAlreadyMissing = false)
        {
            var node = GetById(id);
            if (node != null)
            {
                PortableNodes.Remove(node);
                return;
            }
            if (throwExceptionIfItsAlreadyMissing)
                throw new Exception("Node id does not exist");

        }

        public void Add(List<PortableNode> portableNodes)
        {
            PortableNodes.AddRange(portableNodes);
        }

        public void DeleteAll()
        {
            PortableNodes = new List<PortableNode>();
        }

        public void Dispose()
        {
            PortableNodes = null;
        }

    }
}
