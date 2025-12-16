using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CurrectEmail
    {
        public string EmailCurrection(string email)
        {
            string cleanedEmail = email.Replace("\u00A0", "").Replace(" ", "");

            return cleanedEmail;
        }
    }
}
