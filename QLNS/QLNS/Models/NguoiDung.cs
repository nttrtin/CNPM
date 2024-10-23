using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLNS.Models
{
    public class NguoiDung
    {
        [DisplayName("ID")]
        public int ID { get; set; }


        [DisplayName("Họ và Tên")]
        public int NhanVienID { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Email Không Được Bỏ Trống!")]
        [DisplayName("Email")]
        public string EmailID { get; set; }
        [DisplayName("Điện Thoại")]
        public string SDTID { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Địa Chỉ Không Được Bỏ Trống!")]
        [DisplayName("Địa Chỉ")]
        public string DiaChiID { get; set; }
        [StringLength(50, ErrorMessage = "{0} Phải Ít Nhất {2} Ký Tự.", MinimumLength = 4)]
        [Required(ErrorMessage = "Tên Đăng Nhập Không Được Bỏ Trống!")]
        [DisplayName("Tên Đăng Nhập")]
        public string TenDangNhap { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Mật Khẩu Không Được Để Trống!")]
        [DisplayName("Mập Khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
        [NotMapped]
        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage = "Xác nhận mật khẩu không được bỏ trống!")]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu không chính xác!")]
        [DataType(DataType.Password)]
        public string XacNhanMatKhau { get; set; }
        public enum quyen
        {
            User,
            Admin,
            [Display(Name = "Quản Lý")]
            QuanLy
        }
        [DisplayName("Quyền hạn")]
        public quyen Quyen { get; set; }
        public NhanVien? NhanVien { get; set; }
        
    }
    
    [NotMapped]
    public class NguoiDung_ChinhSua
    {
        public NguoiDung_ChinhSua()
        {
        }
        public NguoiDung_ChinhSua(NguoiDung n)
        {
            ID = n.ID;
            NhanVienID = n.NhanVienID;
            EmailID = n.EmailID;
            // NhanVienID= n.NhanVienID;
            SDTID = n.SDTID;
            DiaChiID = n.DiaChiID;
            TenDangNhap = n.TenDangNhap;
            MatKhau = n.MatKhau;
            XacNhanMatKhau = n.XacNhanMatKhau;
            Quyen = (quyen)n.Quyen;
        }
        [DisplayName("ID")]
        public int ID { get; set; }
        [DisplayName("Họ và Tên")]
        public int NhanVienID { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Email Không Được Bỏ Trống!")]
        [DisplayName("Email")]
        public string EmailID { get; set; }
        [DisplayName("Điện Thoại")]
        public string? SDTID { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Địa Chỉ Không Được Bỏ Trống!")]
        [DisplayName("Địa Chỉ")]
        public string? DiaChiID { get; set; }
        [StringLength(50, ErrorMessage = "{0} Phải Ít Nhất {2} Ký Tự.", MinimumLength = 4)]
        [Required(ErrorMessage = "Tên Đăng Nhập Không Được Bỏ Trống!")]
        [DisplayName("Tên Đăng Nhập")]
        public string TenDangNhap { get; set; }
        [StringLength(255)]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        public string? MatKhau { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu không chính xác!")]
        [DataType(DataType.Password)]
        public string? XacNhanMatKhau { get; set; }
 
        public enum quyen
        {
            User,
            Admin,
            [Display(Name = "Quản Lý")]
            QuanLy
        }
        [DisplayName("Quyền hạn")]
        public quyen Quyen { get; set; }
        public NhanVien? NhanVien { get; set; }

    }
    [NotMapped]
    public class DangNhap
    {
        
        //[StringLength(50, ErrorMessage = "{0} Phải Ít Nhất {2} Ký Tự.", MinimumLength = 4)]
        //[Required(ErrorMessage = "Tên Đăng Nhập Không Được Bỏ Trống!")]
        //[DisplayName("Tên Đăng Nhập")]
        //public string TenDangNhap { get; set; }
        [StringLength(255)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }
        [DisplayName("Duy trì đăng nhập")]
        public bool DuyTriDangNhap { get; set; }
        [StringLength(255)]
        [DisplayName("Liên kết chuyển trang")]
        public string? LienKetChuyenTrang { get; set; }
        [StringLength(11, ErrorMessage = "{0} không được quá {1} ký tự.")]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống!")]
        [DisplayName("Số điện thoại")]
        public string SDTID { get; set; }
    }
}
