using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLNS.Models
{
    public class PhuCap
    {
        public int ID { get; set; }
        [DisplayName("Mã Phụ Cấp")]
        public string MaPhuCap { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Tên Phụ Cấp Không Được Bỏ Trống!")]
        [DisplayName("Tên Phụ Cấp")]
        public string TenPhuCap { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [DisplayName("Số Tiền Phụ Cấp")]
        public float SoTienPhuCap { get; set; }
     

        public ICollection<Luong>? Luong { get; set; }
    }
}
