using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Tapas.MvcClient
{
    public class ContentController:Controller
    {

        public ActionResult Index(string url)
        {
            return View(ContentService.NodeCollection.ContentByUrl(url));
        }
        public ActionResult ByTemplateAlias(string url)
        {
            var content = ContentService.NodeCollection.ContentByUrl(url);
            if (content == null)
                return View("NotFound");
            else
                return View(content.TemplateAlias, content);
        }
    }
}
