using DataAccessTier.DataAccessModel;
using Services;
using ITCompanyCVSender.Business;
using ITCompanyCVSender.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Services.EmailSVC;
using Services.CompanySVC;
using System.Windows;
using System.Linq;

namespace ITCompanyCVSender.Controllers
{
    public class CompanyController : Controller
    {
        CompanyServices services = new CompanyServices();
        EmailSentServises sentServises = new EmailSentServises();
        EmailSender EmailSender = new EmailSender();
        EmailFinder emailFinder = new EmailFinder();
        GetCompaniesWithEmails withEmails = new GetCompaniesWithEmails();
        EmailCleaner cleaner = new EmailCleaner();
        CheckEmailStatus check = new CheckEmailStatus();
        DeactivateAccount DeactivateAccount = new DeactivateAccount();  
        public ActionResult Index()
        {
            List<Company> companies = services.Get();
            List<Company> updatedCompanies = check.CompaniesEmailStatus(companies);
            List<CompanyVM> companyVMs = AutoMapperConfig.Mapper.Map<List<CompanyVM>>(updatedCompanies);
            return View(companyVMs);
        }
        public ActionResult Details(int id)
        {
            Company company = services.Get(id);
            CompaniesEmailSentVM companyVM = AutoMapperConfig.Mapper.Map<CompaniesEmailSentVM>(company);

            List<EmailsSent> emailsSent = sentServises.GetBasedOnCompanyId(id);
            companyVM.EmaisSentVM = AutoMapperConfig.Mapper.Map<List<EmaisSentVM>>(emailsSent);

            return View(companyVM);
        }
        public ActionResult Create() 
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Create(CompanyVM companyVM)
        {
            Company company = AutoMapperConfig.Mapper.Map<Company>(companyVM);
            company.DateAdded = DateTime.Now;
            company.UpdatedDate = DateTime.Now;
            services.Add(company);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Company company = services.Get(id);
            CompanyVM companyVM = AutoMapperConfig.Mapper.Map<CompanyVM>(company);
            return View(companyVM);
        }
        [HttpPost]
        public ActionResult Edit(CompanyVM companyVM)
        {

            Company company = AutoMapperConfig.Mapper.Map<CompanyVM,Company>(companyVM);
            company.UpdatedDate = DateTime.Now;
            services.Edit(company);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Company company = services.Get(id);
            CompanyVM companyVM = AutoMapperConfig.Mapper.Map<CompanyVM>(company);
            return View(companyVM);
        }
        [HttpPost]
        public ActionResult Delete(CompanyVM companyVM)
        {
            Company company = AutoMapperConfig.Mapper.Map<Company>(companyVM);
            List<EmailsSent> emailsSents = sentServises.GetBasedOnCompanyId(companyVM.Id);
            sentServises.DeleteList(emailsSents);
            services.Delete(company);
            return RedirectToAction("Index");
        }
        public JsonResult SendEmail(int id)
        {
            var company = services.Get(id);
            if (company == null || string.IsNullOrWhiteSpace(company.Email))
                return Json(new { success = false, message = "Invalid company or missing email." });

            try
            {
                string path = Server.MapPath("~/Content/Osama_Elayan_CV.pdf");
                EmailSender.SendEmail(company, path);

                var emailSent = new EmailsSent
                {
                    Status = "Sent",
                    DateSent = DateTime.Now,
                    Response = "Not Yet",
                    CompanyId = company.Id,
                    Subject = company.Name
                };
                sentServises.Add(emailSent);
                company = DeactivateAccount.Deactivate(company);
                services.Edit(company);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Optionally log
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<JsonResult> sendToAll()
        {
            List<Company> companies = withEmails.Get();
            string absolutePath = Server.MapPath("~/Content/Osama_Elayan_CV.pdf");
            List<EmailsSent> emailsToInsert = new List<EmailsSent>();
            int sentCount = 0;
            var currentDate = DateTime.Now;
                foreach (var company in companies)
                {
                   try
                   {
                       if (!string.IsNullOrWhiteSpace(company.Email) && cleaner.IsValidEmail(company.Email))
                       {
                           await EmailSender.SendEmail(company, absolutePath);
                  
                           company.sentDate = currentDate;
                  
                           EmailsSent emailsSent = new EmailsSent
                           {
                               Status = "Sent",
                               DateSent = currentDate,
                               Response = "Not Yet",
                               CompanyId = company.Id,
                               Subject = company.Name
                           };
                           sentServises.Add(emailsSent);
                           Company newCompany = DeactivateAccount.Deactivate(company);
                           services.DisableTrakingForEditActive(newCompany);
                           sentCount++;
                       }
                   }
                   catch (Exception ex)
                   {
                  
                       return Json(new { success = false, message = $"Error sending to {company.Email}: {ex.Message}" });
                   }
                    
              }
                sentServises.AddList(emailsToInsert);
                return Json(new { success = true, message = $"{sentCount} emails sent successfully." });
        }
        public async Task<JsonResult> findMissingEmails()
        {
            try
            {
                List<Company> companies = services.GetCompaniesWithNoEmail();
                await emailFinder.FindEmailsAsync(companies);

                return Json(new { success = true, message = $"{companies.Count} companies processed for email search." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Failed: " + ex.Message });
            }
        }
    }
}