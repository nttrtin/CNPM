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
//    public class ChuyenMonController : Controller
//    {

//        private readonly QuanlynhansuDbContext _context;

//        public ChuyenMonController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: ChuyenMon
//        public async Task<IActionResult> Index()
//        {
//            return _context.ChuyenMon != null ?
//                        View(await _context.ChuyenMon.ToListAsync()) :
//                        Problem("Entity set 'QuanlynhansuDbContext.ChuyenMon'  is null.");
//        }

//        // GET: ChuyenMon/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.ChuyenMon == null)
//            {
//                return NotFound();
//            }

//            var chuyenMon = await _context.ChuyenMon
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (chuyenMon == null)
//            {
//                return NotFound();
//            }

//            return View(chuyenMon);
//        }

//        // GET: ChuyenMon/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: ChuyenMon/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,MaChuyenMon,TenChuyenMon")] ChuyenMon chuyenMon)
//        {
//            if (!IsDuplicateCode(chuyenMon.MaChuyenMon))
//            {
//                if (ModelState.IsValid)
//                {
//                    _context.Add(chuyenMon);
//                    await _context.SaveChangesAsync();
//                    return RedirectToAction(nameof(Index));
//                }
//                else
//                {
//                    return View(chuyenMon);
//                }

//            }
//            else
//            {
//                ModelState.AddModelError("MaChuyenMon", "Mã Đã Có Trong Hệ Thống, Hãy Nhập Mã Mới!");
//                return View(chuyenMon);
//            }
//        }
//        public bool IsDuplicateCode(string code)
//        {
//            return _context.ChuyenMon.Any(b => b.MaChuyenMon == code);
//        }

//        // GET: ChuyenMon/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.ChuyenMon == null)
//            {
//                return NotFound();
//            }

//            var chuyenMon = await _context.ChuyenMon.FindAsync(id);
//            if (chuyenMon == null)
//            {
//                return NotFound();
//            }
//            return View(chuyenMon);
//        }

//        // POST: ChuyenMon/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,MaChuyenMon,TenChuyenMon")] ChuyenMon chuyenMon)
//        {
//            if (id != chuyenMon.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(chuyenMon);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ChuyenMonExists(chuyenMon.ID))
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
//            return View(chuyenMon);
//        }

//        // GET: ChuyenMon/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.ChuyenMon == null)
//            {
//                return NotFound();
//            }

//            var chuyenMon = await _context.ChuyenMon
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (chuyenMon == null)
//            {
//                return NotFound();
//            }

//            return View(chuyenMon);
//        }

//        // POST: ChuyenMon/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            try
//            {
//                var chuyenMon = await _context.ChuyenMon.FindAsync(id);
//                if (chuyenMon == null)
//                {
//                    return NotFound("Không thể tìm thấy chức vụ để xóa.");
//                }

//                _context.ChuyenMon.Remove(chuyenMon);
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

//        private bool ChuyenMonExists(int id)
//        {
//            return (_context.ChuyenMon?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
