using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Training.Mvc.OnlineStore.UI.Models;
using Training.Mvc.OnlineStore.UI.ViewModels;
using Training.Services.OnlineStore.Models;

namespace Training.Mvc.OnlineStore.UI.Controllers
{
    public class CategoryController : BaseController
    {
        public ActionResult ProductsByCategory(int id, int page, ProductSortBy sortBy = ProductSortBy.RateHighest)
        {
            int totalItems;
            var products = this.ProductService.GetAll(new ProductSearchFilter() { CategoryId = id, SortBy = sortBy }, out totalItems, page);

            var vm = new ListOfProductsViewModel()
            {
                List = new Pager<ProductViewModel>(Mapper.Map<IEnumerable<ProductViewModel>>(products), totalItems, page, urlFormat: string.Format("/category/{0}/{{0}}", id))
            };

            if (vm.List != null && vm.List.TotalItems > 0)
            {
                vm.ListTitle = CategoryService.GetById(id).Name;
            }

            return View("_ListOfProducts", vm);
        }
    }
}