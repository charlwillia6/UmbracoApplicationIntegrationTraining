using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Training.Services.OnlineStore.Concretes;
using Training.Services.OnlineStore.Interfaces;
using Training.Services.OnlineStore.Models;
using Training.Umbraco.WebSite.UI.ViewModels;
using Umbraco.Web.Editors;

namespace Training.Umbraco.WebSite.UI.Controllers
{
    public class ProductPickerController : UmbracoAuthorizedJsonController
    {
        protected readonly IProductService ProductService;
        protected readonly ICategoryService CategoryService;

        public ProductPickerController()
        {
            ProductService = new PetaPocoProductService("onlineStoreDb");
            CategoryService = new PetaPocoCategoryService("onlineStoreDb");
        }

        public IEnumerable<ProductPreviewViewModel> GetAllProducts()
        {
            var products = ProductService.GetAll(new ProductSearchFilter());

            return Mapper.Map<IEnumerable<ProductPreviewViewModel>>(products);
        }

        public ProductPreviewViewModel GetProduct(int id)
        {
            var product = ProductService.GetById(id);

            return Mapper.Map<ProductPreviewViewModel>(product);
        }

    }
}
