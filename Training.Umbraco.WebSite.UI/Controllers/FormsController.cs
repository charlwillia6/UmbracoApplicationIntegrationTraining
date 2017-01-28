using System.Web.Mvc;
using Training.Umbraco.WebSite.UI.ViewModels.Forms;

namespace Training.Umbraco.WebSite.UI.Controllers
{
    public class FormsController : StoreSurfaceController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUs(ContactUsFormViewModel vm)
        {
            if (ModelState.IsValid)
            {
                TempData["RequestDispatched"] = true;
            }

            return CurrentUmbracoPage();
        }
    }
}