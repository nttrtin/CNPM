using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLNS.Models
{
    public class DanToc
    {
        public int ID { get; set; }
        [DisplayName("Mã Dân Tộc")]
        public string MaDanToc { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Tên Dân Tộc Được Bỏ Trống!")]
        [DisplayName("Tên Dân Tộc")]
        public string TenDanToc { get; set; }
        public ICollection<NhanVien>? NhanVien { get; set; }
    }
}
