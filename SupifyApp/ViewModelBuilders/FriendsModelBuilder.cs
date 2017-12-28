using SupifyApp.Models;
using SupifyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupifyApp.ViewModelBuilders
{
    public class FriendsModelBuilder
    {
        public SupinfydbEntities db = new SupinfydbEntities();
        public FriendsViewModel fvm;

        public FriendsModelBuilder()
        {
            fvm = new FriendsViewModel();
        }

        public FriendsViewModel Build(Users usr)
        {
            fvm.u = usr;

            List<Users> friends = new List<Users>();
            IEnumerable<Friends> contacts = db.Friends.Where(c => c.UserId == usr.Id);
            if (contacts == null)
            {
                fvm.friendList = null;
            }
            else
            {
                foreach (Friends c in contacts)
                {
                    Users user = db.Users.Find(c.FriendId);
                    friends.Add(user);
                }

                fvm.friendList = friends;
            }

            return fvm;
        }
    }
}