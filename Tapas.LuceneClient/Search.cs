using Lucene.Net.Documents;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas.LuceneClient
{
    public class Search
    {
        public Search(string path)
        {
            //state the file location of the index
            var indexFileLocation = new System.IO.DirectoryInfo(path);
            Lucene.Net.Store.Directory dir = Lucene.Net.Store.FSDirectory.Open(indexFileLocation);

            //create an index searcher that will perform the search
            Lucene.Net.Search.IndexSearcher searcher = new
            Lucene.Net.Search.IndexSearcher(dir);

            //build a query object
            Lucene.Net.Index.Term searchTerm =
              new Lucene.Net.Index.Term("content", "fox");
            Lucene.Net.Search.Query query = new Lucene.Net.Search.TermQuery(searchTerm);

            TopScoreDocCollector collector = TopScoreDocCollector.Create(100, true);


            //execute the query
            searcher.Search(query, collector);
            ScoreDoc[] hits = collector.TopDocs().ScoreDocs;

            //iterate over the results.
            for (int i = 0; i < hits.Length; i++)
            {
                Document doc = searcher.Doc(i);
                string contentValue = doc.Get("content");

                Console.WriteLine(contentValue);

            }
        }
    }
}
