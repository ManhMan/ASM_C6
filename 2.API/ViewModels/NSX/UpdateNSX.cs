using System.ComponentModel.DataAnnotations;

namespace _2.API.ViewModels.NSX
{
    public class UpdateNSX
    {
        [Required(ErrorMessage = "Không được để trống")]
        public string? TenNSX { get; set; }
    }
}
