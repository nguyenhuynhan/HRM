using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.DataModel
{
    [Table("KyLuat")] 
    public class KyLuat
    {
        [Display(Name = "Mã tăng lương")]
        public int Id { get; set; }

        [Display(Name = "Thời gian")]
        public string ThoiGian { get; set; }

        [Display(Name = "Lý do hình thức")]
        public string LyDoHinhThuc { get; set; }

        [Display(Name = "Cấp quyết định")]
        public string CapQuyetDinh { get; set; }        

        public virtual NhanVien NhanVien { get; set; }
    }
}
