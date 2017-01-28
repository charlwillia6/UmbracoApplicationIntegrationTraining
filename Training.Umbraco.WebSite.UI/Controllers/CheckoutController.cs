using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Web.Mvc;
using Training.Umbraco.WebSite.UI.Extensions;
using Training.Umbraco.WebSite.UI.Helpers;
using Training.Umbraco.WebSite.UI.Models;
using Training.Umbraco.WebSite.UI.ViewModels;
using Umbraco.Web.PublishedCache;

namespace Training.Umbraco.WebSite.UI.Controllers
{
    public class CheckoutController : StoreSurfaceController
    {
        public ActionResult Checkout()
        {
            // get current Cart
            var cart = new CartHelper();
            var products = cart.GetCurrentShoppingCartItems<ShoppingCartProductPreviewViewModel>();

            // get current Member
            var memberEmail = "storemember@local.com";
            if (Members.IsLoggedIn())
            {
                var member = (MemberPublishedContent)Members.GetCurrentMember();
                memberEmail = member.Email;
            }

            // send an email confirmation
            SendOrderConfirmation(products, memberEmail);

            // clear Cart
            ShoppingCartContext.Current.ClearCart();
            return Redirect("/");
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

        private void SendOrderConfirmation(IEnumerable<ShoppingCartProductPreviewViewModel> products, string memberEmail)
        {
            var msg = new MailMessage();
            msg.To.Add(memberEmail);
            msg.Subject = "Your Order";
            msg.From = new MailAddress("store@local.com", "Album Store");

            var mailBody = "Thank you for ordering:" + Environment.NewLine;

            foreach(var product in products)
            {
                mailBody += string.Format("{0} {1}, {2}{3}", product.Quantity, product.Name, product.Price, Environment.NewLine);
            }

            msg.Body = mailBody;

            using (var smtp = new SmtpClient())
            {
                smtp.SetPickupDirectoryLocation();
                smtp.Send(msg);
            }
        }
    }
}
