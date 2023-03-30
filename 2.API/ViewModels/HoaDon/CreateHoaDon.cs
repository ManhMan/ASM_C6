namespace _2.API.ViewModels.HoaDon
{
    public class CreateHoaDon
    {
        public Guid? IdNV { get; set; }
        public Guid? IdKH { get; set; }
        public Guid? IdMGG { get; set; }
        public DateTime? NgayTao { get; set; }
        public decimal? TongTien { get; set; }

        public int? TrangThai { get; set; }
    }
}
