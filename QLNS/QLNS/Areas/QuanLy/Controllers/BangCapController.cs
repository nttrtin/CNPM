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

namespace QLNS.Areas.QuanLy.Controllers
{
    [Area("QuanLy")]
    [Authorize(Roles = "QuanLy")]
    public class BangCapController : Controller
    {
        private readonly QuanlynhansuDbContext _context;

        public BangCapController(QuanlynhansuDbContext context)
        {
            _context = context;
        }

        // GET: BangCap
        public async Task<IActionResult> Index()
        {
            return _context.BangCap != null ?
                        View(await _context.BangCap.ToListAsync()) :
                        Problem("Entity set 'QuanlynhansuDbContext.BangCap'  is null.");
        }

        // GET: BangCap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BangCap == null)
            {
                return NotFound();
            }

            var bangCap = await _context.BangCap
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bangCap == null)
            {
                return NotFound();
            }

            return View(bangCap);
        }

        // GET: BangCap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BangCap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaBangCap,TenBangCap")] BangCap bangCap)
        {
            // Kiểm tra trùng mã trước khi thêm mới
            if (!IsDuplicateCode(bangCap.MaBangCap))
            {
                if (ModelState.IsValid)
                {
                    _context.Add(bangCap);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(bangCap);
                }
            }
            else
            {
                ModelState.AddModelError("MaBangCap", "Mã Đã Có Trong Hệ Thống, Hãy Nhập Mã Mới!");
                return View(bangCap);
            }
        }


        public bool IsDuplicateCode(string code)
        {
            return _context.BangCap.Any(b => b.MaBangCap == code);
        }



        // GET: BangCap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BangCap == null)
            {
                return NotFound();
            }

            var bangCap = await _context.BangCap.FindAsync(id);
            if (bangCap == null)
            {
                return NotFound();
            }
            return View(bangCap);
        }

        // POST: BangCap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaBangCap,TenBangCap")] BangCap bangCap)
        {
            if (id != bangCap.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bangCap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BangCapExists(bangCap.ID))
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
            return View(bangCap);
        }

        // GET: BangCap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BangCap == null)
            {
                return NotFound();
            }

            var bangCap = await _context.BangCap
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bangCap == null)
            {
                return NotFound();
            }

            return View(bangCap);
        }

        // POST: BangCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var bangCap = await _context.BangCap.FindAsync(id);
                if (bangCap == null)
                {
                    return NotFound("Không thể tìm thấy chức vụ để xóa.");
                }

                _context.BangCap.Remove(bangCap);
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

        private bool BangCapExists(int id)
        {
            return (_context.BangCap?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
