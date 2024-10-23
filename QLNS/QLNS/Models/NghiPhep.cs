using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace QLNS.Models
{
    public class NghiPhep
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("Mã Nhân Viên")]
        [Required(ErrorMessage = "Mã Nhân Viên Không Được Bỏ Trống!")]
        public int NhanVienID { get; set; }
        [Required(ErrorMessage = "Ngày Bắt Đầu Không Được Bỏ Trống!")]
        [DisplayName("Ngày Bắt Đầu")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime NgayBatDau { get; set; }
        [Required(ErrorMessage = "Ngày Kết Thúc Không Được Bỏ Trống!")]
        [DisplayName("Ngày Kết Thúc")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime NgayKetThuc { get; set; }
        [Required(ErrorMessage = "Số Ngày Công Không Được Bỏ Trống!")]
        [DisplayName("Số Ngày Nghỉ")]
        public int SoNgayNghi { get; set; }
        [Required(ErrorMessage = "Lý Do Không Được Bỏ Trống!")]
        [DisplayName("Lý Do Nghỉ")]
        public string LyDoNghi { get; set; }
        [DisplayName("Trạng Thái")]
        public TrangThaiNghiPhep TrangThai { get; set; }

        [DisplayName("Nhân Viên")]
        public NhanVien? NhanVien { get; set; }

        public ICollection<ThoiGianLamViec>? ThoiGianLamViec { get; set; }
    }
    public enum TrangThaiNghiPhep
    {
        [Display(Name = "Chưa Xác Nhận")]
        ChưaXácNhận,
        [Display(Name = "Đã Xác Nhận")]
        ĐãXácNhận,
        [Display(Name = "Đã Từ Chối")]
        ĐãTừChối,
    }
}
