using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.DataModel
{
    [Table("BangCapKhac")] 
    public class BangCapKhac
    {
        [Display(Name = "Mã bằng cấp")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Loại bằng cấp")]
        public string LoaiBangCap { get; set; }

        [Required]
        [Display(Name = "Tên bằng cấp")]
        public string TenBangCap { get; set; }

        [Display(Name = "Cấp độ")]
        public string CapDo { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
