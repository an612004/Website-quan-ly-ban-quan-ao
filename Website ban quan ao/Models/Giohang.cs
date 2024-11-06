using System.Linq;
using Website_ban_quan_ao.Models;

namespace Website_ban_quan_ao.Models
{
    public class GioHang
    {
        private readonly ApplicationDbcontext db = new ApplicationDbcontext();

        public int iMasp { get; set; }
        public string sTensp { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public string Size { get; set; } // Thêm thuộc tính Size
        public decimal? GiaGocSp { get; set; }// Thêm thuộc tính Giagoc
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }

        // Hàm tạo cho giỏ hàng
        public GioHang(int Masp, string size)
        {
            iMasp = Masp;
            Size = size; // Khởi tạo size từ đối số truyền vào
            Sanpham sp = db.Sanphams.Single(n => n.Masp == iMasp);
            sTensp = sp.Tensp;
            sAnhBia = sp.Anhbia;
            dDonGia = double.Parse(sp.Giatien.ToString());
            iSoLuong = 1;
        }
    }
}
