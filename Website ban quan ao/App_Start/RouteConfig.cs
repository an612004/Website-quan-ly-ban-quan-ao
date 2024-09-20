using System.Web.Mvc;
using System.Web.Routing;

namespace Website_ban_quan_ao
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Website_ban_quan_ao.Controllers" }  // Thêm namespace của controllers vào đây
            );
        }
    }
}
