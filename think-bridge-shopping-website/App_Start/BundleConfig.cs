using System.Web;
using System.Web.Optimization;

namespace think_bridge_shopping_website
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/E-Shopper/css").Include(
                      "~/E-Shopper/css/style.min.css",
                      "~/E-Shopper/css/style.css",
                      "~/E-Shopper/lib/owlcarousel/assets/owl.carousel.min.css",
                      "~/E-Shopper/lib/owlcarousel/assets/owl.theme.default.min.css",
                      "~/E-Shopper/lib/owlcarousel/assets/owl.theme.green.min.css"));

            bundles.Add(new StyleBundle("~/Login-form/css").Include(
                      "~/Login-form/css/bootstrap.min.css",
                      "~/Login-form/css/style.css",
                      "~/Login-form/bootstrap/mixins/_border-radius.css",
                      "~/Login-form/bootstrap/mixins/_reset-text.css",
                      "~/Login-form/bootstrap/mixins/_screen-reader.css",
                      "~/Login-form/bootstrap/mixins/_text-hide.css",
                      "~/Login-form/bootstrap/mixins/_visibility.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/E-Shopper/lib/easing/easing.min.js",
                       "~/E-Shopper/lib/owlcarousel/owl.carousel.min.js",
                       "~/E-Shopper/mail/jqBootstrapValidation.min.js",
                       "~/E-Shopper/mail/contact.js",
                        "~/E-Shopper/js/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/Login-form-js").Include(
                      "~/Login-form/js/bootstrap.min.js",
                      "~/Login-form/js/jquery.min.js",
                       "~/Login-form/js/main.js",
                      "~/Login-form/js/popper.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin-js").Include(
                "~/Content/admin_theme/js/jquery-3.2.1.min.js",
                "~/Content/admin_theme/js/popper.min.js",
                "~/Content/admin_theme/js/bootstrap.min.js",
                "~/Content/admin_theme/plugins/slimscroll/jquery.slimscroll.min.js",
                "~/Content/admin_theme/plugins/raphael/raphael.min.js",
                "~/Content/admin_theme/js/chart.morris.js",
                "~/Content/admin_theme/plugins/morris/morris.min.js",
                "~/Content/admin_theme/plugins/datatables/jquery.dataTables.min.js",
                "~/Content/admin_theme/plugins/datatables/datatables.min.js",
                "~/Content/admin_theme/js/moment.min.js",
                "~/Content/admin_theme/js/bootstrap-datetimepicker.min.js",
                "~/Content/admin_theme/plugins/timepicker/bootstrap-timepicker.js",
                "~/Content/admin_theme/plugins/theia-sticky-sidebar/ResizeSensor.js",
                "~/Content/admin_theme/plugins/theia-sticky-sidebar/theia-sticky-sidebar.js",
                "~/Content/admin_theme/plugins/dropzone/dropzone.min.js",
                "~/Content/admin_theme/plugins/bootstrap-tagsinput/js/bootstrap-tagsinput.js",
                "~/Content/admin_theme/js/select2.min.js",
                "~/Content/admin_theme/js/profile-settings.js",
                "~/Content/admin_theme/js/script.js"
            ));

            bundles.Add(new StyleBundle("~/Content/admin-css").Include(
                        "~/Content/admin_theme/css/bootstrap.min.css",
                        "~/Content/admin_theme/css/font-awesome.min.css",
                        "~/Content/admin_theme/css/feathericon.min.css",
                       "~/Content/admin_theme/plugins/morris/morris.css",
                       "~/Content/admin_theme/plugins/datatables/datatables.min.css",
                       "~/Content/admin_theme/css/bootstrap-datetimepicker.min.css",
                       "~/Content/admin_theme/plugins/datatables/bootstrap-timepicker.css",
                        "~/Content/admin_theme/plugins/fontawesome/css/all.min.css",
                        "~/Content/admin_theme/plugins/bootstrap-tagsinput/css/bootstrap-tagsinput.css",
                        "~/Content/admin_theme/plugins/dropzone/dropzone.min.css",
                       "~/Content/admin_theme/css/select2.min.css",
                       "~/Content/admin_theme/css/style.css"
            ));
        }
    }
}
