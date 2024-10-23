using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLNS.Models
{
    public class NhanVien
    {
        [DisplayName("Id")]
        public int ID { get; set; }
        [DisplayName("Mã Nhân Viên")]
        [Required(ErrorMessage = "Mã Nhân Viên Không Được Bỏ Trống!")]
        public string MaNhanVien { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Tên Nhân Viên Không Được Bỏ Trống!")]
        [DisplayName("Tên Nhân Viên")]
        public string TenNhanVien { get; set; }
        [StringLength(255)]
        [DisplayName("Hình Ảnh")]
        public string? HinhAnh { get; set; }
        [NotMapped]
        [Display(Name = "Hình ảnh nhân viên")]
        public IFormFile? DuLieuHinhAnh { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Giới Tính Không Được Bỏ Trống!")]
        [DisplayName("Giới Tính")]
        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Ngày Sinh Không Được Bỏ Trống!")]
        [DisplayName("Ngày Sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime NgaySinh { get; set; }
        [RegularExpression("[0-9]{10}", ErrorMessage = "Căn Cước Công Dân Phải Là 12 Chữ Số")]
        [StringLength(20)]
        [Required(ErrorMessage = "Điện thoại không được bỏ trống!")]
        [DisplayName("Điện thoại")]
        public string? SDT { get; set; }
        [Required(ErrorMessage = "CCCD Không Được Bỏ Trống!")]
        [DisplayName("CCCD")]
        public string CanCuocCongDan { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Email Không Được Bỏ Trống!")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Nơi Cấp Căn Cước Không Được Bỏ Trống!")]
        [DisplayName("Nơi Cấp")]
        public string NoiCapCanCuoc { get; set; }
        [Required(ErrorMessage = "Ngày Cấp Căn Cước Không Được Bỏ Trống!")]
        [DisplayName("Ngày Cấp")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime NgayCapCanCuoc { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Địa Chỉ Không Được Bỏ Trống!")]
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }



        [Required(ErrorMessage = "Bằng Cấp Không Được Bỏ Trống!")]
        [DisplayName("Bằng Cấp")]
        public int BangCapID { get; set; }
        [Required(ErrorMessage = "Chức Vụ Không Được Bỏ Trống!")]
        [DisplayName("Chức Vụ")]
        public int ChucVuID { get; set; }
        [Required(ErrorMessage = "Chuyên Môn Không Được Bỏ Trống!")]
        [DisplayName("Chuyên Môn")]
        public int ChuyenMonID { get; set; }
        [Required(ErrorMessage = "Dân Tộc Không Được Bỏ Trống!")]
        [DisplayName("Dân Tộc")]
        public int DanTocID { get; set; }

        [Required(ErrorMessage = "Phòng Ban Không Được Bỏ Trống!")]
        [DisplayName("Phòng Ban")]
        public int PhongBanId { get; set; }
        [Required(ErrorMessage = "Quốc Tịch Không Được Bỏ Trống!")]
        [DisplayName("Quốc Tịch")]
        public int QuocTichID { get; set; }
        [Required(ErrorMessage = "Tôn Giáo Không Được Bỏ Trống!")]
        [DisplayName("Tôn Giáo")]
        public int TonGiaoID { get; set; }
        [Required(ErrorMessage = "Trình Độ Không Được Bỏ Trống!")]
        [DisplayName("Trình Độ")]
        public int TrinhDoID { get; set; }

        public ICollection<Luong>? Luong { get; set; }
        public ICollection<NguoiDung>? NguoiDung { get; set; }
        public ICollection<ThoiGianLamViec>? ThoiGianLamViec { get; set; }
        public ICollection<NghiPhep>? NghiPhep { get; set; }
        public ICollection<CongTac>? CongTac { get; set; }
        [DisplayName("Bằng Cấp")]
        public BangCap? BangCap { get; set; }
        [DisplayName("Chức Vụ")]
        public ChucVu? ChucVu { get; set; }
        [DisplayName("Chuyên Môn")]
        public ChuyenMon? ChuyenMon { get; set; }
        [DisplayName("Dân Tộc")]
        public DanToc? DanToc { get; set; }
        [DisplayName("Phòng Ban")]
        public PhongBan? PhongBan { get; set; }
        [DisplayName("Quốc Tịch")]
        public QuocTich? QuocTich { get; set; }
        [DisplayName("Tôn Giáo")]
        public TonGiao? TonGiao { get; set; }
        [DisplayName("Trình Độ")]
        public TrinhDo? TrinhDo { get; set; }
    }

}
