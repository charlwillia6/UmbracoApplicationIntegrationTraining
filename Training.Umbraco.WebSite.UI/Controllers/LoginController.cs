using System.Web.Mvc;
using Training.Umbraco.WebSite.UI.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Training.Umbraco.WebSite.UI.Controllers
{
    public class LoginController : SurfaceController
    {
  

        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            if (Members.Login(model.Username, model.Password))
                return Redirect("/");

            // if Members.Login does not succeed then return to login form:
            ModelState.AddModelError("", "Invalid Login");

            return CurrentUmbracoPage();
        }

        public ActionResult Logout()
        {
            Members.Logout();

            return Redirect("/");
        }
    }
}