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
//    public class HopDongController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;

//        public HopDongController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: HopDong
//        public async Task<IActionResult> Index()
//        {
//            string userName = HttpContext.User.Identity.Name;
//            var quanlynhansuDbContext = await _context.HopDong.Include(h => h.NhanVien).Where(n => n.NhanVien.TenNhanVien == userName)
//                                         .ToListAsync();
//            if (quanlynhansuDbContext == null)
//            {
//                return NotFound(); // Trả về trang 404 nếu không tìm thấy thông tin của người dùng
//            }

//            return View(quanlynhansuDbContext); // Truyền thông tin của người dùng vào view
//        }
    
//    public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.HopDong == null)
//            {
//                return NotFound();
//            }

//            var hopDong = await _context.HopDong
//                .Include(h => h.NhanVien)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (hopDong == null)
//            {
//                return NotFound();
//            }

//            return View(hopDong);
//        }

//        // GET: HopDong/Create
//        public IActionResult Create()
//        {
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "CanCuocCongDan");
//            return View();
//        }

//        // POST: HopDong/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,MaHopDong,TenHopDong,NgayBatDau,NgayKetThuc,NoiDung,NgayKy,NhanVienID")] HopDong hopDong)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(hopDong);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "CanCuocCongDan", hopDong.NhanVienID);
//            return View(hopDong);
//        }

//        // GET: HopDong/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.HopDong == null)
//            {
//                return NotFound();
//            }

//            var hopDong = await _context.HopDong.FindAsync(id);
//            if (hopDong == null)
//            {
//                return NotFound();
//            }
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "CanCuocCongDan", hopDong.NhanVienID);
//            return View(hopDong);
//        }

//        // POST: HopDong/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,MaHopDong,TenHopDong,NgayBatDau,NgayKetThuc,NoiDung,NgayKy,NhanVienID")] HopDong hopDong)
//        {
//            if (id != hopDong.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(hopDong);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!HopDongExists(hopDong.ID))
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
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "CanCuocCongDan", hopDong.NhanVienID);
//            return View(hopDong);
//        }

//        // GET: HopDong/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.HopDong == null)
//            {
//                return NotFound();
//            }

//            var hopDong = await _context.HopDong
//                .Include(h => h.NhanVien)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (hopDong == null)
//            {
//                return NotFound();
//            }

//            return View(hopDong);
//        }

//        // POST: HopDong/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.HopDong == null)
//            {
//                return Problem("Entity set 'QuanlynhansuDbContext.HopDong'  is null.");
//            }
//            var hopDong = await _context.HopDong.FindAsync(id);
//            if (hopDong != null)
//            {
//                _context.HopDong.Remove(hopDong);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool HopDongExists(int id)
//        {
//          return (_context.HopDong?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
