using _1.Data.Model;
using _2.API.ViewModels.KhachHang;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static _1.Data.IRepo.IAllRepo;

namespace _2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {

        private readonly IAllRepo<KhachHang> _repo;
        public KhachHangController(IAllRepo<KhachHang> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllKhachHang()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có Khách hàng");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetKhachHangById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy Khách Hàng");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateKhachHang([FromBody] CreateKhachHang request)
        {
            KhachHang kh = new KhachHang()
            {
                Id = Guid.NewGuid(),
                Ten = request.Ten,
                DiaChi= request.DiaChi,
                GioiTinh = request.GioiTinh,
                TaiKhoan= request.TaiKhoan,
                MatKhau = request.MatKhau,
                NgaySinh = request.NgaySinh,
                Sdt = request.Sdt
            };
            try
            {
                var result = await _repo.AddOneAsyn(kh);
                return Ok(kh);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tạo mới thất bại");
            }

        }

        [HttpPost]
        [Route("Update/id")]
        public async Task<IActionResult> UpdateKhachHang(Guid id, [FromBody] UpdateKhachHang request)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy khách hàng");
            }
            else
            {
                result.Ten = request.Ten;
                result.NgaySinh = request.NgaySinh;
                result.Sdt = request.Sdt;
                result.DiaChi = request.DiaChi;
                result.GioiTinh= request.GioiTinh;
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy");
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
