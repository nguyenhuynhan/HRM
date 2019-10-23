using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.DataModel
{
    [Table("HocVan")] 
    public class HocVan
    {
        [Display(Name = "Mã học vấn")]
        public int Id { get; set; }

        [Display(Name = "Trình độ")]
        public string TrinhDo { get; set; }

        [Display(Name = "Trường")]
        public string Truong { get; set; }

        [Display(Name = "Chuyên ngành")]
        public string ChuyenNganh { get; set; }

        [Display(Name = "Từ năm")]
        public string TuNam { get; set; }

        [Display(Name = "Đến năm")]
        public string DenNam { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
