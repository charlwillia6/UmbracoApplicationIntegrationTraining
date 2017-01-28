using System.Web;
using System.Web.Mvc;
using Training.Mvc.OnlineStore.UI.Extensions;
using Training.Mvc.OnlineStore.UI.Helpers;

namespace Training.Mvc.OnlineStore.UI.Models
{
    public class CarouselItem
    {
        public CarouselItem(string title, string pageUrl, string imageUrl)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            
            Title = title;
            PageUrl = urlHelper.IsValidUrl(pageUrl) ? pageUrl : "#";
            ImageUrl = !string.IsNullOrEmpty(imageUrl) ? imageUrl : MediaHelper.GetCarouselImage(-1);
        }

        public string Title { get; private set; }

        public string PageUrl { get; private set; }

        public string ImageUrl { get; private set; }
    }
}