using System.ComponentModel.DataAnnotations;

namespace Training.Umbraco.WebSite.UI.ViewModels.Forms
{
    public class ContactUsFormViewModel
    {
        #region Form

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Message { get; set; }

        #endregion
    }
}