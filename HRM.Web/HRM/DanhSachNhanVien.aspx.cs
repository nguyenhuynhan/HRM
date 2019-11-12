using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRM.Web.Models;
using HRM.DataModel;
using System.IO;

namespace HRM.Web.WebPage
{
    public partial class DanhSachNhanVien : System.Web.UI.Page
    {
        private bool _isEmplyList = false;
        private int index = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IList<NhanVien> LayDanhSachNhanVien()
        {
            var db = ApplicationDbContext.Create();
            var search = Request.QueryString["s"];
            if (!string.IsNullOrEmpty(search))
            {
                var s = search.ToLower();
                return db.DanhSachNhanVien.Where(m => m.Id.ToLower().Contains(s) || m.Ten.ToLower().Contains(s) || m.HoVaChuLot.ToLower().Contains(s))
                    .OrderBy(m => m.Ten).ThenBy(m => m.HoVaChuLot)
                    .ToList();
            }

            var phongTo = Request.QueryString["phong"];
            if (string.IsNullOrEmpty(phongTo)) {
                return db.DanhSachNhanVien.OrderBy(m => m.Ten).ThenBy(m => m.HoVaChuLot).ToList();
            }
            return db.DanhSachNhanVien.Where(m => m.PhongTo.Id == phongTo).OrderBy(m => m.Ten).ThenBy(m => m.HoVaChuLot).ToList();
        }
        
        public void gvDanhSachNhanVien_DeleteItem(string id)
        {
            using (var db = ApplicationDbContext.Create())
            {
                NhanVien nhanVien = db.DanhSachNhanVien.Find(id);
                if (nhanVien != null)
                {
                    db.DanhSachNhanVien.Remove(nhanVien);
                }
                db.SaveChanges();
                string picture = Server.MapPath("~/PictureProfile/" + id + ".jpg");
                if (File.Exists(picture))
                {
                    File.Delete(picture);
                }
            }
        }
    }
}