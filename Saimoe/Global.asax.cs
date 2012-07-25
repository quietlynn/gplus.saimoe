using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Web.Optimization;
using Saimoe.Infra;
using System.Globalization;

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


            //will create a warmup util
            ModelMappingUtil.RegisterMapping();
        }

        public static readonly string LangCookieName = "lang";
        public static readonly string LangQueryName = "hl";

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;

            string culture = null;

            var cookie = context.Request.Cookies[LangCookieName];
            if (cookie != null)
            {
                culture = cookie.Value;
            }

            var queryValue = context.Request.QueryString[LangQueryName];
            if (!string.IsNullOrEmpty(queryValue))
            {
                culture = queryValue;
            }

            if (!string.IsNullOrEmpty(culture))
            {
                var thread = System.Threading.Thread.CurrentThread;
                try
                {
                    thread.CurrentCulture = thread.CurrentUICulture = new CultureInfo(culture);
                }
                catch (ArgumentException)
                {
                    // Not a valid culture name.
                }
            }
        }
    }
}