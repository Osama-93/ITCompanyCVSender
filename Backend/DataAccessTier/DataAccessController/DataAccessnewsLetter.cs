using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier.DataAccessController
{
    public class DataAccessnewsLetter
    {
        Jordan_IT_Companies_DBEntities db = new Jordan_IT_Companies_DBEntities();
        public IQueryable<newsLetter> Get()
        {
            return db.newsLetters;
        }
        public newsLetter Get(int id)
        {
            return db.newsLetters.Find(id);
        }
        public void Add(newsLetter newsLetter)
        {
            db.newsLetters.Add(newsLetter);
            db.SaveChanges();
        }
        public void Update(newsLetter newsLetter)
        {
            db.Entry(newsLetter).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(newsLetter newsLetter)
        {
            db.newsLetters.Remove(newsLetter);
            db.SaveChanges();
        }
    }
}
