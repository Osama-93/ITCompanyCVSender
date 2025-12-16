using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmailSVC
{
    public class DeactivateAccount
    {
        public Company Deactivate(Company company)
        {
            company.isActive = false;
            return company;
        }
    }
}
