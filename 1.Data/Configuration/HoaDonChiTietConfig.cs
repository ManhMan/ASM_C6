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
    public class HoaDonChiTietConfig : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.ToTable("HoaDonChiTiet");
            builder.HasKey(x => new { x.IdHoaDon, x.IdSanPham });
            builder.HasOne(x => x.HoaDon).WithMany(x => x.HoaDonChiTiets).HasForeignKey(x => x.IdHoaDon);
            builder.HasOne(x => x.SanPham).WithMany(x => x.HoaDonChiTiets).HasForeignKey(x => x.IdSanPham);
        }
    }
}
