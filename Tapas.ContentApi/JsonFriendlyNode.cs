using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas
{
    public class JsonFriendlyNode
    {
        public DateTime CreateDate { get; set; }
        public int CreatorID { get; set; }
        public string CreatorName { get; set; }
        public int Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string DocumentTypeAlias { get; set; }
        public int ParentId { get; set; }
        public string Path { get; set; }
        public int SortOrder { get; set; }
        public int TemplateId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Url { get; set; }
        public string UrlName { get; set; }
        public Guid Version { get; set; }
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public IEnumerable<int> ChildrenIds { get; set; }
        public IEnumerable<JsonFriendlyNode> ChildrenNodes { get; set; }

    }
}
