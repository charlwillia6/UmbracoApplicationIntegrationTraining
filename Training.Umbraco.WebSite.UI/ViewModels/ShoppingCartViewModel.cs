using Training.Umbraco.WebSite.UI.Models;

namespace Training.Umbraco.WebSite.UI.ViewModels
{
    public class ShoppingCartViewModel
    {
        public Pager<ShoppingCartProductPreviewViewModel> List { get; set; }
    }
}