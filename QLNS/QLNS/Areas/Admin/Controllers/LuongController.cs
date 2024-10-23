//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using OfficeOpenXml;
//using QLNS.Models;

//namespace QLNS.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    [Authorize(Roles = "Admin")]
//    public class LuongController : Controller
//    {
       
//        private readonly QuanlynhansuDbContext _context;

//        public LuongController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Admin/Luong
//        public async Task<IActionResult> Index()
//        {
//            var quanlynhansuDbContext = _context.Luong.Include(l => l.ChucVu).Include(l => l.KhenThuong).Include(l => l.KhoanTru).Include(l => l.NhanVien).Include(l => l.PhuCap).Include(l => l.ThoiGianLamViec);
//            return View(await quanlynhansuDbContext.ToListAsync());
//        }

//        // GET: Admin/Luong/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Luong == null)
//            {
//                return NotFound();
//            }

//            var luong = await _context.Luong
//                .Include(l => l.ChucVu)
//                .Include(l => l.KhenThuong)
//                .Include(l => l.KhoanTru)
//                .Include(l => l.NhanVien)

//                .Include(l => l.PhuCap)
//                .Include(l => l.ThoiGianLamViec)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (luong == null)
//            {
//                return NotFound();
//            }

//            return View(luong);
//        }

//        // GET: Admin/Luong/Create
//        public IActionResult Create()
//        {
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu");
//            ViewData["ThangID"] = new SelectList(_context.ThoiGianLamViec, "ID", "Thang");
//            ViewData["LuongCoBanID"] = new SelectList(_context.ChucVu, "ID", "LuongCoBan");
//            ViewData["LyDoKhenThuongID"] = new SelectList(_context.KhenThuong, "ID", "LyDoKhenThuong");
//            ViewData["KhenThuongID"] = new SelectList(_context.KhenThuong, "ID", "TienThuong");
//            ViewData["LyDoKhoanTruID"] = new SelectList(_context.KhoanTru, "ID", "LyDoKhoanTru");
//            ViewData["KhoanTruID"] = new SelectList(_context.KhoanTru, "ID", "SoTienKhoanTru");
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien");
//            ViewData["TenPhuCapID"] = new SelectList(_context.PhuCap, "ID", "TenPhuCap");
//            ViewData["PhuCapID"] = new SelectList(_context.PhuCap, "ID", "SoTienPhuCap");
//            ViewData["ThoiGianLamViecID"] = new SelectList(_context.ThoiGianLamViec, "ID", "SoNgayCong");
//            return View();
//        }

//        // POST: Admin/Luong/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,NhanVienID,ThangID,ThoiGianLamViecID,LuongCoBanID,TinhTrangLuong,TongThuNhap,PhuongThucThanhToan,NgayThanhToan,ChucVuID,LyDoKhoanTruID,KhoanTruID,LyDoKhenThuongID,KhenThuongID,TenPhuCapID,PhuCapID")] Luong luong)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(luong);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", luong.ChucVuID);
//            ViewData["ThangID"] = new SelectList(_context.ThoiGianLamViec, "ID", "Thang",luong.ThoiGianLamViecID);
//            ViewData["LuongCoBanID"] = new SelectList(_context.ChucVu, "ID", "LuongCoBan", luong.ChucVuID);
//            ViewData["LyDoKhenThuongID"] = new SelectList(_context.KhenThuong, "ID", "LyDoKhenThuong", luong.KhenThuongID);
//            ViewData["KhenThuongID"] = new SelectList(_context.KhenThuong, "ID", "TienThuong", luong.KhenThuongID);
//            ViewData["LyDoKhoanTruID"] = new SelectList(_context.KhoanTru, "ID", "LyDoKhoanTru", luong.KhoanTruID);
//            ViewData["KhoanTruID"] = new SelectList(_context.KhoanTru, "ID", "SoTienKhoanTru", luong.KhoanTruID);
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", luong.NhanVienID);
//            ViewData["TenPhuCapID"] = new SelectList(_context.PhuCap, "ID", "TenPhuCap",luong.TenPhuCapID);
//            ViewData["PhuCapID"] = new SelectList(_context.PhuCap, "ID", "SoTienPhuCap", luong.PhuCapID);
//            ViewData["ThoiGianLamViecID"] = new SelectList(_context.ThoiGianLamViec, "ID", "SoNgayCong", luong.ThoiGianLamViecID);
//            return View(luong);
//        }

//        public IActionResult GetThang(int NhanVienID)
//        {
//            var thoiGianLamViecList = _context.ThoiGianLamViec.Where(t => t.NhanVienID == NhanVienID).ToList();

//            if (thoiGianLamViecList != null && thoiGianLamViecList.Any())
//            {
//                var thangList = thoiGianLamViecList.Select(t => new { id = t.ID, thang = t.Thang }).ToList();
//                return Json(thangList); // Trả về dữ liệu dưới dạng JSON
//            }
//            else
//            {
//                return Json(null); // Trả về null nếu không tìm thấy thông tin về số ngày công
//            }
//        }





//        public IActionResult GetSoNgayCong(int NhanVienID, int Thang)
//        {
//            var thoiGianLamViec = _context.ThoiGianLamViec.FirstOrDefault(t => t.NhanVienID == NhanVienID && t.Thang == Thang);
//            if (thoiGianLamViec != null)
//            {
//                var soNgayCong = new { id = thoiGianLamViec.ID, soNgayCong = thoiGianLamViec.SoNgayCong };
//                return Json(soNgayCong); // Trả về dữ liệu dưới dạng JSON
//            }
//            else
//            {
//                return Json(null); // Trả về null nếu không tìm thấy thông tin về số ngày công cho tháng đó của nhân viên
//            }
//        }
//        public IActionResult GetLuongCoBan(int ChucVuID)
//        {
//            var chucVu = _context.ChucVu.FirstOrDefault(t => t.ID == ChucVuID);
//            if (chucVu != null)
//            {
//                var luongCoBan = new { id = chucVu.ID, luongCoBan = chucVu.LuongCoBan };
//                return Json(luongCoBan); // Trả về dữ liệu dưới dạng JSON
//            }
//            else
//            {
//                return Json(null); // Trả về null nếu không tìm thấy thông tin về số ngày công
//            }
//        }
//        public IActionResult GetPhuCap(int PhuCapID)
//        {
//            var tenPhuCap = _context.PhuCap.FirstOrDefault(t => t.ID == PhuCapID);
//            if (tenPhuCap != null)
//            {
//                var phuCap = new { id = tenPhuCap.ID, phuCap = tenPhuCap.SoTienPhuCap };
//                return Json(phuCap); // Trả về dữ liệu dưới dạng JSON
//            }
//            else
//            {
//                return Json(null); // Trả về null nếu không tìm thấy thông tin về số ngày công
//            }
//        }
//        public IActionResult GetKhenThuong(int KhenThuongID)
//        {
//            var lyDoKhenThuong = _context.KhenThuong.FirstOrDefault(t => t.ID == KhenThuongID);
//            if (lyDoKhenThuong != null)
//            {
//                var khenThuong = new { id = lyDoKhenThuong.ID, khenThuong = lyDoKhenThuong.TienThuong };
//                return Json(khenThuong); // Trả về dữ liệu dưới dạng JSON
//            }
//            else
//            {
//                return Json(null); // Trả về null nếu không tìm thấy thông tin về số ngày công
//            }
//        }
//        public IActionResult GetKhoanTru(int KhoanTruID)
//        {
//            var lyDoKhoanTru = _context.KhoanTru.FirstOrDefault(t => t.ID == KhoanTruID);
//            if (lyDoKhoanTru != null)
//            {
//                var khoanTru = new { id = lyDoKhoanTru.ID, khoanTru = lyDoKhoanTru.SoTienKhoanTru };
//                return Json(khoanTru); // Trả về dữ liệu dưới dạng JSON
//            }
//            else
//            {
//                return Json(null); // Trả về null nếu không tìm thấy thông tin về số ngày công
//            }
//        }
//        // GET: Admin/Luong/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Luong == null)
//            {
//                return NotFound();
//            }

//            var luong = await _context.Luong.FindAsync(id);
//            if (luong == null)
//            {
//                return NotFound();
//            }
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", luong.ChucVuID);
//            ViewData["ThangID"] = new SelectList(_context.ThoiGianLamViec, "ID", "Thang", luong.ThoiGianLamViecID);
//            ViewData["LuongCoBanID"] = new SelectList(_context.ChucVu, "ID", "LuongCoBan", luong.ChucVuID);
//            ViewData["LyDoKhenThuongID"] = new SelectList(_context.KhenThuong, "ID", "LyDoKhenThuong", luong.KhenThuongID);

//            ViewData["KhenThuongID"] = new SelectList(_context.KhenThuong, "ID", "TienThuong", luong.KhenThuongID);
//            ViewData["LyDoKhoanTruID"] = new SelectList(_context.KhoanTru, "ID", "LyDoKhoanTru", luong.KhoanTruID);
//            ViewData["KhoanTruID"] = new SelectList(_context.KhoanTru, "ID", "SoTienKhoanTru", luong.KhoanTruID);
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", luong.NhanVienID);
//            ViewData["TenPhuCapID"] = new SelectList(_context.PhuCap, "ID", "TenPhuCap", luong.TenPhuCapID);
//            ViewData["PhuCapID"] = new SelectList(_context.PhuCap, "ID", "SoTienPhuCap", luong.PhuCapID);
//            ViewData["ThoiGianLamViecID"] = new SelectList(_context.ThoiGianLamViec, "ID", "SoNgayCong", luong.ThoiGianLamViecID);
//            return View(luong);
//        }

//        // POST: Admin/Luong/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,NhanVienID,ThangID,ThoiGianLamViecID,LuongCoBanID,TinhTrangLuong,TongThuNhap,PhuongThucThanhToan,NgayThanhToan,ChucVuID,LyDoKhoanTruID,KhoanTruID,LyDoKhenThuongID,KhenThuongID,TenPhuCapID,PhuCapID")] Luong luong)
//        {
//            if (id != luong.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(luong);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!LuongExists(luong.ID))
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
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", luong.ChucVuID);
//            ViewData["ThangID"] = new SelectList(_context.ThoiGianLamViec, "ID", "Thang", luong.ThoiGianLamViecID);
//            ViewData["LuongCoBanID"] = new SelectList(_context.ChucVu, "ID", "LuongCoBan", luong.ChucVuID);
//            ViewData["LyDoKhenThuongID"] = new SelectList(_context.KhenThuong, "ID", "LyDoKhenThuong", luong.KhenThuongID);
//            ViewData["KhenThuongID"] = new SelectList(_context.KhenThuong, "ID", "TienThuong", luong.KhenThuongID);
//            ViewData["LyDoKhoanTruID"] = new SelectList(_context.KhoanTru, "ID", "LyDoKhoanTru", luong.KhoanTruID);
//            ViewData["KhoanTruID"] = new SelectList(_context.KhoanTru, "ID", "SoTienKhoanTru", luong.KhoanTruID);
//            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "ID", "TenNhanVien", luong.NhanVienID);
//            ViewData["TenPhuCapID"] = new SelectList(_context.PhuCap, "ID", "TenPhuCap", luong.TenPhuCapID);
//            ViewData["PhuCapID"] = new SelectList(_context.PhuCap, "ID", "SoTienPhuCap", luong.PhuCapID);
//            ViewData["ThoiGianLamViecID"] = new SelectList(_context.ThoiGianLamViec, "ID", "SoNgayCong", luong.ThoiGianLamViecID);
//            return View(luong);
//        }

//        // GET: Admin/Luong/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Luong == null)
//            {
//                return NotFound();
//            }

//            var luong = await _context.Luong
//                .Include(l => l.ChucVu)
//                .Include(l => l.KhenThuong)
//                .Include(l => l.KhoanTru)
//                .Include(l => l.NhanVien)

//                .Include(l => l.PhuCap)
//                .Include(l => l.ThoiGianLamViec)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (luong == null)
//            {
//                return NotFound();
//            }

//            return View(luong);
//        }

//        // POST: Admin/Luong/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Luong == null)
//            {
//                return Problem("Entity set 'QuanlynhansuDbContext.Luong'  is null.");
//            }
//            var luong = await _context.Luong.FindAsync(id);
//            if (luong != null)
//            {
//                _context.Luong.Remove(luong);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }
//        public async Task<IActionResult> ExportLuongToExcel()
//        {
//            var luongs = await _context.Luong
//          .Include(l => l.NhanVien)
//        .Include(l => l.ThoiGianLamViec)

//        .Include(l => l.ChucVu)
//        .Include(l => l.KhenThuong)
//        .Include(l => l.KhoanTru)
//        .Include(l => l.PhuCap)
//        .ToListAsync();

//            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

//            using (var package = new ExcelPackage())
//            {
//                var worksheet = package.Workbook.Worksheets.Add("Luong");

//                worksheet.Cells["A1:R1"].Style.Font.Bold = true;

//                worksheet.Cells["A1"].Value = "ID";
//                worksheet.Cells["B1"].Value = "Nhân Viên";
//                worksheet.Cells["C1"].Value = "Thời Gian Làm Việc";
//                worksheet.Cells["D1"].Value = "Lương Cơ Bản";
//                worksheet.Cells["E1"].Value = "Tình Trạng Lương";
//                worksheet.Cells["F1"].Value = "Tổng Thu Nhập";
//                worksheet.Cells["G1"].Value = "Phương Thức Thanh Toán";
//                worksheet.Cells["H1"].Value = "Ngày Thanh Toán";
//                worksheet.Cells["I1"].Value = "Chức Vụ";
//                worksheet.Cells["J1"].Value = "Lý Do Khen Thưởng";
//                worksheet.Cells["K1"].Value = "Khen Thưởng";
//                worksheet.Cells["L1"].Value = "Lý Do Khoản Trừ";
//                worksheet.Cells["M1"].Value = "Khoản Trừ";
//                worksheet.Cells["N1"].Value = "Tháng";
//                worksheet.Cells["O1"].Value = "Phụ Cấp";
      

//                int row = 2;

//                foreach (var luong in luongs)
//                {
//                    worksheet.Cells[row, 1].Value = luong.ID;
//                    worksheet.Cells[row, 2].Value = luong.NhanVien.TenNhanVien;
//                    worksheet.Cells[row, 3].Value = luong.ThoiGianLamViec.Thang;
//                    worksheet.Cells[row, 4].Value = luong.ChucVu.LuongCoBan;
//                    worksheet.Cells[row, 5].Value = luong.TinhTrangLuong;
//                    worksheet.Cells[row, 6].Value = luong.TongThuNhap;
//                    worksheet.Cells[row, 7].Value = luong.PhuongThucThanhToan;
//                    worksheet.Cells[row, 8].Value = luong.NgayThanhToan;
//                    worksheet.Cells[row, 9].Value = luong.ChucVu.TenChucVu;
//                    worksheet.Cells[row, 10].Value = luong.KhenThuong.LyDoKhenThuong;
//                    worksheet.Cells[row, 11].Value = luong.KhenThuong.TienThuong;
//                    worksheet.Cells[row, 12].Value = luong.KhoanTru.LyDoKhoanTru;
//                    worksheet.Cells[row, 13].Value = luong.KhoanTru.SoTienKhoanTru;
//                    worksheet.Cells[row, 14].Value = luong.ThoiGianLamViec.Thang;
//                    worksheet.Cells[row, 15].Value = luong.PhuCap.SoTienPhuCap;
         

//                    row++;
//                }

//                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

//                var stream = new MemoryStream();
//                package.SaveAs(stream);
//                stream.Position = 0;

//                string excelName = $"Luong_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";

//                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
//            }
//        }

//        private bool LuongExists(int id)
//        {
//            return (_context.Luong?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
