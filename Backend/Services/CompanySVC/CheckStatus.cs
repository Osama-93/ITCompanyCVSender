using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CompanySVC
{
    public class CheckStatus
    {
        public List<Company> checkCompanies(List<Company> companies)
        {
            foreach (Company company in companies)
            {
                if(company.DateAdded >= DateTime.Now.AddDays(7))
                {
                    company.isActive = true;
                }
                else
                {
                    company.isActive = false;
                }
            }
            return companies;
        }
    }
}
