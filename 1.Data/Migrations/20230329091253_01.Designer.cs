﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _1.Data.Context;

#nullable disable

namespace _1.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230329091253_01")]
    partial class _01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_1.Data.Model.GiamGia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaGiamGia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTaChiTiet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GiamGia", (string)null);
                });

            modelBuilder.Entity("_1.Data.Model.GioHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdKH")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdKH");

                    b.ToTable("GioHang", (string)null);
                });

            modelBuilder.Entity("_1.Data.Model.GioHangChiTiet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("GiaBan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("IdGioHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SLMua")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGioHang");

                    b.HasIndex("IdSanPham");

                    b.ToTable("GioHangChiTiet", (string)null);
                });

            modelBuilder.Entity("_1.Data.Model.HoaDon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdKH")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdMGG")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdNV")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdKH");

                    b.HasIndex("IdMGG");

                    b.HasIndex("IdNV");

                    b.ToTable("HoaDon", (string)null);
                });

            modelBuilder.Entity("_1.Data.Model.HoaDonChiTiet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("GiaBan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("IdHoaDon")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SLMua")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdHoaDon");

                    b.HasIndex("IdSanPham");

                    b.ToTable("HoaDonChiTiet", (string)null);
                });

            modelBuilder.Entity("_1.Data.Model.KhachHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaiKhoan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KhachHang", (string)null);
                });

            modelBuilder.Entity("_1.Data.Model.NhanVien", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("LinkAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("NhanVien", (string)null);
                });

            modelBuilder.Entity("_1.Data.Model.NSX", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenNSX")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NSX", (string)null);
                });

            modelBuilder.Entity("_1.Data.Model.SanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Anh1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Anh2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Anh3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DanhMuc")
                        .HasColumnType("bit");

                    b.Property<decimal?>("GiaBan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GiaNhap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("IdNSX")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdNSX");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("_1.Data.Model.GioHang", b =>
                {
                    b.HasOne("_1.Data.Model.KhachHang", "KhachHang")
                        .WithMany("GioHangs")
                        .HasForeignKey("IdKH");

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("_1.Data.Model.GioHangChiTiet", b =>
                {
                    b.HasOne("_1.Data.Model.GioHang", "GioHang")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("IdGioHang");

                    b.HasOne("_1.Data.Model.SanPham", "SanPham")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("IdSanPham");

                    b.Navigation("GioHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("_1.Data.Model.HoaDon", b =>
                {
                    b.HasOne("_1.Data.Model.KhachHang", "KhachHang")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdKH");

                    b.HasOne("_1.Data.Model.GiamGia", "GiamGia")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdMGG");

                    b.HasOne("_1.Data.Model.NhanVien", "NhanVien")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdNV");

                    b.Navigation("GiamGia");

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("_1.Data.Model.HoaDonChiTiet", b =>
                {
                    b.HasOne("_1.Data.Model.HoaDon", "HoaDon")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("IdHoaDon");

                    b.HasOne("_1.Data.Model.SanPham", "SanPham")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("IdSanPham");

                    b.Navigation("HoaDon");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("_1.Data.Model.SanPham", b =>
                {
                    b.HasOne("_1.Data.Model.NSX", "NSX")
                        .WithMany("SanPhams")
                        .HasForeignKey("IdNSX");

                    b.Navigation("NSX");
                });

            modelBuilder.Entity("_1.Data.Model.GiamGia", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("_1.Data.Model.GioHang", b =>
                {
                    b.Navigation("GioHangChiTiets");
                });

            modelBuilder.Entity("_1.Data.Model.HoaDon", b =>
                {
                    b.Navigation("HoaDonChiTiets");
                });

            modelBuilder.Entity("_1.Data.Model.KhachHang", b =>
                {
                    b.Navigation("GioHangs");

                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("_1.Data.Model.NhanVien", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("_1.Data.Model.NSX", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("_1.Data.Model.SanPham", b =>
                {
                    b.Navigation("GioHangChiTiets");

                    b.Navigation("HoaDonChiTiets");
                });
#pragma warning restore 612, 618
        }
    }
}