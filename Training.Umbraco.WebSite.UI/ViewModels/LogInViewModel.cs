using System.ComponentModel.DataAnnotations;
using Training.Umbraco.WebSite.UI.ViewModels;

namespace Training.Umbraco.WebSite.UI.ViewModels
{
    public class LogInViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}