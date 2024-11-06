using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_ban_quan_ao.Models;

namespace Website_ban_quan_ao.Controllers
{
    public class SanphamController : Controller
    {
        // GET: Sanpham
        ApplicationDbcontext db = new ApplicationDbcontext();

        public ActionResult Index(string searchQuery1, decimal? minPrice1, decimal? maxPrice1)
        {
            var sanphams1 = db.Sanphams.AsQueryable();

            // Áp dụng bộ lọc dựa trên các tiêu chí tìm kiếm
            if (!string.IsNullOrEmpty(searchQuery1))
            {
                sanphams1 = sanphams1.Where(sp => sp.Tensp.Contains(searchQuery1) || sp.Mota.Contains(searchQuery1));
            }
            if (minPrice1.HasValue)
            {
                sanphams1 = sanphams1.Where(sp => sp.Giatien >= minPrice1);
            }
            if (maxPrice1.HasValue)
            {
                sanphams1 = sanphams1.Where(sp => sp.Giatien <= maxPrice1);
            }

            sanphams1 = sanphams1.OrderBy(sp => sp.Masp);

            var filteredSanphams = sanphams1.ToList(); // Lấy danh sách sản phẩm đã lọc

            return View(filteredSanphams);
        }
        public ActionResult Brioni()
        {
            var nike = db.Sanphams.Where(n => n.Mahang == 1).Take(20).ToList();
            return PartialView(nike);
        }
        public ActionResult Calvin()
        {
            var adidas = db.Sanphams.Where(n => n.Mahang == 2).Take(20).ToList();
            return PartialView(adidas);
        }
        public ActionResult Gucci()
        {
            var puma = db.Sanphams.Where(n => n.Mahang == 3).Take(20).ToList();
            return PartialView(puma);
        }
        public ActionResult Owen()
        {
            var puma = db.Sanphams.Where(n => n.Mahang == 4).Take(20).ToList();
            return PartialView(puma);
        }
        public ActionResult Merriman()
        {
            var puma = db.Sanphams.Where(n => n.Mahang == 5).Take(20).ToList();
            return PartialView(puma);
        }

        public ActionResult xemchitiet(int Masp = 0)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n => n.Masp == Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }

        public ActionResult AoKhoac()
        {
            return View();
        }
        public ActionResult AoThun()
        {
            return View();
        }
        public ActionResult SoMi()
        {
            return View();
        }
        public ActionResult QuanDai()
        {
            return View();
        }
        public ActionResult QuanShort()
        {
            return View();
        }
        public ActionResult PhuKien()
        {
            return View();
        }

        //Các Hàm bên dưới là khai báo các loại sản phẩm của áo 
        public ActionResult AoKhoacNi()
        {
            var AoKhoacNi = db.Sanphams.Where(n => n.Makieudang == 1).Take(20).ToList();
            return PartialView(AoKhoacNi);
        }
        public ActionResult AoKhoacDu()
        {
            var AokhoacDu = db.Sanphams.Where(n => n.Makieudang == 2).Take(20).ToList();
            return PartialView(AokhoacDu);
        }
        public ActionResult AoThunTayNgan()
        {
            var AoThunTayNgan = db.Sanphams.Where(n => n.Makieudang == 3).Take(20).ToList();
            return PartialView(AoThunTayNgan);
        }
        public ActionResult AoThunTayDai()
        {
            var AoThunTayDai = db.Sanphams.Where(n => n.Makieudang == 4).Take(20).ToList();
            return PartialView(AoThunTayDai);
        }
        public ActionResult AoThunPoLo()
        {
            var AoThunPoLo = db.Sanphams.Where(n => n.Makieudang == 5).Take(20).ToList();
            return PartialView(AoThunPoLo);
        }
        public ActionResult AoSoMiTayNgan()
        {
            var AoSoMiTayNgan = db.Sanphams.Where(n => n.Makieudang == 6).Take(20).ToList();
            return PartialView(AoSoMiTayNgan);
        }
        public ActionResult AoSoMiTayDai()
        {
            var AoSoMiTayDai = db.Sanphams.Where(n => n.Makieudang == 7).Take(20).ToList();
            return PartialView(AoSoMiTayDai);
        }
        //Các Hàm bên dưới là khai báo các loại sản phẩm của Quần
        public ActionResult QuanKaki()
        {
            var QuanKaKi = db.Sanphams.Where(n => n.Makieudang == 8).Take(20).ToList();
            return PartialView(QuanKaKi);
        }
        public ActionResult QuanTay()
        {
            var QuanTay = db.Sanphams.Where(n => n.Makieudang == 9).Take(20).ToList();
            return PartialView(QuanTay);
        }
        public ActionResult QuanJean()
        {
            var QuanJean = db.Sanphams.Where(n => n.Makieudang == 10).Take(20).ToList();
            return PartialView(QuanJean);
        }
        public ActionResult QuanShortKaki()
        {
            var QuanShortKaki = db.Sanphams.Where(n => n.Makieudang == 11).Take(20).ToList();
            return PartialView(QuanShortKaki);
        }
        // Phụ kiện
        public ActionResult ViDa()
        {
            var ViDa = db.Sanphams.Where(n => n.Makieudang == 12).Take(20).ToList();
            return PartialView(ViDa);

        }
        public ActionResult Non()
        {
            var Non = db.Sanphams.Where(n => n.Makieudang == 13).Take(20).ToList();
            return PartialView(Non);
        }
        public ActionResult DayNit()
        {
            var DayNit = db.Sanphams.Where(n => n.Makieudang == 14).Take(20).ToList();
            return PartialView(DayNit);
        }
    }
}