<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuaThongTinNhanVien.aspx.cs" Inherits="HRM.Web.HRM.SuaThongTinNhanVien" Title="Hồ sơ nhân viên" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="MainTitle">Hồ sơ nhân viên</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:ValidationSummary ID="valSummary" runat="server" Visible="false" CssClass="validation-text" />
    <asp:FormView ID="frmMain" runat="server"
        ItemType="HRM.DataModel.NhanVien"
        SelectMethod="frmMain_GetItem"
        RenderOuterTable="false"
        UpdateMethod="frmMain_UpdateItem"
        DefaultMode="Edit">
        <EditItemTemplate>
            <div class="row">
                <div class="col-md-8">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblMaNhanVien" runat="server" Text="Mã số" CssClass="field-title"></asp:Label>
                                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Text="<%# BindItem.Id %>"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valMaNhanVien" runat="server" ErrorMessage="Chưa nhập mã số" ControlToValidate="txtId" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblCmnd" runat="server" Text="CMND" CssClass="field-title"></asp:Label>
                                <asp:TextBox ID="CMND" runat="server" CssClass="form-control" Text="<%# BindItem.CMND %>"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblHoLot" runat="server" Text="Họ và chữ lót" CssClass="field-title"></asp:Label>
                                <asp:TextBox ID="txtHoVaChuLot" runat="server" CssClass="form-control" Text="<%# BindItem.HoVaChuLot %>"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valHoLot" runat="server" ErrorMessage="Chưa nhập họ và chữ lót" ControlToValidate="txtHoVaChuLot" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblTen" runat="server" Text="Tên" CssClass="field-title"></asp:Label>
                                <asp:TextBox ID="txtTen" runat="server" CssClass="form-control" Text="<%# BindItem.Ten %>"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valTen" runat="server" ErrorMessage="Chưa nhập tên" ControlToValidate="txtTen" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblNgaySinh" runat="server" Text="Ngày sinh" CssClass="field-title"></asp:Label>
                                <asp:TextBox ID="NgaySinh" runat="server" CssClass="form-control" Text="<%# BindItem.NgaySinh %>"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valNgaySinh" runat="server" ErrorMessage="Chưa nhập ngày sinh" ControlToValidate="NgaySinh" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblGioiTinh" runat="server" Text="Giới tính" CssClass="field-title"></asp:Label>
                                <asp:DropDownList ID="GioiTinh" runat="server"
                                    DataSource='<%#HRM.Lib.CommonData.GetEnumList("GioiTinh") %>'
                                    CssClass="form-control"
                                    SelectedValue='<%# BindItem.GioiTinh %>'>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="valGioiTinh" runat="server" ErrorMessage="Chưa nhập giới tính" ControlToValidate="GioiTinh" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblPhongTo" runat="server" Text="Phòng/Tổ" CssClass="field-title"></asp:Label>
                                <asp:DropDownList ID="ddlPhongTo" runat="server"
                                    CssClass="form-control"
                                    DataTextField="value"
                                    DataValueField="key"
                                    DataMember="key"
                                    DataSource="<%#LayDanhSachPhongTo() %>"
                                    SelectedValue='<%# Item.PhongTo.Id %>'>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="valPhongTo" runat="server" ErrorMessage="Chưa nhập Phòng/Tổ" ControlToValidate="ddlPhongTo" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblChucVu" runat="server" Text="Chức vụ" CssClass="field-title"></asp:Label>
                                <asp:DropDownList ID="ddlChucVu" runat="server"
                                    DataSource='<%#HRM.Lib.CommonData.GetEnumList("ChucVu") %>'
                                    CssClass="form-control"
                                    SelectedValue='<%# BindItem.ChucVu %>'>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="valChucVu" runat="server" ErrorMessage="Chưa nhập chức vụ" ControlToValidate="ddlChucVu" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblTinhTrangHonNhan" runat="server" Text="Tình trạng hôn nhân" CssClass="field-title"></asp:Label>
                                <asp:DropDownList ID="TinhTrangHonNhan" runat="server"
                                    DataSource='<%#HRM.Lib.CommonData.GetEnumList("TinhTrangHonNhan") %>'
                                    CssClass="form-control"
                                    SelectedValue='<%# BindItem.TinhTrangHonNhan %>'>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblHeSoLuong" runat="server" Text="Hệ số lương" CssClass="field-title"></asp:Label>
                                <asp:TextBox ID="HeSoLuong" runat="server" CssClass="form-control" Text="<%# BindItem.HeSoLuong %>"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Chưa nhập hệ số lương" ControlToValidate="HeSoLuong" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group avatar-group">
                        <span style="width: 255px;">
                            <asp:Image ID="ProfilePicture" runat="server" CssClass="avatar-image" Style="margin-top: 20px" ImageUrl='<%# HRM.Lib.WebHelper.GetImagePath(Item.HinhAnh) %>' />
                            <asp:Button ID="btUpload" runat="server" Text="Chọn ảnh đại diện" CssClass="btn btn-info avatar-button" OnClientClick="$('.upload-file').trigger('click'); return false;" CausesValidation="false" />
                            <asp:FileUpload ID="PictureUpload" runat="server" onchange='__doPostBack(this.name, "Load")' OnLoad="PictureUpload_Load" Style="display: none" CssClass="upload-file" />
                            <asp:HiddenField ID="HinhAnh" runat="server" Value="<%# Item.HinhAnh %>" />
                        </span>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblNgayThamGiaCachMang" runat="server" Text="Ngày vào Đoàn" CssClass="field-title"></asp:Label>
                        <asp:TextBox ID="NgayThamGiaCachMang" runat="server" CssClass="form-control" Text="<%# BindItem.NgayTangLuong %>"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblNgayVaoCongTy" runat="server" Text="Ngày vào công ty" CssClass="field-title"></asp:Label>
                        <asp:TextBox ID="NgayVaoCongTy" runat="server" CssClass="form-control" Text="<%# BindItem.NgayVaoCongTy %>"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblNgayVaoDang" runat="server" Text="Ngày vào Đảng" CssClass="field-title"></asp:Label>
                        <asp:TextBox ID="NgayVaoDang" runat="server" CssClass="form-control" Text="<%# BindItem.NgayVaoDang %>"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblDienThoaiBan" runat="server" Text="Điện thoại bàn" CssClass="field-title"></asp:Label>
                        <asp:TextBox ID="DienThoaiBan" runat="server" CssClass="form-control" Text="<%# BindItem.DienThoaiBan %>"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblDienThoai" runat="server" Text="Điện thoại di động" CssClass="field-title"></asp:Label>
                        <asp:TextBox ID="DienThoai" runat="server" CssClass="form-control" Text="<%# BindItem.DienThoai %>"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="field-title"></asp:Label>
                        <asp:TextBox ID="Email" runat="server" CssClass="form-control" Text="<%# BindItem.Email %>"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <asp:HiddenField ID="HiddenField1" runat="server" Value="<%#Item.QueQuan.Id %>" />
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblQueQuan" runat="server" Text="Quê quán" CssClass="field-title"></asp:Label><br />
                        <asp:TextBox ID="txtQueQuanXa" runat="server" CssClass="form-control" placeholder="Địa chỉ" Text="<%# BindItem.QueQuan.Xa %>"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <br />
                        <asp:TextBox ID="txtQueQuanHuyen" runat="server" CssClass="form-control" placeholder="Quận/Huyện/TP" Text="<%# BindItem.QueQuan.Huyen %>"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <br />
                        <asp:TextBox ID="txtQueQuanTinh" runat="server" CssClass="form-control" placeholder="Tỉnh/Thành" Text="<%# BindItem.QueQuan.Tinh %>"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:Panel ID="pnThuongTru" runat="server" CssClass="row">
                <asp:HiddenField ID="Id" runat="server" Value="<%#Item.HienTai.Id %>" />
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblThuongTru" runat="server" Text="Chỗ ở hiện nay" CssClass="field-title"></asp:Label><br />
                        <asp:TextBox ID="txtThuongTruXa" runat="server" CssClass="form-control" placeholder="Địa chỉ" Text="<%# BindItem.HienTai.Xa %>"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <br />
                        <asp:TextBox ID="txtThuongTruHuyen" runat="server" CssClass="form-control" placeholder="Quận/Huyện/TP" Text="<%# BindItem.HienTai.Huyen %>"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <br />
                        <asp:TextBox ID="txtThuongTruTinh" runat="server" CssClass="form-control" placeholder="Tỉnh/Thành" Text="<%# BindItem.HienTai.Tinh %>"></asp:TextBox>
                    </div>
                </div>
            </asp:Panel>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblChinhTri" runat="server" Text="Lý luận chính trị" CssClass="field-title"></asp:Label>
                        <asp:DropDownList ID="LyLuanChinhTri" runat="server"
                                    DataSource='<%#HRM.Lib.CommonData.GetEnumList("LyLuanChinhTri") %>'
                                    CssClass="form-control"
                                    SelectedValue='<%# BindItem.LyLuanChinhTri %>'>
                                </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="form-group">
                        <asp:Label ID="lblGhiChu" runat="server" Text="Ghi chú" CssClass="field-title"></asp:Label>
                        <asp:TextBox ID="GhiChu" runat="server" CssClass="form-control" Text="<%# BindItem.GhiChuChinhTri %>"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lblTrinhDoHocVan" runat="server" Text="Chuyên môn" CssClass="field-title"></asp:Label><br />
                        <asp:GridView ID="gvTrinhDo" runat="server"
                            AutoGenerateColumns="False"
                            ItemType="HRM.DataModel.HocVan"
                            DataKeyNames="Id"
                            OnLoad="gvTrinhDo_Load"
                            CssClass="table table-striped table-hover table-noborder"
                            OnRowDeleting="gvTrinhDo_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Trình độ">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="Id" runat="server" Value="<%#Item.Id %>" />
                                        <asp:DropDownList ID="TrinhDo" runat="server"
                                            DataSource='<%#HRM.Lib.CommonData.GetEnumList("TrinhDo") %>'
                                            CssClass="form-control"
                                            SelectedValue='<%# Item.TrinhDo %>'>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valTrinhDo" runat="server" ErrorMessage="Chưa chọn trình độ" ControlToValidate="TrinhDo" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chuyên ngành">
                                    <ItemTemplate>
                                        <asp:TextBox ID="ChuyenNganh" runat="server" CssClass="form-control" Text="<%#BindItem.ChuyenNganh %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valChuyenNganh" runat="server" ErrorMessage="Chưa nhập chuyên ngành" ControlToValidate="ChuyenNganh" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Button ID="btXoa" runat="server" CausesValidation="False" CommandName="Delete" Text="Xóa" CssClass="btn btn-danger"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btThemTrinhDo" runat="server" Text="Thêm trình độ" CssClass="btn btn-info" OnClick="btThemTrinhDo_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lbBangCapKhac" runat="server" Text="Bằng cấp khác" CssClass="field-title"></asp:Label><br />
                        <asp:GridView ID="BangCapKhac" runat="server"
                            AutoGenerateColumns="False"
                            ItemType="HRM.DataModel.BangCapKhac"
                            OnLoad="BangCapKhac_Load"
                            DataKeyNames="Id"
                            CssClass="table table-striped table-hover table-noborder"
                            OnRowDeleting="BangCapKhac_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Loại bằng cấp">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="Id" runat="server" Value="<%#Item.Id %>" />
                                        <asp:DropDownList ID="LoaiBangCap" runat="server"
                                            DataSource='<%#HRM.Lib.CommonData.GetEnumList("LoaiBangCap") %>'
                                            CssClass="form-control"
                                            SelectedValue='<%# Item.LoaiBangCap %>'>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valLoaiBangCap" runat="server" ErrorMessage="Chưa chọn loại bằng cấp" ControlToValidate="LoaiBangCap" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên bằng cấp">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TenBangCap" runat="server" Text='<%# Item.TenBangCap %>' CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valTenBangCap" runat="server" ErrorMessage="Chưa nhập tên bằng cấp" ControlToValidate="TenBangCap" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cấp độ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="CapDo" runat="server" CssClass="form-control" Text="<%# Item.CapDo %>"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Button ID="btXoa" runat="server" CausesValidation="False" CommandName="Delete" Text="Xóa" CssClass="btn btn-danger"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btThemBangCapKhac" runat="server" Text="Thêm bằng cấp khác" CssClass="btn btn-info" OnClick="btThemBangCapKhac_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lbQuaTrinhCongTac" runat="server" Text="Quá trình công tác" CssClass="field-title"></asp:Label><br />
                        <asp:GridView ID="gvCongTac" runat="server"
                            AutoGenerateColumns="False"
                            ItemType="HRM.DataModel.CongTac"
                            DataKeyNames="Id"
                            OnLoad="gvCongTac_Load"
                            CssClass="table table-striped table-hover table-noborder"
                            OnRowDeleting="gvCongTac_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Khoảng thời gian">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="Id" runat="server" Value="<%#Item.Id %>" />
                                        <asp:TextBox ID="ThoiGian" runat="server" CssClass="form-control" Text="<%#BindItem.ThoiGian %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valThoiGian" runat="server" ErrorMessage="Chưa nhập khoảng thời gian công tác" ControlToValidate="ThoiGian" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Đơn vị công tác">
                                    <ItemTemplate>
                                        <asp:TextBox ID="DonViCongTac" runat="server" CssClass="form-control" Text="<%#BindItem.DonViCongTac %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valDonViCongTac" runat="server" ErrorMessage="Chưa nhập đơn vị công tác" ControlToValidate="DonViCongTac" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chức vụ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="ChucVu" runat="server" CssClass="form-control" Text="<%#BindItem.ChucVu %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valChucVu" runat="server" ErrorMessage="Chưa nhập chức vụ trong khoảng thời gian này" ControlToValidate="ChucVu" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Button ID="btXoa" runat="server" CausesValidation="False" CommandName="Delete" Text="Xóa" CssClass="btn btn-danger"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btThemCongTac" runat="server" Text="Thêm quá trình công tác" CssClass="btn btn-info" OnClick="btThemCongTac_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lbQuaTrinhTangLuong" runat="server" Text="Nâng lương" CssClass="field-title"></asp:Label><br />
                        <asp:GridView ID="gvTangLuong" runat="server"
                            AutoGenerateColumns="False"
                            ItemType="HRM.DataModel.TangLuong"
                            DataKeyNames="Id"
                            OnLoad="gvTangLuong_Load"
                            CssClass="table table-striped table-hover table-noborder"
                            OnRowDeleting="gvTangLuong_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Số quyết định">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="Id" runat="server" Value="<%#Item.Id %>" />
                                        <asp:TextBox ID="ThoiGian" runat="server" CssClass="form-control" Text="<%#BindItem.ThoiGian %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valThoiGian" runat="server" ErrorMessage="Chưa nhập khoảng thời gian tăng lương" ControlToValidate="ThoiGian" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bậc lương">
                                    <ItemTemplate>
                                        <asp:TextBox ID="BacLuong" runat="server" CssClass="form-control" Text="<%#BindItem.BacLuong %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valBacLuong" runat="server" ErrorMessage="Chưa nhập bậc lương" ControlToValidate="BacLuong" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hệ số lương">
                                    <ItemTemplate>
                                        <asp:TextBox ID="HeSoLuong" runat="server" CssClass="form-control" Text="<%#BindItem.HeSoLuong %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valHeSoLuong" runat="server" ErrorMessage="Chưa nhập hệ số lương" ControlToValidate="HeSoLuong" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Button ID="btXoa" runat="server" CausesValidation="False" CommandName="Delete" Text="Xóa" CssClass="btn btn-danger"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btThemTangLuong" runat="server" Text="Thêm nâng lương" CssClass="btn btn-info" OnClick="btThemTangLuong_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lbQuaTrinhKhenThuong" runat="server" Text="Khen thưởng" CssClass="field-title"></asp:Label><br />
                        <asp:GridView ID="gvKhenThuong" runat="server"
                            AutoGenerateColumns="False"
                            ItemType="HRM.DataModel.KhenThuong"
                            DataKeyNames="Id"
                            OnLoad="gvKhenThuong_Load"
                            CssClass="table table-striped table-hover table-noborder"
                            OnRowDeleting="gvKhenThuong_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Năm">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="Id" runat="server" Value="<%#Item.Id %>" />
                                        <asp:TextBox ID="ThoiGian" runat="server" CssClass="form-control" Text="<%#BindItem.ThoiGian %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valThoiGian" runat="server" ErrorMessage="Chưa nhập khoảng thời gian khen thưởng" ControlToValidate="ThoiGian" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lý do, hình thức">
                                    <ItemTemplate>
                                        <asp:TextBox ID="LyDoHinhThuc" runat="server" CssClass="form-control" Text="<%#BindItem.LyDoHinhThuc %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valLyDoHinhThuc" runat="server" ErrorMessage="Chưa nhập lý do, hình thức" ControlToValidate="LyDoHinhThuc" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cấp quyết định">
                                    <ItemTemplate>
                                        <asp:TextBox ID="CapQuyetDinh" runat="server" CssClass="form-control" Text="<%#BindItem.CapQuyetDinh %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valCapQuyetDinh" runat="server" ErrorMessage="Chưa nhập cấp quyết định" ControlToValidate="CapQuyetDinh" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Button ID="btXoa" runat="server" CausesValidation="False" CommandName="Delete" Text="Xóa" CssClass="btn btn-danger"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btThemKhenThuong" runat="server" Text="Thêm khen thưởng" CssClass="btn btn-info" OnClick="btThemKhenThuong_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lbQuaTrinhKyLuat" runat="server" Text="Kỷ luật" CssClass="field-title"></asp:Label><br />
                        <asp:GridView ID="gvKyLuat" runat="server"
                            AutoGenerateColumns="False"
                            ItemType="HRM.DataModel.KyLuat"
                            DataKeyNames="Id"
                            OnLoad="gvKyLuat_Load"
                            CssClass="table table-striped table-hover table-noborder"
                            OnRowDeleting="gvKyLuat_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Năm">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="Id" runat="server" Value="<%#Item.Id %>" />
                                        <asp:TextBox ID="ThoiGian" runat="server" CssClass="form-control" Text="<%#BindItem.ThoiGian %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valThoiGian" runat="server" ErrorMessage="Chưa nhập khoảng thời gian khen thưởng" ControlToValidate="ThoiGian" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lý do, hình thức">
                                    <ItemTemplate>
                                        <asp:TextBox ID="LyDoHinhThuc" runat="server" CssClass="form-control" Text="<%#BindItem.LyDoHinhThuc %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valLyDoHinhThuc" runat="server" ErrorMessage="Chưa nhập lý do, hình thức" ControlToValidate="LyDoHinhThuc" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cấp quyết định">
                                    <ItemTemplate>
                                        <asp:TextBox ID="CapQuyetDinh" runat="server" CssClass="form-control" Text="<%#BindItem.CapQuyetDinh %>"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valCapQuyetDinh" runat="server" ErrorMessage="Chưa nhập cấp quyết định" ControlToValidate="CapQuyetDinh" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Button ID="btXoa" runat="server" CausesValidation="False" CommandName="Delete" Text="Xóa" CssClass="btn btn-danger"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btThemKyLuat" runat="server" Text="Thêm kỷ luật" CssClass="btn btn-info" OnClick="btThemKyLuat_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lbNguoiThan" runat="server" Text="Quan hệ cha, mẹ ruột, chồng, vợ, con" CssClass="field-title"></asp:Label><br />
                        <asp:GridView ID="NguoiThan" runat="server"
                            AutoGenerateColumns="False"
                            ItemType="HRM.DataModel.NguoiThan"
                            DataKeyNames="Id"
                            OnLoad="NguoiThan_Load"
                            CssClass="table table-striped table-hover table-noborder"
                            OnRowDeleting="NguoiThan_RowDeleting"
                            ShowHeader="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="Id" Value="<%# Item.Id %>" runat="server" />
                                        <div class="row">
                                            <div class="col-md-4">
                                                <asp:Label ID="lblHoTen" runat="server" Text="Họ và tên"></asp:Label><br />
                                                <asp:TextBox ID="HoTen" runat="server" CssClass="form-control" Text="<%# Item.Name %>"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valHoTen" runat="server" ErrorMessage="Chưa nhập họ tên người thân" ControlToValidate="HoTen" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Label ID="lblMoiQuanHe" runat="server" Text="Mối quan hệ"></asp:Label><br />
                                                <asp:DropDownList ID="QuanHe" runat="server"
                                                    DataSource='<%#HRM.Lib.CommonData.GetEnumList("QuanHe") %>'
                                                    CssClass="form-control"
                                                    SelectedValue='<%# Item.QuanHe %>'>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="valQuanHe" runat="server" ErrorMessage="Chưa quan hệ của người thân" ControlToValidate="QuanHe" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Label ID="lblGioiTinh" runat="server" Text="Giới tính"></asp:Label><br />
                                                <asp:DropDownList ID="GioiTinh" runat="server"
                                                    DataSource='<%#HRM.Lib.CommonData.GetEnumList("GioiTinh") %>'
                                                    CssClass="form-control"
                                                    SelectedValue='<%# Item.GioiTinh %>'>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="valGioiTinh" runat="server" ErrorMessage="Chưa nhập giới tính người thân" ControlToValidate="GioiTinh" CssClass="validation-text" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <asp:Label ID="lblNgaySinh" runat="server" Text="Ngày sinh"></asp:Label><br />
                                                <asp:TextBox ID="NgaySinh" runat="server" CssClass="form-control" Text="<%# Item.NgaySinh %>"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Label ID="lblNgheNghiep" runat="server" Text="Nghề nghiệp"></asp:Label><br />
                                                <asp:TextBox ID="NgheNghiep" runat="server" CssClass="form-control" Text="<%# Item.NgheNghiep %>"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Label ID="lblTinhTrang" runat="server" Text="Ghi chú"></asp:Label><br />
                                                <asp:TextBox ID="TinhTrang" runat="server" CssClass="form-control" Text="<%# Item.TinhTrang %>"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <asp:HiddenField ID="DiaChi_Id" runat="server" Value='<%# Item.ThuongTru != null ? Item.ThuongTru.Id.ToString():"" %>' />
                                            <div class="col-md-4">
                                                <asp:Label ID="lblDiaChi" runat="server" Text="Địa chỉ"></asp:Label><br />
                                                <asp:TextBox ID="DiaChi_Xa" runat="server" CssClass="form-control" placeholder="Địa chỉ" Text='<%# Item.ThuongTru != null ? Item.ThuongTru.Xa:"" %>'></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <br />
                                                <asp:TextBox ID="DiaChi_Huyen" runat="server" CssClass="form-control" placeholder="Quận/Huyện/TP" Text='<%# Item.ThuongTru != null ? Item.ThuongTru.Huyen:"" %>'></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <br />
                                                <asp:TextBox ID="DiaChi_Tinh" runat="server" CssClass="form-control" placeholder="Tỉnh/Thành" Text='<%# Item.ThuongTru != null ? Item.ThuongTru.Tinh:"" %>'></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12 text-right">
                                                <br />
                                                <asp:Button ID="btXoa" runat="server" CausesValidation="False" CommandName="Delete" Text="Xóa" CssClass="btn btn-danger"></asp:Button>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btThemNguoiThan" runat="server" Text="Thêm người thân" CssClass="btn btn-info" OnClick="btThemNguoiThan_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group text-right">
                        <asp:Button ID="btSubmit" CausesValidation="true" runat="server" Text="Lưu lại" CssClass="btn btn-success btn-lg" CommandName="Update" />
                    </div>
                </div>
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
