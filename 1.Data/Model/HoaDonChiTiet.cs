using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.Model
{
    public class HoaDonChiTiet
    {
        public Guid IdSanPham { get; set; }
        public Guid IdHoaDon { get; set; }
        public int? SLMua { get; set; }
        public decimal? GiaBan { get; set; }
        public HoaDon? HoaDon { get; set; }
        public SanPham? SanPham { get; set; }
    }
}
