using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web;
namespace Tapas
{
    
    public class SerializableNode : IPublishedContent
    {
        private PortableNodeCollection portableNodeCollection;
        public PortableNodeCollection PortableNodeCollection
        {
            set
            {
                portableNodeCollection = value;
            }
        }
        public SerializableNode()
        {
            //this.Children = new List<PortableNode>();
            //this.ContentSet = new List<PortableNode>();
            this.Properties = new List<IPublishedProperty>();
        }
        public SerializableNode(IPublishedContent content, bool traverseChildren, bool getTemplateAlias = true)
        {
            if (traverseChildren)
                this.Children = content.Children.Select(c => new SerializableNode(c, traverseChildren));
            else
                this.Children = new List<SerializableNode>();

            //this.ContentType = content.ContentType;
            //this.ContentSet = new List<PortableNode>();// content.ContentSet;
            this.CreateDate = content.CreateDate;
            this.CreatorId = content.CreatorId;
            this.CreatorName = content.CreatorName;
            this.DocumentTypeAlias = content.DocumentTypeAlias;
            this.DocumentTypeId = content.DocumentTypeId;
            this.Id = content.Id;
            this.IsDraft = content.IsDraft;
            this.ItemType = content.ItemType;
            this.Level = content.Level;
            this.Name = content.Name;
            //this.Parent = content.Parent;
            this.ParentId = (content.Parent == null) ? -1 : content.Parent.Id;
            this.Path = content.Path; 
            //this.Properties = content.Properties;
            //this.Properties = content.Properties.Select(p=>new SerializableProperty(p)).ToList<IPublishedProperty>();// new List<IPublishedProperty>();
            this.PropertiesDictionary = content.Properties.ToDictionary(k => k.PropertyTypeAlias, k => k.DataValue);
            this.SortOrder = content.SortOrder;
            this.TemplateId = content.TemplateId;
            this.TemplateAlias = content.GetTemplateAlias();
            this.UpdateDate = content.UpdateDate;
            this.Url = content.Url;
            this.UrlName = content.UrlName;
            this.Version = content.Version;
            this.WriterId = content.WriterId;
            this.WriterName = content.WriterName;

        }
        public IEnumerable<IPublishedContent> Children
        {
            get;
            set;
        }
        public IEnumerable<IPublishedContent> ContentSet
        {
            get;
            set;
        }

        [JsonIgnore]
        public Umbraco.Core.Models.PublishedContent.PublishedContentType ContentType { get; set; }
        
        public DateTime CreateDate { get; set; }
        public int CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string DocumentTypeAlias { get; set; }
        public int DocumentTypeId { get; set; }
        public int GetIndex()
        {
            throw new NotImplementedException();
        }
        public IPublishedProperty GetProperty(string alias, bool recurse)
        {
            throw new NotImplementedException();
        }
        public IPublishedProperty GetProperty(string alias)
        {
            throw new NotImplementedException();
        }
        public int Id { get; set; }
        public bool IsDraft { get; set; }

        [JsonIgnore]
        public PublishedItemType ItemType { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        
        [JsonIgnore]
        public IPublishedContent Parent { get; set; }
        public int ParentId { get; set; }
        public string Path { get; set; }
        
        [JsonIgnore]
        public ICollection<IPublishedProperty> Properties { get; set; }

        [JsonProperty(PropertyName = "Properties")]
        public Dictionary<string, object> PropertiesDictionary { get; set; }
        public int SortOrder { get; set; }
        public int TemplateId { get; set; }
        public string TemplateAlias { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Url { get; set; }
        public string UrlName { get; set; }
        public Guid Version { get; set; }
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        
        [JsonIgnore]
        public object this[string alias]
        {
            get { return null; }
            set { ; }
        }

    }
}
