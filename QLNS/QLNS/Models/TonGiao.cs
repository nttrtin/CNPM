using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLNS.Models
{
    public class TonGiao
    {
        public int ID { get; set; }
        [DisplayName("Mã Tôn Giáo")]
        public string MaTonGiao { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Tên Tôn Giáo Không Được Bỏ Trống!")]
        [DisplayName("Tên Tôn Giáo")]
        public string TenTonGiao { get; set; }
        public ICollection<NhanVien>? NhanVien { get; set; }
    }
}
