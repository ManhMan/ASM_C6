using _1.Data.Configuration;
using _1.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public virtual DbSet<GiamGia> GiamGias { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NSX> NSXs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<GioHangChiTiet> GioHangChiTiet { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GiamGiaConfig());
            modelBuilder.ApplyConfiguration(new HoaDonConfig());
            modelBuilder.ApplyConfiguration(new HoaDonChiTietConfig());
            modelBuilder.ApplyConfiguration(new KhachHangConfig());
            modelBuilder.ApplyConfiguration(new NhanVienConfig());
            modelBuilder.ApplyConfiguration(new NSXConfig());
            modelBuilder.ApplyConfiguration(new SanPhamConfig());
            modelBuilder.ApplyConfiguration(new GioHangConfig());
            modelBuilder.ApplyConfiguration(new GioHangChiTietConfig());
            
            //modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());

            //modelBuilder.Seed(); //gọi cái này để seeding data
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=DESKTOP-JNDR021\\SQLEXPRESS;Database=ASM_C6;Trusted_Connection=True;"));
        }
    }
}
