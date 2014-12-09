using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace Tapas
{
    public class SerializableProperty : IPublishedProperty
    {
        public SerializableProperty(IPublishedProperty property)
        {
            this.Value = property.Value;
            this.HasValue = property.HasValue;
            this.PropertyTypeAlias = property.PropertyTypeAlias;
        }
        public object DataValue { get { return null; } set { } }

        public bool HasValue { get; set; }

        public string PropertyTypeAlias { get; set; }

        public object Value { get; set; }

        public object XPathValue { get { return null; } set { } }
    }
}
