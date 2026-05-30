using BCrypt.Net;
using DataAccessTier.DataAccessController;
using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices
    {
        DataAccessUser dataAccess = new DataAccessUser();
        public List<User> Get()
        {
            return dataAccess.Get().ToList();
        }
        public User Get(int Id)
        {
            return dataAccess.Get(Id); 
        }
        public User Get(string email)
        {
            return dataAccess.Get().Where(u => u.Email == email).FirstOrDefault();
        }
        public void Edit(User user)
        {
            dataAccess.Update(user);    
        }
        public void Add(User user)
        {
            dataAccess.Add(user);
        }
        public void Delete(User user)
        {
            dataAccess.Delete(user);
        }
        public bool ValidateUser(string email, string password)
        {
            var user = dataAccess.Get(email);
            if (user == null)
                return false;
            bool result = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            return result;
        }
        public User GetUserIfValid(string email, string password) 
        {
            var user = dataAccess.Get(email);
            if(user == null)
                return null;

            return BCrypt.Net.BCrypt.Verify(password,user.PasswordHash)? user : null;
        }
    }
}
