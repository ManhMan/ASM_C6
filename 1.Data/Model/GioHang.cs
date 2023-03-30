using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.Model
{
    public class GioHang
    {
        public Guid Id { get; set; }
        public Guid? IdKH { get; set; }
        public KhachHang? KhachHang { get; set; }

        public virtual ICollection<GioHangChiTiet>? GioHangChiTiets { get; set; }
    }
}
