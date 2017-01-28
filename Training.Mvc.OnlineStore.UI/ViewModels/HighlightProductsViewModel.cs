using System.Collections.Generic;

namespace Training.Mvc.OnlineStore.UI.ViewModels
{
    public class HighlightProductsViewModel
    {
        public string Heading { get; set; }

        public IEnumerable<ProductPreviewViewModel> Products { get; set; }
    }
}