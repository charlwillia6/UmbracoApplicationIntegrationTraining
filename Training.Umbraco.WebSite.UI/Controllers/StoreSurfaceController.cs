using Training.Services.OnlineStore.Concretes;
using Training.Services.OnlineStore.Interfaces;
using Umbraco.Web.Mvc;

namespace Training.Umbraco.WebSite.UI.Controllers
{
    public abstract class StoreSurfaceController : SurfaceController
    {
        #region Fields

        protected readonly IProductService ProductService;

        protected readonly ICategoryService CategoryService;

        #endregion

        #region Constructors

        public StoreSurfaceController()
        {
            ProductService = new PetaPocoProductService("onlineStoreDb");
            CategoryService = new PetaPocoCategoryService("onlineStoreDb");
        }
        
        #endregion
    }
}