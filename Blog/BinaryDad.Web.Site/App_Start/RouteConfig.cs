using System.Web.Mvc;
using System.Web.Routing;

namespace BinaryDad.Web.Site
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();
            routes.RouteExistingFiles = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Home", "", new { controller = "Content", action = "Home", id = UrlParameter.Optional });
            routes.MapRoute("Admin", "{action}/{*path}", new { controller = "Admin" }, new { action = "edit|delete|save|create|upload|login|logout" });
            routes.MapRoute("Files", "file/{*path}", new { Controller = "Content", action = "File" });
            routes.MapRoute("Page", "{*path}", new { controller = "Content", action = "Page" });
        }
    }
}
