using System.Web.Mvc;

namespace Training.Mvc.OnlineStore.UI.Extensions
{
    public static class UrlHelperExtension
    {
        public static bool IsValidUrl(this UrlHelper urlHelper, string url)
        {
            return urlHelper.IsLocalUrl(url) && url.Length > 1 && url.StartsWith("/")
            && !url.StartsWith("//") && !url.StartsWith("/\\");
        }
    }
}