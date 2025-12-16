using DataAccessTier.DataAccessController;
using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GetCompaniesWithEmails
    {
        DataAccessCompany dataAccess = new DataAccessCompany();
        public List<Company> Get()
        {
            List<Company> companies = dataAccess.Get()
                .Where(c => c.Email != null && c.ContactName != string.Empty && c.isActive == true || c.isActive == null).ToList();
            return companies;
        }
    }
}
