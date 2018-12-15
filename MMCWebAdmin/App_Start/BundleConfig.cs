﻿using System.Web;
using System.Web.Optimization;

namespace DMAHR
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
            bundles.Add(new ScriptBundle("~/bundles/project").Include(
                        "~/Scripts/modernizr-*",
                         "~/Content/fuelux/js/fuelux.js",
                         "~/Scripts/search-toolbar.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                     "~/Scripts/switchery.min.js",
                     "~/Scripts/bootstrap_multiselect.js",
                     "~/Scripts/moment.min.js",
                     "~/Scripts/underscore.min.js",
                     "~/Scripts/daterangepicker.js",
                     "~/Scripts/respond.js",
                     "~/Scripts/ripple.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/validation").Include(
              "~/Scripts/bootstrapValidator.js"
          ));
            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/themecss").Include(
                    "~/Content/style.css",
                    "~/Content/core.css",
                    "~/Content/fuelux/css/fuelux.css",
                    "~/Content/components.css",
                    "~/Content/colors.css"));
        }
    }
}
