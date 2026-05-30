using Services.EmailSVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITCompanyCVSender.Controllers
{
    public class newsLetterController : Controller
    {
        newsLetterServices services = new newsLetterServices();
        // GET: newsLetter
        public ActionResult Index()
        {
            return View();
        }
    }
}