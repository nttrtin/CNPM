using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;
using QLNS.Models;
namespace QLNS.Controllers
{

    public class NguoiDungChungController : Controller
    {
        private readonly QuanlynhansuDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NguoiDungChungController(QuanlynhansuDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }
        public IActionResult Index(string? successMessage)
        {
            int maNguoiDung = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value);
            var nguoiDung = _context.NguoiDung.Where(r => r.ID == maNguoiDung).SingleOrDefault();
            if (nguoiDung == null)
            {
                return NotFound();
            }


            if (!string.IsNullOrEmpty(successMessage))
                TempData["ThongBao"] = successMessage;
            return View(new NguoiDung_ChinhSua(nguoiDung));
        }
        // GET: CapNhatHoSo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CapNhatHoSo(int id, [Bind("ID,EmailID,SDTID,DiaChiID,TenDangNhap,MatKhau,XacNhanMatKhau")] NguoiDung_ChinhSua nguoiDung)
        {
            if (id != nguoiDung.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var n = _context.NguoiDung.Find(id);
                    // Giữ nguyên mật khẩu cũ
                    if (nguoiDung.MatKhau == null)
                    {
                        n.ID = nguoiDung.ID;
                      /*  n.NhanVienID = nguoiDung.NhanVienID;*/
                        n.SDTID = nguoiDung.SDTID;
                        n.DiaChiID = nguoiDung.DiaChiID;
                        n.TenDangNhap = nguoiDung.TenDangNhap;
                        n.XacNhanMatKhau = n.MatKhau;
   
                    }
                    else // Cập nhật mật khẩu mới
                    {
                        n.ID = nguoiDung.ID;
                       /* n.NhanVienID = nguoiDung.NhanVienID;*/
                        n.SDTID = nguoiDung.SDTID;
                        n.DiaChiID = nguoiDung.DiaChiID;
                        n.TenDangNhap = nguoiDung.TenDangNhap;
                        n.MatKhau = BC.HashPassword(nguoiDung.MatKhau);
                        n.XacNhanMatKhau = BC.HashPassword(nguoiDung.MatKhau);
                  
                    }
                    _context.Update(n);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
                return RedirectToAction("Index", "NguoiDungChung", new { Area = "", successMessage = "Đã cập nhật thông tin thành công." });
            }
            return View("Index", nguoiDung);
        }
    }
}
