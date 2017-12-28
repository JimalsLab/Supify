using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupifyApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Username is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

    }
}