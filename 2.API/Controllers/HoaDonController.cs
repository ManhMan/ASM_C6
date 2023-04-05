using _1.Data.Model;
using _2.API.ViewModels.HoaDon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static _1.Data.IRepo.IAllRepo;

namespace _2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {

        private readonly IAllRepo<HoaDon> _repo;
        public HoaDonController(IAllRepo<HoaDon> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllHoaDon()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có HoaDon");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetHoaDonById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy HoaDon");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateHoaDon([FromBody] CreateHoaDon request)
        {
            HoaDon cv = new HoaDon()
            {
                Id = Guid.NewGuid(),
                IdKH= request.IdKH,
                IdMGG= request.IdMGG,
                IdNV = request.IdNV,
                NgayTao= DateTime.Now,
                TongTien = request.TongTien,
                TrangThai= request.TrangThai,
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
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateHoaDon(Guid id, [FromBody] UpdateHoaDon request)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy Hóa đơn");
            }
            else
            {
                result.IdNV = request.IdNV;
                result.IdKH = request.IdKH;
                result.IdMGG= request.IdMGG;
                result.TongTien = request.TongTien;
                result.TrangThai= request.TrangThai;
                result.NgayTao = DateTime.Now;
                try
                {
                    await _repo.UpdateOneAsyn(result);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update thất bại");
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy hóa đơn");
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
