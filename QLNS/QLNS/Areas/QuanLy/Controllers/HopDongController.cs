using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;

namespace QLNS.Areas.QuanLy.Controllers
{
    [Area("QuanLy")]
    [Authorize(Roles = "QuanLy")]
    public class HopDongController : Controller
    {
        private readonly QuanlynhansuDbContext _context;

        public HopDongController(QuanlynhansuDbContext context)
        {
            _context = context;
        }

        // GET: Admin/HopDong
        public async Task<IActionResult> Index()
        {
            var quanlynhansuDbContext = _context.HopDong.Include(h => h.NhanVien);
            return View(await quanlynhansuDbContext.ToListAsync());
        }

        // GET: Admin/HopDong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HopDong == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDong
                .Include(h => h.NhanVien)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hopDong == null)
            {
                return NotFound();
            }

            return View(hopDong);
        }

        // GET: Admin/HopDong/Create
        public IActionResult Create()
        {
          

            var hopDong = new HopDong();

            // Tạo mã nhân viên ngẫu nhiên và gán vào trường MaNhanVien
            hopDong.MaHopDong = GenerateMaHopDong();
            hopDong.NgayBatDau = DateTime.Today;
            hopDong.NgayKetThuc = DateTime.Today;
            hopDong.NgayKy = DateTime.Today;
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien");
            return View(hopDong);
        }

        // POST: Admin/HopDong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaHopDong,TenHopDong,NgayBatDau,NgayKetThuc,NoiDung,NgayKy,NhanVienID")] HopDong hopDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hopDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", hopDong.NhanVienID);
            return View(hopDong);
        }
        public string GenerateMaHopDong()
        {
            string maHopDong = "";
            Random random = new Random();
            bool duplicateFound = true;

            while (duplicateFound)
            {
                // Sinh mã nhân viên ngẫu nhiên (ví dụ: NV0001)
                maHopDong = "MHD" + random.Next(1000, 9999);

                // Kiểm tra xem mã nhân viên đã tồn tại trong cơ sở dữ liệu chưa
                var existingNhanVien = _context.HopDong.FirstOrDefault(nv => nv.MaHopDong == maHopDong);

                if (existingNhanVien == null)
                {
                    duplicateFound = false;
                }
            }

            return maHopDong;
        }
        // GET: Admin/HopDong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HopDong == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDong.FindAsync(id);
            if (hopDong == null)
            {
                return NotFound();
            }
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", hopDong.NhanVienID);
            return View(hopDong);
        }

        // POST: Admin/HopDong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaHopDong,TenHopDong,NgayBatDau,NgayKetThuc,NoiDung,NgayKy,NhanVienID")] HopDong hopDong)
        {
            if (id != hopDong.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopDongExists(hopDong.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", hopDong.NhanVienID);
            return View(hopDong);
        }

        // GET: Admin/HopDong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HopDong == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDong
                .Include(h => h.NhanVien)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hopDong == null)
            {
                return NotFound();
            }

            return View(hopDong);
        }

        // POST: Admin/HopDong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HopDong == null)
            {
                return Problem("Entity set 'QuanlynhansuDbContext.HopDong'  is null.");
            }
            var hopDong = await _context.HopDong.FindAsync(id);
            if (hopDong != null)
            {
                _context.HopDong.Remove(hopDong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopDongExists(int id)
        {
          return (_context.HopDong?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
