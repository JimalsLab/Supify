
using SupifyApp.Models;
using SupifyApp.ViewModelBuilders;
using SupifyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SupifyApp.Controllers
{

    public class HomeController : Controller
    {

        public SupinfydbEntities db = new SupinfydbEntities();
        public HomeModelBuilder hb = new HomeModelBuilder();

        // GET: Home
        public ActionResult Index()
        {
            IndexViewModel idx = new IndexViewModel();

            try
            {
                string cookieId = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = HttpContext.Request.Cookies[cookieId];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                int usrId = int.Parse(ticket.Name);
                Users usr = db.Users.Where(u => u.Id == usrId).First();

                return View("../Player/HomePage", hb.Build(usr));
            }
            catch (Exception e)
            {
                return View(idx);
            }

        }

        public ActionResult Login()
        {
            LoginViewModel log = new LoginViewModel();
            return View(log);
        }

        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
            }
            catch (Exception e)
            {

            }
            IndexViewModel i = new IndexViewModel();
            return View("Index", i);
        }

        public ActionResult HomePage(LoginViewModel log)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Users> usermatches = db.Users.Where(p => p.Username == log.username);
                if (usermatches.Count() != 0)
                {
                    if (usermatches.First().Password == log.password)
                    {
                        FormsAuthentication.SetAuthCookie(usermatches.First().Id.ToString(), false);

                        return View("../Player/HomePage",hb.Build(usermatches.First()));
                    }
                    else
                    {
                        ModelState.AddModelError("pass_err", "Username or Password is wrong");
                    }
                }
                else
                {
                    ModelState.AddModelError("usr_err", "Username could not be found");
                }
            }
            return View("Login",log);
        }

        public ActionResult Register()
        {
            UsersViewModel usr = new UsersViewModel();
            return View(usr);
        }

        [HttpPost]
        public ActionResult VerifyRegister(UsersViewModel usr)
        {
            IndexViewModel idx = new IndexViewModel();
            if (ModelState.IsValid)
            {
                //c de la merde votre truc 
                IEnumerable<Users> userlist = db.Users.OrderByDescending(p => p.Id);
                Users lastuser = userlist.First();

                Users dbuser = new Models.Users();
                dbuser.CreationDate = DateTime.Now;
                dbuser.Email = usr.Email;
                dbuser.Firstname = usr.Firstname;
                dbuser.Lastname = usr.Lastname;
                dbuser.Password = usr.Password;
                dbuser.Phone = usr.Phone;
                dbuser.Username = usr.Username;
                dbuser.Id = lastuser.Id +1;

                // le truc qui devrait marcher si linq marchait :
                //dbuser.Id = db.Users.Last().Id + 1; 

                db.Users.Add(dbuser);
                db.SaveChanges();

                idx.registered = "You are now registered ! login on the top-left corner";
                return View("Index",idx);
            }
            else
            {
                return View("Register",usr);
            }

        }
    }
}