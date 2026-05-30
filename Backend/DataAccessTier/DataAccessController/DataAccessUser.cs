using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier.DataAccessController
{
    public class DataAccessUser
    {
        Jordan_IT_Companies_DBEntities db = new Jordan_IT_Companies_DBEntities();
        public IQueryable<User> Get()
        {
            IQueryable<User> users = db.Users;
            return users;
        }
        public User Get(int id)
        {
            return db.Users.Find(id);
        }
        public User Get(string Email)
        {
            return db.Users.Where(u => u.Email == Email).FirstOrDefault();
        }
        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void Delete(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
