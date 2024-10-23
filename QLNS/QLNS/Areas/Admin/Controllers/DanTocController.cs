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
    public class DanTocController : Controller
    {
        private readonly QuanlynhansuDbContext _context;

        public DanTocController(QuanlynhansuDbContext context)
        {
            _context = context;
        }

        // GET: DanToc
        public async Task<IActionResult> Index()
        {
            return _context.DanToc != null ?
                        View(await _context.DanToc.ToListAsync()) :
                        Problem("Entity set 'QuanlynhansuDbContext.DanToc'  is null.");
        }

        // GET: DanToc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DanToc == null)
            {
                return NotFound();
            }

            var danToc = await _context.DanToc
                .FirstOrDefaultAsync(m => m.ID == id);
            if (danToc == null)
            {
                return NotFound();
            }

            return View(danToc);
        }

        // GET: DanToc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanToc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaDanToc,TenDanToc")] DanToc danToc)
        {
            if (!IsDuplicateCode(danToc.MaDanToc))
            {
                if (ModelState.IsValid)
                {
                    _context.Add(danToc);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(danToc);
                }
            }
            else
            {
                ModelState.AddModelError("MaDanToc", "Mã Đã Có Trong Hệ Thống, Hãy Nhập Mã Mới!");
                return View(danToc);
            }
        }
        public bool IsDuplicateCode(string code)
        {
            return _context.DanToc.Any(b => b.MaDanToc == code);
        }

        // GET: DanToc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DanToc == null)
            {
                return NotFound();
            }

            var danToc = await _context.DanToc.FindAsync(id);
            if (danToc == null)
            {
                return NotFound();
            }
            return View(danToc);
        }

        // POST: DanToc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaDanToc,TenDanToc")] DanToc danToc)
        {
            if (id != danToc.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danToc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanTocExists(danToc.ID))
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
            return View(danToc);
        }

        // GET: DanToc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DanToc == null)
            {
                return NotFound();
            }

            var danToc = await _context.DanToc
                .FirstOrDefaultAsync(m => m.ID == id);
            if (danToc == null)
            {
                return NotFound();
            }

            return View(danToc);
        }

        // POST: DanToc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var danToc = await _context.DanToc.FindAsync(id);
                if (danToc == null)
                {
                    return NotFound("Không thể tìm thấy chức vụ để xóa.");
                }

                _context.DanToc.Remove(danToc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                if (innerException is SqlException sqlEx && sqlEx.Number == 547) // Foreign key constraint violation
                {
                    TempData["ErrorMessage"] = "Không thể xóa chức vụ vì đã được liên kết với bảng nhân viên.";
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

        private bool DanTocExists(int id)
        {
            return (_context.DanToc?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
