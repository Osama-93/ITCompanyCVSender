using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessTier.DataAccessModel;
using DataAccessTier.DataAccessController;

namespace Services
{
    public class CompanyServices
    {
        DataAccessCompany dataAccess = new DataAccessCompany();
        public List<Company> Get() 
        {
            return dataAccess.Get().ToList();
        }
        public List<Company> GetEmails()
        {
            return dataAccess.Get().Where(c => !string.IsNullOrWhiteSpace(c.Email)).ToList(); 
        }
        public Company Get(int id)
        {
            return dataAccess.Get(id);
        }
        public void Add(Company company)
        {
            dataAccess.Add(company);
        }
        public void Delete(Company company)
        {
            dataAccess.Delete(company);
        }
        public void Edit(Company company)
        {
            dataAccess.Update(company);
        }
        public void EditList(List<Company> companies)
        {
            foreach (Company company in companies)
            {
                dataAccess.UpdateEmail(company);
            }
        }
        public List<Company> GetCompaniesWithNoEmail()
        {
            return dataAccess.Get().Where(c => string.IsNullOrEmpty(c.Email)).ToList();
        }
        public void DisableTrakingEdit(Company company)
        {
            dataAccess.UpdateEmail(company);
        }
        public void DisableTrakingForEditActive(Company company)
        {
            dataAccess.UpdateActive(company);
        }
        public void DisableTrakingForEditDate(Company company)
        {
            dataAccess.UpdateSentDate(company);
        }
    }
}
