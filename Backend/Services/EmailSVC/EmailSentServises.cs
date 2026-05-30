using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessTier.DataAccessController;
using DataAccessTier.DataAccessModel;

namespace Services
{
    public class EmailSentServises
    {
        DataAccessSentEmails dataAccess = new DataAccessSentEmails();
        public List<EmailsSent> Get()
        {
            return dataAccess.Get().ToList();
        }
        public EmailsSent Get(int id)
        {
            return dataAccess.Get(id);
        }
        public List<EmailsSent> GetBasedOnCompanyId(int companyId)
        {
           return dataAccess.Get().ToList().FindAll(c  => c.CompanyId == companyId);
        }
        public void Add(EmailsSent emailsSent)
        {
            dataAccess.Add(emailsSent);
        }
        public void AddList(List<EmailsSent> emailsSents)
        {
            dataAccess.AddList(emailsSents);
        }
        public void Edit(EmailsSent email)
        {
            dataAccess.Update(email);
        }
        public void Delete(EmailsSent emailsSent)
        {
            dataAccess.Delete(emailsSent);
        }
        public void DeleteList(List<EmailsSent> emailsSents)
        {
            dataAccess.DeleteList(emailsSents);
        }
    }
}
