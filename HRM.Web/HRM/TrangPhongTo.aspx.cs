using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRM.Web.Models;
using HRM.DataModel;

namespace HRM.Web.WebPage
{
    public partial class TrangPhongTo : System.Web.UI.Page
    {
        private bool _isEmplyList = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<PhongTo> LayDanhSachPhongTo()
        {
            var db = ApplicationDbContext.Create();
            if (db.DanhSachPhongTo.Count() == 0)
            {
                PhongTo phongTo = new PhongTo();
                List<PhongTo> emptyList = new List<PhongTo>();
                emptyList.Add(phongTo);
                gvDanhSachPhongTo.ShowFooter = true;
                btThem.Visible = false;
                _isEmplyList = true;
                return emptyList;
            }
            _isEmplyList = false;
            return db.DanhSachPhongTo.ToList();
        }

        public void CapNhat()
        {
            var row = gvDanhSachPhongTo.Rows[gvDanhSachPhongTo.EditIndex];
            string maPhongTo = ((Label)row.FindControl("lblMaPhongTo")).Text;
            string tenPhongTo = ((TextBox)row.FindControl("txtTenPhongTo")).Text;
            string loaiPhongTo = ((DropDownList)row.FindControl("ddlLoaiPhongTo")).SelectedValue;
            using (ApplicationDbContext db = ApplicationDbContext.Create())
            {
                PhongTo PhongTo = db.DanhSachPhongTo.FirstOrDefault(m => m.Id.Equals(maPhongTo));
                if (PhongTo != null)
                {
                    PhongTo.Loai = loaiPhongTo;
                    PhongTo.Name = tenPhongTo;
                }
                db.SaveChanges();
            }
        }

        protected void btThem_Click(object sender, EventArgs e)
        {
            btThem.Visible = false;
            gvDanhSachPhongTo.ShowFooter = true;
        }

        protected void gvDanhSachPhongTo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            btThem.Visible = true;
            gvDanhSachPhongTo.ShowFooter = false;
        }

        protected void gvDanhSachPhongTo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            btThem.Visible = false;
            gvDanhSachPhongTo.ShowFooter = false;
        }

        protected void btLuuThemMoi_Click(object sender, EventArgs e)
        {
            GridViewRow row = gvDanhSachPhongTo.FooterRow;

            string maPhongTo = ((TextBox)row.FindControl("txtMaPhongTo")).Text;
            string tenPhongTo = ((TextBox)row.FindControl("txtTenPhongTo")).Text;
            string loaiPhongTo = ((DropDownList)row.FindControl("ddlLoaiPhongTo")).SelectedValue;
            using (ApplicationDbContext db = ApplicationDbContext.Create())
            {
                PhongTo PhongTo = new PhongTo();
                PhongTo.Id = maPhongTo;
                PhongTo.Name = tenPhongTo;
                PhongTo.Loai = loaiPhongTo;

                db.DanhSachPhongTo.Add(PhongTo);

                db.SaveChanges();

                gvDanhSachPhongTo.ShowFooter = false;
                btThem.Visible = true;
                gvDanhSachPhongTo.DataBind();
            }
        }

        protected void gvDanhSachPhongTo_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (_isEmplyList && e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells.Clear();
            }
        }

        protected void gvDanhSachPhongTo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            gvDanhSachPhongTo.EditIndex = e.RowIndex;
        }

        public void Xoa()
        {
            GridViewRow row = gvDanhSachPhongTo.Rows[gvDanhSachPhongTo.EditIndex];

            string maPhongTo = ((Label)row.FindControl("lblMaPhongTo")).Text;

            using (var db = ApplicationDbContext.Create())
            {
                PhongTo phongTo = db.DanhSachPhongTo.FirstOrDefault(m => m.Id.Equals(maPhongTo));
                if (phongTo != null)
                {
                    db.DanhSachPhongTo.Remove(phongTo);
                }
                db.SaveChanges();
            }
        }
    }
}