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
    public partial class SuaThongTinNhanVien : System.Web.UI.Page
    {
        private string maSoNhanVien = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            maSoNhanVien = Request["masonhanvien"];
        }

        public Dictionary<string, string> LayDanhSachPhongTo()
        {
            ApplicationDbContext db = ApplicationDbContext.Create();
            if (db.DanhSachPhongTo.Count() > 0)
                return db.DanhSachPhongTo
                    .ToDictionary(k => k.Id, v => v.Loai + " " + v.Name);
            return null;
        }

        private string ProcessAvatar(string HinhAnh)
        {
            try
            {
                string temp = Server.MapPath("~/Temp");
                string path = Server.MapPath("~/ProfilePicture");
                if(!File.Exists(temp + "\\" + HinhAnh)) //Không upload hình mới
                {
                    if (File.Exists(path + "\\" + HinhAnh))
                    {
                        return HinhAnh;
                    }
                }
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
            else if (string.IsNullOrEmpty(HinhAnh.Value))
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
                gv.DataSource = ((NhanVien)frmMain.DataItem).TrinhDo;
                gv.DataBind();
            }
        }

        protected List<HocVan> LayDanhSachHocVan()
        {
            List<HocVan> dsHocVan = new List<HocVan>();
            GridView gvTrinhDo = (GridView)frmMain.FindControl("gvTrinhDo");

            foreach (GridViewRow row in gvTrinhDo.Rows)
            {
                HocVan hocVan = new HocVan();
                string id = ((HiddenField)row.FindControl("Id")).Value;
                if (!string.IsNullOrEmpty(id))
                {
                    hocVan.Id = int.Parse(id);
                }
                hocVan.TrinhDo = ((DropDownList)row.FindControl("TrinhDo")).SelectedValue;
                hocVan.ChuyenNganh = ((TextBox)row.FindControl("ChuyenNganh")).Text;
                dsHocVan.Add(hocVan);
            }

            return dsHocVan;
        }

        protected void SuaDanhSachHocVan(IList<HocVan> dsSua, ApplicationDbContext db)
        {
            IList<HocVan> dsHocVan = new List<HocVan>();
            IList<int> existedIds = new List<int>();
            GridView gvTrinhDo = (GridView)frmMain.FindControl("gvTrinhDo");

            foreach (GridViewRow row in gvTrinhDo.Rows)
            {
                string id = ((HiddenField)row.FindControl("Id")).Value;
                HocVan trackingItem = dsSua.FirstOrDefault(m => m.Id.ToString().Equals(id));
                string TrinhDo = ((DropDownList)row.FindControl("TrinhDo")).SelectedValue;
                string ChuyenNganh = ((TextBox)row.FindControl("ChuyenNganh")).Text;
                if (trackingItem != null)
                {
                    trackingItem.TrinhDo = TrinhDo;
                    trackingItem.ChuyenNganh = ChuyenNganh;
                    existedIds.Add(int.Parse(id));
                }
                else
                {
                    HocVan hocVan = new HocVan();
                    hocVan.TrinhDo = TrinhDo;
                    hocVan.ChuyenNganh = ChuyenNganh;
                    dsHocVan.Add(hocVan);
                }
            }
            for (int i = 0; i < dsSua.Count; i++)
            {
                var entity = dsSua[i];
                if (!existedIds.Contains(entity.Id))
                {
                    db.DanhSachHocVan.Remove(entity);
                    dsSua.Remove(entity);
                }
            }
            foreach(var item in dsHocVan)
            {
                dsSua.Add(item);
            }
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

        protected void BangCapKhac_Load(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            if (!IsPostBack)
            {
                gv.DataSource = ((NhanVien)frmMain.DataItem).BangCapKhac;
                gv.DataBind();
            }
        }
        
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
                string id = ((HiddenField)row.FindControl("Id")).Value;
                if (!string.IsNullOrEmpty(id))
                {
                    bangCapKhac.Id = int.Parse(id);
                }
                bangCapKhac.LoaiBangCap = ((DropDownList)row.FindControl("LoaiBangCap")).SelectedValue;
                bangCapKhac.TenBangCap = ((TextBox)row.FindControl("TenBangCap")).Text;
                bangCapKhac.CapDo = ((TextBox)row.FindControl("CapDo")).Text;
                dsBangCapKhac.Add(bangCapKhac);
            }

            return dsBangCapKhac;
        }

        protected void SuaDanhSachBangCap(IList<BangCapKhac> dsSua, ApplicationDbContext db)
        {
            IList<BangCapKhac> dsBangCapKhac = new List<BangCapKhac>();
            IList<int> existedIds = new List<int>();
            GridView gvBangCapKhac = (GridView)frmMain.FindControl("BangCapKhac");

            foreach (GridViewRow row in gvBangCapKhac.Rows)
            {
                string id = ((HiddenField)row.FindControl("Id")).Value;
                BangCapKhac trackingItem = dsSua.FirstOrDefault(m => m.Id.ToString().Equals(id));

                string LoaiBangCap = ((DropDownList)row.FindControl("LoaiBangCap")).SelectedValue;
                string TenBangCap = ((TextBox)row.FindControl("TenBangCap")).Text;
                string CapDo = ((TextBox)row.FindControl("CapDo")).Text;

                if (trackingItem != null)
                {
                    trackingItem.LoaiBangCap = LoaiBangCap;
                    trackingItem.TenBangCap = TenBangCap;
                    trackingItem.CapDo = CapDo;
                    existedIds.Add(int.Parse(id));
                }
                else
                {
                    BangCapKhac bangCapKhac = new BangCapKhac();
                    bangCapKhac.LoaiBangCap = LoaiBangCap;
                    bangCapKhac.TenBangCap = TenBangCap;
                    bangCapKhac.CapDo = CapDo;
                    dsBangCapKhac.Add(bangCapKhac);
                }
            }

            for (int i = 0; i < dsSua.Count; i++)
            {
                var entity = dsSua[i];
                if (!existedIds.Contains(entity.Id))
                {
                    db.DanhSachBangCapKhac.Remove(entity);
                    dsSua.Remove(entity);
                }
            }
            foreach(var item in dsBangCapKhac)
            {
                dsSua.Add(item);
            }
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
                gv.DataSource = ((NhanVien)frmMain.DataItem).QuaTrinhCongTac;
                gv.DataBind();
            }
        }

        protected List<CongTac> LayDanhSachCongTac()
        {
            List<CongTac> dsCongTac = new List<CongTac>();
            GridView gvCongTac = (GridView)frmMain.FindControl("gvCongTac");

            foreach (GridViewRow row in gvCongTac.Rows)
            {
                CongTac congTac = new CongTac();
                string id = ((HiddenField)row.FindControl("Id")).Value;
                if (!string.IsNullOrEmpty(id))
                {
                    congTac.Id = int.Parse(id);
                }
                congTac.ThoiGian = ((TextBox)row.FindControl("ThoiGian")).Text;
                congTac.DonViCongTac = ((TextBox)row.FindControl("DonViCongTac")).Text;
                congTac.ChucVu = ((TextBox)row.FindControl("ChucVu")).Text;
                dsCongTac.Add(congTac);
            }

            return dsCongTac;
        }

        protected void SuaDanhSachCongTac(IList<CongTac> dsSua, ApplicationDbContext db)
        {
            IList<CongTac> dsCongTac = new List<CongTac>();
            IList<int> existedIds = new List<int>();
            GridView gvCongTac = (GridView)frmMain.FindControl("gvCongTac");

            foreach (GridViewRow row in gvCongTac.Rows)
            {
                string id = ((HiddenField)row.FindControl("Id")).Value;
                CongTac trackingItem = dsSua.FirstOrDefault(m => m.Id.ToString().Equals(id));
                string ThoiGian = ((TextBox)row.FindControl("ThoiGian")).Text;
                string DonViCongTac = ((TextBox)row.FindControl("DonViCongTac")).Text;
                string ChucVu = ((TextBox)row.FindControl("ChucVu")).Text;
                if (trackingItem != null)
                {
                    trackingItem.ThoiGian = ThoiGian;
                    trackingItem.DonViCongTac = DonViCongTac;
                    trackingItem.ChucVu = ChucVu;
                    existedIds.Add(int.Parse(id));
                }
                else
                {
                    CongTac congTac = new CongTac();
                    congTac.ThoiGian = ThoiGian;
                    congTac.DonViCongTac = DonViCongTac;
                    congTac.ChucVu = ChucVu;
                    dsCongTac.Add(congTac);
                }
            }
            for (int i = 0; i < dsSua.Count; i++)
            {
                var entity = dsSua[i];
                if (!existedIds.Contains(entity.Id))
                {
                    db.DanhSachCongTac.Remove(entity);
                    dsSua.Remove(entity);
                }
            }
            foreach (var item in dsCongTac)
            {
                dsSua.Add(item);
            }
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
                gv.DataSource = ((NhanVien)frmMain.DataItem).QuaTrinhTangLuong;
                gv.DataBind();
            }
        }

        protected List<TangLuong> LayDanhSachTangLuong()
        {
            List<TangLuong> dsTangLuong = new List<TangLuong>();
            GridView gvTangLuong = (GridView)frmMain.FindControl("gvTangLuong");

            foreach (GridViewRow row in gvTangLuong.Rows)
            {
                TangLuong tangLuong = new TangLuong();
                string id = ((HiddenField)row.FindControl("Id")).Value;
                if (!string.IsNullOrEmpty(id))
                {
                    tangLuong.Id = int.Parse(id);
                }

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

        protected void SuaDanhSachTangLuong(IList<TangLuong> dsSua, ApplicationDbContext db)
        {
            IList<TangLuong> dsTangLuong = new List<TangLuong>();
            IList<int> existedIds = new List<int>();
            GridView gvTangLuong = (GridView)frmMain.FindControl("gvTangLuong");

            foreach (GridViewRow row in gvTangLuong.Rows)
            {
                string id = ((HiddenField)row.FindControl("Id")).Value;
                TangLuong trackingItem = dsSua.FirstOrDefault(m => m.Id.ToString().Equals(id));
                string ThoiGian = ((TextBox)row.FindControl("ThoiGian")).Text;
                double bacLuong = 0;
                double heSoLuong = 0;
                double.TryParse(((TextBox)row.FindControl("BacLuong")).Text, out bacLuong);
                double.TryParse(((TextBox)row.FindControl("HeSoLuong")).Text, out heSoLuong);
                if (trackingItem != null)
                {
                    trackingItem.ThoiGian = ThoiGian;
                    trackingItem.BacLuong = bacLuong;
                    trackingItem.HeSoLuong = heSoLuong;
                    existedIds.Add(int.Parse(id));
                }
                else
                {
                    TangLuong tangLuong = new TangLuong();
                    tangLuong.ThoiGian = ThoiGian;
                    tangLuong.BacLuong = bacLuong;
                    tangLuong.HeSoLuong = heSoLuong;
                    dsTangLuong.Add(tangLuong);
                }
            }
            for (int i = 0; i < dsSua.Count; i++)
            {
                var entity = dsSua[i];
                if (!existedIds.Contains(entity.Id))
                {
                    db.DanhSachTangLuong.Remove(entity);
                    dsSua.Remove(entity);
                }
            }
            foreach (var item in dsTangLuong)
            {
                dsSua.Add(item);
            }
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
            List<TangLuong> dsTangLuong = LayDanhSachTangLuong();
            dsTangLuong.RemoveAt(e.RowIndex);
            gvTangLuong.DataSource = dsTangLuong;
            gvTangLuong.DataBind();
        }

        #endregion

        #region QuaTrinhKhenThuong

        protected void gvKhenThuong_Load(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            if (!IsPostBack)
            {
                gv.DataSource = ((NhanVien)frmMain.DataItem).QuaTrinhKhenThuong;
                gv.DataBind();
            }
        }

        protected List<KhenThuong> LayDanhSachKhenThuong()
        {
            List<KhenThuong> dsKhenThuong = new List<KhenThuong>();
            GridView gvKhenThuong = (GridView)frmMain.FindControl("gvKhenThuong");

            foreach (GridViewRow row in gvKhenThuong.Rows)
            {
                KhenThuong khenThuong = new KhenThuong();
                string id = ((HiddenField)row.FindControl("Id")).Value;
                if (!string.IsNullOrEmpty(id))
                {
                    khenThuong.Id = int.Parse(id);
                }
                khenThuong.ThoiGian = ((TextBox)row.FindControl("ThoiGian")).Text;
                khenThuong.LyDoHinhThuc = ((TextBox)row.FindControl("LyDoHinhThuc")).Text;
                khenThuong.CapQuyetDinh = ((TextBox)row.FindControl("CapQuyetDinh")).Text;
                dsKhenThuong.Add(khenThuong);
            }

            return dsKhenThuong;
        }

        protected void SuaDanhSachKhenThuong(IList<KhenThuong> dsSua, ApplicationDbContext db)
        {
            IList<KhenThuong> dsKhenThuong = new List<KhenThuong>();
            IList<int> existedIds = new List<int>();
            GridView gvKhenThuong = (GridView)frmMain.FindControl("gvKhenThuong");

            foreach (GridViewRow row in gvKhenThuong.Rows)
            {
                string id = ((HiddenField)row.FindControl("Id")).Value;
                KhenThuong trackingItem = dsSua.FirstOrDefault(m => m.Id.ToString().Equals(id));
                string ThoiGian = ((TextBox)row.FindControl("ThoiGian")).Text;
                string LyDoHinhThuc = ((TextBox)row.FindControl("LyDoHinhThuc")).Text;
                string CapQuyetDinh = ((TextBox)row.FindControl("CapQuyetDinh")).Text;
                if (trackingItem != null)
                {
                    trackingItem.ThoiGian = ThoiGian;
                    trackingItem.LyDoHinhThuc = LyDoHinhThuc;
                    trackingItem.CapQuyetDinh = CapQuyetDinh;
                    existedIds.Add(int.Parse(id));
                }
                else
                {
                    KhenThuong khenThuong = new KhenThuong();
                    khenThuong.ThoiGian = ThoiGian;
                    khenThuong.LyDoHinhThuc = LyDoHinhThuc;
                    khenThuong.CapQuyetDinh = CapQuyetDinh;
                    dsKhenThuong.Add(khenThuong);
                }
            }
            for (int i = 0; i < dsSua.Count; i++)
            {
                var entity = dsSua[i];
                if (!existedIds.Contains(entity.Id))
                {
                    db.DanhSachKhenThuong.Remove(entity);
                    dsSua.Remove(entity);
                }
            }
            foreach (var item in dsKhenThuong)
            {
                dsSua.Add(item);
            }
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

        #region QuaTrinhKyLuat

        protected void gvKyLuat_Load(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            if (!IsPostBack)
            {
                gv.DataSource = ((NhanVien)frmMain.DataItem).QuaTrinhKyLuat;
                gv.DataBind();
            }
        }

        protected List<KyLuat> LayDanhSachKyLuat()
        {
            List<KyLuat> dsKyLuat = new List<KyLuat>();
            GridView gvKyLuat = (GridView)frmMain.FindControl("gvKyLuat");

            foreach (GridViewRow row in gvKyLuat.Rows)
            {
                KyLuat kyLuat = new KyLuat();
                string id = ((HiddenField)row.FindControl("Id")).Value;
                if (!string.IsNullOrEmpty(id))
                {
                    kyLuat.Id = int.Parse(id);
                }
                kyLuat.ThoiGian = ((TextBox)row.FindControl("ThoiGian")).Text;
                kyLuat.LyDoHinhThuc = ((TextBox)row.FindControl("LyDoHinhThuc")).Text;
                kyLuat.CapQuyetDinh = ((TextBox)row.FindControl("CapQuyetDinh")).Text;
                dsKyLuat.Add(kyLuat);
            }

            return dsKyLuat;
        }

        protected void SuaDanhSachKyLuat(IList<KyLuat> dsSua, ApplicationDbContext db)
        {
            IList<KyLuat> dsKyLuat = new List<KyLuat>();
            IList<int> existedIds = new List<int>();
            GridView gvKyLuat = (GridView)frmMain.FindControl("gvKyLuat");

            foreach (GridViewRow row in gvKyLuat.Rows)
            {
                string id = ((HiddenField)row.FindControl("Id")).Value;
                KyLuat trackingItem = dsSua.FirstOrDefault(m => m.Id.ToString().Equals(id));
                string ThoiGian = ((TextBox)row.FindControl("ThoiGian")).Text;
                string LyDoHinhThuc = ((TextBox)row.FindControl("LyDoHinhThuc")).Text;
                string CapQuyetDinh = ((TextBox)row.FindControl("CapQuyetDinh")).Text;
                if (trackingItem != null)
                {
                    trackingItem.ThoiGian = ThoiGian;
                    trackingItem.LyDoHinhThuc = LyDoHinhThuc;
                    trackingItem.CapQuyetDinh = CapQuyetDinh;
                    existedIds.Add(int.Parse(id));
                }
                else
                {
                    KyLuat kyLuat = new KyLuat();
                    kyLuat.ThoiGian = ThoiGian;
                    kyLuat.LyDoHinhThuc = LyDoHinhThuc;
                    kyLuat.CapQuyetDinh = CapQuyetDinh;
                    dsKyLuat.Add(kyLuat);
                }
            }
            for (int i = 0; i < dsSua.Count; i++)
            {
                var entity = dsSua[i];
                if (!existedIds.Contains(entity.Id))
                {
                    db.DanhSachKyLuat.Remove(entity);
                    dsSua.Remove(entity);
                }
            }
            foreach (var item in dsKyLuat)
            {
                dsSua.Add(item);
            }
        }

        protected void btThemKyLuat_Click(object sender, EventArgs e)
        {
            GridView gvKyLuat = (GridView)frmMain.FindControl("gvKyLuat");
            List<KyLuat> dsKyLuat = LayDanhSachKyLuat();
            dsKyLuat.Add(new KyLuat());
            gvKyLuat.DataSource = dsKyLuat;
            gvKyLuat.DataBind();
        }

        protected void gvKyLuat_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gvKyLuat = (GridView)frmMain.FindControl("gvKyLuat");
            List<KyLuat> dsKyLuat = LayDanhSachKyLuat();
            dsKyLuat.RemoveAt(e.RowIndex);
            gvKyLuat.DataSource = dsKyLuat;
            gvKyLuat.DataBind();
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
                string id = ((HiddenField)row.FindControl("Id")).Value;
                if (!string.IsNullOrEmpty(id))
                {
                    nguoiThan.Id = int.Parse(id);
                }
                nguoiThan.Name = ((TextBox)row.FindControl("Hoten")).Text;
                nguoiThan.QuanHe = ((DropDownList)row.FindControl("QuanHe")).SelectedValue;
                nguoiThan.GioiTinh = ((DropDownList)row.FindControl("GioiTinh")).SelectedValue;
                nguoiThan.TinhTrang = ((TextBox)row.FindControl("TinhTrang")).Text;
                nguoiThan.NgaySinh = ((TextBox)row.FindControl("NgaySinh")).Text;
                nguoiThan.NgheNghiep = ((TextBox)row.FindControl("NgheNghiep")).Text;
                nguoiThan.ThuongTru = new DiaChi();
                string thuongTruId = ((HiddenField)row.FindControl("DiaChi_Id")).Value;
                if (!string.IsNullOrEmpty(thuongTruId))
                {
                    nguoiThan.ThuongTru.Id = int.Parse(thuongTruId);
                }
                nguoiThan.ThuongTru.Xa = ((TextBox)row.FindControl("DiaChi_Xa")).Text;
                nguoiThan.ThuongTru.Huyen = ((TextBox)row.FindControl("DiaChi_Huyen")).Text;
                nguoiThan.ThuongTru.Tinh = ((TextBox)row.FindControl("DiaChi_Tinh")).Text;
                dsNguoiThan.Add(nguoiThan);
            }

            return dsNguoiThan;
        }

        protected void SuaDanhSachNguoiThan(IList<NguoiThan> dsSua, ApplicationDbContext db)
        {
            IList<NguoiThan> dsNguoiThan = new List<NguoiThan>();
            IList<int> existedIds = new List<int>();
            GridView gvNguoiThan = (GridView)frmMain.FindControl("NguoiThan");

            foreach (GridViewRow row in gvNguoiThan.Rows)
            {
                string id = ((HiddenField)row.FindControl("Id")).Value;
                NguoiThan trackingItem = dsSua.FirstOrDefault(m => m.Id.ToString().Equals(id));

                string Id = ((HiddenField)row.FindControl("Id")).Value;
                string Name = ((TextBox)row.FindControl("Hoten")).Text;
                string QuanHe = ((DropDownList)row.FindControl("QuanHe")).SelectedValue;
                string GioiTinh = ((DropDownList)row.FindControl("GioiTinh")).SelectedValue;
                string TinhTrang = ((TextBox)row.FindControl("TinhTrang")).Text;
                string NgaySinh = ((TextBox)row.FindControl("NgaySinh")).Text;
                string NgheNghiep = ((TextBox)row.FindControl("NgheNghiep")).Text;
                string ThuongTru_Id = ((HiddenField)row.FindControl("DiaChi_Id")).Value;
                string ThuongTru_Xa = ((TextBox)row.FindControl("DiaChi_Xa")).Text;
                string ThuongTru_Huyen = ((TextBox)row.FindControl("DiaChi_Huyen")).Text;
                string ThuongTru_Tinh = ((TextBox)row.FindControl("DiaChi_Tinh")).Text;

                if (trackingItem != null)
                {
                    trackingItem.Name = Name;
                    trackingItem.QuanHe = QuanHe;
                    trackingItem.GioiTinh = GioiTinh;
                    trackingItem.TinhTrang = TinhTrang;
                    trackingItem.NgaySinh = NgaySinh;
                    trackingItem.NgheNghiep = NgheNghiep;
                    if (trackingItem == null)
                    {
                        trackingItem.ThuongTru = new DiaChi();
                    }
                    if (string.IsNullOrEmpty(ThuongTru_Id) == false)
                    {
                        trackingItem.ThuongTru.Id = int.Parse(ThuongTru_Id);
                    }
                    trackingItem.ThuongTru.Xa = ThuongTru_Xa;
                    trackingItem.ThuongTru.Huyen = ThuongTru_Huyen;
                    trackingItem.ThuongTru.Tinh = ThuongTru_Tinh;
                    existedIds.Add(int.Parse(id));
                }
                else
                {
                    NguoiThan nguoiThan = new NguoiThan();
                    nguoiThan.Name = Name;
                    nguoiThan.QuanHe = QuanHe;
                    nguoiThan.GioiTinh = GioiTinh;
                    nguoiThan.TinhTrang = TinhTrang;
                    nguoiThan.NgaySinh = NgaySinh;
                    nguoiThan.NgheNghiep = NgheNghiep;
                    nguoiThan.ThuongTru = new DiaChi();
                    nguoiThan.ThuongTru.Xa = ThuongTru_Xa;
                    nguoiThan.ThuongTru.Huyen = ThuongTru_Huyen;
                    nguoiThan.ThuongTru.Tinh = ThuongTru_Tinh;
                    dsNguoiThan.Add(nguoiThan);
                }
            }

            for (int i = 0; i < dsSua.Count; i++)
            {
                var entity = dsSua[i];
                if (!existedIds.Contains(entity.Id))
                {
                    db.DanhSachNguoiThan.Remove(entity);
                    dsSua.Remove(entity);
                }
            }

            foreach(var item in dsNguoiThan)
            {
                dsSua.Add(item);
            }
        }

        protected void NguoiThan_Load(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            if (!IsPostBack)
            {
                gv.DataSource = ((NhanVien)frmMain.DataItem).NguoiThan;
                gv.DataBind();
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
        public NhanVien frmMain_GetItem()
        {
            ApplicationDbContext db = ApplicationDbContext.Create();
            return db.DanhSachNhanVien.Find(maSoNhanVien);
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationDbContext db = ApplicationDbContext.Create())
                {
                    var nhanVien = new NhanVien();
                    valSummary.Visible = true;
                    TryUpdateModel(nhanVien);
                    
                    nhanVien.TrinhDo = LayDanhSachHocVan();
                    nhanVien.BangCapKhac = LayDanhSachBangCap();
                    nhanVien.NguoiThan = LayDanhSachNguoiThan();
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
                ModelState.AddModelError("Summary", "Đã tồn tại nhân viên với mã số này!");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Summary", "Lỗi hệ thống!");
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void frmMain_UpdateItem(string id)
        {
            NhanVien nhanVien = null;

            try
            {
                using (ApplicationDbContext db = ApplicationDbContext.Create())
                {
                    nhanVien = db.DanhSachNhanVien.Find(id);
                    db.DanhSachNhanVien.Attach(nhanVien);
                    var phongToOld = nhanVien.PhongTo;
                    db.DanhSachPhongTo.Attach(phongToOld);

                    if(nhanVien == null)
                    {
                        ModelState.AddModelError("", String.Format("Không tồn tại nhân viên có mã số {0}", id));
                    }

                    valSummary.Visible = true;
                    TryUpdateModel(nhanVien);
                    SuaDanhSachHocVan(nhanVien.TrinhDo, db);
                    SuaDanhSachBangCap(nhanVien.BangCapKhac, db);
                    SuaDanhSachCongTac(nhanVien.QuaTrinhCongTac, db);
                    SuaDanhSachTangLuong(nhanVien.QuaTrinhTangLuong, db);
                    SuaDanhSachKhenThuong(nhanVien.QuaTrinhKhenThuong, db);
                    SuaDanhSachKyLuat(nhanVien.QuaTrinhKyLuat, db);
                    SuaDanhSachNguoiThan(nhanVien.NguoiThan, db);

                    DropDownList phongTo = (DropDownList)frmMain.FindControl("ddlPhongTo");
                    nhanVien.PhongTo = db.DanhSachPhongTo.First(m => m.Id.Equals(phongTo.SelectedValue));

                    if (ModelState.IsValid)
                    {
                        HiddenField HinhAnh = (HiddenField)frmMain.FindControl("HinhAnh");
                        if (!nhanVien.HinhAnh.Equals(HinhAnh.Value))
                        {
                            nhanVien.HinhAnh = ProcessAvatar(HinhAnh.Value);
                        }
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
                ModelState.AddModelError("Summary", "Đã tồn tại nhân viên với mã số này!");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Summary", "Lỗi hệ thống!");
            }
        }
    }
}