<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrangPhongTo.aspx.cs" Inherits="HRM.Web.WebPage.TrangPhongTo" Title="Quản lý phòng ban" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="MainTitle">Quản lý phòng ban</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="gvDanhSachPhongTo"
        runat="server"
        AutoGenerateColumns="False"
        UpdateMethod="CapNhat"
        SelectMethod="LayDanhSachPhongTo" GridLines="None" OnRowCancelingEdit="gvDanhSachPhongTo_RowCancelingEdit" OnRowEditing="gvDanhSachPhongTo_RowEditing" ShowHeaderWhenEmpty="True"
        OnRowCreated="gvDanhSachPhongTo_RowCreated"
        OnRowDeleting="gvDanhSachPhongTo_RowDeleting"
        DeleteMethod="Xoa"
        CssClass="table table-striped table-hover">
        <Columns>
            <asp:TemplateField HeaderText="Mã phòng/tổ">
                <ItemTemplate>
                    <asp:Label ID="lblMaPhongTo" runat="server" Text='<%# Bind("Id")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtMaPhongTo" runat="server" Text='<%# Bind("Id") %>' CssClass="form-control"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="MaPhongToKhongRong" runat="server" ErrorMessage="Chưa nhập dữ liệu" ControlToValidate="txtMaPhongTo" Display="Dynamic" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phòng/Tổ">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlLoaiPhongTo" runat="server" DataSource='<%#HRM.Lib.CommonData.GetEnumList("PhongTo") %>' SelectedValue='<%# Bind("Loai") %>' CssClass="form-control">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLoaiPhongTo" runat="server" Text='<%# Bind("Loai") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlLoaiPhongTo" runat="server" DataSource='<%#HRM.Lib.CommonData.GetEnumList("PhongTo") %>' SelectedValue='<%# Bind("Loai") %>' CssClass="form-control">
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tên phòng/tổ">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTenPhongTo" runat="server" Text='<%# Bind("Name") %>' CssClass="form-control"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="TenPhongToKhongRong" CssClass="alert alert-danger" runat="server" ErrorMessage="Chưa nhập dữ liệu" ControlToValidate="txtTenPhongTo" Display="Dynamic"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTenPhongTo" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtTenPhongTo" runat="server" Text='<%# Bind("Name") %>' CssClass="form-control"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="TenPhongToKhongRong" CssClass="alert alert-danger" runat="server" ErrorMessage="Chưa nhập dữ liệu" ControlToValidate="txtTenPhongTo" Display="Dynamic"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:Button ID="btLuu" runat="server" CausesValidation="True" CommandName="Update" Text="Lưu" CssClass="btn btn-success" />
                    <asp:Button ID="btHuy" runat="server" CausesValidation="False" CommandName="Cancel" Text="Hủy" CssClass="btn btn-default" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="danhSachNhanVien" runat="server" 
                        Text='Danh sách nhân viên'
                        NavigateUrl='<%#"~/HRM/DanhSachNhanVien?phong=" + ((HRM.DataModel.PhongTo)GetDataItem()).Id %>'></asp:HyperLink>
                    <asp:Button ID="btSua" runat="server" CausesValidation="False" CommandName="Edit" Text="Sửa" CssClass="btn btn-default" />
                    <asp:Button ID="btXoa" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="Xóa" OnClientClick='return PrepareConfirmDialog(this.name, "Xóa bộ phận", "Bạn có thật sự muốn xóa bộ phận này không?");'
                        CssClass="btn btn-danger" data-toggle="modal" data-target="#myModal" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btLuu" runat="server" CausesValidation="True" Text="Lưu" OnClick="btLuuThemMoi_Click" CssClass="btn btn-success" />
                    <asp:Button ID="btHuy" runat="server" CausesValidation="False" CommandName="Cancel" Text="Hủy" CssClass="btn btn-default" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btThem" runat="server" Text="Thêm Phòng/Tổ" OnClick="btThem_Click" CssClass="btn btn-primary" />
</asp:Content>
