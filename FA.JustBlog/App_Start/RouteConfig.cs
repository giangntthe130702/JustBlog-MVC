using System.Web.Mvc;
using System.Web.Routing;

namespace IdentitySample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Post", "Posts/{year}/{month}/{title}",
               new { controller = "Posts", action = "Details" },
               new { year = @"\d{4}", month = @"\d{2}" });

            routes.MapRoute("Tag", "{controller}/{id}",
               new { controller = "Tag", action = "Details" },
               new { name = @"\s{4}" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           

        }
    }
}