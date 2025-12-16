using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITCompanyCVSender.Models
{
    public class CompanyVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "LinkedIn Url")]
        public string LinkedInUrl { get; set; }
        public string City { get; set; }
        [Display(Name = "Contact Form Url")]
        public string ContactFormUrl { get; set; }
        public string Status { get; set; }
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }
        [Display(Name = "Alt Email")]
        public string AltEmail { get; set; }
        [Display(Name = "Alt Number")]
        public string AltNumber { get; set; }
        [Display(Name = "Whats App")]
        public string WhatsApp { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Date Added")]
        public Nullable<System.DateTime> DateAdded { get; set; }
        [Display(Name = "Updatd Date")]
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public List<EmaisSentVM> EmaisSentVM { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string Country { get; set; }
    }
}