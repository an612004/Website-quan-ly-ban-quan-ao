using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website_ban_quan_ao.Models
{
    public class TinTuc
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề là bắt buộc")]
        [StringLength(200, ErrorMessage = "Tiêu đề không được vượt quá 200 ký tự")]
        public string TieuDe { get; set; }

        [Required(ErrorMessage = "Nội dung là bắt buộc")]
        public string NoiDung { get; set; }

        [Required(ErrorMessage = "Hình ảnh là bắt buộc")]
        [StringLength(300)]
        public string Anhbia { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime NgayTao { get; set; } = DateTime.Now; // Lấy thời gian hiện tại khi tạo bài viết

        [DataType(DataType.DateTime)]
        public DateTime? NgayCapNhat { get; set; } // Ngày cập nhật gần nhất, có thể null

        public bool TrangThai { get; set; } = true; // true: hiển thị, false: ẩn
    }
}
