using SupifyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupifyApp.ViewModels
{
    public class FriendsViewModel
    {
        public FriendsViewModel()
        {
            Users u = new Users();

            List<Users> friendList = new List<Users>();
        }

        public Users u { get; set; }

        public IEnumerable<Users> friendList { get; set; }

    }
}