using Lucene.Net.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas.LuceneClient
{
    public static class Converters
    {
        public static PortableNode ConvertToPortableNode(Document document)
        {
            var node = new PortableNode();

            node.PortableNodeWalker = new LucenePortableNodeWalker();

            var getStringField = new Func<string, string>((key) =>
            document.GetField(key).StringValue);

            node.Url = getStringField("Url");
            node.Name = getStringField("Name");
            node.Path = getStringField("Path");
            node.CreatorName = getStringField("CreatorName");
            node.DocumentTypeAlias = getStringField("DocumentTypeAlias");
            node.TemplateAlias = getStringField("TemplateAlias");
            node.UrlName = getStringField("UrlName");
            node.WriterName = getStringField("WriterName");

            var getDateField = new Func<string, DateTime>((key) =>
            {
                var value = document.GetField(key).StringValue;
                return DateTime.Parse(value);
            });

            node.CreateDate = getDateField("CreateDate");
            node.UpdateDate = getDateField("UpdateDate");

            var getBoolField = new Func<string, Boolean>((key) =>
            {
                var value = document.GetField(key).StringValue;
                return Boolean.Parse(value);
            });

            node.IsDraft = getBoolField("IsDraft");


            var getIntField = new Func<string, Int32>((key) =>
            {
                var value = document.GetField(key).StringValue;
                return Int32.Parse(value);
            });

            node.CreatorId = getIntField("CreatorId");
            node.DocumentTypeId = getIntField("DocumentTypeId");
            node.Id = getIntField("Id");
            node.Level = getIntField("Level");
            node.ParentId = getIntField("ParentId");
            node.SortOrder = getIntField("SortOrder");
            node.WriterId = getIntField("WriterId");

            var getGuidField = new Func<string, Guid>((key) =>
            {
                var value = document.GetField(key).StringValue;
                return Guid.Parse(value);
            });

            node.Version = getGuidField("Version");
            node.PropertiesDictionary = new Dictionary<string, object>();
            var properties = document.GetFields().Where(f => f.Name.StartsWith("_"));
            foreach (var prop in properties)
            {
                node.PropertiesDictionary.Add(prop.Name.Substring(1), prop.StringValue);
            }

            return node;
        }

        public static Document ConvertToDocument(PortableNode portableNode)
        {

            var createStringField = new Func<string, string, Field>((key, value) => new Field(
                    key,
                    value,
                    Lucene.Net.Documents.Field.Store.YES,
                    Lucene.Net.Documents.Field.Index.ANALYZED,
                    Lucene.Net.Documents.Field.TermVector.YES
                ));
            var createIdField = new Func<string, string, Field>((key, value) => new Field(
                    key,
                    value,
                    Lucene.Net.Documents.Field.Store.YES,
                    Lucene.Net.Documents.Field.Index.NOT_ANALYZED,
                    Lucene.Net.Documents.Field.TermVector.YES
                ));

            var doc = new Lucene.Net.Documents.Document();

            var addStringField = new Action<string, string>((key, value) =>
            {
                doc.Add(createStringField(key, value ?? ""));
            });

            // convert to objects?
            var addObjectField = new Action<string, object>((key, value) =>
            {
                var valueAsString = (value != null) ? value.ToString() : "";
                doc.Add(createStringField(key, valueAsString));
            });

            // convert to objects?
            var addIdField = new Action<string, object>((key, value) =>
            {
                var valueAsString = (value != null) ? value.ToString() : "";
                doc.Add(createIdField(key, valueAsString));
            });

            addIdField("Url", portableNode.Url);

            addStringField("Name", portableNode.Name);
            addIdField("Path", portableNode.Path);

            addStringField("CreatorName", portableNode.CreatorName);
            addStringField("DocumentTypeAlias", portableNode.DocumentTypeAlias);
            addStringField("TemplateAlias", portableNode.TemplateAlias);
            addStringField("UrlName", portableNode.UrlName);
            addStringField("WriterName", portableNode.WriterName);

            addObjectField("CreateDate", portableNode.CreateDate);
            addObjectField("CreatorId", portableNode.CreatorId);
            addObjectField("DocumentTypeId", portableNode.DocumentTypeId);

            addIdField("Id", portableNode.Id);

            addObjectField("IsDraft", portableNode.IsDraft);
            addObjectField("Level", portableNode.Level);
            addObjectField("ParentId", portableNode.ParentId);
            addObjectField("SortOrder", portableNode.SortOrder);
            addObjectField("TemplateId", portableNode.TemplateId);
            addObjectField("UpdateDate", portableNode.UpdateDate);
            addObjectField("Version", portableNode.Version);
            addObjectField("WriterId", portableNode.WriterId);

            foreach (var p in portableNode.PropertiesDictionary)
            {
                addStringField("Property_" + p.Key, p.Value.ToString());
            }

            return doc;

        }

    }

}
