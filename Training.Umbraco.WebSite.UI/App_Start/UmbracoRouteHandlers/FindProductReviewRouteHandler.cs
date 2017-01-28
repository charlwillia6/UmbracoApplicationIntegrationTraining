using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Training.Umbraco.WebSite.UI.Extensions;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Training.Umbraco.WebSite.UI.App_Start.UmbracoRouteHandlers
{
    public class FindProductReviewRouteHandler : UmbracoVirtualNodeRouteHandler
    {
        protected override IPublishedContent FindContent(RequestContext requestContext, UmbracoContext umbracoContext)
        {
            var productId = requestContext.RouteData.Values["id"].ToString();
            var umbracoHelper = new UmbracoHelper(umbracoContext);
            var homePage = umbracoHelper.GetHomePage();

            // look for pages with a matching productId
            var productPages = homePage.Children(f => f.HasProperty("productId") && f.HasValue("productId") && f.GetPropertyValue<string>("productId") == productId);
            var productPage = productPages.FirstOrDefault();
            
            if (productPage != null)
            {
                return productPage;
            }

            return homePage;
        }
    }
}