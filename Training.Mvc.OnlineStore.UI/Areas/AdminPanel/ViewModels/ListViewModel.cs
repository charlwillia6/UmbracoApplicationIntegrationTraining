using Training.Mvc.OnlineStore.UI.Models;
using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Areas.AdminPanel.ViewModels
{
    public class ListViewModel<T> : BaseViewModel
    {
        public Pager<T> List { get; set; }
    }
}