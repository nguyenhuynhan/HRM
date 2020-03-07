using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRM.Web.Models;
using HRM.Lib;
using HRM.DataModel;
using System.IO;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace HRM.Web.HRM
{
    public partial class NhapThongTinNhanVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Dictionary<string, string> LayDanhSachPhongTo()
        {
            ApplicationDbContext db = ApplicationDbContext.Create();
            if (db.DanhSachPhongTo.Count() > 0)
                return db.DanhSachPhongTo
                    .ToDictionary(k => k.Id, v => v.Loai + " " + v.Name);
            return null;
        }

        protected void btThemChoOHienNay_Click(object sender, EventArgs e)
        {
            Button btThemChoOHienNay = (Button)sender;
            Panel pnThuongTru = (Panel)frmMain.FindControl("pnThuongTru");
            if (pnThuongTru.Visible == false)
            {
                btThemChoOHienNay.Text = "Xóa địa chỉ hiện nay";
                btThemChoOHienNay.CssClass = "btn btn-warning";
                pnThuongTru.Visible = true;
            }
            else
            {
                btThemChoOHienNay.Text = "Thêm địa chỉ hiện tại (nếu khác)";
                btThemChoOHienNay.CssClass = "btn btn-info";
                pnThuongTru.Visible = false;
            }
        }

        public void frmMain_InsertItem()
        {
            var nhanVien = new NhanVien();
            valSummary.Visible = true;
            TryUpdateModel(nhanVien);

            nhanVien.TrinhDo = LayDanhSachHocVan();
            nhanVien.BangCapKhac = LayDanhSachBangCap();
            nhanVien.NguoiThan = LayDanhSachNguoiThan();

            try
            {
                using (ApplicationDbContext db = ApplicationDbContext.Create())
                {
                    nhanVien.PhongTo = db.DanhSachPhongTo.First(m => m.Id.Equals(nhanVien.PhongTo.Id));

                    if (ModelState.IsValid)
                    {
                        HiddenField HinhAnh = (HiddenField)frmMain.FindControl("HinhAnh");
                        nhanVien.HinhAnh = ProcessAvatar(HinhAnh.Value);
                        db.DanhSachNhanVien.Add(nhanVien);
                        db.SaveChanges();
                        Response.Redirect("DanhSachNhanVien");
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                ModelState.AddModelError("Summary", "Dữ liệu không đúng!");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("Summary", "Đã tồn tại nhân viên với mã số " + nhanVien.Id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Summary", "Lỗi hệ thống!");
            }

        }

        private string ProcessAvatar(string HinhAnh)
        {
            try
            {
                string temp = Server.MapPath("~/Temp");
                string path = Server.MapPath("~/ProfilePicture");
                File.Move(temp + "\\" + HinhAnh, path + "\\" + HinhAnh);
                return HinhAnh;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        protected void PictureUpload_Load(object sender, EventArgs e)
        {
            FileUpload upload = (FileUpload)sender;
            Image picture = (Image)frmMain.FindControl("ProfilePicture");
            HiddenField HinhAnh = (HiddenField)frmMain.FindControl("HinhAnh");

            if (upload.HasFile)
            {
                string fileExtension = Path.GetExtension(upload.FileName);
                string fileName = DateTime.Now.Ticks + fileExtension;
                upload.SaveAs(Server.MapPath("~/Temp/") + fileName);
                picture.ImageUrl = "\\Temp\\" + fileName;
                HinhAnh.Value = fileName;
            }
            else if(string.IsNullOrEmpty(HinhAnh.Value))
            {
                picture.ImageUrl = "\\ProfilePicture\\default-user.png";
            }
        }

        #region TrinhDoHocVan

        protected void gvTrinhDo_Load(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            if (!IsPostBack)
            {
                List<HocVan> dsHocVan = new List<HocVan>();
                dsHocVan.Add(new HocVan());
                gv.DataSource = dsHocVan;
            }
        }

        protected List<HocVan> LayDanhSachHocVan()
        {
            List<HocVan> dsHocVan = new List<HocVan>();
            GridView gvTrinhDo = (GridView)frmMain.FindControl("gvTrinhDo");

            foreach (GridViewRow row in gvTrinhDo.Rows)
            {
                HocVan hocVan = new HocVan();
                hocVan.TrinhDo = ((DropDownList)row.FindControl("TrinhDo")).SelectedValue;
                hocVan.ChuyenNganh = ((TextBox)row.FindControl("ChuyenNganh")).Text;
                dsHocVan.Add(hocVan);
            }

            return dsHocVan;
        }

        protected void btThemTrinhDo_Click(object sender, EventArgs e)
        {
            GridView gvTrinhDo = (GridView)frmMain.FindControl("gvTrinhDo");
            List<HocVan> dsHocVan = LayDanhSachHocVan();
            dsHocVan.Add(new HocVan());
            gvTrinhDo.DataSource = dsHocVan;
            gvTrinhDo.DataBind();
        }

        protected void gvTrinhDo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gvTrinhDo = (GridView)frmMain.FindControl("gvTrinhDo");
            List<HocVan> dsHocVan = LayDanhSachHocVan();
            dsHocVan.RemoveAt(e.RowIndex);
            gvTrinhDo.DataSource = dsHocVan;
            gvTrinhDo.DataBind();
        }

        #endregion

        #region BangCap
        
        protected void BangCapKhac_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gvBangCapKhac = (GridView)frmMain.FindControl("BangCapKhac");
            List<BangCapKhac> dsBangCapKhac = LayDanhSachBangCap();
            dsBangCapKhac.RemoveAt(e.RowIndex);
            gvBangCapKhac.DataSource = dsBangCapKhac;
            gvBangCapKhac.DataBind();
        }

        protected List<BangCapKhac> LayDanhSachBangCap()
        {
            List<BangCapKhac> dsBangCapKhac = new List<BangCapKhac>();
            GridView gvBangCapKhac = (GridView)frmMain.FindControl("BangCapKhac");

            foreach (GridViewRow row in gvBangCapKhac.Rows)
            {
                BangCapKhac bangCapKhac = new BangCapKhac();
                bangCapKhac.LoaiBangCap = ((DropDownList)row.FindControl("LoaiBangCap")).SelectedValue;
                bangCapKhac.TenBangCap = ((TextBox)row.FindControl("TenBangCap")).Text;
                bangCapKhac.CapDo = ((TextBox)row.FindControl("CapDo")).Text;
                dsBangCapKhac.Add(bangCapKhac);
            }

            return dsBangCapKhac;
        }

        protected void btThemBangCapKhac_Click(object sender, EventArgs e)
        {
            GridView gvBangcapKhac = (GridView)frmMain.FindControl("BangCapKhac");
            List<BangCapKhac> dsBangCapKhac = LayDanhSachBangCap();
            dsBangCapKhac.Add(new BangCapKhac());
            gvBangcapKhac.DataSource = dsBangCapKhac;
            gvBangcapKhac.DataBind();
        }

        #endregion

        #region QuaTrinhCongTac

        protected void gvCongTac_Load(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            if (!IsPostBack)
            {
                List<CongTac> dsCongTac = new List<CongTac>();
                dsCongTac.Add(new CongTac());
                gv.DataSource = dsCongTac;
            }
        }

        protected List<CongTac> LayDanhSachCongTac()
        {
            List<CongTac> dsCongTac = new List<CongTac>();
            GridView gvCongTac = (GridView)frmMain.FindControl("gvCongTac");

            foreach (GridViewRow row in gvCongTac.Rows)
            {
                CongTac congTac = new CongTac();
                congTac.ThoiGian = ((TextBox)row.FindControl("ThoiGian")).Text;
                congTac.DonViCongTac = ((TextBox)row.FindControl("DonViCongTac")).Text;
                congTac.ChucVu = ((TextBox)row.FindControl("ChucVu")).Text;
                dsCongTac.Add(congTac);
            }

            return dsCongTac;
        }

        protected void btThemCongTac_Click(object sender, EventArgs e)
        {
            GridView gvCongTac = (GridView)frmMain.FindControl("gvCongTac");
            List<CongTac> dsCongTac = LayDanhSachCongTac();
            dsCongTac.Add(new CongTac());
            gvCongTac.DataSource = dsCongTac;
            gvCongTac.DataBind();
        }

        protected void gvCongTac_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gvCongTac = (GridView)frmMain.FindControl("gvCongTac");
            List<CongTac> dsHocVan = LayDanhSachCongTac();
            dsHocVan.RemoveAt(e.RowIndex);
            gvCongTac.DataSource = dsHocVan;
            gvCongTac.DataBind();
        }

        #endregion

        #region QuaTrinhTangLuong

        protected void gvTangLuong_Load(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            if (!IsPostBack)
            {
                List<TangLuong> dsTangLuong = new List<TangLuong>();
                dsTangLuong.Add(new TangLuong());
                gv.DataSource = dsTangLuong;
            }
        }

        protected List<TangLuong> LayDanhSachTangLuong()
        {
            List<TangLuong> dsTangLuong = new List<TangLuong>();
            GridView gvTangLuong = (GridView)frmMain.FindControl("gvTangLuong");

            foreach (GridViewRow row in gvTangLuong.Rows)
            {
                TangLuong tangLuong = new TangLuong();
                double bacLuong = 0;
                double heSoLuong = 0;
                double.TryParse(((TextBox) row.FindControl("BacLuong")).Text, out bacLuong);
                double.TryParse(((TextBox)row.FindControl("HeSoLuong")).Text, out heSoLuong);
                tangLuong.ThoiGian = ((TextBox)row.FindControl("ThoiGian")).Text;
                tangLuong.BacLuong = bacLuong;
                tangLuong.HeSoLuong = heSoLuong;
                dsTangLuong.Add(tangLuong);
            }

            return dsTangLuong;
        }

        protected void btThemTangLuong_Click(object sender, EventArgs e)
        {
            GridView gvTangLuong = (GridView)frmMain.FindControl("gvTangLuong");
            List<TangLuong> dsTangLuong = LayDanhSachTangLuong();
            dsTangLuong.Add(new TangLuong());
            gvTangLuong.DataSource = dsTangLuong;
            gvTangLuong.DataBind();
        }

        protected void gvTangLuong_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gvTangLuong = (GridView)frmMain.FindControl("gvTangLuong");
            List<TangLuong> dsHocVan = LayDanhSachTangLuong();
            dsHocVan.RemoveAt(e.RowIndex);
            gvTangLuong.DataSource = dsHocVan;
            gvTangLuong.DataBind();
        }

        #endregion

        #region QuaTrinhKhenThuong

        protected void gvKhenThuong_Load(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            if (!IsPostBack)
            {
                List<KhenThuong> dsKhenThuong = new List<KhenThuong>();
                dsKhenThuong.Add(new KhenThuong());
                gv.DataSource = dsKhenThuong;
            }
        }

        protected List<KhenThuong> LayDanhSachKhenThuong()
        {
            List<KhenThuong> dsKhenThuong = new List<KhenThuong>();
            GridView gvKhenThuong = (GridView)frmMain.FindControl("gvKhenThuong");

            foreach (GridViewRow row in gvKhenThuong.Rows)
            {
                KhenThuong khenThuong = new KhenThuong();
                khenThuong.ThoiGian = ((TextBox)row.FindControl("ThoiGian")).Text;
                khenThuong.LyDoHinhThuc = ((TextBox)row.FindControl("LyDoHinhThuc")).Text;
                khenThuong.CapQuyetDinh = ((TextBox)row.FindControl("CapQuyetDinh")).Text;
                dsKhenThuong.Add(khenThuong);
            }

            return dsKhenThuong;
        }

        protected void btThemKhenThuong_Click(object sender, EventArgs e)
        {
            GridView gvKhenThuong = (GridView)frmMain.FindControl("gvKhenThuong");
            List<KhenThuong> dsKhenThuong = LayDanhSachKhenThuong();
            dsKhenThuong.Add(new KhenThuong());
            gvKhenThuong.DataSource = dsKhenThuong;
            gvKhenThuong.DataBind();
        }

        protected void gvKhenThuong_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gvKhenThuong = (GridView)frmMain.FindControl("gvKhenThuong");
            List<KhenThuong> dsKhenThuong = LayDanhSachKhenThuong();
            dsKhenThuong.RemoveAt(e.RowIndex);
            gvKhenThuong.DataSource = dsKhenThuong;
            gvKhenThuong.DataBind();
        }

        #endregion


        #region NguoiThan

        protected List<NguoiThan> LayDanhSachNguoiThan()
        {
            List<NguoiThan> dsNguoiThan = new List<NguoiThan>();
            GridView gvNguoiThan = (GridView)frmMain.FindControl("NguoiThan");

            foreach (GridViewRow row in gvNguoiThan.Rows)
            {
                NguoiThan nguoiThan = new NguoiThan();
                nguoiThan.Name = ((TextBox)row.FindControl("Hoten")).Text;
                nguoiThan.QuanHe = ((DropDownList)row.FindControl("QuanHe")).SelectedValue;
                nguoiThan.GioiTinh = ((DropDownList)row.FindControl("GioiTinh")).SelectedValue;
                nguoiThan.TinhTrang = ((TextBox)row.FindControl("TinhTrang")).Text;
                nguoiThan.NgaySinh = ((TextBox)row.FindControl("NgaySinh")).Text;
                nguoiThan.NgheNghiep = ((TextBox)row.FindControl("NgheNghiep")).Text;
                nguoiThan.ThuongTru = new DiaChi();
                nguoiThan.ThuongTru.Xa = ((TextBox)row.FindControl("DiaChi_Xa")).Text;
                nguoiThan.ThuongTru.Huyen = ((TextBox)row.FindControl("DiaChi_Huyen")).Text;
                nguoiThan.ThuongTru.Tinh = ((TextBox)row.FindControl("DiaChi_Tinh")).Text;
                dsNguoiThan.Add(nguoiThan);
            }

            return dsNguoiThan;
        }

        protected void NguoiThan_Load(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            if (!IsPostBack)
            {
                List<NguoiThan> dsNguoiThan = new List<NguoiThan>();
                dsNguoiThan.Add(new NguoiThan());
                gv.DataSource = dsNguoiThan;
            }
        }

        protected void NguoiThan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gvNguoiThan = (GridView)frmMain.FindControl("NguoiThan");
            List<NguoiThan> dsNguoiThan = LayDanhSachNguoiThan();
            dsNguoiThan.RemoveAt(e.RowIndex);
            gvNguoiThan.DataSource = dsNguoiThan;
            gvNguoiThan.DataBind();
        }

        protected void btThemNguoiThan_Click(object sender, EventArgs e)
        {
            GridView gvNguoiThan = (GridView)frmMain.FindControl("NguoiThan");
            List<NguoiThan> dsNguoiThan = LayDanhSachNguoiThan();
            dsNguoiThan.Add(new NguoiThan());
            gvNguoiThan.DataSource = dsNguoiThan;
            gvNguoiThan.DataBind();
        }

        #endregion

        protected void btUpload_Click(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public NhanVien frmMain_GetItem(int id)
        {
            ApplicationDbContext db = ApplicationDbContext.Create();
            var temp = db.DanhSachNhanVien.Find("1234");
            return temp;
        }

    }
}
