using _1.Data.Model;
using _2.API.ViewModels.HoaDonChiTiet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static _1.Data.IRepo.IAllRepo;

namespace _2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonChiTietController : ControllerBase
    {
        private readonly IAllRepo<HoaDonChiTiet> _repo;
        public HoaDonChiTietController(IAllRepo<HoaDonChiTiet> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllHoaDonChiTiet()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có hóa đơn chi tiết");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetHoaDonChiTietById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateHoaDonChiTiet([FromBody] CreateHoaDonChiTiet request)
        {
            HoaDonChiTiet cv = new HoaDonChiTiet()
            {
                Id = Guid.NewGuid(),
                IdHoaDon = request.IdHoaDon,
                IdSanPham = request.IdSanPham,
                GiaBan = request.GiaBan,
                SLMua= request.SLMua,
            };
            try
            {
                var result = await _repo.AddOneAsyn(cv);
                return Ok(cv);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tạo mới thất bại");
            }

        }

        [HttpPost]
        [Route("Update/id")]
        public async Task<IActionResult> UpdateHoaDonChiTiet(Guid id, [FromBody] UpdateHoaDonChiTiet request)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy HoaDonChiTiet");
            }
            else
            {
                result.IdHoaDon = request.IdHoaDon;
                result.IdSanPham = request.IdSanPham;
                result.GiaBan = request.GiaBan;
                result.SLMua = request.SLMua;
                try
                {
                    await _repo.UpdateOneAsyn(result);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update không thành công");
                }
            }
        }
    }
}
