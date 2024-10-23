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
//    public class ThongKeThangController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;

//        public ThongKeThangController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Admin/ThongKeThang
//        public async Task<IActionResult> Index()
//        {
//            return _context.ThongKeThang != null ?
//                        View(await _context.ThongKeThang.ToListAsync()) :
//                        Problem("Entity set 'QuanlynhansuDbContext.ThongKeThang'  is null.");
//        }
      
//        [HttpGet]
//        public IActionResult ExportExcel(int thang, int Nam)
//        {
//            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Đặt LicenseContext

//            var thongKeLuong = _context.Luong
//                    .Where(ct => ct.ThangID == thang && ct.NgayThanhToan.Year == Nam) //Lọc theo tháng được chọn
//                    .GroupBy(ct => ct.NhanVienID)
//                    .Select(g => new ThongKeThang
//                    {
//                        ID = g.Key,
//                        TenNhanVien = g.FirstOrDefault().NhanVien.TenNhanVien,
//                        TenChucVu = g.FirstOrDefault().ChucVu.TenChucVu,
//                        Thang = g.FirstOrDefault().ThangID,
//                        nam = g.FirstOrDefault().NgayThanhToan.Year,
//                        ThucLanh = g.FirstOrDefault().TongThuNhap,
//                        TongDoanhThuThang = g.Sum(ct => ct.TongThuNhap)
//                    })
//                    .ToList();

//            // Tạo file Excel
//            byte[] fileContents;
//            using (var package = new ExcelPackage())
//            {
//                var worksheet = package.Workbook.Worksheets.Add("ThongKeThang");
//                worksheet.Cells["A1:S1"].Style.Font.Bold = true;
//                // Đặt tên cho các cột
//                worksheet.Cells[1, 1].Value = "ID";
//                worksheet.Cells[1, 2].Value = "Tên Nhân Viên";
//                worksheet.Cells[1, 3].Value = "Chức Vụ";
//                worksheet.Cells[1, 4].Value = "Tháng";
//                worksheet.Cells[1, 5].Value = "Năm";
//                worksheet.Cells[1, 6].Value = "Thực Lãnh";

//                // Lấy dữ liệu cho từng cột
//                int row = 2;
//                decimal tongDoanhThuThang = 0; // Khởi tạo biến tổng doanh thu tháng

//                foreach (var item in thongKeLuong)
//                {
//                    worksheet.Cells[row, 1].Value = item.ID;
//                    worksheet.Cells[row, 2].Value = item.TenNhanVien;
//                    worksheet.Cells[row, 3].Value = item.TenChucVu;
//                    worksheet.Cells[row, 4].Value = item.Thang;
//                    worksheet.Cells[row, 5].Value = item.nam;
//                    worksheet.Cells[row, 6].Value = item.nam;
//                    tongDoanhThuThang += (decimal)item.TongDoanhThuThang; // Chuyển đổi kiểu và cộng tổng doanh thu tháng
                   
//                    row++;
//                }
//                worksheet.Cells[row, 3].Value = "Tổng Doanh Thu Tháng:";
//                worksheet.Cells[row, 5].Value = tongDoanhThuThang;
//                // Ghi tổng doanh thu tháng vào dòng tiếp theo

//                fileContents = package.GetAsByteArray();
//            }
//            /*string fileName = $"ThongKeThang_{thang}.xlsx"; // Tạo tên file dựa trên tháng*/
//            // Trả về file Excel
//            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"ThongKeThang_{thang}.xlsx");
//        }
//        [HttpGet]
//        public IActionResult ThongKeThang(int thang, int Nam)
//        {
//            try
//            {
//                var thongKeLuong = _context.Luong
//                    .Where(ct => ct.ThangID == thang && ct.NgayThanhToan.Year == Nam) //Lọc theo tháng được chọn
//                    .GroupBy(ct => ct.NhanVienID)

//                    .Select(g => new ThongKeThang
//                    {
//                        ID = g.Key,
//                        TenNhanVien = g.FirstOrDefault().NhanVien.TenNhanVien,
//                        TenChucVu = g.FirstOrDefault().ChucVu.TenChucVu,
//                        Thang = g.FirstOrDefault().ThangID,
//                        nam = g.FirstOrDefault().NgayThanhToan.Year,
//                        ThucLanh = g.FirstOrDefault().TongThuNhap,
//                        TongDoanhThuThang = g.Sum(ct => ct.TongThuNhap)
//                    })
//                    .ToList();

//                return View("ThongKeThang", thongKeLuong);
//            }
//            catch (Exception ex)
//            {
//                TempData["Loi"] = $"Lỗi khi thực hiện thống kê doanh thu: {ex.Message}";
//                return RedirectToAction("Index", "ThongKeThang");
//            }
//        }
//        /* [HttpGet]
//         public IActionResult ThongKeDoanhThu()
//         {
//             try
//             {
//                 var thongKeDonHang = _context.DatHang_ChiTiet
//                     .GroupBy(ct => ct.SanPhamID)
//                     .Select(g => new ThongKeDoanhThu
//                     {
//                         MaSanPham = g.Key,
//                         TenSanPham = g.FirstOrDefault().SanPham.TenSanPham,
//                         TongSoLuong = g.Sum(ct => ct.SoLuong),
//                         TongDoanhThu = g.Sum(ct => ct.DonGia * ct.SoLuong)
//                     })
//                     .ToList();

//                 return View("ThongKeDoanhThu", thongKeDonHang);
//             }
//             catch (Exception ex)
//             {
//                 TempData["Loi"] = $"Lỗi khi thực hiện thống kê doanh thu: {ex.Message}";
//                 return RedirectToAction("Index", "Home");
//             }
//         }*/
//        // GET: Admin/ThongKeThang/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.ThongKeThang == null)
//            {
//                return NotFound();
//            }

//            var thongKeThang = await _context.ThongKeThang
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (thongKeThang == null)
//            {
//                return NotFound();
//            }

//            return View(thongKeThang);
//        }

//        // GET: Admin/ThongKeThang/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Admin/ThongKeThang/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,TenNhanVien,TenChucVu,Thang,ThucLanh,TongDoanhThuThang")] ThongKeThang thongKeThang)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(thongKeThang);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(thongKeThang);
//        }

//        // GET: Admin/ThongKeThang/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.ThongKeThang == null)
//            {
//                return NotFound();
//            }

//            var thongKeThang = await _context.ThongKeThang.FindAsync(id);
//            if (thongKeThang == null)
//            {
//                return NotFound();
//            }
//            return View(thongKeThang);
//        }

//        // POST: Admin/ThongKeThang/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,TenNhanVien,TenChucVu,Thang,ThucLanh,TongDoanhThuThang")] ThongKeThang thongKeThang)
//        {
//            if (id != thongKeThang.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(thongKeThang);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ThongKeThangExists(thongKeThang.ID))
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
//            return View(thongKeThang);
//        }

//        // GET: Admin/ThongKeThang/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.ThongKeThang == null)
//            {
//                return NotFound();
//            }

//            var thongKeThang = await _context.ThongKeThang
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (thongKeThang == null)
//            {
//                return NotFound();
//            }

//            return View(thongKeThang);
//        }

//        // POST: Admin/ThongKeThang/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.ThongKeThang == null)
//            {
//                return Problem("Entity set 'QuanlynhansuDbContext.ThongKeThang'  is null.");
//            }
//            var thongKeThang = await _context.ThongKeThang.FindAsync(id);
//            if (thongKeThang != null)
//            {
//                _context.ThongKeThang.Remove(thongKeThang);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ThongKeThangExists(int id)
//        {
//            return (_context.ThongKeThang?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
