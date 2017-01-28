using System;
using System.Web.Mvc;
using Training.Mvc.OnlineStore.UI.Models;
using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Controllers
{
    public class CheckoutController : BaseController
    {
        public ActionResult Checkout()
        {
            ShoppingCartContext.Current.ClearCart();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddressAndPayment()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddressAndPayment(OrderViewModel model)
        {
            throw new NotImplementedException();
        }

        public ActionResult Complete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
