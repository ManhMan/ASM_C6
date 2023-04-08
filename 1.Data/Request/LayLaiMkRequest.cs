using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.Request
{
    public class LayLaiMkRequest
    {
        [Required(ErrorMessage = "Không được để trống")]
        public string? TaiKhoan { get; set; }

        [Required(ErrorMessage = "Không được để trống")]

        public string? SDT { get; set; }
    }
}
