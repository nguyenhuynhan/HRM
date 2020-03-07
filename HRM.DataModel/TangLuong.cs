using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.DataModel
{
    [Table("TangLuong")] 
    public class TangLuong
    {
        [Display(Name = "Mã tăng lương")]
        public int Id { get; set; }

        [Display(Name = "Thời gian")]
        public string ThoiGian { get; set; }

        [Display(Name = "Bậc lương")]
        public double BacLuong { get; set; }

        [Display(Name = "Hệ số lương")]
        public double HeSoLuong { get; set; }        

        public virtual NhanVien NhanVien { get; set; }
    }
}
