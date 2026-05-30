using DataAccessTier.DataAccessModel;
using ITCompanyCVSender.Business;
using ITCompanyCVSender.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITCompanyCVSender.Controllers
{
    public class RegestrationController : Controller
    {
        UserServices services = new UserServices();
        HashPassword hash = new HashPassword();
        // GET: Regestratio
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserVM userVM)
        {
            User validateEmail = services.Get(userVM.Email);
            if (validateEmail != null)
            {
                ModelState.AddModelError("Email", "Email is already registered.");
                return View("Index", userVM);
            }
            User user = AutoMapperConfig.Mapper.Map<User>(userVM);
            user.PasswordHash = hash.Hash(userVM.PasswordHash);
            user.RoleId = 2;
            services.Add(user);
            return RedirectToAction("Index");
        }
    }
}