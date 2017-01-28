using System.Web.Mvc;
using AutoMapper;
using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Details(int id)
        {
            var product = this.ProductService.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(Mapper.Map<ProductViewModel>(product));
        }
    }
}