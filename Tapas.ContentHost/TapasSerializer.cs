using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace Tapas.Helpers
{
    public class TapasSerializer : Newtonsoft.Json.JsonSerializer
    {
        public TapasSerializer(bool traverse = false, bool excludeProtected = true, bool minimal = false)
            : base()
        {            
            Converters.Add(new PublishedNodeSerializer(traverse, excludeProtected, minimal));
            Converters.Add(new HtmlStringSerializer());
            Converters.Add(new PublishedPropertySerializer());
        }
    }

}
