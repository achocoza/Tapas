using Examine.LuceneEngine.Providers;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas.ExamineClient
{
    public static class ExamineContentService
    {
        public static PortableNode ContentByUrl(string url)
        {
            var searcher = new LuceneSearcher(new SimpleFSDirectory(new System.IO.FileInfo("~/App_Data/PortableNode")), new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));

            var criteria = searcher.CreateSearchCriteria("PortableNode");
            var filter = criteria.GroupedOr(new string[] { "Url" }, url);
            var results = searcher.Search(filter.Compile());

            var single = results.
            return single.

        }
    }
}
