using SupifyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupifyApp.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Users user = new Users();
        }

        public string registered { get; set; }

        public Users user { get; set; }

    }
}