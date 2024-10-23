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
//    public class CongTacController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;

//        public CongTacController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Admin/CongTac
//        public async Task<IActionResult> Index()
//        {
//            var quanlynhansuDbContext = _context.CongTac.Include(c => c.ChucVu).Include(c => c.NhanVien);
//            return View(await quanlynhansuDbContext.ToListAsync());
//        }

//        // GET: Admin/CongTac/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.CongTac == null)
//            {
//                return NotFound();
//            }

//            var congTac = await _context.CongTac
//                .Include(c => c.ChucVu)
//                .Include(c => c.NhanVien)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (congTac == null)
//            {
//                return NotFound();
//            }

//            return View(congTac);
//        }

//        // GET: Admin/CongTac/Create
//        public IActionResult Create()
//        {
//            var congTac = new CongTac();

//            // Tạo mã nhân viên ngẫu nhiên và gán vào trường MaNhanVien
//            congTac.MaCongTac = GenerateMaCongTac();
//            congTac.NgayBatDau = DateTime.Today;
//            congTac.NgayKetThuc = DateTime.Today;
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu");
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien");
//            return View(congTac);
//        }

//        /* // POST: Admin/CongTac/Create
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create([Bind("ID,MaCongTac,NhanVienID,ChucVuID,NgayBatDau,NgayKetThuc,DiaDiemCongTac,MucDich,TrangThai")] CongTac congTac)
//         {
//             if (ModelState.IsValid)
//             {
//                 _context.Add(congTac);
//                 await _context.SaveChangesAsync();
//                 return RedirectToAction(nameof(Index));
//             }
//             ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", congTac.ChucVuID);
//             ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", congTac.NhanVienID);
//             return View(congTac);
//         }*/

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,MaCongTac,NhanVienID,ChucVuID,NgayBatDau,NgayKetThuc,DiaDiemCongTac,MucDich,TrangThai")] CongTac congTac)
//        {
//            if (ModelState.IsValid)
//            {
//                // Kiểm tra ngày bắt đầu và ngày kết thúc
//                if (congTac.NgayBatDau >= congTac.NgayKetThuc)
//                {
//                    ModelState.AddModelError("", "Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
//                    ViewData["ChucVuID"] = new SelectList(_context.ChucVu.Select(c => new SelectListItem { Text = c.TenChucVu, Value = c.ID.ToString() }), "Value", "Text", congTac.ChucVuID);
//                    ViewData["NhanVienID"] = new SelectList(_context.NhanVien.Select(n => new SelectListItem { Text = n.TenNhanVien, Value = n.ID.ToString() }), "Value", "Text", congTac.NhanVienID);
//                    return View(congTac);
//                }

//                // Kiểm tra xem có ngày trùng lặp không
//                if (_context.CongTac.Any(c => c.NhanVienID == congTac.NhanVienID &&
//                                                ((congTac.NgayBatDau >= c.NgayBatDau && congTac.NgayBatDau <= c.NgayKetThuc) ||
//                                                (congTac.NgayKetThuc >= c.NgayBatDau && congTac.NgayKetThuc <= c.NgayKetThuc))))
//                {
//                    ModelState.AddModelError("", "Ngày bắt đầu hoặc ngày kết thúc đã trùng với một công tác khác của nhân viên này.");
//                    ViewData["ChucVuID"] = new SelectList(_context.ChucVu.Select(c => new SelectListItem { Text = c.TenChucVu, Value = c.ID.ToString() }), "Value", "Text", congTac.ChucVuID);
//                    ViewData["NhanVienID"] = new SelectList(_context.NhanVien.Select(n => new SelectListItem { Text = n.TenNhanVien, Value = n.ID.ToString() }), "Value", "Text", congTac.NhanVienID);
//                    return View(congTac);
//                }

//                _context.Add(congTac);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu.Select(c => new SelectListItem { Text = c.TenChucVu, Value = c.ID.ToString() }), "Value", "Text", congTac.ChucVuID);
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien.Select(n => new SelectListItem { Text = n.TenNhanVien, Value = n.ID.ToString() }), "Value", "Text", congTac.NhanVienID);
//            return View(congTac);
//        }
//        public string GenerateMaCongTac()
//        {
//            string maCongTac = "";
//            Random random = new Random();
//            bool duplicateFound = true;

//            while (duplicateFound)
//            {
//                // Sinh mã nhân viên ngẫu nhiên (ví dụ: NV0001)
//                maCongTac = "CT" + random.Next(1000, 9999);

//                // Kiểm tra xem mã nhân viên đã tồn tại trong cơ sở dữ liệu chưa
//                var existingCongTac = _context.CongTac.FirstOrDefault(nv => nv.MaCongTac == maCongTac);

//                if (existingCongTac == null)
//                {
//                    duplicateFound = false;
//                }
//            }

//            return maCongTac;
//        }

//        // GET: Admin/CongTac/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.CongTac == null)
//            {
//                return NotFound();
//            }

//            var congTac = await _context.CongTac.FindAsync(id);
//            if (congTac == null)
//            {
//                return NotFound();
//            }
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", congTac.ChucVuID);
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", congTac.NhanVienID);
//            return View(congTac);
//        }

//        // POST: Admin/CongTac/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,MaCongTac,NhanVienID,ChucVuID,NgayBatDau,NgayKetThuc,DiaDiemCongTac,MucDich,TrangThai")] CongTac congTac)
//        {
//            if (id != congTac.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(congTac);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CongTacExists(congTac.ID))
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
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", congTac.ChucVuID);
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", congTac.NhanVienID);
//            return View(congTac);
//        }

//        // GET: Admin/CongTac/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.CongTac == null)
//            {
//                return NotFound();
//            }

//            var congTac = await _context.CongTac
//                .Include(c => c.ChucVu)
//                .Include(c => c.NhanVien)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (congTac == null)
//            {
//                return NotFound();
//            }

//            return View(congTac);
//        }

//        // POST: Admin/CongTac/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.CongTac == null)
//            {
//                return Problem("Entity set 'QuanlynhansuDbContext.CongTac'  is null.");
//            }
//            var congTac = await _context.CongTac.FindAsync(id);
//            if (congTac != null)
//            {
//                _context.CongTac.Remove(congTac);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool CongTacExists(int id)
//        {
//          return (_context.CongTac?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
