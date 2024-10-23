using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;
using BC = BCrypt.Net.BCrypt;
namespace QLNS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NguoiDungController : Controller
    {
        private readonly QuanlynhansuDbContext _context;

        public NguoiDungController(QuanlynhansuDbContext context)
        {
            _context = context;
        }

        // GET: NguoiDung
        public async Task<IActionResult> Index()
        {
            var quanlynhansuDbContext = _context.NguoiDung.Include(t => t.NhanVien);
            return View(await quanlynhansuDbContext.ToListAsync());
        }

        // GET: NguoiDung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NguoiDung == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDung
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        // GET: NguoiDung/Create
        public IActionResult Create()
        {
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien");
            ViewData["EmailID"] = new SelectList(_context.NhanVien, "ID", "Email");
            ViewData["SDTID"] = new SelectList(_context.NhanVien, "ID", "SDT");
            ViewData["DiaChiID"] = new SelectList(_context.NhanVien, "ID", "DiaChi");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EmailID,NhanVienID,SDTID,DiaChiID,TenDangNhap,MatKhau,XacNhanMatKhau,Quyen")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                nguoiDung.MatKhau = BC.HashPassword(nguoiDung.MatKhau);
                nguoiDung.XacNhanMatKhau = BC.HashPassword(nguoiDung.MatKhau);
                _context.Add(nguoiDung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", nguoiDung.NhanVienID);
            ViewData["EmailID"] = new SelectList(_context.NhanVien, "ID", "Email", nguoiDung.NhanVienID);
            ViewData["SDTID"] = new SelectList(_context.NhanVien, "ID", "SDT",nguoiDung.NhanVienID);
            ViewData["DiaChiID"] = new SelectList(_context.NhanVien, "ID", "DiaChi",nguoiDung.NhanVienID);
            return View(nguoiDung);
        }

        // POST: NguoiDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.




        public IActionResult GetEmail(int NhanVienID)
        {
            var email = _context.NhanVien.FirstOrDefault(t => t.ID == NhanVienID);
            if (email != null)
            {
                var emaill = new { id = email.Email, email = email.Email };
                return Json(emaill); // Trả về dữ liệu dưới dạng JSON
            }
            else
            {
                return Json(null); // Trả về null nếu không tìm thấy thông tin về số ngày công
            }
        }
   /*     public IActionResult GetSDT(int NhanVienID)
        {
            var sdt = _context.NhanVien.FirstOrDefault(t => t.ID == NhanVienID);
            if (sdt != null)
            {
                var sdtt = new { id = sdt.SDT, sdt = sdt.SDT };
                return Json(sdtt); // Trả về dữ liệu dưới dạng JSON
            }
            else
            {
                return Json(null); // Trả về null nếu không tìm thấy thông tin về số ngày công
            }
        }*/
        public IActionResult GetSDT(int NhanVienID)
        {
            var nhanVien = _context.NhanVien.FirstOrDefault(t => t.ID == NhanVienID);
            if (nhanVien != null)
            {
                var sDT = new { id = nhanVien.SDT, sdt = nhanVien.SDT };
                return Json(sDT); // Trả về dữ liệu dưới dạng JSON
            }
            else
            {
                return Json(null); // Trả về null nếu không tìm thấy thông tin về số ngày công
            }
        }
        public IActionResult GetDiaChi(int NhanVienID)
        {
            var nhanVien = _context.NhanVien.FirstOrDefault(t => t.ID == NhanVienID);
            if (nhanVien != null)
            {
                var diaChi = new { id = nhanVien.DiaChi, diachi = nhanVien.DiaChi };
                return Json(diaChi); // Trả về dữ liệu dưới dạng JSON
            }
            else
            {
                return Json(null); // Trả về null nếu không tìm thấy thông tin về số ngày công
            }
        }
   
        // GET: NguoiDung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NguoiDung == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDung.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", nguoiDung.NhanVienID);
            ViewData["EmailID"] = new SelectList(_context.NhanVien, "ID", "Email", nguoiDung.EmailID);
            ViewData["SDTID"] = new SelectList(_context.NhanVien, "ID", "SDT", nguoiDung.SDTID);
            ViewData["DiaChiID"] = new SelectList(_context.NhanVien, "ID", "DiaChi", nguoiDung.DiaChiID);
            return View(new NguoiDung_ChinhSua(nguoiDung));
        }


        // POST: NguoiDung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EmailID,NhanVienID,SDTID,DiaChiID,TenDangNhap,MatKhau,XacNhanMatKhau,Quyen")] NguoiDung_ChinhSua nguoiDung)
        {
            if (id != nguoiDung.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var n = await _context.NguoiDung.FindAsync(id);
                    // Giữ nguyên mật khẩu cũ
                    if (nguoiDung.MatKhau == null)
                    {
                        n.ID = nguoiDung.ID;
                        n.NhanVienID = nguoiDung.NhanVienID;
                        n.EmailID = nguoiDung.EmailID;
                        n.SDTID = nguoiDung.SDTID;
                        n.DiaChiID = nguoiDung.DiaChiID;
                        n.TenDangNhap = nguoiDung.TenDangNhap;
                        n.XacNhanMatKhau = n.MatKhau;
                        n.Quyen = (NguoiDung.quyen)nguoiDung.Quyen;
                    }
                    else // Cập nhật mật khẩu mới
                    {
                        n.ID = nguoiDung.ID;
                        n.NhanVienID = nguoiDung.NhanVienID;
                        n.EmailID = nguoiDung.EmailID;
                        n.SDTID = nguoiDung.SDTID;
                        n.DiaChiID = nguoiDung.DiaChiID;
                        n.TenDangNhap = nguoiDung.TenDangNhap;
                        n.MatKhau = BC.HashPassword(nguoiDung.MatKhau);
                        n.XacNhanMatKhau = BC.HashPassword(nguoiDung.MatKhau);
                        n.Quyen = (NguoiDung.quyen)nguoiDung.Quyen;
                    }
                    _context.Update(n);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiDungExists(nguoiDung.ID))
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
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", nguoiDung.NhanVienID);
            ViewData["EmailID"] = new SelectList(_context.NhanVien, "ID", "Email", nguoiDung.EmailID);
            ViewData["SDTID"] = new SelectList(_context.NhanVien, "ID", "SDT", nguoiDung.SDTID);
            ViewData["DiaChiID"] = new SelectList(_context.NhanVien, "ID", "DiaChi", nguoiDung.DiaChiID);
            return View(nguoiDung);
        }

        // GET: NguoiDung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NguoiDung == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDung
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        // POST: NguoiDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NguoiDung == null)
            {
                return Problem("Entity set 'QuanlynhansuDbContext.NguoiDung'  is null.");
            }
            var nguoiDung = await _context.NguoiDung.FindAsync(id);
            if (nguoiDung != null)
            {
                _context.NguoiDung.Remove(nguoiDung);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiDungExists(int id)
        {
            return (_context.NguoiDung?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
