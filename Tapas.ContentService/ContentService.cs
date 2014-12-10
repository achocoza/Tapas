using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapas
{
    public static class ContentService
    {
        public static ConnectedNodeCollection NodeCollection { get; set; }
        public static void Initialize(string remoteUrl, string remoteRelativeUrl)
        {
            NodeCollection = new ConnectedNodeCollection(remoteUrl, remoteRelativeUrl);
        }
    }

}
