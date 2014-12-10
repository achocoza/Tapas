using Examine.LuceneEngine.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tapas.ExamineClient
{
    public class PortableNodeIndexer : LuceneIndexer
    {
        protected override void PerformIndexAll(string type)
        {
            var content = ContentService.NodeCollection.RemoteContent.GetRemoteContent("/").Select(t => t.ToXElement());
            AddNodesToIndex(content, "PortableNodeIndexer");
        }

        protected override void PerformIndexRebuild()
        {
            IndexAll("PortableNodeIndexer");
        }
    }
}
