namespace Training.Umbraco.WebSite.UI.Models
{
    public class CarouselItem
    {
        public CarouselItem(string title, string pageUrl, string imageUrl)
        {
            Title = title;
            PageUrl = pageUrl;
            ImageUrl = imageUrl;
        }

        public string Title { get; private set; }

        public string PageUrl { get; private set; }

        public string ImageUrl { get; private set; }
    }
}