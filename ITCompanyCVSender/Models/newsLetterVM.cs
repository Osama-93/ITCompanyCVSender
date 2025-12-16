using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCompanyCVSender.Models
{
    public class newsLetterVM
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<UserVM> Users { get; set; }
    }
}