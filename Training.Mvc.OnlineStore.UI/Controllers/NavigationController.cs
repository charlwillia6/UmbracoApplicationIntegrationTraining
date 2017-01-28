using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Controllers
{
    public class NavigationController : BaseController
    {
        // GET: Navigation
        [ChildActionOnly]
        public ActionResult CategoryNav(bool includeCategoryWithNoProducts = false)
        {
            var allCategories = CategoryService.GetAll();
            IEnumerable<CategoryViewModel> vm;

            if (includeCategoryWithNoProducts)
            {
                vm = Mapper.Map<IEnumerable<CategoryViewModel>>(allCategories);
            }
            else
            {
                var categoryIdsWithProducts = this.ProductService.GetAll(null).Select(x => x.Category).Distinct();
                vm = Mapper.Map<IEnumerable<CategoryViewModel>>(allCategories.Where(x => categoryIdsWithProducts.Contains(x.Id)));
            }

            return PartialView("_CategoryNav", vm);
        }

        


    }
}