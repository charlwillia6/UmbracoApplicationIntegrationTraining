using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training.Umbraco.WebSite.UI.Models
{
    public class StoreRegisterModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

    }
}