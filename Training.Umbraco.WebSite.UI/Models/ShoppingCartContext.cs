using System.Web;
using Training.Umbraco.WebSite.UI.Models.Interfaces;

namespace Training.Umbraco.WebSite.UI.Models
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