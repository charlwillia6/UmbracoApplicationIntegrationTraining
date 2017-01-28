using System.Collections.Generic;
using System.Linq;
using System.Web;
using Training.Mvc.OnlineStore.UI.Models.Interfaces;

namespace Training.Mvc.OnlineStore.UI.Models
{
    public class SessionShoppingCart : IShoppingCart
    {
        #region Fields

        public List<CartItem> CartItems
        {
            get { return GetProductsInCart(); }
            private set { SetProductsInCart(value); }
        }

        public int NumberOfProducts
        {
            get { return this.CartItems.Select(x => x.ProductId).Count(); }
        }

        public decimal ShoppingTotal
        {
            get { return this.CartItems.Sum(x => x.Price*x.Quantity); }
        }

        private HttpSessionStateBase Session
        {
            get { return this.HttpContext.Session; }
        }

        private HttpContextBase HttpContext { get; set; }

        private const string CartSessionKey = "CartId";
        
        #endregion

        #region Constructors

        public SessionShoppingCart(HttpContextBase httpContext)
        {
            HttpContext = httpContext;
        }

        #endregion

        #region Methods

        public void AddItemsToCart(IEnumerable<CartItem> cartItems)
        {
            var currentItems = GetProductsInCart();

            foreach (var cartItem in cartItems)
            {
                var itemAlreadyInCart = currentItems.SingleOrDefault(x => x.ProductId == cartItem.ProductId);

                if (itemAlreadyInCart == null)
                {
                    currentItems.Add(cartItem);
                }
                else
                {
                    itemAlreadyInCart.Quantity += cartItem.Quantity;
                }
            }

            CartItems = currentItems;
        }

        public void AddItemToCart(CartItem cartItem)
        {
            AddItemsToCart(new[] { cartItem });
        }

        public void RemoveItem(int productId)
        {
            var currentItems = GetProductsInCart();

            var itemToRemove = currentItems.SingleOrDefault(x => x.ProductId == productId);

            if (itemToRemove != null)
            {
                currentItems.Remove(itemToRemove);
                CartItems = currentItems;
            }
        }

        public void ChangeQuantity(int productId, int quantity)
        {
            var currentItems = GetProductsInCart();

            var itemToUpdate = currentItems.SingleOrDefault(x => x.ProductId == productId);

            if (itemToUpdate != null)
            {
                itemToUpdate.Quantity = quantity;
                CartItems = currentItems;
            }
        }

        public void ClearCart()
        {
            CartItems = null;
        }

        #endregion

        #region Session Helpers

        private List<CartItem> GetProductsInCart()
        {
            if (Session[CartSessionKey] == null)
            {
                return new List<CartItem>();
            }

            return (List<CartItem>)Session[CartSessionKey];
        }

        private void SetProductsInCart(List<CartItem> value)
        {
            Session[CartSessionKey] = value;
        }

        #endregion
    }
}