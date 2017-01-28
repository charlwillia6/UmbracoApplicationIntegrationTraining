using System.Web;

namespace Training.Mvc.OnlineStore.UI.ViewModels
{
    public class TextViewModel
    {
        public string Heading { get; set; }

        public IHtmlString RichText { get; set; }
    }
}