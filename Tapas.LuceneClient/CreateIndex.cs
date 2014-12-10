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

    public class CreateIndex
    {
        public CreateIndex(string path)
        {
            //state the file location of the index
            var indexFileLocation = new System.IO.DirectoryInfo(path);
            Lucene.Net.Store.Directory dir = Lucene.Net.Store.FSDirectory.Open(indexFileLocation);

            //create an analyzer to process the text
            Lucene.Net.Analysis.Analyzer analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);

            //create the index writer with the directory and analyzer defined.
            Lucene.Net.Index.IndexWriter indexWriter = new
            Lucene.Net.Index.IndexWriter(dir, analyzer, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED);

            //create a document, add in a single field
            Lucene.Net.Documents.Document doc = new
            Lucene.Net.Documents.Document();

            Lucene.Net.Documents.Field fldContent =
              new Lucene.Net.Documents.Field("content",
              "The quick brown fox jumps over the lazy dog",
              Lucene.Net.Documents.Field.Store.YES,
            Lucene.Net.Documents.Field.Index.ANALYZED,
            Lucene.Net.Documents.Field.TermVector.YES);

            doc.Add(fldContent);

            //write the document to the index
            indexWriter.AddDocument(doc);

            //optimize and close the writer
            indexWriter.Optimize();
            indexWriter.Close();

        }
    }

}
