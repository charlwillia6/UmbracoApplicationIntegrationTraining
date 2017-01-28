using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using onlineStoreDb;
using Training.Mvc.OnlineStore.UI.Areas.AdminPanel.ViewModels;
using Training.Mvc.OnlineStore.UI.Models;
using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Areas.AdminPanel.Controllers
{
    public class CategoryController : AdminPanelBaseController
    {
        public ActionResult Add()
        {
            return View(new AddOrEditCategoryViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddOrEditCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(vm);
                if (CategoryService.Add(category) != 0)
                {
                    return RedirectToAction("Index", "Dashboard");
                }

                ModelState.AddModelError("", "An error occurred, category has not been created. Please contact the administrator.");
            }

            return View(vm);
        }

        public ActionResult List(int page)
        {
            int totalItems;
            var categories = this.CategoryService.GetAll(out totalItems, page);

            var vm = new ListViewModel<CategoryViewModel>()
            {
                List =
                    new Pager<CategoryViewModel>(Mapper.Map<IEnumerable<CategoryViewModel>>(categories), totalItems,
                        page, urlFormat: "/AdminPanel/Category/List?page={0}")
            };
            return View(vm);
        }
    }
}