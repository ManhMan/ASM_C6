using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public string? TaiKhoan { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 ký tự")]
        public string? MatKhau { get; set; }
    }
}
