//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using QLNS.Models;

//namespace QLNS.Controllers
//{
//    public class NhanVienController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        public NhanVienController(QuanlynhansuDbContext context, IHttpContextAccessor httpContextAccessor)
//        {
//            _context = context;
//            _httpContextAccessor = httpContextAccessor;
//        }
//      /* public async Task<IActionResult> Index()
//        {

//            var qLNSDbContext = _context.NhanVien.Include(n => n.BangCap).Include(n => n.ChucVu).Include(n => n.ChuyenMon).Include(n => n.DanToc).Include(n => n.PhongBan).Include(n => n.QuocTich).Include(n => n.TonGiao).Include(n => n.TrinhDo);
//            return View(await qLNSDbContext.ToListAsync());
//        }*/
//       public async Task<IActionResult> Index()
//        {
//            // Lấy tên người dùng từ HttpContext
//            string userName = HttpContext.User.Identity.Name;

//            // Lấy thông tin của người dùng hiện tại
//            var currentUser = await _context.NhanVien
//                                             .Include(n => n.BangCap)
//                                             .Include(n => n.ChucVu)
//                                             .Include(n => n.ChuyenMon)
//                                             .Include(n => n.DanToc)
//                                             .Include(n => n.PhongBan)
                                      
//                                             .Include(n => n.QuocTich)
//                                             .Include(n => n.TonGiao)
//                                             .Include(n => n.TrinhDo)
//                                             .Where(n => n.TenNhanVien == userName)
//                                             .ToListAsync();

//            if (currentUser == null)
//            {
//                return NotFound(); // Trả về trang 404 nếu không tìm thấy thông tin của người dùng
//            }

//            return View(  currentUser ); // Truyền thông tin của người dùng vào view
//        }

//        // GET: NhanVien/Details/5
//        public async Task<IActionResult> Details(string? successMessage)
//        {
//            // Lấy tên người đăng nhập từ HttpContext.User
//            var userName = User.Identity.Name;

//            // Tìm kiếm thông tin của người dùng đăng nhập trong cơ sở dữ liệu
//            var nhanVien = await _context.NhanVien
//                .Include(n => n.BangCap)
//                .Include(n => n.ChucVu)
//                .Include(n => n.ChuyenMon)
//                .Include(n => n.DanToc)
//                .Include(n => n.PhongBan)
//                .Include(n => n.QuocTich)
//                .Include(n => n.TonGiao)
//                .Include(n => n.TrinhDo)
//                .FirstOrDefaultAsync(n => n.TenNhanVien == userName);

//            // Nếu không tìm thấy thông tin người dùng, trả về 404
//            if (nhanVien == null)
//            {
//                return NotFound();
//            }

//            // Nếu tìm thấy, trả về view với thông tin người dùng
//            return View(nhanVien);
//        }

//        // GET: NhanVien/Create
//        public IActionResult Create()
//        {
//            ViewData["BangCapID"] = new SelectList(_context.BangCap, "ID", "TenBangCap");
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu");
//            ViewData["ChuyenMonID"] = new SelectList(_context.ChuyenMon, "ID", "TenChuyenMon");
//            ViewData["DanTocID"] = new SelectList(_context.DanToc, "ID", "TenDanToc");
       
//            ViewData["PhongBanId"] = new SelectList(_context.PhongBan, "ID", "TenPhongBan");
//            ViewData["QuocTichID"] = new SelectList(_context.QuocTich, "ID", "TenQuocTich");
//            ViewData["TonGiaoID"] = new SelectList(_context.TonGiao, "ID", "TenTonGiao");
//            ViewData["TrinhDoID"] = new SelectList(_context.TrinhDo, "ID", "TenTrinhDo");
//            return View();
//        }

//        // POST: NhanVien/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,MaNhanVien,TenNhanVien,HinhAnh,GioiTinh,NgaySinh,SDT,CanCuocCongDan,Email,NoiCapCanCuoc,NgayCapCanCuoc,DiaChi,BangCapID,ChucVuID,ChuyenMonID,DanTocID,PhongBanId,QuocTichID,TonGiaoID,TrinhDoID")] NhanVien nhanVien)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(nhanVien);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["BangCapID"] = new SelectList(_context.BangCap, "ID", "TenBangCap", nhanVien.BangCapID);
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", nhanVien.ChucVuID);
//            ViewData["ChuyenMonID"] = new SelectList(_context.ChuyenMon, "ID", "TenChuyenMon", nhanVien.ChuyenMonID);
//            ViewData["DanTocID"] = new SelectList(_context.DanToc, "ID", "TenDanToc", nhanVien.DanTocID);
       
//            ViewData["PhongBanId"] = new SelectList(_context.PhongBan, "ID", "TenPhongBan", nhanVien.PhongBanId);
//            ViewData["QuocTichID"] = new SelectList(_context.QuocTich, "ID", "TenQuocTich", nhanVien.QuocTichID);
//            ViewData["TonGiaoID"] = new SelectList(_context.TonGiao, "ID", "TenTonGiao", nhanVien.TonGiaoID);
//            ViewData["TrinhDoID"] = new SelectList(_context.TrinhDo, "ID", "TenTrinhDo", nhanVien.TrinhDoID);
//            return View(nhanVien);
//        }

//        // GET: NhanVien/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.NhanVien == null)
//            {
//                return NotFound();
//            }

//            var nhanVien = await _context.NhanVien.FindAsync(id);
//            if (nhanVien == null)
//            {
//                return NotFound();
//            }
//            ViewData["BangCapID"] = new SelectList(_context.BangCap, "ID", "TenBangCap", nhanVien.BangCapID);
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", nhanVien.ChucVuID);
//            ViewData["ChuyenMonID"] = new SelectList(_context.ChuyenMon, "ID", "TenChuyenMon", nhanVien.ChuyenMonID);
//            ViewData["DanTocID"] = new SelectList(_context.DanToc, "ID", "TenDanToc", nhanVien.DanTocID);
        
//            ViewData["PhongBanId"] = new SelectList(_context.PhongBan, "ID", "TenPhongBan", nhanVien.PhongBanId);
//            ViewData["QuocTichID"] = new SelectList(_context.QuocTich, "ID", "TenQuocTich", nhanVien.QuocTichID);
//            ViewData["TonGiaoID"] = new SelectList(_context.TonGiao, "ID", "TenTonGiao", nhanVien.TonGiaoID);
//            ViewData["TrinhDoID"] = new SelectList(_context.TrinhDo, "ID", "TenTrinhDo", nhanVien.TrinhDoID);
//            return View(nhanVien);
//        }

//        // POST: NhanVien/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,MaNhanVien,TenNhanVien,HinhAnh,GioiTinh,NgaySinh,SDT,CanCuocCongDan,Email,NoiCapCanCuoc,NgayCapCanCuoc,DiaChi,BangCapID,ChucVuID,ChuyenMonID,DanTocID,PhongBanId,QuocTichID,TonGiaoID,TrinhDoID")] NhanVien nhanVien)
//        {
//            if (id != nhanVien.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(nhanVien);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!NhanVienExists(nhanVien.ID))
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
//            ViewData["BangCapID"] = new SelectList(_context.BangCap, "ID", "TenBangCap", nhanVien.BangCapID);
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", nhanVien.ChucVuID);
//            ViewData["ChuyenMonID"] = new SelectList(_context.ChuyenMon, "ID", "TenChuyenMon", nhanVien.ChuyenMonID);
//            ViewData["DanTocID"] = new SelectList(_context.DanToc, "ID", "TenDanToc", nhanVien.DanTocID);
   
//            ViewData["PhongBanId"] = new SelectList(_context.PhongBan, "ID", "TenPhongBan", nhanVien.PhongBanId);
//            ViewData["QuocTichID"] = new SelectList(_context.QuocTich, "ID", "TenQuocTich", nhanVien.QuocTichID);
//            ViewData["TonGiaoID"] = new SelectList(_context.TonGiao, "ID", "TenTonGiao", nhanVien.TonGiaoID);
//            ViewData["TrinhDoID"] = new SelectList(_context.TrinhDo, "ID", "TenTrinhDo", nhanVien.TrinhDoID);
//            return View(nhanVien);
//        }

//        // GET: NhanVien/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.NhanVien == null)
//            {
//                return NotFound();
//            }

//            var nhanVien = await _context.NhanVien
//                .Include(n => n.BangCap)
//                .Include(n => n.ChucVu)
//                .Include(n => n.ChuyenMon)
//                .Include(n => n.DanToc)
    
//                .Include(n => n.PhongBan)
//                .Include(n => n.QuocTich)
//                .Include(n => n.TonGiao)
//                .Include(n => n.TrinhDo)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (nhanVien == null)
//            {
//                return NotFound();
//            }

//            return View(nhanVien);
//        }
       
//        // POST: NhanVien/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.NhanVien == null)
//            {
//                return Problem("Entity set 'QuanlynhansuDbContext.NhanVien'  is null.");
//            }
//            var nhanVien = await _context.NhanVien.FindAsync(id);
//            if (nhanVien != null)
//            {
//                _context.NhanVien.Remove(nhanVien);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool NhanVienExists(int id)
//        {
//          return (_context.NhanVien?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
