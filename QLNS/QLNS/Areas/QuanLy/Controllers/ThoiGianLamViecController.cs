using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;
namespace QLNS.Areas.QuanLy.Controllers
{
    [Area("QuanLy")]
    [Authorize(Roles = "QuanLy")]
    public class ThoiGianLamViecController : Controller
    {
        private readonly QuanlynhansuDbContext _context;
        public ThoiGianLamViecController(QuanlynhansuDbContext context)
        {
            _context = context;
        }
        // GET: ThoiGianLamViec
        public async Task<IActionResult> Index()
        {
            var quanlynhansuDbContext = _context.ThoiGianLamViec.Include(t => t.NhanVien).Include(t => t.NghiPhep);
            return View(await quanlynhansuDbContext.ToListAsync());
        }
        // GET: ThoiGianLamViec/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ThoiGianLamViec == null)
            {
                return NotFound();
            }

            var thoiGianLamViec = await _context.ThoiGianLamViec
                .Include(t => t.NhanVien)
                .Include(t => t.NghiPhep)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (thoiGianLamViec == null)
            {
                return NotFound();
            }

            return View(thoiGianLamViec);
        }

        // GET: ThoiGianLamViec/Create
        public IActionResult Create()
        {

            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien");
            ViewData["SoNgayNghiID"] = new SelectList(_context.NghiPhep, "ID", "SoNgayNghi");
            return View();
        }

        // POST: ThoiGianLamViec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NhanVienID,Thang,SoNgayNghiID,SoNgayCong")] ThoiGianLamViec thoiGianLamViec)
        {
            if (ModelState.IsValid)
            {
                thoiGianLamViec.SoNgayCong = 22 - thoiGianLamViec.SoNgayNghiID;
                _context.Add(thoiGianLamViec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", thoiGianLamViec.NhanVienID);
            ViewData["SoNgayNghiID"] = new SelectList(_context.NghiPhep, "ID", "SoNgayNghi", thoiGianLamViec.SoNgayNghiID);
            return View(thoiGianLamViec);
        }

        /* public IActionResult GetSoNgayNghi(int NhanVienID)
         {
             // Truy vấn nhân viên dựa trên NhanVienID

             var tongSoNgayNghi = _context.NghiPhep
                      .Where(np => np.NhanVienID == NhanVienID)
                      .Sum(np => np.SoNgayNghi);
             if (tongSoNgayNghi != null)
             {
                 // Tạo một object mới chứa ID và tên chức vụ
                 var soNgayNghi = new { id = tongSoNgayNghi, soNgayNghi = tongSoNgayNghi };
                 return Json(soNgayNghi); // Trả về dữ liệu dưới dạng JSON
             }
             else
             {
                 return Json(null); // Trả về null nếu không tìm thấy thông tin về nhân viên
             }
         }*/

        public IActionResult GetSoNgayNghi(int NhanVienID, int selectedMonth)
        {
            // Truy vấn nhân viên dựa trên NhanVienID và tháng đã chọn
            var tongSoNgayNghi = _context.NghiPhep
                .Where(np => np.NhanVienID == NhanVienID && np.NgayKetThuc.Month == selectedMonth)
                .Sum(np => np.SoNgayNghi);

            if (tongSoNgayNghi > 0)
            {
                // Tạo một object mới chứa ID và số ngày nghỉ theo tháng đã chọn
                var soNgayNghi = new { id = NhanVienID, soNgayNghi = tongSoNgayNghi };
                return Json(soNgayNghi); // Trả về dữ liệu dưới dạng JSON
            }
            else
            {
                return Json(null); // Trả về null nếu không tìm thấy thông tin về nhân viên trong tháng đã chọn
            }
        }
        // GET: ThoiGianLamViec/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ThoiGianLamViec == null)
            {
                return NotFound();
            }

            var thoiGianLamViec = await _context.ThoiGianLamViec.FindAsync(id);
            if (thoiGianLamViec == null)
            {
                return NotFound();
            }
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", thoiGianLamViec.NhanVienID);
            ViewData["SoNgayNghiID"] = new SelectList(_context.NghiPhep, "ID", "SoNgayNghi", thoiGianLamViec.SoNgayNghiID);
            return View(thoiGianLamViec);
        }

        // POST: ThoiGianLamViec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NhanVienID,Thang,SoNgayNghiID,SoNgayCong")] ThoiGianLamViec thoiGianLamViec)
        {
            if (id != thoiGianLamViec.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thoiGianLamViec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThoiGianLamViecExists(thoiGianLamViec.ID))
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
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", thoiGianLamViec.NhanVienID);
            ViewData["SoNgayNghiID"] = new SelectList(_context.NghiPhep, "ID", "SoNgayNghi", thoiGianLamViec.SoNgayNghiID);
            return View(thoiGianLamViec);
        }

        // GET: ThoiGianLamViec/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ThoiGianLamViec == null)
            {
                return NotFound();
            }

            var thoiGianLamViec = await _context.ThoiGianLamViec
                .Include(t => t.NhanVien)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (thoiGianLamViec == null)
            {
                return NotFound();
            }

            return View(thoiGianLamViec);
        }

        // POST: ThoiGianLamViec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ThoiGianLamViec == null)
            {
                return Problem("Entity set 'QuanlynhansuDbContext.ThoiGianLamViec'  is null.");
            }
            var thoiGianLamViec = await _context.ThoiGianLamViec.FindAsync(id);
            if (thoiGianLamViec != null)
            {
                _context.ThoiGianLamViec.Remove(thoiGianLamViec);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThoiGianLamViecExists(int id)
        {
            return (_context.ThoiGianLamViec?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
