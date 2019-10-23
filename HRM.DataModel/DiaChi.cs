using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DataModel
{
    [Table("DiaChi")] 
    public class DiaChi
    {
        [Display(Name = "Mã địa chỉ")]
        public int Id { get; set; }

        [Display(Name = "Xã")]
        public string Xa { get; set; }

        [Display(Name = "Huyện")]
        public string Huyen { get; set; }

        [Display(Name = "Tỉnh")]
        public string Tinh { get; set; }
    }
}
