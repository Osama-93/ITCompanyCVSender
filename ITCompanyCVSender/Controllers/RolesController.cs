using DataAccessTier.DataAccessModel;
using ITCompanyCVSender.Business;
using ITCompanyCVSender.Models;
using Services;
using Services.UsersSVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using System.Web.Security;

namespace ITCompanyCVSender.Controllers
{
    public class RolesController : Controller
    {
        RolesServices services = new RolesServices();
        public ActionResult Index()
        {
            List<Role> roles = services.Get();
            List<RolesVM> rolesVM = AutoMapperConfig.Mapper.Map<List<RolesVM>>(roles);
            return View(rolesVM);
        }
        public ActionResult Details(int Id)
        {
            Role role = services.Get(Id);
            RolesVM rolesVM = AutoMapperConfig.Mapper.Map<RolesVM>(role);
            return View(rolesVM);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RolesVM rolesVM)
        {
            Role role = AutoMapperConfig.Mapper.Map<Role>(rolesVM);
            services.Add(role);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            Role role = services.Get(Id);
            RolesVM rolesVM = AutoMapperConfig.Mapper.Map<RolesVM>(role);
            return View(rolesVM);
        }
        [HttpPost]
        public ActionResult Edit(RolesVM rolesVM)
        {
            Role role = AutoMapperConfig.Mapper.Map<Role>(rolesVM);
            services.Edit(role);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            Role role = services.Get(Id);
            RolesVM rolesVM = AutoMapperConfig.Mapper.Map<RolesVM>(role);
            return View(rolesVM);
        }
        [HttpPost]
        public ActionResult Delete(Role rolesVM)
        {
            Role role = AutoMapperConfig.Mapper.Map<Role>(rolesVM);
            services.Delete(role);
            return RedirectToAction("Index");
        }
    }
}