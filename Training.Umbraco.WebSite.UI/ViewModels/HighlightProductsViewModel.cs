using System.Collections.Generic;

namespace Training.Umbraco.WebSite.UI.ViewModels
{
    public class HighlightProductsViewModel
    {
        public string Heading { get; set; }

        public IEnumerable<ProductPreviewViewModel> Products { get; set; }
    }
}