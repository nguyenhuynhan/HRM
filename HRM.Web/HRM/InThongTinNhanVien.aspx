<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InThongTinNhanVien.aspx.cs" Inherits="HRM.Web.HRM.InThongTinNhanVien" Title="Hồ sơ nhân viên" %>

<asp:Content runat="server" ContentPlaceHolderID="HeaderMainStyleContent">
    <%: Styles.Render("~/bundles/print") %>
</asp:Content>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="MainTitle"></asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="float-left text-center">
        <div>ỦY BAN NHÂN DÂN TỈNH ĐỒNG THÁP</div>
        <div><b>CÔNG TY TNHHMTV XSKT</b></div>
        <div>---------------</div>
    </div>
    <div class="float-right text-center">
        <div><b>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</b></div>
        <div><b>Độc lập - Tự do - Hạnh Phúc</b></div>
        <div>---------------</div>
    </div>
    <div class="clear-fix text-center">
        <br />
        <h2>LÝ LỊCH NHÂN VIÊN</h2>
    </div>

    <asp:FormView ID="frmMain" runat="server"
        ItemType="HRM.DataModel.NhanVien"
        RenderOuterTable="false"
        SelectMethod="frmMain_GetItem">
        <ItemTemplate>
            <div class="field-header">I. THÔNG TIN CÁ NHÂN</div>
            <div>
                <div class="float-right avatar-container">
                    <asp:Image runat="server" CssClass="avatar-image" ImageUrl='<%# HRM.Lib.WebHelper.GetImagePath(Item.HinhAnh) %>' />
                </div>
                <div class="float-left common-info">
                    <div>
                        <asp:Label runat="server" Text="Họ và tên: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# (Item.HoVaChuLot + " " + Item.Ten).ToUpper() %>'></asp:Label>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="CMND: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.CMND %>'></asp:Label>
                    </div>
                    <%--<div>
                        <asp:Label runat="server" Text="Mã số: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.Id %>'></asp:Label>
                    </div>--%>
                    <div>
                        <asp:Label runat="server" Text="Ngày sinh: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.NgaySinh %>'></asp:Label>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Giới tính: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.GioiTinh %>'></asp:Label>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Tình trạng hôn nhân: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.TinhTrangHonNhan %>'></asp:Label>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Quê quán: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# HienThiDiaChi(Item.QueQuan) %>'></asp:Label>
                    </div>
                    <div runat="server" visible='<%# Item.HienTai != null && !string.IsNullOrEmpty(HienThiDiaChi(Item.HienTai)) %>'>
                        <asp:Label runat="server" Text="Thường trú: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# HienThiDiaChi(Item.HienTai) %>'></asp:Label>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Đơn vị: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.PhongTo.Loai + " " + Item.PhongTo.Name %>'>
                        </asp:Label>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Chức vụ, nhiệm vụ: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.ChucVu %>'></asp:Label>
                    </div>
                    <div runat="server" visible='<%# !string.IsNullOrEmpty(Item.NgayThamGiaCachMang) %>'>
                        <asp:Label runat="server" Text="Ngày vào Đoàn: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.NgayTangLuong %>'></asp:Label>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Ngày vào công ty: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.NgayVaoCongTy %>'></asp:Label>
                    </div>
                    <div runat="server" visible='<%# !string.IsNullOrEmpty(Item.NgayVaoDang) %>'>
                        <asp:Label runat="server" Text="Ngày vào Đảng: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.NgayVaoDang %>'></asp:Label>
                    </div>
                    <div runat="server" visible='<%# Item.TrinhDo != null && Item.TrinhDo.Count > 0 %>'>
                        <asp:Label runat="server" Text="Trình độ chuyên môn: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.TrinhDo[0].TrinhDo %>'></asp:Label>
                    </div>
                    <div runat="server" visible='<%# Item.TrinhDo != null && Item.TrinhDo.Count > 0 %>'>
                        <asp:Label runat="server" Text='Chuyên ngành: ' CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.TrinhDo[0].ChuyenNganh %>'></asp:Label>
                    </div>
                    <div runat="server" visible='<%# !string.IsNullOrEmpty(Item.LyLuanChinhTri) %>'>
                        <asp:Label runat="server" Text='Lý luận chính trị: ' CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.LyLuanChinhTri %>'></asp:Label>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Điện thoại: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.DienThoai %>'></asp:Label>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Email: " CssClass="field-title"></asp:Label>
                        <asp:Label runat="server" Text='<%# Item.Email %>'></asp:Label>
                    </div>
                </div>
            </div>
            <div class="clear-fix"></div>
            <div>
                <div>
                    <div class="field-header">II. DANH SÁCH NGƯỜI THÂN</div>
                    <asp:GridView ID="NguoiThan" runat="server" AutoGenerateColumns="False" ItemType="HRM.DataModel.NguoiThan"
                        DataSource='<%# Item.NguoiThan %>' CssClass="table table-striped table-hover table-noborder nguoi-than" ShowHeader="false">
                        <Columns>
                            <asp:TemplateField ItemStyle-CssClass="inner-cell">
                                <ItemTemplate>
                                    <div class="none-break">
                                        <div class="four-col">
                                            <asp:Label ID="lblHoTen" runat="server" Text="Họ và tên: " CssClass="field-title"></asp:Label>
                                            <asp:Label ID="HoTen" runat="server" Text='<%# Item.Name %>'></asp:Label>
                                        </div>
                                        <div class="four-col">
                                            <asp:Label ID="lblMoiQuanHe" runat="server" Text="Mối quan hệ: " CssClass="field-title"></asp:Label>
                                            <asp:Label ID="QuanHe" runat="server" Text='<%# Item.QuanHe %>'></asp:Label>
                                        </div>
                                        <div class="four-col">
                                            <asp:Label ID="lblNgaySinh" runat="server" Text="Ngày sinh: " CssClass="field-title"></asp:Label>
                                            <asp:Label ID="NgaySinh" runat="server" Text='<%# Item.NgaySinh %>'></asp:Label>
                                        </div>
                                        <div class="four-col">
                                            <asp:Label ID="lblNgheNghiep" runat="server" Text="Nghề nghiệp: " CssClass="field-title"></asp:Label>
                                            <asp:Label ID="NgheNghiep" runat="server" Text='<%# string.Format("{0} ({1})", Item.NgheNghiep, Item.TinhTrang).Replace("(Còn sống)", string.Empty) %>'></asp:Label>
                                        </div>
                                        <div class="clear-fix">
                                            <asp:Label ID="lblDiaChi" runat="server" Text="Địa chỉ: " CssClass="field-title"></asp:Label>
                                            <asp:Label ID="DiaChi_Xa" runat="server" Text='<%# HienThiDiaChi(Item.ThuongTru) %>'></asp:Label>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div class="alert alert-danger">Không nhân viên nào được tìm thấy! <a href="DanhSachNhanVien.aspx" class="alert-link">Xem danh sách nhân viên</a></div>
        </EmptyDataTemplate>
    </asp:FormView>
</asp:Content>
<asp:Content ContentPlaceHolderID="ModalContent" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="FooterSubScriptContent" runat="server">
    <script type="text/javascript">
        self.print();
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="FrameworkContent" runat="server"></asp:Content>
