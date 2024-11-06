using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;

namespace QLNS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ChucVuController : Controller
    {
        private readonly QuanlynhansuDbContext _context;

        public ChucVuController(QuanlynhansuDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ChucVu
        public async Task<IActionResult> Index()
        {
            return _context.ChucVu != null ?
                        View(await _context.ChucVu.ToListAsync()) :
                        Problem("Entity set 'QuanlynhansuDbContext.ChucVu'  is null.");
        }

        // GET: Admin/ChucVu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChucVu == null)
            {
                return NotFound();
            }

            var chucVu = await _context.ChucVu
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chucVu == null)
            {
                return NotFound();
            }

            return View(chucVu);
        }

        // GET: Admin/ChucVu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChucVu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaChucVu,TenChucVu,MoTa,LuongCoBan")] ChucVu chucVu)
        {
            if (!IsDuplicateCode(chucVu.MaChucVu))
            {
                if (ModelState.IsValid)
                {
                    _context.Add(chucVu);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(chucVu);
                }
            }
            else
            {
                ModelState.AddModelError("MaChucVu", "Mã Đã Có Trong Hệ Thống, Hãy Nhập Mã Mới!");
                return View(chucVu);
            }
        }
        public bool IsDuplicateCode(string code)
        {
            return _context.ChucVu.Any(b => b.MaChucVu == code);
        }


        // GET: Admin/ChucVu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChucVu == null)
            {
                return NotFound();
            }

            var chucVu = await _context.ChucVu.FindAsync(id);
            if (chucVu == null)
            {
                return NotFound();
            }
            return View(chucVu);
        }

        // POST: Admin/ChucVu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaChucVu,TenChucVu,MoTa,LuongCoBan")] ChucVu chucVu)
        {
            if (id != chucVu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chucVu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChucVuExists(chucVu.ID))
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
            return View(chucVu);
        }

        // GET: Admin/ChucVu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChucVu == null)
            {
                return NotFound();
            }

            var chucVu = await _context.ChucVu
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chucVu == null)
            {
                return NotFound();
            }

            return View(chucVu);
        }

        // POST: Admin/ChucVu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var chucVu = await _context.ChucVu.FindAsync(id);
                if (chucVu == null)
                {
                    return NotFound("Không thể tìm thấy chức vụ để xóa.");
                }

                _context.ChucVu.Remove(chucVu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                if (innerException is SqlException sqlEx && sqlEx.Number == 547) // Foreign key constraint violation
                {
                    TempData["ErrorMessage"] = "Không thể xóa chức vụ vì đã được liên kết với bảng lương.";
                    return RedirectToAction(nameof(Index)); // Redirect back to the index page
                }
                else
                {
                    TempData["ErrorMessage"] = $"Đã xảy ra lỗi khi xóa chức vụ: {ex.Message}";
                    return RedirectToAction(nameof(Index)); // Redirect back to the index page
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Đã xảy ra lỗi khi xóa chức vụ: {ex.Message}";
                return RedirectToAction(nameof(Index)); // Redirect back to the index page
            }
        }

        private bool ChucVuExists(int id)
        {
            return (_context.ChucVu?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
