using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace SouthernTravelsWeb
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterJQueryScriptManager();

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

            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            // CSS Bundle
            bundles.Add(new StyleBundle("~/Content/mainCss").Include(
        "~/Assets/css/bootstrap.min.css",          // Bootstrap CSS first (good)
        "~/Assets/css/style.css",                   // Your custom styles after bootstrap (good)
        "~/Assets/css/bootstrap-select.css",       // Plugin CSS (good here)
        "~/Assets/css/font-awesome.css",           // Fonts/icons (fine anywhere before usage)
        "~/Assets/css/owl-carousel/owl.carousel.css",
        "~/Assets/css/owl-carousel/owl.theme.css",
        "~/Assets/css/animate.css",
        "~/Assets/css/query-ui.css"
    ));


            bundles.Add(new ScriptBundle("~/bundles/mainJs").Include(
          "~/Assets/js/jquery-2.2.0.min.js",          // Core
          "~/Assets/js/jquery-ui.js",                  // UI depends on jQuery
          "~/Assets/js/bootstrap.min.js",             // Bootstrap depends on jQuery
          "~/Assets/js/jquery-scrolltofixed.js",      // Plugin depends on jQuery
          "~/Assets/js/owl-carousel/owl.carousel.min.js", // Plugin depends on jQuery
          "~/Assets/js/bootstrap-select.min.js",      // Plugin depends on Bootstrap/jQuery
          "~/Assets/js/language.js",                   // Custom code last
          "~/Assets/js/jquery.newsTicker.js"
      ));


            bundles.Add(new ScriptBundle("~/bundles/datepickerJs").Include(
                "~/Assets/js/bootstrap-datepicker.js"
            ));

            bundles.Add(new StyleBundle("~/Content/datepickerCss").Include(
                "~/Assets/css/bootstrap-datepicker.css"
            ));

          

            // Enable bundling and minification even in debug mode
            BundleTable.EnableOptimizations = true;
        }

        public static void RegisterJQueryScriptManager()
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/scripts/jquery-3.7.0.min.js",
                    DebugPath = "~/scripts/jquery-3.7.0.js",
                    CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.0.min.js",
                    CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.0.js"
                });
        }
    }
}