using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier.DataAccessController
{
    public class DataAccessSentEmails
    {
        Jordan_IT_Companies_DBEntities db = new Jordan_IT_Companies_DBEntities();
        public IQueryable<EmailsSent> Get()
        {
            IQueryable<EmailsSent> emailsSents = db.EmailsSents;
            return emailsSents;
        }
        public EmailsSent Get(int id)
        {
            return db.EmailsSents.Where(c => c.Id == id).FirstOrDefault();
        }
        public void Update(EmailsSent emailsSent)
        {
            db.Entry(emailsSent).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Add(EmailsSent emailsSent)
        {
            db.EmailsSents.Add(emailsSent);
            db.SaveChanges();
        }
        public void AddList(List<EmailsSent> emailsSents)
        {
            db.EmailsSents.AddRange(emailsSents);
            db.SaveChanges();
        }
        public void Delete(EmailsSent emailsSent)
        {
            db.EmailsSents.Remove(emailsSent);
            db.SaveChanges();
        }
        public void DeleteList(List<EmailsSent> emailsSent)
        {
            db.EmailsSents.RemoveRange(emailsSent);
            db.SaveChanges();
        }
    }
}
