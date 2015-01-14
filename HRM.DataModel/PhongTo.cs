using System.ComponentModel.DataAnnotations;

namespace HRM.DataModel
{
    //Phòng/Tổ
    public class PhongTo
    {
        [Required]
        [Display(Name = "Mã Phòng/Tổ")]
        public string MaPhongTo { get; set; }
        [Required]
        [Display(Name="Phòng/Tổ")]
        public string TenPhongTo { get; set; }
    }
}
