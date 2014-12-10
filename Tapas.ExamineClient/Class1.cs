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

            var nodes = new List<XElement>();


            AddNodesToIndex(null, "PortableNodeIndexer");

            throw new NotImplementedException();
        }

        protected override void PerformIndexRebuild()
        {
            throw new NotImplementedException();
        }
    }
}
