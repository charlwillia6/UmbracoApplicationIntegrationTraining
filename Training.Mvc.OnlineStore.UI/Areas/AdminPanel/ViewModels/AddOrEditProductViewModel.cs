using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.Areas.AdminPanel.ViewModels
{
    public class AddOrEditProductViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 10000000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please choose a category")]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public bool HpFeatured { get; set; }

        [Display(Name = "Carousel image (suggested size 800 x 300)")]
        public HttpPostedFileBase CarouselImage { get; set; }

        [Display(Name = "Preview image (suggested size 320 x 150)")]
        public HttpPostedFileBase PreviewImage { get; set; }

        [Display(Name = "Preview image (suggested size 500 x 500)")]
        public HttpPostedFileBase DetailsImage { get; set; }

        [Range(0, 5)]
        public int Rates { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}