using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace Training.Umbraco.WebSite.UI.ViewModels
{
    public class ProductViewModel : RenderModel
    {
        public ProductViewModel(IPublishedContent content) : base(content)
        {

        }
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string Summary { get; set; }
        //public string DetailsImageUrl { get; set; }
        public int Rates { get; set; }
        public string ImageUrl { get; set; }
    }
}