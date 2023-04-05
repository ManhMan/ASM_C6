using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2.API.ViewModels.NhanVien
{
    public class NhanVienModel
    {
        [Required(ErrorMessage = "Không được để trống")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? MatKhau { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? Ten { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public DateTime? NgaySinh { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? DiaChi { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public bool? GioiTinh { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public bool? TrangThai { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? LinkAnh { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? Sdt { get; set; }
        [Required(ErrorMessage = "Vui lòng thêm ảnh cho nhân viên")]
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }
    }
}
