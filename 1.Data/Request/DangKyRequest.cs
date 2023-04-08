using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.Request
{
    public class DangKyRequest
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? TaiKhoan { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 ký tự")]
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

        public string? Sdt { get; set; }
    }
}
