using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLNS.Models
{
    public class BangCap
    {
        public int ID { get; set; }
        [DisplayName("Mã Bằng Cấp")]
        public string MaBangCap { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Tên Bằng Cấp Không Được Bỏ Trống!")]
        [DisplayName("Tên Bằng Cấp")]
        public string TenBangCap { get; set; }
        public ICollection<CongTac>? CongTac { get; set; }
        public ICollection<NhanVien>? NhanVien { get; set; }
    }
}
