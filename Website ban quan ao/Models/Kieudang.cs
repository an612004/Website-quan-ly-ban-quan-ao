using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website_ban_quan_ao.Models;

namespace Website_ban_quan_ao.Models
{
    public class Kieudang
    {
        [Key]
        public int Makieudang { get; set; }

        public string Tenkieudang { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}