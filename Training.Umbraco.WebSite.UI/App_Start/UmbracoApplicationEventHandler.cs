using System.Web.Mvc;
using System.Web.Routing;
using Training.Umbraco.WebSite.UI.App_Start.UmbracoRouteHandlers;
using Training.Umbraco.WebSite.UI.ContentFinders;
using Training.Umbraco.WebSite.UI.Controllers;
using Training.Umbraco.WebSite.UI.UmbracoRouteHandlers;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.Routing;

namespace Training.Umbraco.WebSite.UI
{
    public class UmbracoApplicationEventHandler : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            // AutoMapper
            AutoMapperHandler.RegisterMappings();

            
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            AreaRegistration.RegisterAllAreas();

            var umbracoRouteHandler = new AssignHomePageToRouteHandler();

            RouteTable.Routes.MapRoute(
                "Account",
                "Account/{action}/{id}",
                new { controller = "Account", action = "Index", id = UrlParameter.Optional },
                umbracoRouteHandler,
                namespaces: new[] { "Training.Umbraco.WebSite.UI.Controllers" })
                .RouteHandler = umbracoRouteHandler;

            RouteTable.Routes.MapUmbracoRoute(
                "Product list by category",
                "category/{id}",
                new
                {
                    controller = "Category",
                    action = "ProductsByCategory",
                    id = UrlParameter.Optional,
                    page = 1
                }, new UmbracoVirtualNodeByIdRouteHandler(1058));

            RouteTable.Routes.MapUmbracoRoute(
                "Product details",
                "Product/details/{id}",
                new
                {
                    controller = "Product",
                    action = "Details",
                    id = UrlParameter.Optional
                }, new FindProductReviewRouteHandler());
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentFinderResolver.Current.InsertTypeBefore<ContentFinderByNotFoundHandlers, FindContentByFormerUrl>();
            DefaultRenderMvcControllerResolver.Current.SetDefaultControllerType(typeof(StoreRenderMvcController));
        }
    }
}