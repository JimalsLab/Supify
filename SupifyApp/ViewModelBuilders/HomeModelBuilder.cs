using SupifyApp.Models;
using SupifyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupifyApp.ViewModelBuilders
{
    public class HomeModelBuilder
    {
        public SupinfydbEntities db = new SupinfydbEntities();
        HomePageViewModel hvm;

        public HomeModelBuilder()
        {
            hvm = new HomePageViewModel();
        }

        public HomePageViewModel Build(Users u)
        {
            hvm.user = u;
            return hvm;
        }
    }
}