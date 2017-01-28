using System.Web.Routing;
using Training.Umbraco.WebSite.UI.Extensions;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Training.Umbraco.WebSite.UI.UmbracoRouteHandlers
{
    public class AssignHomePageToRouteHandler : UmbracoVirtualNodeRouteHandler
    {
        protected override IPublishedContent FindContent(RequestContext requestContext, UmbracoContext umbracoContext)
        {
            var umbracoHelper = new UmbracoHelper(umbracoContext);
            return umbracoHelper.GetHomePage();
        }
    }
}