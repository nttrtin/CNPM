using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace QLNS.Models
{
    public class ThoiGianLamViec
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("Mã Nhân Viên")]
        [Required(ErrorMessage = "Mã Nhân Viên Không Được Bỏ Trống!")]
        public int NhanVienID { get; set; }
        [Required(ErrorMessage = "Tháng Không Được Bỏ Trống!")]
        [DisplayName("Tháng")]
        public int Thang { get; set; }

        [Required(ErrorMessage = "Số Ngày Công Không Được Bỏ Trống!")]
        [DisplayName("Số Ngày Nghỉ")]
        public int SoNgayNghiID { get; set; }
        [Required(ErrorMessage = "Số Ngày Công Không Được Bỏ Trống!")]
        [DisplayName("Số Ngày Công")]
        public int SoNgayCong { get; set; }

        [DisplayName("Nhân Viên")]
        public NhanVien? NhanVien { get; set; }
 
        public NghiPhep? NghiPhep { get; set; }
        public ICollection<Luong>? Luong { get; set; }
    }
}
