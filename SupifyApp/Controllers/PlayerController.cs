using SupifyApp.Models;
using SupifyApp.ViewModelBuilders;
using SupifyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JamendoApi;

namespace SupifyApp.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        public JamendoApiClient j = new JamendoApiClient("382429ae"); //no new write method needed iguess ?
        public SupinfydbEntities db = new SupinfydbEntities();

        FriendsModelBuilder fbuilder;
        // GET: Player
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomePage(HomePageViewModel h)
        {
            // tro marrant le projet
            return View(h);
        }

        public ActionResult Friends()
        {
            // pour récup le mec logged dans la session
            Users usr = getSessionUser();

            fbuilder = new FriendsModelBuilder();

            return View(fbuilder.Build(usr));
        }

        public ActionResult Music()
        {
            Users usr = getSessionUser();
            MusicModelBuilder mmb = new MusicModelBuilder();

            return View(mmb.Build(usr));
        }

        public class jsonMusicId
        {
            public int id { get; set; }
        }

        [HttpPost]
        public void Addtrack(jsonMusicId jid)
        {
            IEnumerable<Track> list = db.Track.OrderByDescending(p => p.Id);
            Track last = list.FirstOrDefault();

            Users usr = getSessionUser();
            Track m = new Track();
            m.trackid = jid.id.ToString();
            m.userid = usr.Id;
            if (last != null)
            {
                m.Id = last.Id + 1;
            }
            m.times_lstened = 0;
            m.added_date = DateTime.Now;

            if (db.Track.Where(p=>p.trackid == jid.id.ToString()).Count() == 0)
            {
                db.Track.Add(m);
                db.SaveChanges();
            }
        
        }

        public ActionResult AddPlaylist()
        {
            //TODOOOOOOOOOOOOOOOOOO
            return View();
        }

        public ActionResult AddFriends()
        {
            Users usr = getSessionUser();

            fbuilder = new FriendsModelBuilder();
            FriendsViewModel fvm = fbuilder.Build(usr);
            List<Users> usrList = db.Users.ToList();
            List<Users> friends = fvm.friendList.ToList();

            // magie noire ? STILL NOT FIXEDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD

            List<Users> canAdd = usrList.Except(friends).ToList();
            canAdd.Remove(usr);

            foreach (Users u in friends)
            {
                canAdd.Remove(u);
            }

            return View(canAdd);
        }

        //adds a friend
        public ActionResult Add(string id)
        {
            Users usr = getSessionUser();

            int friendId = int.Parse(id);

            IEnumerable<Friends> list = db.Friends.OrderByDescending(p => p.Id);
            Friends last = list.FirstOrDefault();

            Friends friend = new Friends();
            friend.FriendId = friendId;
            friend.UserId = usr.Id;
            if (last != null)
            {
               friend.Id = last.Id + 1;
            }

            db.Friends.Add(friend);
            db.SaveChanges();

            return RedirectToAction("AddFriends");
        }

        public ActionResult MyProfile()
        {

            Users usr = getSessionUser();

            UsersViewModel user = new UsersViewModel();
            user.Email = usr.Email;
            user.Firstname = usr.Firstname;
            user.Lastname = usr.Lastname;
            user.Password = usr.Password;
            user.Phone = usr.Phone;
            user.Username = usr.Username;

            return View(user);
        }

        public ActionResult ValidateEdit(UsersViewModel usr)
        {

            Users u = getSessionUser();
            int usrId = u.Id;

            var user = db.Users.Find(usrId);

            user.Email = usr.Email;
            user.Firstname = usr.Firstname;
            user.Lastname = usr.Lastname;
            user.Password = usr.Password;
            user.Phone = usr.Phone;
            user.Username = usr.Username;

            try
            {
                bool a = TryUpdateModel(user);
                //db.Entry(user).State = EntityState.Modified;    
                db.SaveChanges();

                return RedirectToAction("MyProfile");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("err", "Unable to save changes. Try again, and if the problem persists, call 911");
            }
                
            
            return RedirectToAction("MyProfile");
        }

        public Users getSessionUser()
        {

            string cookieId = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieId];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            int usrId = int.Parse(ticket.Name);

            Users usr = db.Users.Where(u => u.Id == usrId).First();
            return usr;
        }


    }
}