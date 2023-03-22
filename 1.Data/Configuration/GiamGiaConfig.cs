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
    public class GiamGiaConfig : IEntityTypeConfiguration<GiamGia>
    {
        public void Configure(EntityTypeBuilder<GiamGia> builder)
        {
            builder.ToTable("GiamGia");
            builder.HasKey(x => x.Id);
        }
    }
}
