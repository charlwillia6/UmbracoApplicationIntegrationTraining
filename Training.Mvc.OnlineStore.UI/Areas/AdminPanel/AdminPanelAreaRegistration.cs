using System.Web.Mvc;

namespace Training.Mvc.OnlineStore.UI.Areas.AdminPanel
{
    public class AdminPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminPanel_default",
                "AdminPanel/{controller}/{action}",
                new
                {
                    controller = "Dashboard",
                    action = "Index"
                },
                null,
                new[] { "Training.Mvc.OnlineStore.UI.Areas.AdminPanel.Controllers" }
            );
        }
    }
}