using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupifyApp.ViewModels
{
    public class UsersViewModel
    {
        [Required(ErrorMessage = "Le nom d'utilisateur est requis")]
        [MaxLength(20, ErrorMessage = "20 caractères maximum")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Le mail est requis")]
        public string Email { get; set; }
    }
}