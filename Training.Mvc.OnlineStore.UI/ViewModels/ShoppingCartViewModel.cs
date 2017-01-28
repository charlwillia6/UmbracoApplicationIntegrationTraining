using Training.Mvc.OnlineStore.UI.Models;

namespace Training.Mvc.OnlineStore.UI.ViewModels
{
    public class ShoppingCartViewModel : BaseViewModel
    {
        public Pager<ShoppingCartProductPreviewViewModel> List { get; set; }
    }
}