using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCompanyCVSenderAPI.Models
{
    public class UserAPI
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Nullable<int> RoleId { get; set; }

        public virtual Role Role { get; set; }
        public List<newsLetter> newsLetters { get; set; }
    }
}