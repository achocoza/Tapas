using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Tapas.TapasMvcClient
{
    public class ContentController:Controller
    {
        public ActionResult Index(string url)
        {
            return View(ContentService.Current.ContentByUrl(url));
        }
    }
}
