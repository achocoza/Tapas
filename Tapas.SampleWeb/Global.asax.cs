using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tapas.MvcClient;

namespace Tapas.SampleWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // connect to remote Umbraco host, this sample
            // assumes the default Umbraco 7.2 installation
            // depending on your installation you will need to change
            // the views to match the template aliases you use

            ContentService.InitializeCurrent("http://localhost:43896/");

            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{*url}",
                defaults: new { controller = "Content", action = "ByTemplateAlias" }
            );

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
