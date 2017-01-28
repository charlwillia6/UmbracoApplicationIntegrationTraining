using System.ComponentModel.DataAnnotations;
using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Areas.AdminPanel.ViewModels
{
    public class AddOrEditCategoryViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}