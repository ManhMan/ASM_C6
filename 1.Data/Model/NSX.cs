using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.Model
{
    public class NSX
    {
        public Guid Id { get; set; }
        public string? TenNSX { get; set; }
        public virtual ICollection<SanPham>? SanPhams { get;set; }
    }
}
