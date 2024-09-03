using CipherStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CipherStudio.CipherDbContext;
using System.Web.Security;

namespace CipherStudio.Controllers
{
    
    public class AccountController : Controller
    {
        AppDbContext context = new AppDbContext();
        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            context.users.Add(user);
            context.SaveChanges();
            return RedirectToAction("login");
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(User user)
        {
            bool isvalid = context.users.Any(m=>m.Name == user.Name && m.Passoword==user.Passoword);
            if (isvalid)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                return RedirectToAction("Index", "Student");
            }   
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
    }
}