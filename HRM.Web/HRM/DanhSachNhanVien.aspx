<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhSachNhanVien.aspx.cs" Inherits="HRM.Web.WebPage.DanhSachNhanVien" Title="Danh sách nhân viên" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="MainTitle">Danh sách nhân viên</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="gvDanhSachNhanVien"
        runat="server"
        AutoGenerateColumns="False"
        SelectMethod="LayDanhSachNhanVien"
        GridLines="None"
        ShowHeaderWhenEmpty="True"
        CssClass="table table-striped table-hover" ItemType="HRM.DataModel.NhanVien"
        DeleteMethod="gvDanhSachNhanVien_DeleteItem"
        DataKeyNames="Id">
        <Columns>
            <asp:TemplateField HeaderText="Mã số">
                <ItemTemplate>
                    <asp:Image ID="HinhAnh" ImageUrl='<%# HRM.Lib.WebHelper.GetImagePath(Item.HinhAnh)  %>' Width="30px" runat="server" />
                    <asp:Label ID="Maso" runat="server" Text='<%# Item.Id %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Họ và tên">
                <ItemTemplate>
                    <asp:HyperLink ID="HoTen" runat="server" 
                        Text='<%# Item.HoVaChuLot + " " + Item.Ten %>'
                        NavigateUrl='<%# "~/HRM/ThongTinNhanVien.aspx?masonhanvien=" + Item.Id %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" />
            <asp:BoundField DataField="GioiTinh" HeaderText="Giới tính" />
            <asp:TemplateField HeaderText="Đơn vị">
                <ItemTemplate>
                    <asp:Label ID="DonVi" runat="server" Text='<%# Item.PhongTo.Loai + " " +Item.PhongTo.Name.ToLower() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ChucVu" HeaderText="Chức vụ" />
            <asp:BoundField DataField="DienThoai" HeaderText="Số điện thoại" />
            <asp:TemplateField ShowHeader="False" ItemStyle-CssClass="not-print">
                <ItemTemplate>
                    <a onclick='OpenNewWindow("<%# "/HRM/InThongTinNhanVien.aspx?masonhanvien=" + Item.Id  %>")' class="btn btn-default"><i class="fa fa-print" title="In văn bản"></i></a>
                    <a href='<%# "/HRM/SuaThongTinNhanVien.aspx?masonhanvien=" + Item.Id  %>' class="btn btn-info"><i class="fa fa-edit" title="Sửa thông tin"></i></a>
                    <asp:Button ID="btXoa" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="x" OnClientClick='return PrepareConfirmDialog(this.name, "Xóa thông tin nhân viên", "Bạn có thật sự muốn xóa thông tin nhân viên này không? Sau khi xóa bạn không thể phục hồi được!");'
                        CssClass="btn btn-danger" data-toggle="modal" data-target="#myModal" ToolTip="Xóa thông tin" Font-Bold="true" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ContentPlaceHolderID="HeaderSubScriptContent" runat="server">
    <script type="text/javascript">
        function OpenNewWindow(url) {
            window.open(url,
                'targetWindow',
                'toolbar=no, location=no, status=no, menubar=no, scrollbars=yes, resizable=yes, width=800,height=600');
        }
    </script>
</asp:Content>
