using SupifyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SupifyApp.Buisness
{
    public class session : Controller
    {
        public SupinfydbEntities db = new SupinfydbEntities();
        private Users usr;

        public session()
        {
            string cookieId = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieId];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            int usrId = int.Parse(ticket.Name);

            usr = db.Users.Where(u => u.Id == usrId).First();
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