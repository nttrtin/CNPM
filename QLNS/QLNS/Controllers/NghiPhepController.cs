//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using QLNS.Models;

//namespace QLNS.Controllers
//{
//    public class NghiPhepController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;

//        public NghiPhepController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: NghiPhep
//        public async Task<IActionResult> Index()
//        { // Lấy tên người dùng từ HttpContext
//            string userName = HttpContext.User.Identity.Name;
//            var quanlynhansuDbContext = await _context.NghiPhep.Include(n => n.NhanVien).
//                Where(n => n.NhanVien.TenNhanVien == userName)
//                                             .ToListAsync(); ;
//            if (quanlynhansuDbContext == null)
//            {
//                return NotFound(); // Trả về trang 404 nếu không tìm thấy thông tin của người dùng
//            }

//            return View(quanlynhansuDbContext); // Truyền thông tin của người dùng vào view
//        }
       
//        // GET: NghiPhep/Details/5
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

//        // GET: NghiPhep/Create
//        public IActionResult Create()
//        {
//            string userName = HttpContext.User.Identity.Name;
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien.Where(n => n.TenNhanVien == userName), "ID", "TenNhanVien");
//            return View();
//        }

//        // POST: NghiPhep/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,NhanVienID,NgayBatDau,NgayKetThuc,SoNgayNghi,LyDoNghi,TrangThai")] NghiPhep nghiPhep)
//        {
//            string userName = HttpContext.User.Identity.Name;
//            if (ModelState.IsValid)
//            {
//                _context.Add(nghiPhep);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien.Where(n => n.TenNhanVien == userName), "ID", "TenNhanVien", nghiPhep.NhanVienID);
//            return View(nghiPhep);
//        }

//        // GET: NghiPhep/Edit/5
//      /*  public async Task<IActionResult> Edit(int? id)
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
//        }*/
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

//            // Lấy tên nhân viên đăng nhập
//            string userName = HttpContext.User.Identity.Name;

//            // Lấy thông tin của nhân viên đăng nhập
//            var tennhanvien = await _context.NhanVien.FirstOrDefaultAsync(n => n.TenNhanVien == userName);

//            // Chỉ hiển thị tên nhân viên đăng nhập trong danh sách chọn "Nhân viên"
//            ViewData["NhanVienID"] = new SelectList(new List<NhanVien> { tennhanvien }, "ID", "TenNhanVien", nghiPhep.NhanVienID);

//            return View(nghiPhep);
//        }
//        // POST: NghiPhep/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//       /* [HttpPost]
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
//        }*/
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

//            // Lấy tên nhân viên đăng nhập
//            string userName = HttpContext.User.Identity.Name;

//            // Lấy thông tin của nhân viên đăng nhập
//            var loggedInEmployee = await _context.NhanVien.FirstOrDefaultAsync(n => n.TenNhanVien == userName);

//            // Chỉ hiển thị tên nhân viên đăng nhập trong danh sách chọn "Nhân viên"
//            ViewData["NhanVienID"] = new SelectList(new List<NhanVien> { loggedInEmployee }, "ID", "TenNhanVien", nghiPhep.NhanVienID);

//            return View(nghiPhep);
//        }
//        // GET: NghiPhep/Delete/5
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

//        // POST: NghiPhep/Delete/5
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
//          return (_context.NghiPhep?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
