using System.Collections.Generic;
using Training.Umbraco.WebSite.UI.Models;

namespace Training.Umbraco.WebSite.UI.Models.Interfaces
{
    public interface IShoppingCart
    {
        #region Fields

        List<CartItem> CartItems { get; }

        int NumberOfProducts { get; }

        decimal ShoppingTotal { get; }
        
        #endregion

        #region Methods

        void AddItemsToCart(IEnumerable<CartItem> cartItems);

        void AddItemToCart(CartItem cartItem);

        void RemoveItem(int productId);

        void ChangeQuantity(int productId, int quantity);

        void ClearCart();

        #endregion
    }
}