using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Web.Optimization;

namespace Saimoe
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleTable.Bundles.EnableDefaultBundles();
            var bootstrapOrdering = new BundleFileSetOrdering("bootstrap");

            // Responsive plugin should be loaded later than the main css.
            bootstrapOrdering.Files.Add("bootstrap.css");
            bootstrapOrdering.Files.Add("bootstrap-responsive.css");

            BundleTable.Bundles.FileSetOrderList.Add(bootstrapOrdering);
        }
    }
}