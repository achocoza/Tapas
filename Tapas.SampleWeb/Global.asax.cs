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

            // Initialize "ContentService" to load data from remote 
            // Umbraco host. This sample assumes a default Umbraco 7.2 
            // installation running Tapas.ContentHost.

            // Depending on your installation you will need to change
            // the views to match the template aliases you use.

            // This project has no dependency to Umbraco at all.

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
