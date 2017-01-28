using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training.Umbraco.WebSite.UI.ViewModels;

namespace Training.Umbraco.WebSite.UI.Controllers
{
    public class HomePageController : StoreSurfaceController
    {
        [ChildActionOnly]
        // GET: Featured Products
        public ActionResult FeaturedProducts(int count = 3)
        {
            var featuredProducts = ProductService.GetFeatured(count);
            var items = Mapper.Map<IEnumerable<ProductPreviewViewModel>>(featuredProducts);

            return PartialView("_FeaturedProducts", items);
        }

        [ChildActionOnly]
        // GET: Featured Products
        public ActionResult TopSelling(int count = 6)
        {
            var topSelling = ProductService.GetTopSelling(count);
            var items = Mapper.Map<IEnumerable<ProductPreviewViewModel>>(topSelling);

            items = items.OrderByDescending(x => x.Rates);
            return PartialView("_HighlightProducts", items);
        }
    }
}