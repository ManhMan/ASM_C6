namespace _2.API.ViewModels.NhanVien
{
	public class ViewNhanVien
	{
		public Guid Id { get; set; }
		public string? Email { get; set; }
		public string? MatKhau { get; set; }
		public string? Ten { get; set; }
		public DateTime? NgaySinh { get; set; }
		public string? DiaChi { get; set; }
		public bool? GioiTinh { get; set; }
		public bool? TrangThai { get; set; }
		public string? LinkAnh { get; set; }
		public string? Sdt { get; set; }
	}
}
