using System.Web.Mvc;
using System.Web.Routing;

namespace Training.Mvc.OnlineStore.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Products by category",
                url: "category/{id}/{page}",
                defaults: new { controller = "Category", action = "ProductsByCategory", page = 1 },
                constraints: new { id = @"\d+", page = @"\d+" }, 
                namespaces: new [] { "Training.Mvc.OnlineStore.UI.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: null,
                namespaces: new [] { "Training.Mvc.OnlineStore.UI.Controllers" } 
            );
        }
    }
}
