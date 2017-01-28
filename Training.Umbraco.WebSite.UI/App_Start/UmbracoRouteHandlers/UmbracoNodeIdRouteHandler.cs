using System.Web.Routing;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Training.Umbraco.WebSite.UI.UmbracoRouteHandlers
{
    public class UmbracoNodeIdRouteHandler : UmbracoVirtualNodeRouteHandler
    {
        protected override IPublishedContent FindContent(RequestContext requestContext, UmbracoContext umbracoContext)
        {
            var id = requestContext.RouteData.Values["id"];
            var umbracoHelper = new UmbracoHelper(umbracoContext);

            return umbracoHelper.TypedContent(id);
        }
    }
}