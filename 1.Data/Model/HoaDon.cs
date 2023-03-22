using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.Model
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public Guid? IdNV { get; set; }
        public Guid? IdKH { get; set; }
        public Guid? IdMGG { get; set; }
        public DateTime? NgayTao { get; set; }
        public decimal? TongTien { get; set; }

        public int? TrangThai { get; set; }
        public GiamGia? GiamGia { get; set; }
        public NhanVien? NhanVien { get; set; }
        public KhachHang? KhachHang { get; set; }
        public virtual ICollection<HoaDonChiTiet>? HoaDonChiTiets { get; set; }
    }
}
