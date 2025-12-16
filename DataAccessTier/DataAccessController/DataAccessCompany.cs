using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DataAccessTier.DataAccessModel;

namespace DataAccessTier.DataAccessController
{
    public class DataAccessCompany
    {
        Jordan_IT_Companies_DBEntities db = new Jordan_IT_Companies_DBEntities();
        public IQueryable<Company> Get()
        {
            return db.Companies;
        }
        public Company Get(int id)
        {
            return db.Companies.Where(c => c.Id == id).FirstOrDefault();
        }
        public void Update(Company company)
        {
            db.Companies.Attach(company);
            db.Entry(company).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Add(Company company)
        {
            db.Companies.Add(company);
            db.SaveChanges();
        }
        public void Delete(Company company)
        {
            var existing = db.Companies.Find(company.Id);
            if (existing != null)
            {
                db.Companies.Remove(existing);
                db.SaveChanges();
            }
        }
        public void UpdateEmail(Company company)
        {
            Company newCompany = new Company();
            newCompany.Id = company.Id;
            newCompany.Email = company.Email;

            db.Companies.Attach(newCompany);
            db.Entry(newCompany).Property(c => c.Email).IsModified = true;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public void UpdateActive(Company company)
        {
            Company newCompany = new Company();
            newCompany.Id = company.Id;
            newCompany.isActive = company.isActive;

            db.Companies.Attach(newCompany);
            db.Entry(newCompany).Property(c => c.isActive).IsModified = true;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public void UpdateSentDate(Company company)
        {
            Company newCompany = new Company();
            newCompany.Id = company.Id;
            newCompany.sentDate = company.sentDate;

            db.Companies.Attach(newCompany);
            db.Entry(newCompany).Property(c => c.sentDate).IsModified = true;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
