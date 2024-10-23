//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using QLNS.Models;

//namespace QLNS.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    [Authorize(Roles = "Admin")]
//    public class QuocTichController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;

//        public QuocTichController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: QuocTich
//        public async Task<IActionResult> Index()
//        {
//            return _context.QuocTich != null ?
//                        View(await _context.QuocTich.ToListAsync()) :
//                        Problem("Entity set 'QuanlynhansuDbContext.QuocTich'  is null.");
//        }

//        // GET: QuocTich/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.QuocTich == null)
//            {
//                return NotFound();
//            }

//            var quocTich = await _context.QuocTich
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (quocTich == null)
//            {
//                return NotFound();
//            }

//            return View(quocTich);
//        }

//        // GET: QuocTich/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: QuocTich/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,MaQuocTich,TenQuocTich")] QuocTich quocTich)
//        {
//            // Kiểm tra trùng mã trước khi thêm mới
//            if (!IsDuplicateCode(quocTich.MaQuocTich))
//            {
//                if (ModelState.IsValid)
//                {
//                    _context.Add(quocTich);
//                    await _context.SaveChangesAsync();
//                    return RedirectToAction(nameof(Index));
//                }
//                else
//                {
//                    return View(quocTich);
//                }
//            }
//            else
//            {
//                ModelState.AddModelError("MaQuocTich", "Mã Đã Có Trong Hệ Thống, Hãy Nhập Mã Mới!");
//                return View(quocTich);
//            }
//        }
//        public bool IsDuplicateCode(string code)
//        {
//            return _context.QuocTich.Any(b => b.MaQuocTich == code);
//        }
//        // GET: QuocTich/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.QuocTich == null)
//            {
//                return NotFound();
//            }

//            var quocTich = await _context.QuocTich.FindAsync(id);
//            if (quocTich == null)
//            {
//                return NotFound();
//            }
//            return View(quocTich);
//        }

//        // POST: QuocTich/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,MaQuocTich,TenQuocTich")] QuocTich quocTich)
//        {
//            if (id != quocTich.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(quocTich);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!QuocTichExists(quocTich.ID))
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
//            return View(quocTich);
//        }

//        // GET: QuocTich/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.QuocTich == null)
//            {
//                return NotFound();
//            }

//            var quocTich = await _context.QuocTich
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (quocTich == null)
//            {
//                return NotFound();
//            }

//            return View(quocTich);
//        }

//        // POST: QuocTich/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            try
//            {
//                var quocTich = await _context.QuocTich.FindAsync(id);
//                if (quocTich == null)
//                {
//                    return NotFound("Không thể tìm thấy chức vụ để xóa.");
//                }

//                _context.QuocTich.Remove(quocTich);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            catch (DbUpdateException ex)
//            {
//                var innerException = ex.InnerException;
//                if (innerException is SqlException sqlEx && sqlEx.Number == 547) // Foreign key constraint violation
//                {
//                    TempData["ErrorMessage"] = "Không thể xóa chức vụ vì đã được liên kết với bảng nhân viên.";
//                    return RedirectToAction(nameof(Index)); // Redirect back to the index page
//                }
//                else
//                {
//                    TempData["ErrorMessage"] = $"Đã xảy ra lỗi khi xóa chức vụ: {ex.Message}";
//                    return RedirectToAction(nameof(Index)); // Redirect back to the index page
//                }
//            }
//            catch (Exception ex)
//            {
//                TempData["ErrorMessage"] = $"Đã xảy ra lỗi khi xóa chức vụ: {ex.Message}";
//                return RedirectToAction(nameof(Index)); // Redirect back to the index page
//            }
//        }

//        private bool QuocTichExists(int id)
//        {
//            return (_context.QuocTich?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
