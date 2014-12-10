using Lucene.Net.Documents;
using Lucene.Net.Index;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas.LuceneClient
{
    /// <summary>
    /// http://www.codeproject.com/Articles/29755/Introducing-Lucene-Net
    /// </summary>

    public class PortableNodeIndex
    {
        public static string Path { get; set; }

        public static void DeleteAll()
        {
            //state the file location of the index
            var indexFileLocation = new System.IO.DirectoryInfo(Path);
            Lucene.Net.Store.Directory dir = Lucene.Net.Store.FSDirectory.Open(indexFileLocation);

            //create an analyzer to process the text
            using (Lucene.Net.Analysis.Analyzer analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
            {

                //create the index writer with the directory and analyzer defined.
                using (Lucene.Net.Index.IndexWriter indexWriter = new
                Lucene.Net.Index.IndexWriter(dir, analyzer, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED))
                {

                    indexWriter.DeleteAll();
                    indexWriter.Commit();
                    indexWriter.Optimize();
                    indexWriter.Dispose();
                }
            }

        }
        public static void AddNode(PortableNode portableNode)
        {

            //state the file location of the index
            var indexFileLocation = new System.IO.DirectoryInfo(Path);
            Lucene.Net.Store.Directory dir = Lucene.Net.Store.FSDirectory.Open(indexFileLocation);

            //create an analyzer to process the text
            using (Lucene.Net.Analysis.Analyzer analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
            {

                //create the index writer with the directory and analyzer defined.
                using (Lucene.Net.Index.IndexWriter indexWriter = new
                Lucene.Net.Index.IndexWriter(dir, analyzer, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED))
                {

                    var doc = Converters.ConvertToDocument(portableNode);
                    //write the document to the index

                    Lucene.Net.Index.Term searchTerm = new Lucene.Net.Index.Term("Id", portableNode.Id.ToString());
                    Lucene.Net.Search.Query query = new Lucene.Net.Search.TermQuery(searchTerm);
                    indexWriter.DeleteDocuments(query);

                    indexWriter.AddDocument(doc);

                    //optimize and close the writer
                    indexWriter.Optimize();
                    indexWriter.Dispose();
                }
            }
        }
        public static void DeleteNode(int Id)
        {
            //state the file location of the index
            var indexFileLocation = new System.IO.DirectoryInfo(Path);
            Lucene.Net.Store.Directory dir = Lucene.Net.Store.FSDirectory.Open(indexFileLocation);

            //create an analyzer to process the text
            using (Lucene.Net.Analysis.Analyzer analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
            {

                //create the index writer with the directory and analyzer defined.
                using (Lucene.Net.Index.IndexWriter indexWriter = new
                Lucene.Net.Index.IndexWriter(dir, analyzer, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED))
                {


                    Lucene.Net.Index.Term searchTerm = new Lucene.Net.Index.Term("Id", Id.ToString());
                    Lucene.Net.Search.Query query = new Lucene.Net.Search.TermQuery(searchTerm);
                    indexWriter.DeleteDocuments(query);

                    //optimize and close the writer
                    indexWriter.Optimize();
                    indexWriter.Dispose();
                }
            }
        }
    }

}
