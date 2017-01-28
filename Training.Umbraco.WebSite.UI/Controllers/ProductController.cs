using AutoMapper;
using System.Web.Mvc;
using Training.Umbraco.WebSite.UI.ViewModels;
using Umbraco.Web.Models;

namespace Training.Umbraco.WebSite.UI.Controllers
{
    public class ProductController : StoreRenderMvcController
    {
        // GET: Product
        public ActionResult Details(RenderModel model, int id)
        {
            if (model == null || model.Content == null || id < 0)
            {
                return HttpNotFound();
            }

            var product = ProductService.GetById(id);
            var vm = new ProductViewModel(model.Content);

            Mapper.Map(product, vm);
            return View(vm);
        }
    }
}