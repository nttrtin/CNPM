using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLNS.Models
{
    public class QuocTich
    {
        [DisplayName("ID")]
        public int ID { get; set; }
        [DisplayName("Mã Quốc Tịch")]
        public string MaQuocTich { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Tên Quốc Tịch Không Được Bỏ Trống!")]
        [DisplayName("Tên Quốc Tịch")]
        public string TenQuocTich { get; set; }
        public ICollection<NhanVien>? NhanVien { get; set; }
    }
}
