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
//    public class ThongKeNamController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;

//        public ThongKeNamController(QuanlynhansuDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Admin/ThongKeNam
//        public async Task<IActionResult> Index()
//        {
//              return _context.ThongKeNam != null ? 
//                          View(await _context.ThongKeNam.ToListAsync()) :
//                          Problem("Entity set 'QuanlynhansuDbContext.ThongKeNam'  is null.");
//        }

//        // GET: Admin/ThongKeNam/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.ThongKeNam == null)
//            {
//                return NotFound();
//            }

//            var thongKeNam = await _context.ThongKeNam
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (thongKeNam == null)
//            {
//                return NotFound();
//            }

//            return View(thongKeNam);
//        }
//        [HttpGet]
//        public IActionResult ExportExcel()
//        {
//            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Đặt LicenseContext

//            var thongKeLuong = _context.Luong
//                    //Lọc theo tháng được chọn
//                    .GroupBy(ct => ct.ThangID)

//                    .Select(g => new ThongKeNam
//                    {
//                        ID = (int)g.Key,
//                        ThangID = g.FirstOrDefault().ThangID,
//                        namID = g.FirstOrDefault().NgayThanhToan.Year,
//                        TongDoanhThuThangID = g.Sum(ct => ct.TongThuNhap),

//                        TongDoanhThuNam = g.Sum(ct => ct.TongThuNhap)
//                    })
//                    .ToList();

//            // Tạo file Excel
//            byte[] fileContents;
//            using (var package = new ExcelPackage())
//            {
//                var worksheet = package.Workbook.Worksheets.Add("ThongKeNam");

//                // Đặt tên cho các cột
//                worksheet.Cells["A1:S1"].Style.Font.Bold = true;
//                worksheet.Cells[1, 1].Value = "ID";
//                worksheet.Cells[1, 2].Value = "Tháng";
//                worksheet.Cells[1, 3].Value = "Năm";
//                worksheet.Cells[1, 4].Value = "Tổng Doanh Thu Tháng";
       


//                // Lấy dữ liệu cho từng cột
//                int row = 2;
//                decimal tongDoanhThuNam = 0; // Khởi tạo biến tổng doanh thu tháng

//                foreach (var item in thongKeLuong)
//                {
//                    worksheet.Cells[row, 1].Value = item.ID;
//                    worksheet.Cells[row, 2].Value = item.ThangID;
//                    worksheet.Cells[row, 3].Value = item.namID;
//                    worksheet.Cells[row, 4].Value = item.TongDoanhThuThangID;
             

//                    tongDoanhThuNam += (decimal)item.TongDoanhThuNam; // Chuyển đổi kiểu và cộng tổng doanh thu tháng

//                    row++;
//                }
//                worksheet.Cells[row, 1].Value = "Tổng Doanh Thu Năm:";
//                worksheet.Cells[row, 4].Value = tongDoanhThuNam;
//                // Ghi tổng doanh thu tháng vào dòng tiếp theo

//                fileContents = package.GetAsByteArray();
//            }
//            /*string fileName = $"ThongKeThang_{thang}.xlsx"; // Tạo tên file dựa trên tháng*/
//            // Trả về file Excel
//            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"ThongKeNam.xlsx");
//        }
//        [HttpGet]
//        public IActionResult ThongKeNam(int Nam)
//        {
//            try
//            {
//                var thongKeLuong = _context.Luong
//                    //Lọc theo tháng được chọn
//                    .Where(ct => ct.NgayThanhToan.Year == Nam) //Lọc theo tháng được chọn
//                    .GroupBy(ct => ct.ThangID )

//                    .Select(g => new ThongKeNam
//                    {
//                        ID = (int)g.Key,
//                        ThangID = g.FirstOrDefault().ThangID,
//                        namID = g.FirstOrDefault().NgayThanhToan.Year,
//                        TongDoanhThuThangID = g.Sum(ct => ct.TongThuNhap),

//                        TongDoanhThuNam = g.Sum(ct => ct.TongThuNhap)
//                    })
//                    .ToList();

//                return View("ThongKeNam", thongKeLuong);
//            }
//            catch (Exception ex)
//            {
//                TempData["Loi"] = $"Lỗi khi thực hiện thống kê doanh thu: {ex.Message}";
//                return RedirectToAction("Index", "ThongKeNam");
//            }
//        }
//        // Định nghĩa lớp ThongKeNamEntity


//        /*        [HttpGet]
//                public IActionResult ThongKeNam()
//                {
//                    try
//                    {
//                        var thongKeLuong = _context.Luong
//                            .GroupBy(ct => ct.ThangID)
//                            .Select(g => new ThongKeNam
//                            {
//                                ID = (int)g.Key,
//                                ThangID = g.FirstOrDefault().ThangID,
//                                TongDoanhThuThangID = g.Sum(ct => ct.TongThuNhap),
//                                TongDoanhThuNam = g.Sum(ct => ct.TongThuNhap)
//                            })
//                            .ToList();

//                        foreach (var thongKe in thongKeLuong)
//                        {
//                            var existingThongKe = _context.ThongKeNam.FirstOrDefault(t => t.ThangID == thongKe.ThangID);

//                            if (existingThongKe != null)
//                            {
//                                existingThongKe.TongDoanhThuThangID = thongKe.TongDoanhThuThangID;
//                                existingThongKe.TongDoanhThuNam = thongKe.TongDoanhThuNam;
//                                _context.ThongKeNam.Update(existingThongKe); // Cập nhật dữ liệu
//                            }
//                            else
//                            {
//                                _context.ThongKeNam.Add(thongKe); // Thêm dữ liệu mới
//                            }
//                        }

//                        _context.SaveChanges(); // Lưu các thay đổi vào CSDL

//                        return View("ThongKeNam", thongKeLuong);
//                    }
//                    catch (Exception ex)
//                    {
//                        TempData["Loi"] = $"Lỗi khi thực hiện thống kê doanh thu: {ex.Message}";
//                        return RedirectToAction("Index", "ThongKeNam");
//                    }
//                }
//        */



//        // GET: Admin/ThongKeNam/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Admin/ThongKeNam/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,ThangID,TongDoanhThuThangID,TongDoanhThuNang")] ThongKeNam thongKeNam)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(thongKeNam);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(thongKeNam);
//        }

//        // GET: Admin/ThongKeNam/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.ThongKeNam == null)
//            {
//                return NotFound();
//            }

//            var thongKeNam = await _context.ThongKeNam.FindAsync(id);
//            if (thongKeNam == null)
//            {
//                return NotFound();
//            }
//            return View(thongKeNam);
//        }

//        // POST: Admin/ThongKeNam/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,ThangID,TongDoanhThuThangID,TongDoanhThuNang")] ThongKeNam thongKeNam)
//        {
//            if (id != thongKeNam.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(thongKeNam);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ThongKeNamExists(thongKeNam.ID))
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
//            return View(thongKeNam);
//        }

//        // GET: Admin/ThongKeNam/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.ThongKeNam == null)
//            {
//                return NotFound();
//            }

//            var thongKeNam = await _context.ThongKeNam
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (thongKeNam == null)
//            {
//                return NotFound();
//            }

//            return View(thongKeNam);
//        }

//        // POST: Admin/ThongKeNam/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.ThongKeNam == null)
//            {
//                return Problem("Entity set 'QuanlynhansuDbContext.ThongKeNam'  is null.");
//            }
//            var thongKeNam = await _context.ThongKeNam.FindAsync(id);
//            if (thongKeNam != null)
//            {
//                _context.ThongKeNam.Remove(thongKeNam);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ThongKeNamExists(int id)
//        {
//          return (_context.ThongKeNam?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
