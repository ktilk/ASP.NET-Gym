using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/bower_components/jquery/dist/jquery.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/bower_components/jquery-validation/dist/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js", // original ms package
                "~/Scripts/app/jquery.validate.globalize.datetime.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/cldr").Include(
                "~/bower_components/cldrjs/dist/cldr.js",
                "~/bower_components/cldrjs/dist/cldr/event.js",
                "~/bower_components/cldrjs/dist/cldr/supplemental.js",
                "~/bower_components/cldrjs/dist/cldr/unresolved.js"));

            bundles.Add(new ScriptBundle("~/bundles/globalize").Include(
                "~/bower_components/globalize/dist/globalize.js",
                "~/bower_components/globalize/dist/globalize/number.js",
                "~/bower_components/globalize/dist/globalize/*.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/bower_components/moment/min/moment-with-locales.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/bower_components/bootstrap/dist/js/bootstrap.js",
                "~/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                "~/bower_components/respond/respond.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/bower_components/bootstrap/dist/css/bootstrap.css",
                "~/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css",
                "~/Content/font-awesome-4.6.1/css/font-awesome.css"
                // "~/Content/site.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                   "~/Scripts/app/app.js"));

            bundles.Add(new StyleBundle("~/Content/niceadmincss").Include(
                "~/Content/NiceAdmin/css/bootstrap.min.css",
                "~/Content/NiceAdmin/css/bootstrap-theme.css",
                "~/Content/NiceAdmin/css/elegant-icons-style.css",
                "~/Content/NiceAdmin/css/font-awesome.min.css",
                "~/Content/NiceAdmin/css/owl.carousel.css",
                "~/Content/NiceAdmin/css/widgets.css",
                "~/Content/NiceAdmin/css/style.css",
                "~/Content/NiceAdmin/css/style-responsive.css",
                "~/Content/NiceAdmin/css/xcharts.min.css",
                "~/Content/NiceAdmin/css/jquery-ui-1.10.4.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/niceadminjs").Include(
                "~/Scripts/NiceAdmin/jquery.js",
                "~/Scripts/NiceAdmin/jquery-ui-1.10.4.min.js",
                "~/Scripts/NiceAdmin/jquery-1.8.3.min.js",
                "~/Scripts/NiceAdmin/jquery-ui-1.9.2.custom.min.js",
                "~/Scripts/NiceAdmin/bootstrap.min.js",
                "~/Scripts/NiceAdmin/jquery.scrollTo.min.js",
                "~/Scripts/NiceAdmin/jquery.nicescroll.js",
                "~/Scripts/NiceAdmin/jquery.rateit.min.js",
                "~/Scripts/NiceAdmin/jquery.customSelect.min.js",
                "~/Scripts/NiceAdmin/scripts.js",
                "~/Scripts/NiceAdmin/sparkline-chart.js",
                "~/Scripts/NiceAdmin/jquery-jvectormap-1.2.2.min.js",
                "~/Scripts/NiceAdmin/jquery-jvectormap-world-mill-en.js",
                "~/Scripts/NiceAdmin/xcharts.min.js",
                "~/Scripts/NiceAdmin/jquery.autosize.min.js",
                "~/Scripts/NiceAdmin/jquery.placeholder.min.js",
                "~/Scripts/NiceAdmin/gdp-data.js",
                "~/Scripts/NiceAdmin/morris.min.js",
                "~/Scripts/NiceAdmin/sparklines.js",
                "~/Scripts/NiceAdmin/jquery.slimscroll.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/niceadminjsall").IncludeDirectory("~/Scripts/NiceAdmin", "", false));

            BundleTable.EnableOptimizations = false;
        }
    }
}