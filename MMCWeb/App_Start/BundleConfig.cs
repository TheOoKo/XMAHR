using System.Web;
using System.Web.Optimization;

namespace MMCWeb
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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Admin panel scripts
            bundles.Add(new StyleBundle("~/themes/assets/css/global").Include(
                "~/themes/assets/css/bootstrap.min.css",
                "~/themes/assets/css/core.min.css",
                "~/themes/assets/css/components.min.css",
                "~/themes/assets/css/colors.min.css"
            ));

            bundles.Add(new StyleBundle("~/themes/assets/css/icons/icomoon/iconfont").Include(
                "~/themes/assets/css/icons/icomoon/styles.css"
            ));

            bundles.Add(new StyleBundle("~/themes/kendo/css/kendo").Include(
                "~/themes/kendo/css/kendo.common.min.css",
                "~/themes/kendo/css/kendo.material.min.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/kendojs").Include(
                 "~/themes/kendo/js/kendo.all.min.js"
             ));

            bundles.Add(new ScriptBundle("~/bundles/jsrequire").Include(
                 "~/themes/assets/js/core/libraries/jquery.min.js",
                 "~/themes/assets/js/core/libraries/bootstrap.min.js",
                 "~/themes/assets/js/plugins/loaders/blockui.min.js",
                 "~/themes/assets/js/plugins/ui/nicescroll.min.js",
                 "~/themes/assets/js/core/app.min.js",
                 "~/themes/assets/js/pages/layout_fixed_custom.js"
             ));

            //Page level script
            bundles.Add(new ScriptBundle("~/bundles/articlespage").Include(
               "~/themes/assets/js/plugins/notifications/sweet_alert.min.js",
                "~/Scripts/page_scripts/articles.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/accountspage").Include(
               "~/themes/assets/js/plugins/notifications/sweet_alert.min.js",
                "~/Scripts/page_scripts/accounts.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/validation").Include(
             "~/Scripts/bootstrapValidator.js"

          ));
            bundles.Add(new StyleBundle("~/Content/validation/css").Include(
                 "~/Assets/css/bootstrapValidator.css"

            ));
        }
    }
}
