using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website_ban_quan_ao.Models;

namespace Website_ban_quan_ao.Models
{
    public class Nguoidung
    {
        [Key]
        public int Manguoidung { get; set; }

        public string Hoten { get; set; }
        public string Email { get; set; }
        public string Dienthoai { get; set; }
        public string Matkhau { get; set; }
        public int? IDQuyen { get; set; }
        public string Diachi { get; set; }

        [ForeignKey("IDQuyen")]
        public virtual Phanquyen Phanquyen { get; set; }
    }
}