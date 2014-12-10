using Lucene.Net.Analysis;
using Lucene.Net.Contrib.Management.Client;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas.LuceneClient
{
    public class ContentService
    {
        public static SearcherContext Searcher { get; private set; }

        //public static IndexSearcher Searcher { get; set; }
        private static string indexPath;
        public static void Initialize(string path)
        {
            indexPath = path;
            
            Searcher = new SearcherContext(FSDirectory.Open(path), new WhitespaceAnalyzer());
            
        }

        public static PortableNode GetBy(string fieldName, string value)
        {
            using (var search = Searcher.GetSearcher())
            {

                //build a query object
                Lucene.Net.Index.Term searchTerm = new Lucene.Net.Index.Term(fieldName, value);
                Lucene.Net.Search.Query query = new Lucene.Net.Search.TermQuery(searchTerm);

                TopScoreDocCollector collector = TopScoreDocCollector.Create(1, true);

                //execute the query
                search.Searcher.Search(query, collector);
                ScoreDoc[] hits = collector.TopDocs().ScoreDocs;

                if (hits.Length == 1) return Converters.ConvertToPortableNode(search.Searcher.Doc(hits[0].Doc));

                return null;
            }
        }
        public static List<PortableNode> GetAllBy(string fieldName, string value)
        {
            using (var search = Searcher.GetSearcher())
            {

                //build a query object
                Lucene.Net.Index.Term searchTerm = new Lucene.Net.Index.Term(fieldName, value);
                Lucene.Net.Search.Query query = new Lucene.Net.Search.TermQuery(searchTerm);

                TopScoreDocCollector collector = TopScoreDocCollector.Create(1000, true);

                //execute the query
                search.Searcher.Search(query, collector);
                ScoreDoc[] hits = collector.TopDocs().ScoreDocs;
                if (hits != null)
                    return hits.Select(t => search.Searcher.Doc(t.Doc)).Select(t => Converters.ConvertToPortableNode(t)).ToList();

                return null;
            }
        }
        public static PortableNode GetByUrl(string url)
        {
            return GetBy("Url", url);
        }
        public static PortableNode GetByName(string name)
        {
            return GetBy("Name", name);
        }
        public static PortableNode GetById(int Id)
        {
            return GetBy("Id", Id.ToString());
        }
        public static List<PortableNode> GetByParentId(int Id)
        {
            return GetAllBy("ParentId", Id.ToString());
        }
        public static void DeleteAll()
        {
            ContentService.Searcher.Manager.DeleteAll();
        }
        public static void AddNode(PortableNode portableNode, bool wait = false)
        {

            var doc = Converters.ConvertToDocument(portableNode);
            //write the document to the index

            Lucene.Net.Index.Term searchTerm = new Lucene.Net.Index.Term("Id", portableNode.Id.ToString());
            Lucene.Net.Search.Query query = new Lucene.Net.Search.TermQuery(searchTerm);
            
            ContentService.Searcher.Manager.DeleteDocuments(query);

            var gen = ContentService.Searcher.Manager.AddDocument(doc);

            if (wait) ContentService.Searcher.Manager.WaitForGeneration(gen);

        }
        public static void DeleteNode(int Id)
        {
            Lucene.Net.Index.Term searchTerm = new Lucene.Net.Index.Term("Id", Id.ToString());
            Lucene.Net.Search.Query query = new Lucene.Net.Search.TermQuery(searchTerm);
            ContentService.Searcher.Manager.DeleteDocuments(query);
        }


        public static void Dispose()
        {
            Searcher.Dispose();
        }
    }
}
