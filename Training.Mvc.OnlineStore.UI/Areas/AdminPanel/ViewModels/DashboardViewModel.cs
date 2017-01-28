using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Areas.AdminPanel.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public int CategoriesCount { get; set; }

        public int ProductsCount { get; set; }
    }
}