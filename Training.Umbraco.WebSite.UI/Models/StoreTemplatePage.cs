using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace Training.Umbraco.WebSite.UI.Models
{
    public class StoreTemplatePage : UmbracoTemplatePage
    {
        public Services.OnlineStore.Interfaces.IProductService ProductService { get; private set; }
        public Services.OnlineStore.Interfaces.ICategoryService CategoryService { get; private set; }

        public StoreTemplatePage() : base( )
        {
            ProductService = new Services.OnlineStore.Concretes.PetaPocoProductService("onlineStoreDb");
            CategoryService = new Services.OnlineStore.Concretes.PetaPocoCategoryService("onlineStoreDb");
        }

        public override void Execute()
        {
        }
    }
    public class StoreTemplatePage<T> : UmbracoTemplatePage<T> where T : IPublishedContent
    {
        public Services.OnlineStore.Interfaces.IProductService ProductService { get; private set; }
        public Services.OnlineStore.Interfaces.ICategoryService CategoryService { get; private set; }

        protected override void InitializePage()
        {
            base.InitializePage();
            ProductService = new Services.OnlineStore.Concretes.PetaPocoProductService("onlineStoreDb");
            CategoryService = new Services.OnlineStore.Concretes.PetaPocoCategoryService("onlineStoreDb");
        }
        public override void Execute()
        {

        }
    }
}