using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace HRM.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            // SbAdmin template 2
            bundles.Add(new ScriptBundle("~/bundles/sbadmin2js").Include(
                            "~/Scripts/sb-admin-2.js",
                            "~/bower_components/metisMenu/dist/metisMenu.min.js",
                            "~/bower_components/raphael/raphael-min.js",
                            "~/bower_components/morrisjs/morris.min.js",
                            "~/bower_components/metisMenu/dist/metisMenu.min.js",
                            "~/Scripts/morris.min.js",
                            "~/Scripts/raphael-min.js"));
            bundles.Add(new StyleBundle("~/bundles/sbadmin2css").Include(
                            "~/bower_components/sb-admin-2.css",
                            "~/bower_components/morrisjs/morris.css",
                            "~/bower_components/metisMenu/dist/metisMenu.min.css",
                            "~/bower_components/font-awesome/css/font-awesome.min.css"));
            bundles.Add(new StyleBundle("~/bundles/print").Include("~/Content/print.css"));
            //Datetimepicker
            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                            "~/Scripts/bootstrap-datepicker.js",
                            "~/Scripts/bootstrap-datepicker.vi.js"));
            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/respond.min.js",
                    DebugPath = "~/Scripts/respond.js",
                });
        }
    }
}