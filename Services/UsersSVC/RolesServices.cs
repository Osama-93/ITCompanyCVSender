using DataAccessTier.DataAccessController;
using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UsersSVC
{
    public class RolesServices
    {
        DataAccessRoles DataAccess = new DataAccessRoles();
        public List<Role> Get()
        {
            return DataAccess.Get().ToList();
        }
        public Role Get(int Id)
        {
            return DataAccess.Get(Id); 
        }
        public void Add(Role role)
        {
            DataAccess.Add(role);
        }
        public void Delete(Role role)
        {
            DataAccess.Delete(role);
        }
        public void Edit(Role role)
        {
            DataAccess.Update(role);
        }
    }
}
