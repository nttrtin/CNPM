using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLNS.Models
{
    public class Luong
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Mã Nhân Viên Không Được Bỏ Trống!")]
        [DisplayName("Tên Nhân Viên")]
        public int NhanVienID { get; set; }
        [Required(ErrorMessage = "Tháng Không Được Bỏ Trống!")]
        [DisplayName("Tháng")]
        public int ThangID { get; set; }

        [Required(ErrorMessage = "Số Ngày Công Không Được Bỏ Trống!")]
        [DisplayName("Ngày Công")]
        public int ThoiGianLamViecID { get; set; }
        [Required(ErrorMessage = "Lương Cơ Bản Không Được Bỏ Trống!")]
        [DisplayName("Lương Cơ Bản")]
        public int LuongCoBanID { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Tình Trạng Lương Không Được Bỏ Trống!")]
        [DisplayName("Tình Trạng Lương")]
        public string TinhTrangLuong { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Required(ErrorMessage = "Tổng Thu Nhập Không Được Bỏ Trống!")]
        [DisplayName("Tổng Thu Nhập")]
        public float TongThuNhap { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Phương Thức Thanh Toán Không Được Bỏ Trống!")]
        [DisplayName("Phương Thức Thanh Toán")]
        public string PhuongThucThanhToan { get; set; }
        [Required(ErrorMessage = "Ngày Thanh Toán Không Được Bỏ Trống!")]
        [DisplayName("Ngày Thanh Toán")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime NgayThanhToan { get; set; }


        [Required(ErrorMessage = "Chức Vụ Không Được Bỏ Trống!")]
        [DisplayName("Chức Vụ")]
        public int ChucVuID { get; set; }

        [Required(ErrorMessage = "Mã Khoản Trừ Không Được Bỏ Trống!")]
        [DisplayName("Lý Do Khoản Trừ")]
        public string LyDoKhoanTruID { get; set; }
        [Required(ErrorMessage = "Mã Khoản Trừ Không Được Bỏ Trống!")]
        [DisplayName("Số Tiền Trừ")]
        public int KhoanTruID { get; set; }
        [Required(ErrorMessage = "Mã Khoản Trừ Không Được Bỏ Trống!")]
        [DisplayName("Lý Do Khen Thưởng")]
        public string LyDoKhenThuongID { get; set; }
        [Required(ErrorMessage = "Mã Khen Thưởng Không Được Bỏ Trống!")]
        [DisplayName("Số Tiền Thưởng")]

        public int KhenThuongID { get; set; }
        [Required(ErrorMessage = "Mã Phụ Cấp Không Được Bỏ Trống!")]
        [DisplayName("Phụ Cấp")]
        public int PhuCapID { get; set; }
        [DisplayName("Tên Phụ Cấp")]
        public string TenPhuCapID { get; set; }

        public ThoiGianLamViec? ThoiGianLamViec { get; set; }
        [DisplayName("Chức Vụ")]
        public ChucVu? ChucVu { get; set; }
     
        [DisplayName("Khoản Trừ")]
        public KhoanTru? KhoanTru { get; set; }
        [DisplayName("Khen Thưởng")]
        public KhenThuong? KhenThuong { get; set; }
        [DisplayName("Phụ Cấp")]
        public PhuCap? PhuCap { get; set; }
        [DisplayName("Nhân Viên")]
        public NhanVien? NhanVien { get; set; }

        internal object FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        internal float Sum(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
