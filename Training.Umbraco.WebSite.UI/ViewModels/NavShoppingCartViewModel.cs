using System.Collections.Generic;
using Training.Umbraco.WebSite.UI.ViewModels;

namespace Training.Umbraco.WebSite.UI.ViewModels
{
    public class NavShoppingCartViewModel
    {
        public IEnumerable<ProductBasicViewModel> Products { get; set; }

        public string CartTotal { get; set; }

        public int TotalItems { get; set; }
    }
}