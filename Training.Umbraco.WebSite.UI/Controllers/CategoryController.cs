using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using Training.Services.OnlineStore.Models;
using Training.Umbraco.WebSite.UI.Models;
using Training.Umbraco.WebSite.UI.ViewModels;
using Umbraco.Web.Models;

namespace Training.Umbraco.WebSite.UI.Controllers
{
    public class CategoryController : StoreRenderMvcController
    {
        // GET: Category
        public ActionResult ProductsByCategory(RenderModel model, int id, int page, ProductSortBy sortBy = ProductSortBy.RateHighest)
        {
            int totalItems;

            var category = this.CategoryService.GetById(id);

            var filter = new ProductSearchFilter() { CategoryId = id, SortBy = sortBy };
            var products = this.ProductService.GetAll(filter, out totalItems, page);

            var vm = new CategoryViewModel(model.Content);
            Mapper.Map(category, vm);

            var pager = new Pager<ProductPreviewViewModel>(Mapper.Map<IEnumerable<ProductPreviewViewModel>>(products), totalItems, page, urlFormat: string.Format("/category/{0}/{{0}}", model.Content.Id));
            vm.Products = new ListOfProductsPreviewViewModel()
            {
                List = pager,
                ListTitle = model.Content.Name
            };

            return View(vm);
        }
    }
}