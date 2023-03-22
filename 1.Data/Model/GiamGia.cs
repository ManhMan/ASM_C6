using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.Model
{
    public class GiamGia
    {
        public Guid Id { get; set; }
        public string? MaGiamGia { get; set; }
        public string? MoTaChiTiet { get; set; }
        public int? SoLuong { get; set; }
        public virtual ICollection<HoaDon>? HoaDons { get; set; }
    }
}
