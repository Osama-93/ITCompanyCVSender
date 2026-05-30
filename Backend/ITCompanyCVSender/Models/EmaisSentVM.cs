using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCompanyCVSender.Models
{
    public class EmaisSentVM
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Nullable<System.DateTime> DateSent { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public string Response { get; set; }

        public virtual CompanyVM CompanyVM { get; set; }
    }
}