using _1.Data.IRepo;
using _1.Data.Model;
using _2.API.ViewModels.GiamGia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static _1.Data.IRepo.IAllRepo;

namespace _2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaController : ControllerBase
    {
        private readonly IAllRepo<GiamGia> _repo;
        public GiamGiaController(IAllRepo<GiamGia> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllGiamGia()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có KhachHang");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetGiamGiaById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy Mã Giảm giá");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateGiamGia([FromBody] CreateGiamGia request)
        {
            GiamGia gg = new GiamGia()
            {
                Id = Guid.NewGuid(),
                MaGiamGia= request.MaGiamGia,
                MoTaChiTiet = request.MoTaChiTiet,
                SoLuong = request.SoLuong
            };
            try
            {
                var result = await _repo.AddOneAsyn(gg);
                return Ok(gg);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tạo mới thất bại");
            }

        }

        [HttpPost]
        [Route("Update/id")]
        public async Task<IActionResult> UpdateGiamGia(Guid id, [FromBody] UpdateGiamGia request)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy Mã giảm giá");
            }
            else
            {
                result.MaGiamGia = request.MaGiamGia;
                result.MoTaChiTiet = request.MoTaChiTiet;
                result.SoLuong = request.SoLuong;
                try
                {
                    await _repo.UpdateOneAsyn(result);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Cập nhật thất bại");
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy Mã giảm giá");
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
                    return StatusCode(StatusCodes.Status500InternalServerError, "Xóa không thành công");
                }


            }
        }
    }   
}
