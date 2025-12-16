using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier.DataAccessController
{
    public class DataAccessRoles
    {
        Jordan_IT_Companies_DBEntities db = new Jordan_IT_Companies_DBEntities();
        public IQueryable<Role> Get()
        {
            IQueryable<Role> Roles = db.Roles;
            return Roles;
        }
        public Role Get(int id)
        {
            return db.Roles.Find(id);
        }
        public void Update(Role Roles)
        {
            db.Entry(Roles).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Add(Role Roles)
        {
            db.Roles.Add(Roles);
            db.SaveChanges();
        }
        public void Delete(Role Roles)
        {
            db.Roles.Remove(Roles);
            db.SaveChanges();
        }
    }
}
