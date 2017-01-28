using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using onlineStoreDb;
using Training.Mvc.OnlineStore.UI.Extensions;
using Training.Mvc.OnlineStore.UI.Models;
using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Controllers
{
    public class ShoppingCartController : BaseController
    {
        #region Methods

        public ActionResult Index(int page = 1)
        {
            var products = GetCurrentShoppingCartItems<ShoppingCartProductPreviewViewModel>();
            var list = new Pager<ShoppingCartProductPreviewViewModel>(products.Skip((page - 1) * 20).Take(20), products.Count(), page);

            return View(new ShoppingCartViewModel() { List = list });
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            return PartialView("_CartSummary", new NavShoppingCartViewModel
            {
                Products = GetCurrentShoppingCartItems<ProductBasicViewModel>(),
                CartTotal = ShoppingCartContext.Current.ShoppingTotal.ToString("N"),
                TotalItems = ShoppingCartContext.Current.NumberOfProducts
            });
        }

        public ActionResult AddToCart(int productId, int quantity, string returnUrl)
        {
            AddToCart(productId, quantity);

            if (Url.IsValidUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangeQuantity(int productId, int quantity, string returnUrl)
        {
            ShoppingCartContext.Current.ChangeQuantity(productId, quantity);
            return RedirectToOrHome(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFromCart(int productId, string returnUrl)
        {
            ShoppingCartContext.Current.RemoveItem(productId);

            if (Url.IsValidUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Helpers

        private void AddToCart(int productId, int quantity)
        {
            var product = ProductService.GetById(productId);

            if (product != null)
            {
                var cartItem = Mapper.Map<CartItem>(product);
                cartItem.Quantity = quantity;
                ShoppingCartContext.Current.AddItemToCart(cartItem);
            }
        }

        private IEnumerable<T> GetCurrentShoppingCartItems<T>()
        {
            var products = Mapper.Map<IEnumerable<T>>(GetProdutsInCart()).ToList();

            if ((typeof(T).IsAssignableFrom(typeof(ShoppingCartProductPreviewViewModel))))
            {
                products.ForEach(x =>
                {
                    var shoppingCartProductPreviewViewModel = x as ShoppingCartProductPreviewViewModel;
                    if (shoppingCartProductPreviewViewModel != null)
                    {
                        shoppingCartProductPreviewViewModel.Quantity =
                            ShoppingCartContext.Current.CartItems.Single(
                                y => y.ProductId == shoppingCartProductPreviewViewModel.Id).Quantity;
                    }

                });
            }

            return products;
        }

        private IEnumerable<Product> GetProdutsInCart()
        {
            return ShoppingCartContext.Current
                .CartItems
                .Select(x => x.ProductId)
                .Select(y => ProductService.GetById(y))
                .ToList();
        }

        #endregion
    }
}