using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Default
        public ActionResult Index()
        {
            return View(new BaseViewModel());
        }

        [ChildActionOnly]
        public ActionResult FeaturedProducts(int count = 3)
        {
            var products = ProductService.GetFeatured(count);
            var vm = Mapper.Map<IEnumerable<ProductPreviewViewModel>>(products);
            return PartialView("_FeaturedProducts", vm);
        }

        [ChildActionOnly]
        public ActionResult TopSelling(int count = 6)
        {
            var products = ProductService.GetTopSelling(count);
            var vm = Mapper.Map<IEnumerable<ProductPreviewViewModel>>(products);
            return PartialView("_HighlightProducts", vm);
        }

        [ChildActionOnly]
        public ActionResult TopRates(int count = 3)
        {
            var products = ProductService.GetTopRated(count);
            var vm = Mapper.Map<IEnumerable<ProductPreviewViewModel>>(products);
            return PartialView("_HighlightProducts", vm);
        }

      
    }
}