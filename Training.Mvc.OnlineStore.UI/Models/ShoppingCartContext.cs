using System.Web;
using Training.Mvc.OnlineStore.UI.Models.Interfaces;

namespace Training.Mvc.OnlineStore.UI.Models
{
    public class ShoppingCartContext
    {
        public static IShoppingCart Current {
            get
            {
                return new SessionShoppingCart(new HttpContextWrapper(HttpContext.Current));
            }
        }
    }
}