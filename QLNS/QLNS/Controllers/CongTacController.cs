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
//    public class CongTacController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;

//        public CongTacController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: CongTac
//        public async Task<IActionResult> Index()
//        { // Lấy tên người dùng từ HttpContext
//            string userName = HttpContext.User.Identity.Name;
//            // Lấy thông tin của người dùng hiện tại
//            var quanlynhansuDbContext = await _context.CongTac.Include(c => c.ChucVu).Include(c => c.NhanVien)
//                .Where(c => c.NhanVien.TenNhanVien == userName)
//                .ToListAsync();
//            if (quanlynhansuDbContext == null)
//            {
//                return NotFound(); // Trả về trang 404 nếu không tìm thấy thông tin của người dùng
//            }

//            return View(quanlynhansuDbContext); // Truyền thông tin của người dùng vào view
//        }
    
//        // GET: CongTac/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.CongTac == null)
//            {
//                return NotFound();
//            }

//            var congTac = await _context.CongTac
//                .Include(c => c.ChucVu)
//                .Include(c => c.NhanVien)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (congTac == null)
//            {
//                return NotFound();
//            }

//            return View(congTac);
//        }

//        // GET: CongTac/Create
//        public IActionResult Create()
//        {
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu");
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "DiaChi");
//            return View();
//        }

//        // POST: CongTac/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,MaCongTac,NhanVienID,ChucVuID,NgayBatDau,NgayKetThuc,DiaDiemCongTac,MucDich,TrangThai")] CongTac congTac)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(congTac);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", congTac.ChucVuID);
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "DiaChi", congTac.NhanVienID);
//            return View(congTac);
//        }

//        // GET: CongTac/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.CongTac == null)
//            {
//                return NotFound();
//            }

//            var congTac = await _context.CongTac.FindAsync(id);
//            if (congTac == null)
//            {
//                return NotFound();
//            }
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", congTac.ChucVuID);
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "DiaChi", congTac.NhanVienID);
//            return View(congTac);
//        }

//        // POST: CongTac/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,MaCongTac,NhanVienID,ChucVuID,NgayBatDau,NgayKetThuc,DiaDiemCongTac,MucDich,TrangThai")] CongTac congTac)
//        {
//            if (id != congTac.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(congTac);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CongTacExists(congTac.ID))
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
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", congTac.ChucVuID);
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "DiaChi", congTac.NhanVienID);
//            return View(congTac);
//        }

//        // GET: CongTac/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.CongTac == null)
//            {
//                return NotFound();
//            }

//            var congTac = await _context.CongTac
//                .Include(c => c.ChucVu)
//                .Include(c => c.NhanVien)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (congTac == null)
//            {
//                return NotFound();
//            }

//            return View(congTac);
//        }

//        // POST: CongTac/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.CongTac == null)
//            {
//                return Problem("Entity set 'QuanlynhansuDbContext.CongTac'  is null.");
//            }
//            var congTac = await _context.CongTac.FindAsync(id);
//            if (congTac != null)
//            {
//                _context.CongTac.Remove(congTac);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool CongTacExists(int id)
//        {
//          return (_context.CongTac?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
