using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLNS.Models
{
    public class ChuyenMon
    {
        public int ID { get; set; }
        [DisplayName("Mã Chuyên Môn")]
        public string MaChuyenMon { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Tên Chuyên Môn Không Được Bỏ Trống!")]
        [DisplayName("Tên Chuyên Môn")]
        public string TenChuyenMon { get; set; }
        public ICollection<NhanVien>? NhanVien { get; set; }
    }
}
