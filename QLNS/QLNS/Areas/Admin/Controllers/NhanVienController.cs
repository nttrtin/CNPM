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
//using Slugify;
//namespace QLNS.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    [Authorize(Roles = "Admin")]
//    public class NhanVienController : Controller
//    {
//        private readonly QuanlynhansuDbContext _context;
//        private readonly IWebHostEnvironment _hostEnvironment;

//        public NhanVienController(QuanlynhansuDbContext context, IWebHostEnvironment hostEnvironment)
//        {
//            _context = context;
//            _hostEnvironment = hostEnvironment;
//        }

//        // GET: NhanVien
//        public async Task<IActionResult> Index()
//        {
//            var quanlynhansuDbContext = _context.NhanVien.Include(n => n.BangCap).Include(n => n.ChucVu).Include(n => n.ChuyenMon).Include(n => n.DanToc).Include(n => n.PhongBan).Include(n => n.QuocTich).Include(n => n.TonGiao).Include(n => n.TrinhDo);
//            return View(await quanlynhansuDbContext.ToListAsync());
//        }

//        // GET: NhanVien/Details/5
//        public async Task<IActionResult> Details(int? id)
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

//        // GET: NhanVien/Create
//        // GET: NhanVien/Create
//        public IActionResult Create()
//        {
//            // Tạo model mới cho việc thêm nhân viên
//            var nhanVien = new NhanVien();

//            // Tạo mã nhân viên ngẫu nhiên và gán vào trường MaNhanVien
//            nhanVien.MaNhanVien = GenerateMaNhanVien();
//            nhanVien.NgaySinh = DateTime.Today;
//            nhanVien.NgayCapCanCuoc = DateTime.Today;
//            ViewData["BangCapID"] = new SelectList(_context.BangCap, "ID", "TenBangCap");
//            ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu");
//            ViewData["ChuyenMonID"] = new SelectList(_context.ChuyenMon, "ID", "TenChuyenMon");
//            ViewData["DanTocID"] = new SelectList(_context.DanToc, "ID", "TenDanToc");
//            ViewData["PhongBanID"] = new SelectList(_context.PhongBan, "ID", "TenPhongBan");
//            ViewData["QuocTichID"] = new SelectList(_context.QuocTich, "ID", "TenQuocTich");
//            ViewData["TonGiaoID"] = new SelectList(_context.TonGiao, "ID", "TenTonGiao");
//            ViewData["TrinhDoID"] = new SelectList(_context.TrinhDo, "ID", "TenTrinhDo");
//            return View(nhanVien);
//        }
//        public IActionResult GetEmail(int NhanVienID)
//        {
//            // Tìm số ngày công của nhân viên dựa trên ID nhân viên và trả về dữ liệu (ví dụ: số ngày công)
//            //var dMTapThe = _context.DMTapThe.Where(t => t.ID == mau11id).FirstOrDefault()?.TenTapThe;
//            var email = _context.NhanVien
//                                             .Where(t => t.ID == NhanVienID)
//                                             .Select(t => t.Email)
//                                             .FirstOrDefault();

//            if (email != null)
//            {
//                var tentapthe = new { id = email, Email = email };
//                return Json(tentapthe); // Trả về dữ liệu dưới dạng JSON
//            }
//            else
//            {
//                return Json(null); // Trả về null nếu không tìm thấy thông tin về số ngày công
//            }
//        }
//        public IActionResult GetChucVu(int NhanVienID)
//        {
//            // Truy vấn nhân viên dựa trên NhanVienID
//            var nhanVien = _context.NhanVien
//                                    .Include(nv => nv.ChucVu) // Kết hợp bảng ChucVu để có thể truy cập tên chức vụ
//                                    .FirstOrDefault(nv => nv.ID == NhanVienID);

//            if (nhanVien != null)
//            {
//                // Tạo một object mới chứa ID và tên chức vụ
//                var tenChucVu = new { id = nhanVien.ChucVu.ID, tenChucVu = nhanVien.ChucVu.TenChucVu };
//                return Json(tenChucVu); // Trả về dữ liệu dưới dạng JSON
//            }
//            else
//            {
//                return Json(null); // Trả về null nếu không tìm thấy thông tin về nhân viên
//            }
//        }
//        public IActionResult GetLuongCoBan(int NhanVienID)
//        {
//            // Truy vấn nhân viên dựa trên NhanVienID
//            var nhanVien = _context.NhanVien
//                                    .Include(nv => nv.ChucVu) // Kết hợp bảng ChucVu để có thể truy cập tên chức vụ
//                                    .FirstOrDefault(nv => nv.ID == NhanVienID);

//            if (nhanVien != null)
//            {
//                // Tạo một object mới chứa ID và tên chức vụ
//                var luongCoBan = new { id = nhanVien.ChucVu.ID, luongCoBan = nhanVien.ChucVu.LuongCoBan };
//                return Json(luongCoBan); // Trả về dữ liệu dưới dạng JSON
//            }
//            else
//            {
//                return Json(null); // Trả về null nếu không tìm thấy thông tin về nhân viên
//            }
//        }
//        // POST: NhanVien/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(int id, [Bind("ID,MaNhanVien,TenNhanVien,DuLieuHinhAnh,GioiTinh,NgaySinh,SDT,CanCuocCongDan,Email,NoiCapCanCuoc,NgayCapCanCuoc,DiaChi,BangCapID,ChucVuID,ChuyenMonID,DanTocID,PhongBanId,QuocTichID,TonGiaoID,TrinhDoID")] NhanVien nhanVien)
//        {
//            // Kiểm tra trùng mã trước khi thêm mới
//            if (!IsDuplicateCode(nhanVien.MaNhanVien))
//            {
//                if (ModelState.IsValid)
//                {
//                    string path = "";
//                    if (nhanVien.DuLieuHinhAnh != null)
//                    {
//                        string wwwRootPath = _hostEnvironment.WebRootPath;
//                        string folder = "/uploads/";
//                        string fileExtension = Path.GetExtension(nhanVien.DuLieuHinhAnh.FileName).ToLower();
//                        string fileName = nhanVien.TenNhanVien;
//                        SlugHelper slug = new SlugHelper();
//                        string fileNameSluged = slug.GenerateSlug(fileName);
//                        path = fileNameSluged + fileExtension;
//                        string physicalPath = Path.Combine(wwwRootPath + folder, fileNameSluged + fileExtension);
//                        using (var fileStream = new FileStream(physicalPath, FileMode.Create))
//                        {
//                            await nhanVien.DuLieuHinhAnh.CopyToAsync(fileStream);
//                        }
//                    }

//                    // Cập nhật đường dẫn vào CSDL
//                    nhanVien.HinhAnh = path ?? null;
             
//                    _context.Add(nhanVien);
//                    await _context.SaveChangesAsync();
//                    return RedirectToAction(nameof(Index));
//                }
//                else
//                {
//                    return View(nhanVien);
//                }
//            }
//            else
//            {
//                ViewData["BangCapID"] = new SelectList(_context.BangCap, "ID", "TenBangCap", nhanVien.BangCapID);
//                ViewData["ChucVuID"] = new SelectList(_context.ChucVu, "ID", "TenChucVu", nhanVien.ChucVuID);
//                ViewData["ChuyenMonID"] = new SelectList(_context.ChuyenMon, "ID", "TenChuyenMon", nhanVien.ChuyenMonID);
//                ViewData["DanTocID"] = new SelectList(_context.DanToc, "ID", "TenDanToc", nhanVien.DanTocID);
//                ViewData["PhongBanID"] = new SelectList(_context.PhongBan, "ID", "TenPhongBan", nhanVien.PhongBanId);
//                ViewData["QuocTichID"] = new SelectList(_context.QuocTich, "ID", "TenQuocTich", nhanVien.QuocTichID);
//                ViewData["TonGiaoID"] = new SelectList(_context.TonGiao, "ID", "TenTonGiao", nhanVien.TonGiaoID);
//                ViewData["TrinhDoID"] = new SelectList(_context.TrinhDo, "ID", "TenTrinhDo", nhanVien.TrinhDoID);
//                ModelState.AddModelError("MaNV", "Mã đã tồn tại. Vui lòng chọn mã khác!");
//                return View(nhanVien);
//            }
//        }
//        public string GenerateMaNhanVien()
//        {
//            string maNhanVien = "";
//            Random random = new Random();
//            bool duplicateFound = true;

//            while (duplicateFound)
//            {
//                // Sinh mã nhân viên ngẫu nhiên (ví dụ: NV0001)
//                maNhanVien = "NV" + random.Next(1000, 9999);

//                // Kiểm tra xem mã nhân viên đã tồn tại trong cơ sở dữ liệu chưa
//                var existingNhanVien = _context.NhanVien.FirstOrDefault(nv => nv.MaNhanVien == maNhanVien);

//                if (existingNhanVien == null)
//                {
//                    duplicateFound = false;
//                }
//            }

//            return maNhanVien;
//        }
//        public bool IsDuplicateCode(string code)
//        {
//            return _context.NhanVien.Any(b => b.MaNhanVien == code);
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
//        public async Task<IActionResult> Edit(int id, [Bind("ID,MaNhanVien,TenNhanVien,DuLieuHinhAnh,GioiTinh,NgaySinh,SDT,CanCuocCongDan,Email,NoiCapCanCuoc,NgayCapCanCuoc,DiaChi,BangCapID,ChucVuID,ChuyenMonID,DanTocID,PhongBanId,QuocTichID,TonGiaoID,TrinhDoID")] NhanVien nhanVien)
//        {
//            if (id != nhanVien.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    string path = "";
//                    // Nếu hình ảnh không bỏ trống thì upload ảnh mới
//                    if (nhanVien.DuLieuHinhAnh != null)
//                    {

//                        string wwwRootPath = _hostEnvironment.WebRootPath;
//                        string folder = "/uploads/";
//                        string fileExtension = Path.GetExtension(nhanVien.DuLieuHinhAnh.FileName).ToLower();
//                        string fileName = nhanVien.TenNhanVien;
//                        SlugHelper slug = new SlugHelper();
//                        string fileNameSluged = slug.GenerateSlug(fileName);
//                        path = fileNameSluged + fileExtension;
//                        string physicalPath = Path.Combine(wwwRootPath + folder, fileNameSluged + fileExtension);
//                        using (var fileStream = new FileStream(physicalPath, FileMode.Create))
//                        {
//                            await nhanVien.DuLieuHinhAnh.CopyToAsync(fileStream);
//                        }
//                    }
//                    _context.Update(nhanVien);
//                    if (string.IsNullOrEmpty(path))
//                        _context.Entry(nhanVien).Property(x => x.HinhAnh).IsModified = false;
//                    else
//                        nhanVien.HinhAnh = path;
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
//                // Xóa hình ảnh (nếu có)
//                if (!string.IsNullOrEmpty(nhanVien.HinhAnh))
//                {
//                    var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "uploads", nhanVien.HinhAnh);
//                    if (System.IO.File.Exists(imagePath)) System.IO.File.Delete(imagePath);
//                }
//                _context.NhanVien.Remove(nhanVien);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool NhanVienExists(int id)
//        {
//            return (_context.NhanVien?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//        public IActionResult ExportToExcel()
//        {
//            var nhanViens = _context.NhanVien
//        .Include(nv => nv.BangCap)
//        .Include(nv => nv.ChucVu)
//        .Include(nv => nv.ChuyenMon)
//        .Include(nv => nv.DanToc)
//        .Include(nv => nv.PhongBan)
//        .Include(nv => nv.QuocTich)
//        .Include(nv => nv.TonGiao)
//        .Include(nv => nv.TrinhDo)
//        .ToList();
//            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Thiết lập giấy phép cho thư viện EPPlus

//            using (var package = new ExcelPackage())
//            {
//                var worksheet = package.Workbook.Worksheets.Add("NhanVien"); // Tạo một worksheet mới

//                worksheet.Cells["A1:S1"].Style.Font.Bold = true;
//                // Định dạng header của bảng Excel
//                worksheet.Cells["A1"].Value = "Mã Nhân Viên";
//                worksheet.Cells["B1"].Value = "Tên Nhân Viên";
//                worksheet.Cells["C1"].Value = "Hình Ảnh";
//                worksheet.Cells["D1"].Value = "Giới Tính";
//                worksheet.Cells["E1"].Value = "Ngày Sinh";
//                worksheet.Cells["F1"].Value = "Số Điện Thoại";
//                worksheet.Cells["G1"].Value = "Căn Cước Công Dân";
//                worksheet.Cells["H1"].Value = "Email";
//                worksheet.Cells["I1"].Value = "Nơi Cấp Căn Cước";
//                worksheet.Cells["J1"].Value = "Ngày Cấp Căn Cước";
//                worksheet.Cells["K1"].Value = "Địa Chỉ";
//                worksheet.Cells["L1"].Value = "Bằng Cấp";
//                worksheet.Cells["M1"].Value = "Chức Vụ";
//                worksheet.Cells["N1"].Value = "Chuyên Môn";
//                worksheet.Cells["O1"].Value = "Dân Tộc";
//                worksheet.Cells["P1"].Value = "Phòng Ban";
//                worksheet.Cells["Q1"].Value = "Quốc Tịch";
//                worksheet.Cells["R1"].Value = "Tôn Giáo";
//                worksheet.Cells["S1"].Value = "Trình Độ";

//                // Thêm dữ liệu vào từ dòng thứ hai
//                int row = 2;

//                foreach (var nhanVien in nhanViens)
//                {
//                    worksheet.Cells[row, 1].Value = nhanVien.MaNhanVien;
//                    worksheet.Cells[row, 2].Value = nhanVien.TenNhanVien;
//                    worksheet.Cells[row, 3].Value = nhanVien.HinhAnh; // Trường này cần xử lý đặc biệt nếu là hình ảnh
//                    worksheet.Cells[row, 4].Value = nhanVien.GioiTinh;
//                    worksheet.Cells[row, 5].Value = nhanVien.NgaySinh;
//                    worksheet.Cells[row, 6].Value = nhanVien.SDT;
//                    worksheet.Cells[row, 7].Value = nhanVien.CanCuocCongDan;
//                    worksheet.Cells[row, 8].Value = nhanVien.Email;
//                    worksheet.Cells[row, 9].Value = nhanVien.NoiCapCanCuoc;
//                    worksheet.Cells[row, 10].Value = nhanVien.NgayCapCanCuoc;
//                    worksheet.Cells[row, 11].Value = nhanVien.DiaChi;
//                    worksheet.Cells[row, 12].Value = nhanVien.BangCap.TenBangCap; // Thay BangCap bằng tên của quan hệ tương ứng trong model
//                    worksheet.Cells[row, 13].Value = nhanVien.ChucVu.TenChucVu; // Thay ChucVu bằng tên của quan hệ tương ứng trong model
//                    worksheet.Cells[row, 14].Value = nhanVien.ChuyenMon.TenChuyenMon; // Thay ChuyenMon bằng tên của quan hệ tương ứng trong model
//                    worksheet.Cells[row, 15].Value = nhanVien.DanToc.TenDanToc; // Thay DanToc bằng tên của quan hệ tương ứng trong model
//                    worksheet.Cells[row, 16].Value = nhanVien.PhongBan.TenPhongBan; // Thay PhongBan bằng tên của quan hệ tương ứng trong model
//                    worksheet.Cells[row, 17].Value = nhanVien.QuocTich.TenQuocTich; // Thay QuocTich bằng tên của quan hệ tương ứng trong model
//                    worksheet.Cells[row, 18].Value = nhanVien.TonGiao.TenTonGiao; // Thay TonGiao bằng tên của quan hệ tương ứng trong model
//                    worksheet.Cells[row, 19].Value = nhanVien.TrinhDo.TenTrinhDo; // Thay TrinhDo bằng tên của quan hệ tương ứng trong model

//                    row++;
//                }

//                // Auto-fit cho các cột
//                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

//                // Xuất file Excel
//                var stream = new MemoryStream();
//                package.SaveAs(stream);
//                stream.Position = 0;

//                string excelName = $"NhanVien_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx"; // Tên file Excel

//                // Trả về file Excel như là một FileStreamResult
//                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
//            }
//        }

//    }
//}
