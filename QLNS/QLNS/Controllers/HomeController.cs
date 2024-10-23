using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLNS.Models;
using System.Diagnostics;
using System.Security.Claims;
using BC = BCrypt.Net.BCrypt;
using static QLNS.Models.NguoiDung;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
namespace QLNS.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuanlynhansuDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(QuanlynhansuDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: Index
        public async Task<IActionResult> Index(string? successMessage)
        {
            // Lấy tên người đăng nhập từ HttpContext.User
            var userName = User.Identity.Name;

            // Tìm kiếm thông tin của người dùng đăng nhập trong cơ sở dữ liệu
            var nhanVien = await _context.NhanVien
                .Include(n => n.BangCap)
                .Include(n => n.ChucVu)
                .Include(n => n.ChuyenMon)
                .Include(n => n.DanToc)
                .Include(n => n.PhongBan)
                .Include(n => n.QuocTich)
                .Include(n => n.TonGiao)
                .Include(n => n.TrinhDo)
                .FirstOrDefaultAsync(n => n.TenNhanVien == userName);

            // Nếu không tìm thấy thông tin người dùng, trả về 404
            if (nhanVien == null)
            {
                return NotFound();
            }

            // Nếu tìm thấy, trả về view với thông tin người dùng
            return View(nhanVien);
        }

        // GET: Login
        [AllowAnonymous]
        public IActionResult Login(string? ReturnUrl)
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                // Kiểm tra vai trò của người dùng
                if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
                {
                    // Nếu là admin, chuyển đến trang admin
                    return LocalRedirect(ReturnUrl ?? "/Admin/Home/Index");
                }
                else if (_httpContextAccessor.HttpContext.User.IsInRole("QuanLy"))
                {
                    // Nếu là admin, chuyển đến trang admin
                    return LocalRedirect(ReturnUrl ?? "/QuanLy/Home/Index");
                }
                else
                {
                    // Nếu không phải admin, chuyển đến trang người dùng
                    return LocalRedirect(ReturnUrl ?? "/Home/Index");
                }
            }
            else
            {
                // Nếu chưa đăng nhập thì chuyển đến trang đăng nhập
                ViewBag.LienKetChuyenTrang = ReturnUrl ?? "/Home/Login";
                return View();
            }


        }
        // POST: Login
        /*[HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([Bind] DangNhap dangNhap)
        {
            if (ModelState.IsValid)
            {
                var nguoiDung = _context.NguoiDung.Where(r => r.TenDangNhap == dangNhap.TenDangNhap).SingleOrDefault();
                if (nguoiDung == null || !BC.Verify(dangNhap.MatKhau, nguoiDung.MatKhau))
                {
                    TempData["ThongBaoLoi"] = "Tài khoản không tồn tại trong hệ thống.";
                    return View(dangNhap);
                }
                else
                {
                    var claims = new List<Claim>
                    {
                    new Claim("ID", nguoiDung.ID.ToString()),
                    new Claim(ClaimTypes.Name, nguoiDung.TenDangNhap),
                    new Claim("TenDangNhap", nguoiDung.TenDangNhap),
                    new Claim(ClaimTypes.Role, nguoiDung.Quyen ? "Admin" : "User")
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = dangNhap.DuyTriDangNhap
                    };
                    // Đăng nhập hệ thống
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                    return LocalRedirect(dangNhap.LienKetChuyenTrang ?? (nguoiDung.Quyen ? "/Admin" : "/"));

                }
            }
            return View(dangNhap);
        }*/
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([Bind] DangNhap dangNhap)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tài khoản có tồn tại hay không dựa trên SDTID
                var nguoiDung = _context.NguoiDung.Where(r => r.SDTID == dangNhap.SDTID).SingleOrDefault();

                if (nguoiDung == null)
                {
                    // Nếu tài khoản không tồn tại
                    TempData["ThongBaoLoi"] = "Tài khoản không tồn tại trong hệ thống.";
                    return View(dangNhap);
                }

                // Nếu tài khoản tồn tại, kiểm tra mật khẩu
                if (!BC.Verify(dangNhap.MatKhau, nguoiDung.MatKhau))
                {
                    // Nếu mật khẩu không đúng
                    TempData["ThongBaoLoi"] = "Mật khẩu không chính xác.";
                    return View(dangNhap);
                }

                // Nếu tài khoản và mật khẩu đều đúng, thực hiện đăng nhập
                string role = nguoiDung.Quyen switch
                {
                    quyen.Admin => "Admin",
                    quyen.QuanLy => "QuanLy",
                    _ => "User"
                };

                // Tạo các claim cho người dùng, bao gồm TenDangNhap
                var claims = new List<Claim>
        {

                new Claim(ClaimTypes.Name, nguoiDung.TenDangNhap), 
           
                 new Claim("TenDangNhap", nguoiDung.TenDangNhap),
                 new Claim("ID", nguoiDung.ID.ToString()),
                 new Claim(ClaimTypes.Name, nguoiDung.SDTID), 
                 new Claim("SDTID", nguoiDung.SDTID),         
                 new Claim(ClaimTypes.Role, role)
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dangNhap.DuyTriDangNhap
                };

                // Đăng nhập vào hệ thống
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                               new ClaimsPrincipal(claimsIdentity),
                                               authProperties);

                // Điều hướng dựa trên vai trò của người dùng
                return LocalRedirect(dangNhap.LienKetChuyenTrang ??
                                     (nguoiDung.Quyen == quyen.Admin ? "/Admin" :
                                      nguoiDung.Quyen == quyen.QuanLy ? "/QuanLy" : "/"));
            }

            // Nếu ModelState không hợp lệ, trả về View cùng với dữ liệu và lỗi validation
            return View(dangNhap);
        }
        // GET: DangXuat
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home", new { Area = "" });
        }
        // GET: Forbidden
        public IActionResult Forbidden()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}