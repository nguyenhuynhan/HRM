using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using HRM.Web.Models;
using HRM.DataModel;
using System.Data.Entity;

namespace HRM.Web.Models
{
    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<NhanVien> DanhSachNhanVien { get; set; }
        public DbSet<PhongTo> DanhSachPhongTo { get; set; }
        public DbSet<BangCapKhac> DanhSachBangCapKhac { get; set; }
        public DbSet<HocVan> DanhSachHocVan { get; set; }
        public DbSet<CongTac> DanhSachCongTac { get; set; }
        public DbSet<DiaChi> DanhSachDiaChi { get; set; }
        public DbSet<NguoiThan> DanhSachNguoiThan { get; set; }
        public DbSet<EnumItem> LookupList;
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>()
                        .HasOptional(m => m.QueQuan)
                        .WithOptionalDependent()
                        .WillCascadeOnDelete(true);
            //modelBuilder.Entity<NguoiThan>()
            //            .HasOptional(m => m.ThuongTru)
            //            .WithOptionalDependent()
            //            .WillCascadeOnDelete(true);
            //modelBuilder.Entity<NhanVien>()
            //            .HasOptional(m => m.HienTai)
            //            .WithOptionalDependent()
            //            .WillCascadeOnDelete(true);
            modelBuilder.Entity<NhanVien>()
                        .HasMany(m => m.TrinhDo)
                        .WithRequired(m => m.NhanVien)
                        .WillCascadeOnDelete(true);
            modelBuilder.Entity<NhanVien>()
                        .HasMany(m => m.BangCapKhac)
                        .WithRequired(m => m.NhanVien)
                        .WillCascadeOnDelete(true);
            modelBuilder.Entity<NhanVien>()
                        .HasMany(m => m.NguoiThan)
                        .WithRequired(m => m.NhanVien)
                        .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}

#region Helpers
namespace HRM.Web
{
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public static void SignIn(ApplicationUserManager manager, ApplicationUser user, bool isPersistent)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public const string CodeKey = "code";
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public const string UserIdKey = "userId";
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}
#endregion
