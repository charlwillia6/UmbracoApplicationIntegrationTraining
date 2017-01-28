using System.Web;

namespace Training.Mvc.OnlineStore.UI.ViewModels
{
    public class BaseViewModel
    {
        public bool IsUserLogged
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }
    }
}