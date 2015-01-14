using System.ComponentModel.DataAnnotations;

namespace HRM.DataModel
{
    //Chức vụ
    public class ChucVu
    {
        [Required]
        [Display(Name = "Mã chức vụ")]
        public string MaChucVu{ get; set; }

        [Required]
        [Display(Name = "Chức vụ")]
        public string TenChucVu { get; set; }
    }
}
