using Services;
using Services.EmailSVC;
using Services.CompanySVC;
using System;
using System.Collections.Generic;
using System.Web.Hosting;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessTier.DataAccessModel;
using System.Threading.Tasks;

namespace ITCompanyCVSenderAPI.Controllers
{
    public class SendEmailsController : ApiController
    {
        CompanyServices services = new CompanyServices();
        EmailSentServises sentServises = new EmailSentServises();
        EmailSender EmailSender = new EmailSender();
        EmailFinder emailFinder = new EmailFinder();
        GetCompaniesWithEmails withEmails = new GetCompaniesWithEmails();
        EmailCleaner cleaner = new EmailCleaner();
        CheckEmailStatus check = new CheckEmailStatus();
        DeactivateAccount DeactivateAccount = new DeactivateAccount();
        [HttpGet]
        public async Task<IHttpActionResult> sendToAll()
        {
            List<Company> companies = withEmails.Get();
            string absolutePath = HostingEnvironment.MapPath("~/Content/Osama_Elayan_CV.pdf");
            int sentCount = 0;
            var CURRENT_DATE = DateTime.Now;
            foreach (Company company in companies)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(company.Email) && cleaner.IsValidEmail(company.Email) )
                    {
                        await EmailSender.SendEmail(company, absolutePath);

                        company.sentDate = CURRENT_DATE;

                        EmailsSent emailsSent = new EmailsSent
                        {
                            Status = "Sent",
                            DateSent = CURRENT_DATE,
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
                    return Json(new { success = false, message = $"Error sending email to {company.Email}: {ex.Message}" });
                }
            }
            return Ok(new
            {
                data = sentCount, seccess = true, message = sentCount
            });
        }

        public async Task<IHttpActionResult> sendEmail(int id)
        {
            var company = services.Get(id);
            if (company == null || string.IsNullOrWhiteSpace(company.Email))
                return BadRequest();

            string absolutePath = HostingEnvironment.MapPath("~/Content/Osama_Elayan_CV.pdf");
            await EmailSender.SendEmail(company, absolutePath);

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
            return Ok(new
            {
                data = company, 
                message = "Emai sent to "+company.Name+" Seccessfully",
                success = true,
            });
        }
    }
}
