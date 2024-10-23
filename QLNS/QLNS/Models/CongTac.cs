using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLNS.Models
{
    public class CongTac
    {
        public int ID { get; set; }
        [DisplayName("Mã Công Tác")]
        public string MaCongTac { get; set; }
     
        [Required(ErrorMessage = "Tên Nhân Viên Không Được Bỏ Trống!")]
        [DisplayName("Tên Nhân Viên")]
        public int NhanVienID { get; set; }
    
        [Required(ErrorMessage = "Tên Chức Vụ Không Được Bỏ Trống!")]
        [DisplayName("Tên Chức Vụ")]
        public int ChucVuID { get; set; }
        [Required(ErrorMessage = "Ngày Bắt Đầu Không Được Bỏ Trống!")]
        [DisplayName("Ngày Bắt Đầu")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime NgayBatDau { get; set; }
        [Required(ErrorMessage = "Ngày Kết Thúc Không Được Bỏ Trống!")]
        [DisplayName("Ngày Kết Thúc")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime NgayKetThuc { get; set; }
        [StringLength(255)]
        [DisplayName("Địa Điểm Công Tác")]
        public string DiaDiemCongTac { get; set; }
        [StringLength(255)]
        [DisplayName("Mục Đích Công Tác")]
        public string MucDich { get; set; }

        [DisplayName("Tên Nhân Viên")]
        public NhanVien? NhanVien { get; set; }

        [DisplayName("Tên Chức Vụ")]
        public ChucVu? ChucVu { get; set; }
        public TrangThaiCongTac TrangThai { get; set; }
        public enum TrangThaiCongTac
        {
            [Display(Name = "Đang Công Tác")]
            DangCongTac,
            [Display(Name = "Sắp Công Tác")]
            SapCongTac,
            [Display(Name = "Đã Hết Hạn")]
            DaHetHan,
        }
    }
}
