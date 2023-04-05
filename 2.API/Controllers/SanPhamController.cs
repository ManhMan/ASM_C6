using _1.Data.Model;
using _2.API.ViewModels.SanPham;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static _1.Data.IRepo.IAllRepo;

namespace _2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly IAllRepo<NSX> _NSXrepo;
        private readonly IAllRepo<SanPham> _SPrepo;
        public SanPhamController(IAllRepo<NSX> NSXrepo, IAllRepo<SanPham> SPrepo)
        {
           _NSXrepo= NSXrepo;
           _SPrepo= SPrepo;
        }
        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllSanPham()
        {
            var result = await _SPrepo.GetAllAsync();
            if (result == null) return Ok("Không có sản phẩm");
            return Ok(result);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetSanPhamById(Guid id)
        {
            var result = await _SPrepo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy sản phẩm");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateSanPham([FromBody] CreateSanPham request)
        {
            SanPham sp = new SanPham()
            {
                Id = Guid.NewGuid(),
                IdNSX = request.IdNSX,
                TenSP = request.TenSP,
                NgayNhap = DateTime.Now,
                SoLuong= request.SoLuong,
                GiaBan = request.GiaBan,
                GiaNhap = request.GiaNhap,
                TrangThai = request.TrangThai,
                DanhMuc = request.DanhMuc,
                Anh1 = request.Anh1,
                Anh2 = request.Anh2,
                Anh3 = request.Anh3,
                
            };

            try
            {
                var result = await _SPrepo.AddOneAsyn(sp);
                return Ok(sp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tạo mới không thành công");
            }

        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateSanPham(Guid id, [FromBody] UpdateSanPham request)
        {
            var result = await _SPrepo.GetByIdAsync(id);
            var idnsx = result.IdNSX;
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy");
            }
            else
            {
                result.IdNSX = request.IdNSX;
                result.TenSP= request.TenSP;
                result.NgayNhap = DateTime.Now;
                result.SoLuong= request.SoLuong;
                result.GiaBan = request.GiaBan;
                result.GiaNhap = request.GiaNhap;
                result.TrangThai= request.TrangThai;
                result.DanhMuc = request.DanhMuc;
                result.Anh1 = request.Anh1;
                result.Anh2 = request.Anh2;
                result.Anh3 = request.Anh3;
                try
                {
                    await _SPrepo.UpdateOneAsyn(result);
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
            var result = await _SPrepo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy");
            }
            else
            {
                try
                {
                    await _SPrepo.DeleteOneAsyn(result);
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
