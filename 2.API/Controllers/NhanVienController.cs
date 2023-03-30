using _1.Data.Model;
using _2.API.ViewModels.NhanVien;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static _1.Data.IRepo.IAllRepo;

namespace _2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {

        private readonly IAllRepo<NhanVien> _repo;
        public NhanVienController(IAllRepo<NhanVien> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllNhanVien()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có NhanVien");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetNhanVienById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy NhanVien");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateNhanVien([FromBody] CreateNhanVien request)
        {
            NhanVien cv = new NhanVien()
            {
                Id = Guid.NewGuid(),
                Ten = request.Ten,
                Email = request.Email,
                MatKhau = request.MatKhau,
                GioiTinh = request.GioiTinh,
                Sdt = request.Sdt,
                DiaChi = request.DiaChi,
                LinkAnh= request.LinkAnh,
                NgaySinh= request.NgaySinh,
                TrangThai = request.TrangThai
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
        public async Task<IActionResult> UpdateNhanVien(Guid id, [FromBody] UpdateNhanVien request)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy");
            }
            else
            {
                result.Ten = request.Ten;
                result.DiaChi = request.DiaChi;
                result.NgaySinh = request.NgaySinh;
                result.GioiTinh = request.GioiTinh;
                result.TrangThai= request.TrangThai;
                result.LinkAnh= request.LinkAnh;
                result.Sdt = request.Sdt;
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
