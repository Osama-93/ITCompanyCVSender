using DataAccessTier.DataAccessModel;
using DataAccessTier.DataAccessController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmailSVC
{
    public class CheckEmailStatus
    {
        private readonly DataAccessCompany _dataAccess = new DataAccessCompany();

        public List<Company> CompaniesEmailStatus(List<Company> companies)
        {
            var threshold = DateTime.Now.AddDays(-20);

            foreach (var company in companies)
            {
                if ((company.isActive ?? false) == false && company.sentDate.HasValue && company.sentDate.Value <= threshold)
                {
                    company.isActive = true;
                    _dataAccess.UpdateActive(company);
                }
            }

            return companies;
        }
    }

}
