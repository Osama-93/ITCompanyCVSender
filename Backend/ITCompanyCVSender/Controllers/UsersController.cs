using AutoMapper;
using DataAccessTier.DataAccessModel;
using ITCompanyCVSender.Business;
using ITCompanyCVSender.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Services;


namespace ITCompanyCVSender.Controllers
{
    public class UsersController : Controller
    {
        UserServices services = new UserServices();
        public ActionResult Index()
        {
            List<User> users = services.Get();
            List<UserVM> userVM = AutoMapperConfig.Mapper.Map<List<UserVM>>(users);
            return View(userVM);
        }
        public ActionResult Details(int Id)
        {
            User user = services.Get(Id);
            UserVM userVM = AutoMapperConfig.Mapper.Map<UserVM>(user);
            return View(user);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserVM userVM)
        {
            User user = AutoMapperConfig.Mapper.Map<User>(userVM);
            services.Add(user);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            User user = services.Get(Id);
            UserVM userVM = AutoMapperConfig.Mapper.Map<UserVM>(user);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(UserVM userVM)
        {
            User user = AutoMapperConfig.Mapper.Map<User>(userVM);
            services.Edit(user);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            User user = services.Get(Id);
            UserVM userVM = AutoMapperConfig.Mapper.Map<UserVM>(user);
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(UserVM userVM)
        {
            User user = AutoMapperConfig.Mapper.Map<User>(userVM);
            services.Delete(user);
            return RedirectToAction("Index");
        }
    }
}