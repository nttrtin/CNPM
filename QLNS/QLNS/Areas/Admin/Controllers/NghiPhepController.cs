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
//    public class NghiPhepController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;

//        public NghiPhepController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Admin/NghiPhep
//        public async Task<IActionResult> Index()
//        {
//            var quanlynhansuDbContext = _context.NghiPhep.Include(n => n.NhanVien);
//            return View(await quanlynhansuDbContext.ToListAsync());
//        }

//        // GET: Admin/NghiPhep/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.NghiPhep == null)
//            {
//                return NotFound();
//            }

//            var nghiPhep = await _context.NghiPhep
//                .Include(n => n.NhanVien)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (nghiPhep == null)
//            {
//                return NotFound();
//            }

//            return View(nghiPhep);
//        }

//        // GET: Admin/NghiPhep/Create
//        public IActionResult Create()
//        {
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien");
//            return View();
//        }

//        // POST: Admin/NghiPhep/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,NhanVienID,NgayBatDau,NgayKetThuc,SoNgayNghi,LyDoNghi,TrangThai")] NghiPhep nghiPhep)
//        {
//            if (ModelState.IsValid)
//            {
//                var kiemtraNghiPhep = await _context.NghiPhep
//               .FirstOrDefaultAsync(np =>
//                   np.NhanVienID == nghiPhep.NhanVienID &&
//                   ((np.NgayBatDau <= nghiPhep.NgayBatDau && np.NgayKetThuc >= nghiPhep.NgayBatDau) ||
//                   (np.NgayBatDau <= nghiPhep.NgayKetThuc && np.NgayKetThuc >= nghiPhep.NgayKetThuc)));

//                if (kiemtraNghiPhep != null)
//                {
//                    // Nếu có nghiệp vụ nghỉ phép khác trong cùng khoảng thời gian, hiển thị thông báo lỗi
//                    ModelState.AddModelError("NgayBatDau", "Đã có lịch nghỉ phép trong khoảng thời gian này.");
//                    ModelState.AddModelError("NgayKetThuc", "Đã có lịch nghỉ phép trong khoảng thời gian này.");
//                    ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", nghiPhep.NhanVienID);
//                    return View(nghiPhep);
//                }
//                _context.Add(nghiPhep);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", nghiPhep.NhanVienID);
//            /*            ViewData["TrangThai"] = new SelectList(_context.NghiPhep, "ID", "TrangThai", nghiPhep.TrangThai);*/
//            return View(nghiPhep);
//        }
//     /*   public int TinhSoNgayNghi(DateTime ngayBatDau, DateTime ngayKetThuc)
//        {
//            TimeSpan khoangThoiGian = ngayKetThuc - ngayBatDau;
//            int soNgayNghi = khoangThoiGian.Days + 1; // Cộng thêm 1 để bao gồm cả ngày kết thúc

//            // Kiểm tra và loại bỏ các ngày cuối tuần
//            for (DateTime date = ngayBatDau; date <= ngayKetThuc; date = date.AddDays(1))
//            {
//                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
//                {
//                    soNgayNghi--;
//                }
//            }

//            return soNgayNghi;
//        }*/
//        // GET: Admin/NghiPhep/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.NghiPhep == null)
//            {
//                return NotFound();
//            }

//            var nghiPhep = await _context.NghiPhep.FindAsync(id);
//            if (nghiPhep == null)
//            {
//                return NotFound();
//            }
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", nghiPhep.NhanVienID);
//            return View(nghiPhep);
//        }

//        // POST: Admin/NghiPhep/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,NhanVienID,NgayBatDau,NgayKetThuc,SoNgayNghi,LyDoNghi,TrangThai")] NghiPhep nghiPhep)
//        {
//            if (id != nghiPhep.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(nghiPhep);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!NghiPhepExists(nghiPhep.ID))
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
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", nghiPhep.NhanVienID);
//            return View(nghiPhep);
//        }

//        // GET: Admin/NghiPhep/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.NghiPhep == null)
//            {
//                return NotFound();
//            }

//            var nghiPhep = await _context.NghiPhep
//                .Include(n => n.NhanVien)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (nghiPhep == null)
//            {
//                return NotFound();
//            }

//            return View(nghiPhep);
//        }

//        // POST: Admin/NghiPhep/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.NghiPhep == null)
//            {
//                return Problem("Entity set 'QuanlynhansuDbContext.NghiPhep'  is null.");
//            }
//            var nghiPhep = await _context.NghiPhep.FindAsync(id);
//            if (nghiPhep != null)
//            {
//                _context.NghiPhep.Remove(nghiPhep);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool NghiPhepExists(int id)
//        {
//            return (_context.NghiPhep?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
