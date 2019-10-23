using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.DataModel
{
    //Phòng/Tổ
    [Table("PhongTo")] 
    public class PhongTo
    {
        [Display(Name = "Mã Phòng/Tổ")]
        public string Id { get; set; }

        [Display(Name="Loại")]
        public string Loai { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        public virtual IList<NhanVien> NhanVien { get; set; }
    }
}
