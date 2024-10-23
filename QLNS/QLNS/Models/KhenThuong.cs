using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLNS.Models
{
    public class KhenThuong
    {
        public int ID { get; set; }
        [DisplayName("Mã Khen Thưởng")]
        public string MaKhenThuong { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Lý Do Không Được Bỏ Trống!")]
        [DisplayName("Lý Do")]
        public string LyDoKhenThuong { get; set; }
    
        [Required(ErrorMessage = "Tiền Thưởng Không Được Bỏ Trống!")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [DisplayName("Tiền Thưởng")]
        public float TienThuong { get; set; }
        public ICollection<Luong>? Luong { get; set; }
    }
}
