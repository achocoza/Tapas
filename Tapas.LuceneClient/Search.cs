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
        public static IndexSearcher Searcher { get; set; }

        public void InitializeSearcher(string path){
            //state the file location of the index
            var indexFileLocation = new System.IO.DirectoryInfo(path);
            Lucene.Net.Store.Directory dir = Lucene.Net.Store.FSDirectory.Open(indexFileLocation);

            //create an index searcher that will perform the search
            Searcher = new
            Lucene.Net.Search.IndexSearcher(dir);
        }
        public PortableNode SearchByUrl(string url)
        {

            //build a query object
            Lucene.Net.Index.Term searchTerm = new Lucene.Net.Index.Term("Url", url);
            Lucene.Net.Search.Query query = new Lucene.Net.Search.TermQuery(searchTerm);

            TopScoreDocCollector collector = TopScoreDocCollector.Create(1, true);


            //execute the query
            Searcher.Search(query, collector);
            ScoreDoc[] hits = collector.TopDocs().ScoreDocs;

            //iterate over the results.
            for (int i = 0; i < hits.Length; i++)
            {
                Document doc = Searcher.Doc(i);
                return Converters.ConvertToPortableNode(doc);
            }
            return null;
        }
        public PortableNode SearchById(int Id)
        {

            //build a query object
            Lucene.Net.Index.Term searchTerm = new Lucene.Net.Index.Term("Id", Id.ToString());
            Lucene.Net.Search.Query query = new Lucene.Net.Search.TermQuery(searchTerm);

            TopScoreDocCollector collector = TopScoreDocCollector.Create(1, true);


            //execute the query
            Searcher.Search(query, collector);
            ScoreDoc[] hits = collector.TopDocs().ScoreDocs;

            //iterate over the results.
            for (int i = 0; i < hits.Length; i++)
            {
                Document doc = Searcher.Doc(i);
                return Converters.ConvertToPortableNode(doc);
            }
            return null;
        }
    }
}
