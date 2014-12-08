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
            return View(ContentService.Current.ContentByUrl(url));
        }
        public ActionResult ByTemplateAlias(string url)
        {
            var content = ContentService.Current.ContentByUrl(url);
            if (content == null)
                return View("NotFound");
            else
                return View(content.TemplateAlias, content);
        }
    }
}
