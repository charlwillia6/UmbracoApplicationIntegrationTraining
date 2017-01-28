using AutoMapper;
using onlineStoreDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Training.Services.OnlineStore.Concretes;
using Training.Services.OnlineStore.Interfaces;
using Training.Umbraco.WebSite.UI.Models;
using Training.Umbraco.WebSite.UI.ViewModels;

namespace Training.Umbraco.WebSite.UI.Helpers
{
    public class CartHelper
    {
        protected readonly IProductService ProductService;

        public CartHelper()
        {
            ProductService = new PetaPocoProductService("onlineStoreDb");
        }

        public IEnumerable<T> GetCurrentShoppingCartItems<T>()
        {
            var products = Mapper.Map<IEnumerable<T>>(GetProductsInCart()).ToList();

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

        public IEnumerable<Product> GetProductsInCart()
        {
            return ShoppingCartContext.Current
                .CartItems
                .Select(x => x.ProductId)
                .Select(y => ProductService.GetById(y))
                .ToList();
        }
    }
}