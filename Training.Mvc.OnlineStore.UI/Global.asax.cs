using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Training.Mvc.OnlineStore.UI.App_Start;

namespace Training.Mvc.OnlineStore.UI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
