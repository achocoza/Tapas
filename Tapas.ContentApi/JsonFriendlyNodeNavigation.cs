using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas
{
    public class JsonFriendlyNodeNavigation
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string UrlName { get; set; }
        public bool Visible { get; set; }
        public IEnumerable<JsonFriendlyNodeNavigation> Children { get; set; }

    }
}
