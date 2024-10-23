using System.ComponentModel.DataAnnotations.Schema;

namespace QLNS.Models
{
 
    public class ThongKeThang
    {
        public int ID { get; set; }
        public string TenNhanVien {  get; set; }
        public string TenChucVu { get; set; }
        public int nam { get; set; }
        public int Thang {  get; set; }
        public float ThucLanh {  get; set; }
        public float TongDoanhThuThang {  get; set; }

    }
  
    public class ThongKeNam 
    {
        public int ID { get; set; }
        public int namID { get; set; }
        public int ThangID {  get; set; }
        public float TongDoanhThuThangID {  get; set; }
        public float TongDoanhThuNam {  get; set; }
    }
}
