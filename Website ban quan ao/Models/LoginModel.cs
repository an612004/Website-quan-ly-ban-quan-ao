using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Website_ban_quan_ao.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name = "Email")]
        public string userMail { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}