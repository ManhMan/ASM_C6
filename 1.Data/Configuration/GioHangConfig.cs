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
    public class GioHangConfig : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.ToTable("GioHang");
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.KhachHang).WithMany(p => p.GioHangs).HasForeignKey(p => p.IdKH);
        }
    }
}
