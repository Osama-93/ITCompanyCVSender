using AutoMapper;
using DataAccessTier.DataAccessModel;
using ITCompanyCVSenderAPI.Business;
using ITCompanyCVSenderAPI.Models;
using Services;
using Services.EmailSVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace ITCompanyCVSenderAPI.Controllers
{

    [RoutePrefix("api/companies")]
    public class CompaniesController : ApiController
    {
        CompanyServices services = new CompanyServices();
        EmailSentServises sentServises = new EmailSentServises();
        EmailSender EmailSender = new EmailSender();
        EmailFinder emailFinder = new EmailFinder();
        GetCompaniesWithEmails withEmails = new GetCompaniesWithEmails();
        EmailCleaner cleaner = new EmailCleaner();
        CheckEmailStatus check = new CheckEmailStatus();
        DeactivateAccount DeactivateAccount = new DeactivateAccount();

        [System.Web.Http.Authorize]
        public IHttpActionResult GetCompanies()
        {
            List<Company> companies = services.Get();
            List<Company> updatedCompanies = check.CompaniesEmailStatus(companies);
            if (AutoMapperConfig.Mapper == null)
                return InternalServerError(
                    new Exception("Mapper is NULL")
                    );
            List<CompanyAPI> companyAPIs = AutoMapperConfig.Mapper.Map<List<Company>, List<CompanyAPI>>(updatedCompanies);
            return Ok(companyAPIs);
        }
        [System.Web.Http.Authorize]
        public IHttpActionResult GetCompany(int id)
        {
            Company company = services.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            CompanyAPI companyAPI = AutoMapperConfig.Mapper.Map<Company, CompanyAPI>(company);
            List<EmailsSent> emailsSent = sentServises.GetBasedOnCompanyId(id);
            companyAPI.EmaisSentAPI = AutoMapperConfig.Mapper.Map<List<EmailsSent>, List<EmailsSentAPI>>(emailsSent);
            return Ok(companyAPI);
        }
        [System.Web.Http.Authorize]
        public IHttpActionResult CreateCompany(CompanyAPI companyAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Company company = AutoMapperConfig.Mapper.Map<CompanyAPI, Company>(companyAPI);

            company.DateAdded = DateTime.Now;
            company.UpdatedDate = DateTime.Now;

            services.Add(company);

            return CreatedAtRoute("DefaultApi", new { id = company.Id }, company);
        }
        [HttpPut]
        [System.Web.Http.Authorize]
        public IHttpActionResult EditCompany(int id, CompanyAPI companyAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Company company = services.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            company = AutoMapperConfig.Mapper.Map(companyAPI, company);
            company.Id = id;
            company.UpdatedDate = DateTime.Now;
            services.Edit(company);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [System.Web.Http.Authorize]
        public IHttpActionResult DeleteCompany(int id)
        {
            Company company = services.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            services.Delete(company);
            return StatusCode(HttpStatusCode.NoContent);
        }
     }
}
