using System.ComponentModel.DataAnnotations;

namespace _2.API.ViewModels.KhachHang
{
    public class UpdateKhachHang
    {
        [Required(ErrorMessage = "Không được để trống")]
        public string? Ten { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public DateTime? NgaySinh { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? DiaChi { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public bool? GioiTinh { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? Sdt { get; set; }
    }
}
