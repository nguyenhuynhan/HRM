﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThongTinNhanVien.aspx.cs" Inherits="HRM.Web.HRM.ThongTinNhanVien" Title="Hồ sơ nhân viên" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="MainTitle">Hồ sơ nhân viên</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:ValidationSummary ID="valSummary" runat="server" Visible="false" CssClass="validation-text" />
    <asp:FormView ID="frmMain" runat="server"
        ItemType="HRM.DataModel.NhanVien"
        RenderOuterTable="false"
        SelectMethod="frmMain_GetItem">
        <ItemTemplate>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group avatar-group">
                        <span style="width: 255px">
                            <asp:Image ID="ProfilePicture" runat="server" CssClass="avatar-image" ImageUrl='<%# HRM.Lib.WebHelper.GetImagePath(Item.HinhAnh) %>' />
                        </span>
                    </div>
                    <%--<div class="form-group text-center">
                        <asp:Label ID="lblMaSoNhanVien" runat="server" Text="Mã số: " CssClass="field-title"></asp:Label>
                        <asp:Label ID="MaSoNhanVien" runat="server" Text='<%# BindItem.Id %>'></asp:Label>
                    </div>--%>
                    <div class="form-group text-center">
                        <a href='<%# "/HRM/InThongTinNhanVien.aspx?masonhanvien=" + Item.Id  %>' class="btn btn-info"><i class="fa fa-print"></i> In văn bản</a>
                        <a href='<%# "/HRM/SuaThongTinNhanVien.aspx?masonhanvien=" + Item.Id  %>' class="btn btn-success"><i class="fa fa-edit"></i> Sửa thông tin</a>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="row">
                        <div class="form-group">
                            <asp:Label ID="lblHoLot" runat="server" Text="Họ và tên: " CssClass="field-title"></asp:Label>
                            <asp:Label ID="HoVaChuLot" runat="server" Text='<%# (Item.HoVaChuLot + " " + Item.Ten).ToUpper() %>'></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblCmnd" runat="server" Text="CMND: " CssClass="field-title"></asp:Label>
                            <asp:Label ID="CMND" runat="server" Text='<%# BindItem.CMND %>'></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblNgaySinh" runat="server" Text="Ngày sinh: " CssClass="field-title"></asp:Label>
                            <asp:Label ID="NgaySinh" runat="server" Text='<%# BindItem.NgaySinh %>'></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblGioiTinh" runat="server" Text="Giới tính: " CssClass="field-title"></asp:Label>
                            <asp:Label ID="GioiTinh" runat="server" Text='<%# BindItem.GioiTinh %>'></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblTinhTrangHonNhan" runat="server" Text="Tình trạng hôn nhân: " CssClass="field-title"></asp:Label>
                            <asp:Label ID="TinhTrangHonNhan" runat="server" Text='<%# BindItem.TinhTrangHonNhan %>'></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblQueQuan" runat="server" Text="Quê quán: " CssClass="field-title"></asp:Label>
                            <asp:Label ID="QueQuan" runat="server" Text='<%# HienThiDiaChi(Item.QueQuan) %>'></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblHienTai" runat="server" Text="Thường trú: " CssClass="field-title"></asp:Label>
                            <asp:Label ID="HienTai" runat="server" Text='<%# HienThiDiaChi(Item.HienTai) %>'></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPhongTo" runat="server" Text="Đơn vị: " CssClass="field-title"></asp:Label>
                            <asp:Label ID="PhongTo" runat="server" Text='<%# Item.PhongTo.Loai + " " + Item.PhongTo.Name %>'>
                            </asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblChucVu" runat="server" Text="Chức vụ: " CssClass="field-title"></asp:Label>
                            <asp:Label ID="ddlChucVu" runat="server" Text='<%# BindItem.ChucVu %>'></asp:Label>
                        </div>
                        <div class="form-group" runat="server" visible='<%# !string.IsNullOrEmpty(Item.NgayThamGiaCachMang) %>'>
                            <asp:Label runat="server" Text="Ngày vào Đoàn: " CssClass="field-title"></asp:Label>
                            <asp:Label runat="server" Text='<%# Item.NgayTangLuong %>'></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblHeSoLuong" runat="server" Text="Ngày vào công ty: " CssClass="field-title"></asp:Label>
                            <asp:Label ID="HeSoLuong" runat="server" Text='<%# BindItem.NgayVaoCongTy %>'></asp:Label>
                        </div>
                        <div class="form-group" runat="server" visible='<%# !string.IsNullOrEmpty(Item.NgayVaoDang) %>'>
                            <asp:Label runat="server" Text="Ngày vào Đảng: " CssClass="field-title"></asp:Label>
                            <asp:Label runat="server" Text='<%# Item.NgayVaoDang %>'></asp:Label>
                        </div>
                        <div class="form-group" runat="server" visible='<%# !string.IsNullOrEmpty(Item.LyLuanChinhTri) %>'>
                            <asp:Label runat="server" Text='Lý luận chính trị: ' CssClass="field-title"></asp:Label>
                            <asp:Label runat="server" Text='<%# Item.LyLuanChinhTri %>'></asp:Label>
                            <asp:Label runat="server" Text='<%# " (" + Item.GhiChuChinhTri + ")" %>' visible='<%# !string.IsNullOrEmpty(Item.GhiChuChinhTri) %>'></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblDienThoai" runat="server" Text="Điện thoại: " CssClass="field-title"></asp:Label>
                            <asp:Label ID="DienThoai" runat="server" Text='<%# BindItem.DienThoai %>'></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblEmail" runat="server" Text="Email: " CssClass="field-title"></asp:Label>
                            <asp:Label ID="Email" runat="server" Text='<%# BindItem.Email %>'></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lblTrinhDoHocVan" runat="server" Text="Trình độ học vấn" CssClass="field-title"></asp:Label><br />
                        <asp:GridView ID="gvTrinhDo" runat="server"
                            AutoGenerateColumns="False"
                            ItemType="HRM.DataModel.HocVan"
                            CssClass="table table-striped table-hover table-noborder"
                            DataSource='<%#Item.TrinhDo %>'>
                            <Columns>
                                <asp:TemplateField HeaderText="Trình độ">
                                    <ItemTemplate>
                                        <asp:Label ID="TrinhDo" runat="server" Text='<%# Item.TrinhDo %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chuyên ngành">
                                    <ItemTemplate>
                                        <asp:Label ID="ChuyenNganh" runat="server" Text='<%# Item.ChuyenNganh %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lbBangCapKhac" runat="server" Text="Bằng cấp khác" CssClass="field-title" Visible="<%# Item.BangCapKhac.Count > 0 %>"></asp:Label><br />
                        <asp:GridView ID="BangCapKhac" runat="server"
                            AutoGenerateColumns="False"
                            ItemType="HRM.DataModel.BangCapKhac"
                            CssClass="table table-striped table-hover table-noborder"
                            DataSource='<%# Item.BangCapKhac %>'>
                            <Columns>
                                <asp:TemplateField HeaderText="Loại bằng cấp">
                                    <ItemTemplate>
                                        <asp:Label ID="LoaiBangCap" runat="server" Text='<%# Item.LoaiBangCap %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên bằng cấp">
                                    <ItemTemplate>
                                        <asp:Label ID="TenBangCap" runat="server" Text='<%# Item.TenBangCap %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cấp độ">
                                    <ItemTemplate>
                                        <asp:Label ID="CapDo" runat="server" Text='<%# Item.CapDo %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lbQuaTrinhCongTac" runat="server" Text="Quá trình công tác" CssClass="field-title"></asp:Label><br />
                        <asp:GridView ID="gvCongtac" runat="server"
                            AutoGenerateColumns="False"
                            ItemType="HRM.DataModel.CongTac"
                            CssClass="table table-striped table-hover table-noborder"
                            DataSource='<%#Item.QuaTrinhCongTac %>'>
                            <Columns>
                                <asp:TemplateField HeaderText="Quyết định điều động, bổ nhiệm">
                                    <ItemTemplate>
                                        <asp:Label ID="ThoiGian" runat="server" Text='<%# Item.ThoiGian %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Đơn vị">
                                    <ItemTemplate>
                                        <asp:Label ID="DonVi" runat="server" Text='<%# Item.DonViCongTac %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chức vụ">
                                    <ItemTemplate>
                                        <asp:Label ID="ChucVu" runat="server" Text='<%# Item.ChucVu %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
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
                                      CssClass="table table-striped table-hover table-noborder"
                                      DataSource='<%#Item.QuaTrinhTangLuong %>'>
                            <Columns>
                                <asp:TemplateField HeaderText="Số quyết định">
                                    <ItemTemplate>
                                        <asp:Label ID="ThoiGian" runat="server" Text='<%# Item.ThoiGian %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bậc lương">
                                    <ItemTemplate>
                                        <asp:Label ID="BacLuong" runat="server" Text='<%# Item.BacLuong %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hệ số lương">
                                    <ItemTemplate>
                                        <asp:Label ID="HeSoLuong" runat="server" Text='<%# Item.HeSoLuong %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
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
                                      CssClass="table table-striped table-hover table-noborder"
                                      DataSource='<%#Item.QuaTrinhKhenThuong %>'>
                            <Columns>
                                <asp:TemplateField HeaderText="Năm">
                                    <ItemTemplate>
                                        <asp:Label ID="ThoiGian" runat="server" Text='<%# Item.ThoiGian %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lý do, hình thức">
                                    <ItemTemplate>
                                        <asp:Label ID="LyDoHinhThuc" runat="server" Text='<%# Item.LyDoHinhThuc %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cấp quyết định">
                                    <ItemTemplate>
                                        <asp:Label ID="CapQuyetDinh" runat="server" Text='<%# Item.CapQuyetDinh %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
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
                                        CssClass="table table-striped table-hover table-noborder"
                                        DataSource='<%#Item.QuaTrinhKyLuat %>'>
                            <Columns>
                                <asp:TemplateField HeaderText="Năm">
                                    <ItemTemplate>
                                        <asp:Label ID="ThoiGian" runat="server" Text='<%# Item.ThoiGian %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lý do, hình thức">
                                    <ItemTemplate>
                                        <asp:Label ID="LyDoHinhThuc" runat="server" Text='<%# Item.LyDoHinhThuc %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cấp quyết định">
                                    <ItemTemplate>
                                        <asp:Label ID="CapQuyetDinh" runat="server" Text='<%# Item.CapQuyetDinh %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Quan hệ cha, mẹ ruột, chồng, vợ, con" CssClass="field-title"></asp:Label><br />
                        <asp:GridView ID="NguoiThan" runat="server" AutoGenerateColumns="False" ItemType="HRM.DataModel.NguoiThan"
                            DataSource='<%# Item.NguoiThan %>' CssClass="table table-striped table-hover table-noborder" ShowHeader="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <asp:Label ID="lblHoTen" runat="server" Text="Họ và tên: " CssClass="field-title"></asp:Label>
                                                <asp:Label ID="HoTen" runat="server" Text='<%# Item.Name %>'></asp:Label>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Label ID="lblMoiQuanHe" runat="server" Text="Mối quan hệ: " CssClass="field-title"></asp:Label>
                                                <asp:Label ID="QuanHe" runat="server" Text='<%# Item.QuanHe %>'></asp:Label>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Label ID="lblGioiTinh" runat="server" Text="Giới tính: " CssClass="field-title"></asp:Label>
                                                <asp:Label ID="GioiTinh" runat="server" Text='<%# Item.GioiTinh %>'> </asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <asp:Label ID="lblNgaySinh" runat="server" Text="Ngày sinh: " CssClass="field-title"></asp:Label>
                                                <asp:Label ID="NgaySinh" runat="server" Text='<%# Item.NgaySinh %>'></asp:Label>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Label ID="lblNgheNghiep" runat="server" Text="Nghề nghiệp: " CssClass="field-title"></asp:Label>
                                                <asp:Label ID="NgheNghiep" runat="server" Text='<%# Item.NgheNghiep %>'></asp:Label>
                                            </div>
                                            <div class="col-md-4" runat="server" visible='<%# !Item.TinhTrang.Equals("Còn sống") && !string.IsNullOrEmpty(Item.TinhTrang) %>'>
                                                <asp:Label ID="lblTinhTrang" runat="server" Text="Ghi chú: " CssClass="field-title"></asp:Label>
                                                <asp:Label ID="TinhTrang" runat="server" Text='<%# Item.TinhTrang %>'>
                                                </asp:Label>
                                            </div>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblDiaChi" runat="server" Text="Địa chỉ: " CssClass="field-title"></asp:Label>
                                            <asp:Label ID="DiaChi_Xa" runat="server" Text='<%# HienThiDiaChi(Item.ThuongTru) %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div class="alert alert-danger">Không nhân viên nào được tìm thấy! <a href="DanhSachNhanVien.aspx" class="alert-link">Xem danh sách nhân viên</a></div>
        </EmptyDataTemplate>
    </asp:FormView>
</asp:Content>
<asp:Content ContentPlaceHolderID="ModalContent" runat="server"></asp:Content>