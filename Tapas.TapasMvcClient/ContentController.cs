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
            return View(new ContentService("http://localhost:43896/").ContentByUrl(url));
        }
    }
}
