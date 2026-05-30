using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITCompanyCVSenderAPI.Models;
using Services;
using Services.UsersSVC;

namespace ITCompanyCVSenderAPI.Controllers
{
    public class UsersController : Controller
    {
        UserServices services = new UserServices();
        HashPassword hashPassword = new HashPassword();
        // GET: Users
        public ActionResult Index(LogInAPI logInAPI)
        {
            logInAPI.Password = hashPassword.Hash(logInAPI.Password);

            return View();
        }
    }
}