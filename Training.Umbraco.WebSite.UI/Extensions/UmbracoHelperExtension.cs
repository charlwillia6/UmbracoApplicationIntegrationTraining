using System.Linq;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Training.Umbraco.WebSite.UI.Extensions
{
    public static class UmbracoHelperExtension
    {
        public static string GetCurrentPageCropUrl(this UmbracoHelper src, string propertyAlias, string cropAlis)
        {
            if (src == null)
            {
                return string.Empty;
            }

            return src.AssignedContentItem.GetCropUrl(propertyAlias, cropAlis);
        }

        public static string GetProductDetailsUrl(this UrlHelper src, string id)
        {
            return string.Format("/product/details/{0}", id);
        }

        public static string GetLogoUrl(this UmbracoHelper src, IPublishedContent currentPage)
        {
            var mediaId = currentPage.GetPropertyValue<string>("logo", true);

            if (string.IsNullOrEmpty(mediaId))
            {
                mediaId = src.GetHomePage().GetPropertyValue<string>("logo");
            }

            return src.TypedMedia(mediaId).Url;
        }

        public static IPublishedContent GetHomePage(this UmbracoHelper src)
        {
            return src.TypedContentAtRoot().FirstOrDefault();
        }
    }
}