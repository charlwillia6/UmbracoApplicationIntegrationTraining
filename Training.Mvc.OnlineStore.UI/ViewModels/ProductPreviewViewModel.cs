namespace Training.Mvc.OnlineStore.UI.ViewModels
{
    public class ProductPreviewViewModel : ProductBasicViewModel
    {
        public string Summary { get; set; }

        public int Rates { get; set; }

        public string CarouselImageUrl { get; set; }

        public string PreviewImageUrl { get; set; }
    }
}