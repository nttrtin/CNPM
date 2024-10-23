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
//    public class KhoanTruController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;

//        public KhoanTruController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: KhoanTru
//        public async Task<IActionResult> Index()
//        {
//            return _context.KhoanTru != null ?
//                        View(await _context.KhoanTru.ToListAsync()) :
//                        Problem("Entity set 'QuanlynhansuDbContext.KhoanTru'  is null.");
//        }

//        // GET: KhoanTru/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.KhoanTru == null)
//            {
//                return NotFound();
//            }

//            var khoanTru = await _context.KhoanTru
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (khoanTru == null)
//            {
//                return NotFound();
//            }

//            return View(khoanTru);
//        }

//        // GET: KhoanTru/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: KhoanTru/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,MaKhoanTru,LyDoKhoanTru,SoTienKhoanTru")] KhoanTru khoanTru)
//        {
//            // Kiểm tra trùng mã trước khi thêm mới
//            if (!IsDuplicateCode(khoanTru.MaKhoanTru))
//            {
//                if (ModelState.IsValid)
//                {
//                    _context.Add(khoanTru);
//                    await _context.SaveChangesAsync();
//                    return RedirectToAction(nameof(Index));
//                }
//                else
//                {
//                    return View(khoanTru);
//                }
//            }
//            else
//            {
//                ModelState.AddModelError("MaKhoanTru", "Mã Đã Có Trong Hệ Thống, Hãy Nhập Mã Mới!");
//                return View(khoanTru);
//            }
//        }
//        public bool IsDuplicateCode(string code)
//        {
//            return _context.KhoanTru.Any(b => b.MaKhoanTru == code);
//        }


//        // GET: KhoanTru/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.KhoanTru == null)
//            {
//                return NotFound();
//            }

//            var khoanTru = await _context.KhoanTru.FindAsync(id);
//            if (khoanTru == null)
//            {
//                return NotFound();
//            }
//            return View(khoanTru);
//        }

//        // POST: KhoanTru/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,MaKhoanTru,LyDoKhoanTru,SoTienKhoanTru")] KhoanTru khoanTru)
//        {
//            if (id != khoanTru.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(khoanTru);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!KhoanTruExists(khoanTru.ID))
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
//            return View(khoanTru);
//        }

//        // GET: KhoanTru/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.KhoanTru == null)
//            {
//                return NotFound();
//            }

//            var khoanTru = await _context.KhoanTru
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (khoanTru == null)
//            {
//                return NotFound();
//            }

//            return View(khoanTru);
//        }

//        // POST: KhoanTru/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.KhoanTru == null)
//            {
//                return Problem("Entity set 'QuanlynhansuDbContext.KhoanTru'  is null.");
//            }
//            var khoanTru = await _context.KhoanTru.FindAsync(id);
//            if (khoanTru != null)
//            {
//                _context.KhoanTru.Remove(khoanTru);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool KhoanTruExists(int id)
//        {
//            return (_context.KhoanTru?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
