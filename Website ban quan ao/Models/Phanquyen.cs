using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_ban_quan_ao.Models
{
    public class Phanquyen
    {
        [Key]
        public int IDQuyen { get; set; }

        public string TenQuyen { get; set; }
    }
}