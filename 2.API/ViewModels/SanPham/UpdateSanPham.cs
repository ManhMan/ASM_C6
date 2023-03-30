namespace _2.API.ViewModels.SanPham
{
    public class UpdateSanPham
    {
        public Guid? IdNSX { get; set; }
        public string? TenSP { get; set; }
        public DateTime? NgayNhap { get; set; }
        public int? SoLuong { get; set; }
        public decimal? GiaNhap { get; set; }
        public decimal? GiaBan { get; set; }
        public bool? TrangThai { get; set; }
        public bool? DanhMuc { get; set; }
        public string? Anh1 { get; set; }
        public string? Anh2 { get; set; }
        public string? Anh3 { get; set; }
    }
}
