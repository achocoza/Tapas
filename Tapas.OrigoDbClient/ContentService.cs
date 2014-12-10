using OrigoDB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas.OrigoDbClient
{
    [Serializable]
    public class PortableNodeModel : OrigoDB.Core.Model
    {
        public List<PortableNode> PortableNodes { get; set; }
        public PortableNodeModel()
        {
            PortableNodes = new List<PortableNode>();
        }
    }
    public class OrigoContentService
    {
        public static PortableNodeModel db = Db.For<PortableNodeModel>("mode=embedded;");
        public static PortableNode ContentByUrl(string url)
        {
            return db.PortableNodes.LastOrDefault(t => t.Url == url);
        }
        public static void Add(PortableNode portableNode)
        {
            db.PortableNodes.Add(portableNode);
        }
    }
}
