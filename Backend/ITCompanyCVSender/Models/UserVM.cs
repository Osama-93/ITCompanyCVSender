using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITCompanyCVSender.Models
{
    public class UserVM
    {
        public int Id { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(6)]
        public string PasswordHash { get; set; }
        public Nullable<int> RoleId { get; set; }

        public virtual RolesVM RolesVM { get; set; }
    }
}