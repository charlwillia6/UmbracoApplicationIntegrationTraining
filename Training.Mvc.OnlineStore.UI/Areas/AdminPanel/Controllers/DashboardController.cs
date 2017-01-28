using System.Linq;
using System.Web.Mvc;
using Training.Mvc.OnlineStore.UI.Areas.AdminPanel.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Areas.AdminPanel.Controllers
{
    public class DashboardController : AdminPanelBaseController
    {
        public ActionResult Index()
        {
            var vm = new DashboardViewModel
            {
                CategoriesCount = CategoryService.GetAll().Count(),
                ProductsCount = ProductService.GetAll(null).Count()
            };

            return View(vm);
        }
    }
}