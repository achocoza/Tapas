using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas.LuceneClient
{
    public class ContentService
    {
        public static IndexSearcher Searcher { get; set; }
        private static string indexPath;
        public static void Initialize(string path)
        {
            indexPath = path;
            //state the file location of the index
            var indexFileLocation = new System.IO.DirectoryInfo(path);
            Lucene.Net.Store.Directory dir = Lucene.Net.Store.FSDirectory.Open(indexFileLocation);
            //create an index searcher that will perform the search
            Searcher = new
            Lucene.Net.Search.IndexSearcher(dir);
            
        }
        public static void ReInitialize()
        {
            Searcher.Dispose();
            var indexFileLocation = new System.IO.DirectoryInfo(indexPath);
            Lucene.Net.Store.Directory dir = Lucene.Net.Store.FSDirectory.Open(indexFileLocation);
            //create an index searcher that will perform the search
            Searcher = new
            Lucene.Net.Search.IndexSearcher(dir);

        }
        public static PortableNode GetBy(string fieldName, string value)
        {
            //build a query object
            Lucene.Net.Index.Term searchTerm = new Lucene.Net.Index.Term(fieldName, value);
            Lucene.Net.Search.Query query = new Lucene.Net.Search.TermQuery(searchTerm);

            TopScoreDocCollector collector = TopScoreDocCollector.Create(1, true);

            //execute the query
            Searcher.Search(query, collector);
            ScoreDoc[] hits = collector.TopDocs().ScoreDocs;

            if (hits.Length == 1) return Converters.ConvertToPortableNode(Searcher.IndexReader.Document(hits[0].Doc));

            return null;
        }
        public static List<PortableNode> GetAllBy(string fieldName, string value)
        {
            //build a query object
            Lucene.Net.Index.Term searchTerm = new Lucene.Net.Index.Term(fieldName, value);
            Lucene.Net.Search.Query query = new Lucene.Net.Search.TermQuery(searchTerm);

            TopScoreDocCollector collector = TopScoreDocCollector.Create(1000, true);

            //execute the query
            Searcher.Search(query, collector);
            ScoreDoc[] hits = collector.TopDocs().ScoreDocs;
            if (hits != null)
                return hits.Select(t => Searcher.IndexReader.Document(t.Doc)).Select(t => Converters.ConvertToPortableNode(t)).ToList();

            return null;
        }
        public static PortableNode GetByUrl(string url)
        {
            return GetBy("Url", url);
        }
        public static PortableNode GetByName(string name)
        {
            return GetBy("Name", name.ToLower());
        }
        public static PortableNode GetById(int Id)
        {
            return GetBy("Id", Id.ToString());
        }
        public static List<PortableNode> GetByParentId(int Id)
        {
            return GetAllBy("ParentId", Id.ToString());
        }
    }
}
