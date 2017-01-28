using System.Web.Mvc;
using Training.Mvc.OnlineStore.UI.Extensions;
using Training.Services.OnlineStore.Concretes;
using Training.Services.OnlineStore.Interfaces;

namespace Training.Mvc.OnlineStore.UI.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Fields

        protected readonly IProductService ProductService;

        protected readonly ICategoryService CategoryService;

        #endregion

        #region Constructors

        protected BaseController()
        {
            ProductService = new PetaPocoProductService("onlineStoreDb");
            CategoryService = new PetaPocoCategoryService("onlineStoreDb");
        }
        
        #endregion

        #region  Shared Helpers

        protected ActionResult RedirectToOrHome(string url)
        {
            if (Url.IsValidUrl(url))
            {
                return Redirect(url);
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}