using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.DataModel
{
    //Người thân
    [Table("NhanVien")] 
    public class NhanVien
    {
        [Required]
        [Display(Name = "Mã số nhân viên")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Họ và chữ lót")]
        public string HoVaChuLot { get; set; }

        [Required]
        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [Required]
        [Display(Name = "Phòng/Tổ")]
        public virtual PhongTo PhongTo { get; set; }

        [Required]
        [Display(Name = "Chức vụ")]
        public string ChucVu { get; set; }

        [Required]
        [Display(Name = "Ngày sinh")]
        public string NgaySinh { get; set; }

        [Display(Name = "Quê quán")]
        public virtual DiaChi QueQuan { get; set; }

        [Display(Name = "Địa chỉ hiện tại")]
        public virtual DiaChi HienTai { get; set; }

        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [Display(Name = "CMND")]
        public string CMND { get; set; }

        [Display(Name = "Tình trạng hôn nhân")]
        public string TinhTrangHonNhan { get; set; }

        [Display(Name = "Người thân")]
        public virtual IList<NguoiThan> NguoiThan { get; set; }

        [Display(Name = "Học vấn")]
        public virtual IList<HocVan> TrinhDo { get; set; }

        [Display(Name = "Bằng cấp khác")]
        public virtual IList<BangCapKhac> BangCapKhac { get; set; }

        [Display(Name = "Quá trình công tác")]
        public virtual IList<CongTac> QuaTrinhCongTac { get; set; }

        [Display(Name = "Hệ số lương")]
        public float HeSoLuong { get; set; }

        [Display(Name = "Ngày tăng lương")]
        public string NgayTangLuong { get; set; }

        [Display(Name = "Ngày vào công ty")]
        public string NgayVaoCongTy { get; set; }

        [Display(Name = "Ngày tham gia Cách mạng")]
        public string NgayThamGiaCachMang { get; set; }

        [Display(Name = "Ngày vào Đảng")]
        public string NgayVaoDang { get; set; }

        [Display(Name = "Điện thoại bàn")]
        public string DienThoaiBan { get; set; }

        [Display(Name = "Điện thoại")]
        public string DienThoai { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Lý luận chính trị")]
        public string LyLuanChinhTri { get; set; }

        [Display(Name = "Ghi chú chính trị")]
        public string GhiChuChinhTri { get; set; }

        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }
    }
}
