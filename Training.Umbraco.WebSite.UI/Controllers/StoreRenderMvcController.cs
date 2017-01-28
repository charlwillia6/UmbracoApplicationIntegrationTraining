using System.Web.Mvc;
using Training.Services.OnlineStore.Concretes;
using Training.Services.OnlineStore.Interfaces;
using Training.Umbraco.WebSite.UI.ViewModels;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Training.Umbraco.WebSite.UI.Controllers
{
    public class StoreRenderMvcController : RenderMvcController
    {
        #region Fields

        protected readonly IProductService ProductService;

        protected readonly ICategoryService CategoryService;

        #endregion

        #region Constructors

        public StoreRenderMvcController()
        {
            ProductService = new PetaPocoProductService("onlineStoreDb");
            CategoryService = new PetaPocoCategoryService("onlineStoreDb");
        }
        
        #endregion
        
    }
}