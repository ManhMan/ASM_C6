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
    public class GioHangChiTietConfig : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.ToTable("GioHangChiTiet");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.SanPham).WithMany(x => x.GioHangChiTiets).HasForeignKey(x => x.IdSanPham);
            builder.HasOne(x => x.GioHang).WithMany(x => x.GioHangChiTiets).HasForeignKey(x => x.IdGioHang);

        }
    }
}
