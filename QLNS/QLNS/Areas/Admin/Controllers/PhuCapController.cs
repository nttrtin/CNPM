//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using QLNS.Models;

//namespace QLNS.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    [Authorize(Roles = "Admin")]
//    public class PhuCapController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;

//        public PhuCapController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Admin/PhuCap
//        public async Task<IActionResult> Index()
//        {
//              return _context.PhuCap != null ? 
//                          View(await _context.PhuCap.ToListAsync()) :
//                          Problem("Entity set 'QuanlynhansuDbContext.PhuCap'  is null.");
//        }

//        // GET: Admin/PhuCap/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.PhuCap == null)
//            {
//                return NotFound();
//            }

//            var phuCap = await _context.PhuCap
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (phuCap == null)
//            {
//                return NotFound();
//            }

//            return View(phuCap);
//        }

//        // GET: Admin/PhuCap/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Admin/PhuCap/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,MaPhuCap,TenPhuCap,SoTienPhuCap")] PhuCap phuCap)
//        {
//            // Kiểm tra trùng mã trước khi thêm mới
//            if (!IsDuplicateCode(phuCap.MaPhuCap))
//            {
//                if (ModelState.IsValid)
//                {
//                    _context.Add(phuCap);
//                    await _context.SaveChangesAsync();
//                    return RedirectToAction(nameof(Index));
//                }
//                else
//                {
//                    return View(phuCap);
//                }
//            }
//            else
//            {
//                ModelState.AddModelError("MaPhuCap", "Mã Đã Có Trong Hệ Thống, Hãy Nhập Mã Mới!");
//                return View(phuCap);
//            }
//        }
//        public bool IsDuplicateCode(string code)
//        {
//            return _context.PhuCap.Any(b => b.MaPhuCap == code);
//        }
//        // GET: Admin/PhuCap/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.PhuCap == null)
//            {
//                return NotFound();
//            }

//            var phuCap = await _context.PhuCap.FindAsync(id);
//            if (phuCap == null)
//            {
//                return NotFound();
//            }
//            return View(phuCap);
//        }

//        // POST: Admin/PhuCap/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,MaPhuCap,TenPhuCap,SoTienPhuCap")] PhuCap phuCap)
//        {
//            if (id != phuCap.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(phuCap);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!PhuCapExists(phuCap.ID))
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
//            return View(phuCap);
//        }

//        // GET: Admin/PhuCap/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.PhuCap == null)
//            {
//                return NotFound();
//            }

//            var phuCap = await _context.PhuCap
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (phuCap == null)
//            {
//                return NotFound();
//            }

//            return View(phuCap);
//        }

//        // POST: Admin/PhuCap/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.PhuCap == null)
//            {
//                return Problem("Entity set 'QuanlynhansuDbContext.PhuCap'  is null.");
//            }
//            var phuCap = await _context.PhuCap.FindAsync(id);
//            if (phuCap != null)
//            {
//                _context.PhuCap.Remove(phuCap);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool PhuCapExists(int id)
//        {
//          return (_context.PhuCap?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
