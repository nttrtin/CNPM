using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;
using System.Diagnostics;

namespace QLNS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly QuanlynhansuDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(QuanlynhansuDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
            try
            {
                // Lấy tổng số lượng nhân viên từ cơ sở dữ liệu
                var totalEmployees = await _context.NhanVien.CountAsync();

                // Truyền tổng số lượng nhân viên vào ViewBag hoặc ViewData
                ViewBag.TotalEmployees = totalEmployees;

                // Lấy danh sách nhân viên và trả về view
                var quanlynhansuDbContext = _context.NhanVien.Include(n => n.BangCap).Include(n => n.ChucVu).Include(n => n.ChuyenMon).Include(n => n.DanToc).Include(n => n.PhongBan).Include(n => n.QuocTich).Include(n => n.TonGiao).Include(n => n.TrinhDo);
                return View(await quanlynhansuDbContext.ToListAsync());
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                return BadRequest($"Error: {ex.Message}");
            }
        }
        public async Task<IActionResult> TongNV()
        {
            try
            {
                // Lấy tổng số lượng nhân viên từ cơ sở dữ liệu
                var totalEmployees = await _context.NhanVien.CountAsync();

                // Truyền tổng số lượng nhân viên vào ViewBag hoặc ViewData
                ViewBag.TotalEmployees = totalEmployees;

                // Trả về view để hiển thị tổng số lượng nhân viên
                return View();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}