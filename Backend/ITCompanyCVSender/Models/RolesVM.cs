using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCompanyCVSender.Models
{
    public class RolesVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserVM> Users { get; set; }
    }
}