using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;

namespace QLNS.Areas.QuanLy.Controllers
{
    [Area("QuanLy")]
    [Authorize(Roles = "QuanLy")]
    public class KhenThuongController : Controller
    {
        private readonly QuanlynhansuDbContext _context;

        public KhenThuongController(QuanlynhansuDbContext context)
        {
            _context = context;
        }

        // GET: KhenThuong
        public async Task<IActionResult> Index()
        {
            return _context.KhenThuong != null ?
                        View(await _context.KhenThuong.ToListAsync()) :
                        Problem("Entity set 'QuanlynhansuDbContext.KhenThuong'  is null.");
        }

        // GET: KhenThuong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KhenThuong == null)
            {
                return NotFound();
            }

            var khenThuong = await _context.KhenThuong
                .FirstOrDefaultAsync(m => m.ID == id);
            if (khenThuong == null)
            {
                return NotFound();
            }

            return View(khenThuong);
        }

        // GET: KhenThuong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhenThuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaKhenThuong,LyDoKhenThuong,TienThuong")] KhenThuong khenThuong)
        {
            if (!IsDuplicateCode(khenThuong.MaKhenThuong))
            {
                if (ModelState.IsValid)
                {
                    _context.Add(khenThuong);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(khenThuong);
                }
            }
            else
            {
                ModelState.AddModelError("MaKhenThuong", "Mã Đã Có Trong Hệ Thống, Hãy Nhập Mã Mới!");
                return View(khenThuong);
            }
        }
        public bool IsDuplicateCode(string code)
        {
            return _context.KhenThuong.Any(b => b.MaKhenThuong == code);
        }
        // GET: KhenThuong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KhenThuong == null)
            {
                return NotFound();
            }

            var khenThuong = await _context.KhenThuong.FindAsync(id);
            if (khenThuong == null)
            {
                return NotFound();
            }
            return View(khenThuong);
        }

        // POST: KhenThuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaKhenThuong,LyDoKhenThuong,TienThuong")] KhenThuong khenThuong)
        {
            if (id != khenThuong.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khenThuong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhenThuongExists(khenThuong.ID))
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
            return View(khenThuong);
        }

        // GET: KhenThuong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KhenThuong == null)
            {
                return NotFound();
            }

            var khenThuong = await _context.KhenThuong
                .FirstOrDefaultAsync(m => m.ID == id);
            if (khenThuong == null)
            {
                return NotFound();
            }

            return View(khenThuong);
        }

        // POST: KhenThuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KhenThuong == null)
            {
                return Problem("Entity set 'QuanlynhansuDbContext.KhenThuong'  is null.");
            }
            var khenThuong = await _context.KhenThuong.FindAsync(id);
            if (khenThuong != null)
            {
                _context.KhenThuong.Remove(khenThuong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhenThuongExists(int id)
        {
            return (_context.KhenThuong?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
