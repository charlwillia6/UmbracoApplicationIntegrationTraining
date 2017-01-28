using System.Collections.Generic;

namespace Training.Mvc.OnlineStore.UI.Models.Interfaces
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