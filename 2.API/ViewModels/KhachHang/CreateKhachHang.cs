using _1.Data.Model;

namespace _2.API.ViewModels.KhachHang
{
    public class CreateKhachHang
    {
        
        public string? TaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public string? Ten { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public bool? GioiTinh { get; set; }
        public string? Sdt { get; set; }
        
    }
}
