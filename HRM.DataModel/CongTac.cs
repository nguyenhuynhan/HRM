using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.DataModel
{
    [Table("CongTac")] 
    public class CongTac
    {
        [Display(Name = "Mã công tác")]
        public int Id { get; set; }

        [Display(Name = "Thời gian")]
        public string ThoiGian { get; set; }

        [Display(Name = "Đơn vị công tác")]
        public string DonViCongTac { get; set; }

        [Display(Name = "Chức vụ")]
        public string ChucVu { get; set; }        

        public virtual NhanVien NhanVien { get; set; }
    }
}
