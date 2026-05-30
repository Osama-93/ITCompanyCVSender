using DataAccessTier.DataAccessModel;
using ITCompanyCVSender.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ITCompanyCVSender.Controllers
{
    public class LogInController : Controller
    {
        UserServices services = new UserServices();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserVM userVM)
        {
            User user = services.Get(userVM.Email);
            if (user != null)
            {
                if (services.ValidateUser(userVM.Email, userVM.PasswordHash))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    Session["UserId"] = user.Id;
                    return RedirectToAction("Index", "Home");
                }
            }
                ViewBag.Error = "Invalid email or password.";
            return View(userVM);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}