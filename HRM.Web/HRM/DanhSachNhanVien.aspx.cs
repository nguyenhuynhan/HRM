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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IList<NhanVien> LayDanhSachNhanVien()
        {
            var db = ApplicationDbContext.Create();
            return db.DanhSachNhanVien.ToList();
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