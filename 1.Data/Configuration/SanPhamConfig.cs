﻿using _1.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.Configuration
{
    public class SanPhamConfig : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable("SanPham");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.NSX).WithMany(x => x.SanPhams).HasForeignKey(x => x.IdNSX);

        }
    }
}
