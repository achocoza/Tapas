using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umbraco.BusinessLogic;
using umbraco.cms.businesslogic;
using umbraco.cms.businesslogic.web;
using Umbraco.Core;

namespace Tapas
{
    public class RegisterEvents : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {            
            Document.BeforePublish += Document_BeforePublish;
            Document.BeforeUnPublish += Document_BeforeUnPublish;
            Document.BeforeDelete += Document_BeforeDelete;
        }

        void Document_BeforeDelete(Document sender, DeleteEventArgs e)
        {
            // send to tapas client
        }

        void Document_BeforeUnPublish(Document sender, UnPublishEventArgs e)
        {
            // send to tapas client
        }

        private void Document_BeforePublish(Document sender, PublishEventArgs e)
        {
            // send to tapas client
        }
    }
}
