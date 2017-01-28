using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace Training.Umbraco.WebSite.UI.ViewModels
{
    public class CategoryViewModel : RenderModel
    {
        public CategoryViewModel(IPublishedContent content) : base(content)
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ListOfProductsPreviewViewModel Products { get; set; }
    }
}