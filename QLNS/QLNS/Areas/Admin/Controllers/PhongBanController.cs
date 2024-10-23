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
//    public class PhongBanController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;

//        public PhongBanController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: PhongBan
//        public async Task<IActionResult> Index()
//        {
//            return _context.PhongBan != null ?
//                        View(await _context.PhongBan.ToListAsync()) :
//                        Problem("Entity set 'QuanlynhansuDbContext.PhongBan'  is null.");
//        }

//        // GET: PhongBan/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.PhongBan == null)
//            {
//                return NotFound();
//            }

//            var phongBan = await _context.PhongBan
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (phongBan == null)
//            {
//                return NotFound();
//            }

//            return View(phongBan);
//        }

//        // GET: PhongBan/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: PhongBan/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,MaPhongBan,TenPhongBan")] PhongBan phongBan)
//        {
//            // Kiểm tra trùng mã trước khi thêm mới
//            if (!IsDuplicateCode(phongBan.MaPhongBan))
//            {
//                if (ModelState.IsValid)
//                {
//                    _context.Add(phongBan);
//                    await _context.SaveChangesAsync();
//                    return RedirectToAction(nameof(Index));
//                }
//                else
//                {
//                    return View(phongBan);
//                }
//            }
//            else
//            {
//                ModelState.AddModelError("MaPhongBan", "Mã Đã Có Trong Hệ Thống, Hãy Nhập Mã Mới!");
//                return View(phongBan);
//            }
//        }
//        public bool IsDuplicateCode(string code)
//        {
//            return _context.PhongBan.Any(b => b.MaPhongBan == code);
//        }
//        // GET: PhongBan/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.PhongBan == null)
//            {
//                return NotFound();
//            }

//            var phongBan = await _context.PhongBan.FindAsync(id);
//            if (phongBan == null)
//            {
//                return NotFound();
//            }
//            return View(phongBan);
//        }

//        // POST: PhongBan/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,MaPhongBan,TenPhongBan")] PhongBan phongBan)
//        {
//            if (id != phongBan.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(phongBan);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!PhongBanExists(phongBan.ID))
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
//            return View(phongBan);
//        }

//        // GET: PhongBan/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.PhongBan == null)
//            {
//                return NotFound();
//            }

//            var phongBan = await _context.PhongBan
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (phongBan == null)
//            {
//                return NotFound();
//            }

//            return View(phongBan);
//        }

//        // POST: PhongBan/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            try
//            {
//                var phongBan = await _context.PhongBan.FindAsync(id);
//                if (phongBan == null)
//                {
//                    return NotFound("Không thể tìm thấy chức vụ để xóa.");
//                }

//                _context.PhongBan.Remove(phongBan);
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

//        private bool PhongBanExists(int id)
//        {
//            return (_context.PhongBan?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
