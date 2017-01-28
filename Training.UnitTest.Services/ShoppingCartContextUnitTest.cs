using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Mvc.OnlineStore.UI.Models;

namespace Training.UnitTest.Services
{
    [TestClass]
    public class ShoppingCartContextUnitTest : BaseUnitTest
    {
        private SessionShoppingCart SessionShoppingCart { get; set; }

        public ShoppingCartContextUnitTest()
        {
            SessionShoppingCart = new SessionShoppingCart(Context.Object);
        }

        [TestMethod]
        public void When_Add_Item_To_Cart_Cart_Gets_Updated()
        {
            // arrange
            var cartItem = new CartItem() {Quantity = 3, ProductId = 111, Price = 10};

            // act
            SessionShoppingCart.AddItemToCart(cartItem);

            // assert
            Assert.AreEqual(SessionShoppingCart.CartItems.Count, 1);
        }

        [TestMethod]
        public void When_Add_Multiple_Times_A_Cart_Item_Cart_Quantity_Gets_Updated()
        {
            // arrange
            var cartItem = new CartItem() { Quantity = 3, ProductId = 111, Price = 10 };

            // act
            SessionShoppingCart.AddItemToCart(cartItem);
            SessionShoppingCart.AddItemToCart(cartItem);

            // assert
            Assert.AreEqual(SessionShoppingCart.CartItems.Count, 1);
            Assert.AreEqual(SessionShoppingCart.CartItems.First().Quantity, 6);
        }

        [TestMethod]
        public void When_Multiple_Actions_Are_Done_Against_Cart_It_Gets_Updated()
        {
            // arrange
            var cartItem1 = new CartItem() { Quantity = 1, ProductId = 1, Price = 10 };
            var cartItem2 = new CartItem() { Quantity = 2, ProductId = 2, Price = 20 };
            var cartItem3 = new CartItem() { Quantity = 3, ProductId = 3, Price = 5 };
            SessionShoppingCart.AddItemsToCart(new []{cartItem1, cartItem2, cartItem3});
            
            // act
            SessionShoppingCart.ChangeQuantity(1, 5);
            SessionShoppingCart.RemoveItem(2);
            var cartItem4 = new CartItem() { Quantity = 4, ProductId = 4, Price = 2 };
            SessionShoppingCart.AddItemToCart(cartItem4);
            
            // assert
            Assert.AreEqual(SessionShoppingCart.CartItems.Count, 3);
            Assert.AreEqual(SessionShoppingCart.CartItems.First(x => x.ProductId == 1).Quantity, 5);
            Assert.AreEqual(SessionShoppingCart.CartItems.Sum(x => x.Quantity), 12);
        }

        [TestMethod]
        public void When_Cart_Is_Clear_It_Gets_Updated()
        {
            // arrange
            var cartItem1 = new CartItem() { Quantity = 1, ProductId = 1, Price = 10 };
            var cartItem2 = new CartItem() { Quantity = 2, ProductId = 2, Price = 20 };
            var cartItem3 = new CartItem() { Quantity = 3, ProductId = 3, Price = 5 };
            SessionShoppingCart.AddItemsToCart(new[] { cartItem1, cartItem2, cartItem3 });

            // act
            SessionShoppingCart.ClearCart();

            // assert
            Assert.AreEqual(SessionShoppingCart.CartItems.Count, 0);
        }
    }
}
