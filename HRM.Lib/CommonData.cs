using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.DataModel;

namespace HRM.Lib
{
    public class CommonData
    {
        private static List<EnumItem> EnumList;
        public static void InitializeLookupList()
        {
            if (EnumList == null)
            {
                EnumList = new List<EnumItem>();
            }
            EnumList.Add(new EnumItem() { Type = "PhongTo", Word = "Phòng" });
            EnumList.Add(new EnumItem() { Type = "PhongTo", Word = "Tổ" });
            EnumList.Add(new EnumItem() { Type = "PhongTo", Word = "Ban" });

            EnumList.Add(new EnumItem() { Type = "GioiTinh", Word = "Nam" });
            EnumList.Add(new EnumItem() { Type = "GioiTinh", Word = "Nữ" });

            EnumList.Add(new EnumItem() { Type = "TinhTrangHonNhan", Word = "Độc thân" });
            EnumList.Add(new EnumItem() { Type = "TinhTrangHonNhan", Word = "Đã kết hôn" });

            EnumList.Add(new EnumItem() { Type = "LyLuanChinhTri", Word = "Sơ cấp" });
            EnumList.Add(new EnumItem() { Type = "LyLuanChinhTri", Word = "Trung cấp" });
            EnumList.Add(new EnumItem() { Type = "LyLuanChinhTri", Word = "Cao cấp" });
            EnumList.Add(new EnumItem() { Type = "LyLuanChinhTri", Word = "Cử nhân" });

            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Chủ tịch" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Giám đốc" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Kiểm soát viên" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Phó giám đốc" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Trưởng phòng" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Phó trưởng phòng" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Tổ trưởng" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Tổ phó" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Kế toán trưởng" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Thư ký" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Chuyên viên" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Nhân viên" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Cán sự" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Trợ lý" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Tài xế" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Bảo vệ" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Tạp vụ" });
            EnumList.Add(new EnumItem() { Type = "ChucVu", Word = "Khác" });

            EnumList.Add(new EnumItem() { Type = "TrinhDo", Word = "THCS" });
            EnumList.Add(new EnumItem() { Type = "TrinhDo", Word = "THPT" });
            EnumList.Add(new EnumItem() { Type = "TrinhDo", Word = "Sơ cấp" });
            EnumList.Add(new EnumItem() { Type = "TrinhDo", Word = "Trung Cấp" });
            EnumList.Add(new EnumItem() { Type = "TrinhDo", Word = "Cao đẳng" });
            EnumList.Add(new EnumItem() { Type = "TrinhDo", Word = "Đại học" });
            EnumList.Add(new EnumItem() { Type = "TrinhDo", Word = "Thạc sỹ" });
            EnumList.Add(new EnumItem() { Type = "TrinhDo", Word = "Tiến sỹ" });

            EnumList.Add(new EnumItem() { Type = "LoaiBangCap", Word = "Tin học" });
            EnumList.Add(new EnumItem() { Type = "LoaiBangCap", Word = "Ngoại ngữ" });

            EnumList.Add(new EnumItem() { Type = "QuanHe", Word = "Cha" });
            EnumList.Add(new EnumItem() { Type = "QuanHe", Word = "Mẹ" });
            EnumList.Add(new EnumItem() { Type = "QuanHe", Word = "Vợ" });
            EnumList.Add(new EnumItem() { Type = "QuanHe", Word = "Chồng" });
            EnumList.Add(new EnumItem() { Type = "QuanHe", Word = "Anh" });
            EnumList.Add(new EnumItem() { Type = "QuanHe", Word = "Chị" });
            EnumList.Add(new EnumItem() { Type = "QuanHe", Word = "Em" });
            EnumList.Add(new EnumItem() { Type = "QuanHe", Word = "Con" });
            EnumList.Add(new EnumItem() { Type = "QuanHe", Word = "Cháu" });

            EnumList.Add(new EnumItem() { Type = "TinhTrangQuanHe", Word = "Còn sống" });
            EnumList.Add(new EnumItem() { Type = "TinhTrangQuanHe", Word = "Đã mất" });

        }

        public static List<string> GetEnumList(string type)
        {
            if (EnumList == null)
            {
                InitializeLookupList();
            }
            List<string> result = new List<string>();
            result.Add("");
            result.AddRange(EnumList.Where(m => m.Type.Equals(type)).Select(m => m.Word).ToList());
            return result;
        }
    }
}
