using _1.Data.Model;
using _2.API.ViewModels.GiamGia;
using _2.API.ViewModels.KhachHang;
using _2.API.ViewModels.NSX;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static _1.Data.IRepo.IAllRepo;

namespace _2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NSXController : ControllerBase
    {
        private readonly IAllRepo<NSX> _repo;
        public NSXController(IAllRepo<NSX> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllNSX()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có NSX");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetNSXById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy NSX");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateNSX([FromBody] CreateNSX request)
        {
            NSX kh = new NSX()
            {
                Id = Guid.NewGuid(),
                TenNSX = request.TenNSX,
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
        public async Task<IActionResult> UpdateNSX(Guid id, [FromBody] UpdateNSX request)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy NSX");
            }
            else
            {
                result.TenNSX = request.TenNSX;
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy NSX");
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
                    return StatusCode(StatusCodes.Status500InternalServerError, "Xóa Thất Bại");
                }


            }
        }
    }
}
