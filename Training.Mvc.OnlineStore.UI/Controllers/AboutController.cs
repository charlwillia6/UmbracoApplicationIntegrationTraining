using System.Web.Mvc;
using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Controllers
{
    public class AboutController : BaseController
    {
        public ActionResult Index()
        {
            return View(new BaseViewModel());
        }

        [ChildActionOnly]
        public ActionResult About()
        {
            var vm = new TextViewModel()
            {
                Heading = "About us",
                RichText = new MvcHtmlString("Ipsum dolor sit amet, consectetur adipiscing elit. Fusce elementum purus er.")
            };

            return PartialView("_Text", vm);
        }

        [ChildActionOnly]
        public ActionResult Help()
        {
            var vm = new TextViewModel()
            {
                Heading = "Help",
                RichText = new MvcHtmlString("Ipsum dolor sit amet, consectetur adipiscing elit. Fusce elementum purus er.")
            };

            return PartialView("_Text", vm);
        }
    }
}