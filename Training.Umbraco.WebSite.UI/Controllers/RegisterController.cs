using System.Web.Mvc;
using Training.Umbraco.WebSite.UI.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Training.Umbraco.WebSite.UI.Controllers
{
    public class RegisterController : SurfaceController
    {
        public ActionResult Register(StoreRegisterModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            var memberService = Services.MemberService;
            
            if (memberService.GetByEmail(model.Email) != null)
            {
                ModelState.AddModelError("", "A Member with that email already exists");

                return CurrentUmbracoPage();
            }

            var member = memberService.CreateMemberWithIdentity(model.Email, model.Email, model.Name, "StoreMember");

            member.SetValue("address", model.Address);
            member.SetValue("country", model.Country);

            memberService.Save(member);
            memberService.AssignRole(member.Id, "Customer");
            memberService.SavePassword(member, model.Password);
            Members.Login(model.Email, model.Password);

            return Redirect("/");
        }
    }
} 