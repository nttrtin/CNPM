//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using QLNS.Models;

//namespace QLNS.Controllers
//{
//    public class LuongController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;

//        public LuongController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Luong
//        public async Task<IActionResult> Index()
//        {
//            string userName = HttpContext.User.Identity.Name;
//            var quanlynhansuDbContext = await _context.Luong.Include(l => l.ChucVu).Include(l => l.KhenThuong)
//                .Include(l => l.KhoanTru).Include(l => l.NhanVien)
//                .Include(l => l.PhuCap).Include(l => l.ThoiGianLamViec)
//                 .Where(n => n.NhanVien.TenNhanVien == userName)
//                 .ToListAsync();
//            if (quanlynhansuDbContext == null)
//            {
//                return NotFound(); // Trả về trang 404 nếu không tìm thấy thông tin của người dùng
//            }

//            return View(quanlynhansuDbContext); // Truyền thông tin của người dùng vào view
//        }

//        // GET: Luong/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Luong == null)
//            {
//                return NotFound();
//            }

//            var luong = await _context.Luong
//                .Include(l => l.ChucVu)
//                .Include(l => l.KhenThuong)
//                .Include(l => l.KhoanTru)
//                .Include(l => l.NhanVien)
//                .Include(l => l.PhuCap)
//                .Include(l => l.ThoiGianLamViec)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (luong == null)
//            {
//                return NotFound();
//            }

//            return View(luong);
//        }

//        // GET: Luong/Create
//        public IActionResult Create()
//        {
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu");
//            ViewData["KhenThuongID"] = new SelectList(_context.KhenThuong, "ID", "LyDoKhenThuong");
//            ViewData["KhoanTruID"] = new SelectList(_context.KhoanTru, "ID", "LyDoKhoanTru");
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "DiaChi");
//            ViewData["PhuCapID"] = new SelectList(_context.PhuCap, "ID", "TenPhuCap");
//            ViewData["ThoiGianLamViecID"] = new SelectList(_context.ThoiGianLamViec, "ID", "ID");
//            return View();
//        }

//        // POST: Luong/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,NhanVienID,ThangID,ThoiGianLamViecID,LuongCoBanID,TinhTrangLuong,TongThuNhap,PhuongThucThanhToan,NgayThanhToan,ChucVuID,LyDoKhoanTruID,KhoanTruID,LyDoKhenThuongID,KhenThuongID,PhuCapID")] Luong luong)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(luong);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", luong.ChucVuID);
//            ViewData["KhenThuongID"] = new SelectList(_context.KhenThuong, "ID", "LyDoKhenThuong", luong.KhenThuongID);
//            ViewData["KhoanTruID"] = new SelectList(_context.KhoanTru, "ID", "LyDoKhoanTru", luong.KhoanTruID);
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "DiaChi", luong.NhanVienID);
//            ViewData["PhuCapID"] = new SelectList(_context.PhuCap, "ID", "TenPhuCap", luong.PhuCapID);
//            ViewData["ThoiGianLamViecID"] = new SelectList(_context.ThoiGianLamViec, "ID", "ID", luong.ThoiGianLamViecID);
//            return View(luong);
//        }

//        // GET: Luong/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Luong == null)
//            {
//                return NotFound();
//            }

//            var luong = await _context.Luong.FindAsync(id);
//            if (luong == null)
//            {
//                return NotFound();
//            }
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", luong.ChucVuID);
//            ViewData["KhenThuongID"] = new SelectList(_context.KhenThuong, "ID", "LyDoKhenThuong", luong.KhenThuongID);
//            ViewData["KhoanTruID"] = new SelectList(_context.KhoanTru, "ID", "LyDoKhoanTru", luong.KhoanTruID);
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "DiaChi", luong.NhanVienID);
//            ViewData["PhuCapID"] = new SelectList(_context.PhuCap, "ID", "TenPhuCap", luong.PhuCapID);
//            ViewData["ThoiGianLamViecID"] = new SelectList(_context.ThoiGianLamViec, "ID", "ID", luong.ThoiGianLamViecID);
//            return View(luong);
//        }

//        // POST: Luong/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,NhanVienID,ThangID,ThoiGianLamViecID,LuongCoBanID,TinhTrangLuong,TongThuNhap,PhuongThucThanhToan,NgayThanhToan,ChucVuID,LyDoKhoanTruID,KhoanTruID,LyDoKhenThuongID,KhenThuongID,PhuCapID")] Luong luong)
//        {
//            if (id != luong.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(luong);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!LuongExists(luong.ID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", luong.ChucVuID);
//            ViewData["KhenThuongID"] = new SelectList(_context.KhenThuong, "ID", "LyDoKhenThuong", luong.KhenThuongID);
//            ViewData["KhoanTruID"] = new SelectList(_context.KhoanTru, "ID", "LyDoKhoanTru", luong.KhoanTruID);
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "DiaChi", luong.NhanVienID);
//            ViewData["PhuCapID"] = new SelectList(_context.PhuCap, "ID", "TenPhuCap", luong.PhuCapID);
//            ViewData["ThoiGianLamViecID"] = new SelectList(_context.ThoiGianLamViec, "ID", "ID", luong.ThoiGianLamViecID);
//            return View(luong);
//        }

//        // GET: Luong/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Luong == null)
//            {
//                return NotFound();
//            }

//            var luong = await _context.Luong
//                .Include(l => l.ChucVu)
//                .Include(l => l.KhenThuong)
//                .Include(l => l.KhoanTru)
//                .Include(l => l.NhanVien)
//                .Include(l => l.PhuCap)
//                .Include(l => l.ThoiGianLamViec)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (luong == null)
//            {
//                return NotFound();
//            }

//            return View(luong);
//        }

//        // POST: Luong/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Luong == null)
//            {
//                return Problem("Entity set 'QuanlynhansuDbContext.Luong'  is null.");
//            }
//            var luong = await _context.Luong.FindAsync(id);
//            if (luong != null)
//            {
//                _context.Luong.Remove(luong);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool LuongExists(int id)
//        {
//          return (_context.Luong?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
