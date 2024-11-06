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
    public class TrinhDoController : Controller
    {
        private readonly QuanlynhansuDbContext _context;

        public TrinhDoController(QuanlynhansuDbContext context)
        {
            _context = context;
        }

        // GET: TrinhDo
        public async Task<IActionResult> Index()
        {
            return _context.TrinhDo != null ?
                        View(await _context.TrinhDo.ToListAsync()) :
                        Problem("Entity set 'QuanlynhansuDbContext.TrinhDo'  is null.");
        }

        // GET: TrinhDo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrinhDo == null)
            {
                return NotFound();
            }

            var trinhDo = await _context.TrinhDo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trinhDo == null)
            {
                return NotFound();
            }

            return View(trinhDo);
        }

        // GET: TrinhDo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrinhDo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaTrinhDo,TenTrinhDo")] TrinhDo trinhDo)
        {
            // Kiểm tra trùng mã trước khi thêm mới
            if (!IsDuplicateCode(trinhDo.MaTrinhDo))
            {
                if (ModelState.IsValid)
                {
                    _context.Add(trinhDo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(trinhDo);
                }
            }
            else
            {
                ModelState.AddModelError("MaTrinhDo", "Mã Đã Có Trong Hệ Thống, Hãy Nhập Mã Mới!");
                return View(trinhDo);
            }
        }
        public bool IsDuplicateCode(string code)
        {
            return _context.TrinhDo.Any(b => b.MaTrinhDo == code);
        }
        // GET: TrinhDo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrinhDo == null)
            {
                return NotFound();
            }

            var trinhDo = await _context.TrinhDo.FindAsync(id);
            if (trinhDo == null)
            {
                return NotFound();
            }
            return View(trinhDo);
        }

        // POST: TrinhDo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaTrinhDo,TenTrinhDo")] TrinhDo trinhDo)
        {
            if (id != trinhDo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trinhDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrinhDoExists(trinhDo.ID))
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
            return View(trinhDo);
        }

        // GET: TrinhDo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TrinhDo == null)
            {
                return NotFound();
            }

            var trinhDo = await _context.TrinhDo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trinhDo == null)
            {
                return NotFound();
            }

            return View(trinhDo);
        }

        // POST: TrinhDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var trinhDo = await _context.TrinhDo.FindAsync(id);
                if (trinhDo == null)
                {
                    return NotFound("Không thể tìm thấy chức vụ để xóa.");
                }

                _context.TrinhDo.Remove(trinhDo);
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

        private bool TrinhDoExists(int id)
        {
            return (_context.TrinhDo?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
