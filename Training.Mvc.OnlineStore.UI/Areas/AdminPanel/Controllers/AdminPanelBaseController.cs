using System.Web.Mvc;
using Training.Mvc.OnlineStore.UI.Controllers;

namespace Training.Mvc.OnlineStore.UI.Areas.AdminPanel.Controllers
{
    [Authorize]
    public abstract class AdminPanelBaseController : BaseController
    {
    }
}