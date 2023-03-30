using _1.Data.Model;
using _2.API.ViewModels.GioHang;
using _2.API.ViewModels.GioHangChiTiet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static _1.Data.IRepo.IAllRepo;

namespace _2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangChiTietController : ControllerBase
    {
        private readonly IAllRepo<GioHangChiTiet> _repo;
        public GioHangChiTietController(IAllRepo<GioHangChiTiet> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllGioHangChiTiet()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có giỏ hàng chi tiết");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetGioHangChiTietById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy giỏ hàng chi tiết");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateGioHangChiTiet([FromBody] CreateGioHangChiTiet request)
        {
            GioHangChiTiet cv = new GioHangChiTiet()
            {
                Id = Guid.NewGuid(),
                IdGioHang = request.IdGioHang,
                IdSanPham = request.IdSanPham,
                GiaBan = request.GiaBan,
                SLMua = request.SLMua
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
        public async Task<IActionResult> UpdateGioHangChiTiet(Guid id, [FromBody] UpdateGioHangChiTiet request)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy giỏ hàng chi tiết");
            }
            else
            {
                result.IdGioHang = request.IdGioHang;
                result.IdSanPham = request.IdSanPham;
                result.SLMua = request.SLMua;
                result.GiaBan = request.GiaBan;
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
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy giỏ hàng chi tiết");
            }
            else
            {
                try
                {
                    await _repo.DeleteOneAsyn(result);
                    return Ok("Xóa thành công");
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Xóa thất bại");
                }


            }
        }
    }
}
