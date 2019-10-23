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
    public partial class InThongTinNhanVien : System.Web.UI.Page
    {
        private string maSoNhanVien = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            maSoNhanVien = Request["masonhanvien"];
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public NhanVien frmMain_GetItem()
        {
            ApplicationDbContext db = ApplicationDbContext.Create();
            return db.DanhSachNhanVien.FirstOrDefault(m => m.Id.Equals(maSoNhanVien));
        }

        protected string HienThiDiaChi(DiaChi diachi)
        {
            string result = "";
            string semi = "";
            if (!string.IsNullOrEmpty(diachi.Xa))
            {
                result += diachi.Xa;
                semi = ", ";
            }

            if (!string.IsNullOrEmpty(diachi.Huyen))
            {
                result += semi + diachi.Huyen;
                semi = ", ";
            }

            if (!string.IsNullOrEmpty(diachi.Huyen))
            {
                result += semi + diachi.Tinh;
            }
            return result;
        }
    }
}