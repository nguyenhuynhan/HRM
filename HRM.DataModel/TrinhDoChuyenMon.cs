using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRM.DataModel
{
    //Trình độ chuyên môn
    public class TrinhDoChuyenMon
    {
        [Required]
        [Display(Name = "Mã trình độ")]
        public string MaTrinhDo { get; set; }

        [Required]
        [Display(Name = "Trình độ chuyên môn")]
        public string TenTrinhDoChuyenMon { get; set; }
    }
}
