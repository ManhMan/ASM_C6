using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.Request
{
    public class GioHangChiTietCreate
    {
        public Guid Id { get; set; }
        public Guid? IdSanPham { get; set; }
        public Guid? IdGioHang { get; set; }
        public int? SLMua { get; set; }
        public decimal? GiaBan { get; set; }
    }
}
