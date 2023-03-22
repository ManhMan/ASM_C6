using _1.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.Configuration
{
    public class HoaDonConfig : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");
            builder.HasKey(x => x.Id);
            builder.HasOne(p=>p.NhanVien).WithMany(p=>p.HoaDons).HasForeignKey(p=>p.IdNV);
            builder.HasOne(p=>p.KhachHang).WithMany(p=>p.HoaDons).HasForeignKey(p=>p.IdKH);
            builder.HasOne(p=>p.GiamGia).WithMany(p=>p.HoaDons).HasForeignKey(p=>p.IdMGG);
        }
    }
}
