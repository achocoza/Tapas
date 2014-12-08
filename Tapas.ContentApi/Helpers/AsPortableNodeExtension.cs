using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace Tapas.Helpers
{
    public static class AsPortableNodeExtension
    {
        public static PortableNode AsPortableNode(this IPublishedContent node, bool traverseChildren)
        {
            return new PortableNode(node,traverseChildren);
        }
    }
}
