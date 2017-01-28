using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Training.Umbraco.WebSite.UI.Extensions;
using Training.Umbraco.WebSite.UI.ViewModels;
using Umbraco.Web;

namespace Training.Umbraco.WebSite.UI.Controllers
{
    public class NavigationController : StoreSurfaceController
    {
        // GET: Navigation
        [ChildActionOnly]
        public ActionResult CategoryNav(bool includeCategoryWithNoProducts = false)
        {
            var topRates = CategoryService.GetAll(!includeCategoryWithNoProducts);
            var items = Mapper.Map<IEnumerable<CategoryBasicViewModel>>(topRates);

            return PartialView("_CategoryNav", items);
        }

        [ChildActionOnly]
        public ActionResult TopNav()
        {
            var hp = Umbraco.GetHomePage();
            return PartialView("_TopNav", hp.Children.Where(x => x.GetPropertyValue<bool>("showInMainNavigation")));
        }
    }
}