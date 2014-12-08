using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tapas.TapasMvcClient;

namespace Tapas.SampleWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            var c = new ContentService("http://localhost:43896/");
            c.LoadContent("/");

            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{*url}",
                defaults: new { controller = "Content", action = "Index" }
            );

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
