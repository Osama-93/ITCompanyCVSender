using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCompanyCVSenderAPI.Models
{
    public class EmailsSentAPI
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Nullable<System.DateTime> DateSent { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public string Response { get; set; }

        public virtual CompanyAPI CompanyVM { get; set; }
    }
}