using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DataModel
{
    //Người thân
    [Table("NguoiThan")] 
    public class NguoiThan
    {
        [Display(Name = "Mã số người thân")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Mối quan hệ")]
        public string QuanHe { get; set; }

        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [Display(Name = "Tình trạng")]
        public string TinhTrang { get; set; }

        [Display(Name = "Ngày sinh")]
        public string NgaySinh { get; set; }

        [Display(Name = "Thường trú")]
        public virtual DiaChi ThuongTru { get; set; }

        [Display(Name = "Nghề nghiệp")]
        public string NgheNghiep { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
