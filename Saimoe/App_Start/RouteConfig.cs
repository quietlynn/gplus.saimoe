using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Saimoe
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // TODO: (Korepwx) On my laptop, I cannot make the Url Routing work. So the following is not tested.

            routes.MapRoute(
                name: "oauth2callback",
                url: "oauth2callback",
                defaults: new { controller = "OAuth", action = "GoogleCallback", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "oauth2login",
                url: "oauth2login",
                defaults: new { controller = "OAuth", action = "GoogleLogin", id = UrlParameter.Optional }
            );
        }
    }
}