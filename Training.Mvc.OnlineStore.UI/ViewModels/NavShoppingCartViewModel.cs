using System.Collections.Generic;

namespace Training.Mvc.OnlineStore.UI.ViewModels
{
    public class NavShoppingCartViewModel : BaseViewModel
    {
        public IEnumerable<ProductBasicViewModel> Products { get; set; }

        public string CartTotal { get; set; }

        public int TotalItems { get; set; }
    }
}