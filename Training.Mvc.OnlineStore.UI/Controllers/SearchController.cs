using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Training.Mvc.OnlineStore.UI.Models;
using Training.Mvc.OnlineStore.UI.ViewModels;
using Training.Services.OnlineStore.Models;

namespace Training.Mvc.OnlineStore.UI.Controllers
{
    public class SearchController : BaseController
    {
        // GET: Default
        public ActionResult Index(string q, int page = 1, ProductSortBy sortBy = ProductSortBy.RateHighest)
        {
            int totalItems;
            var productSearchFilter = new ProductSearchFilter() {SortBy = sortBy};
            var products = this.ProductService.Search(q, productSearchFilter, out totalItems, page);

            var vm = new ListOfProductsViewModel(productSearchFilter == null ? ProductSortBy.RateHighest : productSearchFilter.SortBy)
            {
                List = new Pager<ProductViewModel>(Mapper.Map<IEnumerable<ProductViewModel>>(products), totalItems, page, urlFormat: string.Format("/Search/Index/{0}/{{0}}", q)),
                ListTitle = q
            };

            return View("_ListOfProducts", vm);
        }
    }
}