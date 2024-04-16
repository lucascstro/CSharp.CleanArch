using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.MVC.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Emails is required")]
        [EmailAddress(ErrorMessage = "Invald format email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "the {0} must be at least {2} and at max {1} characters long", MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}