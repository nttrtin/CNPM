using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLNS.Models
{
    public class KhoanTru
    {
        public int ID { get; set; }
        [DisplayName("Mã Khoản Trừ")]
        public string MaKhoanTru { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Lý Do Không Được Bỏ Trống!")]
        [DisplayName("Lý Do")]
        public string LyDoKhoanTru { get; set; }
        [DisplayName("Số Tiền Khoản Trừ")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public float SoTienKhoanTru { get; set; }
        public ICollection<Luong>? Luong { get; set; }
    }
}
