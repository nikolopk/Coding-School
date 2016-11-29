using System.Web;
using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/myTemplate").Include(
                      "~/Content/myTemplate/js/raphael-min.js",
                      "~/Content/myTemplate/js/jquery-1.9.1.min.js",
                      "~/Content/myTemplate/js/jquery-migrate-1.2.1.min.js",
                      "~/Content/myTemplate/js/jquery.touchwipe.min.js",
                      "~/Content/myTemplate/js/md_slider.min.js",
                      "~/Content/myTemplate/js/jquery.sidr.min.js",
                      "~/Content/myTemplate/js/jquery.tweet.min.js",
                      "~/Content/myTemplate/js/pie.js",
                      "~/Content/myTemplate/js/script.js",
                      "~/Content/myTemplate/js/responsiveslides.min.js",
                      "~/Content/myTemplate/js/selectnav.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
