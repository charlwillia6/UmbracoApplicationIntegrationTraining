using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using onlineStoreDb;
using Training.Mvc.OnlineStore.UI.Areas.AdminPanel.ViewModels;
using Training.Mvc.OnlineStore.UI.Helpers;
using Training.Mvc.OnlineStore.UI.Models;
using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Areas.AdminPanel.Controllers
{
    public class ProductController : AdminPanelBaseController
    {
        public ActionResult Add()
        {
            var vm = new AddOrEditProductViewModel
            {
                Categories = GetCategories()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddOrEditProductViewModel vm)
        {
            if (ModelState.IsValid && ExtraModelValidation(vm))
            {
                var product = Mapper.Map<Product>(vm);
                if (ProductService.Add(product) != 0)
                {
                    MediaHelper.SaveImages(vm, product.Id);
                    return RedirectToAction("Index", "Dashboard");
                }

                ModelState.AddModelError("", "An error occurred, product has not been created. Please contact the administrator.");
            }

            vm.Categories = GetCategories();
            return View(vm);
        }

        public ActionResult List(int page)
        {
            int totalItems;
            var products = this.ProductService.GetAll(null, out totalItems, page);

            var vm = new ListViewModel<ProductViewModel>()
            {
                List = new Pager<ProductViewModel>(Mapper.Map<IEnumerable<ProductViewModel>>(products), totalItems, page, urlFormat: "/AdminPanel/Product/List?page={0}")
            };
            return View(vm);
        }

        private IEnumerable<SelectListItem> GetCategories()
        {
            return CategoryService.GetAll()
                .Select(x => new SelectListItem() {Value = x.Id.ToString(), Text = x.Name})
                .ToList();
        }

        private bool ExtraModelValidation(AddOrEditProductViewModel vm)
        {
            var isModelValid = true;

            // validate images
            var images = new[] { vm.CarouselImage, vm.DetailsImage, vm.PreviewImage };
            if (!images.ToList().TrueForAll(IsValid))
            {
                ModelState.AddModelError("", "You can uplaod png and jpg files only.");
                isModelValid = false;
            }

            return isModelValid;
        }

        private static bool IsValid(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return true;
            }

            var allowedExtensions = new[] {".pgn", ".jpg"};
            return allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower());
        }
    }
}