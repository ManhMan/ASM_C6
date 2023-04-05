using System.ComponentModel.DataAnnotations;

namespace _2.API.ViewModels.GiamGia
{
    public class CreateGiamGia
    {
		[Required(ErrorMessage = "Không được để trống")]
		public string? MaGiamGia { get; set; }
		[Required(ErrorMessage = "Không được để trống")]
		public string? MoTaChiTiet { get; set; }
		[Required(ErrorMessage = "Không được để trống")]
		public int? SoLuong { get; set; }
    }
}
