using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCompanyCVSender.Models
{
    public class CompaniesEmailSentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedInUrl { get; set; }
        public string City { get; set; }
        public string ContactFormUrl { get; set; }
        public string Status { get; set; }
        public string ContactName { get; set; }
        public string AltEmail { get; set; }
        public string AltNumber { get; set; }
        public string WhatsApp { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public List<EmaisSentVM> EmaisSentVM { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}