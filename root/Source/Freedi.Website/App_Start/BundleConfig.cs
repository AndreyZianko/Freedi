using System.Web;
using System.Web.Optimization;

namespace Freedi.Website
{
    public class BundleConfig
    {
       
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/TemplateScripts/jquery-3.2.1.min.js", "~/Scripts/jquery.unobtrusive-ajax.min.js"));
             bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js", "~/Scripts/jquery.validate.unobtrusive.js"));

    
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));



            bundles.Add(new ScriptBundle("~/bundles/custom-validator").Include(
                                 "~/Scripts/script-custom-validator.js"));
  

            bundles.Add(new StyleBundle("~/bundles/AdminPanel").Include("~/Content/AdminPanel/vendor/bootstrap/js/bootstrap.bundle.min.js" 
                ,"~/Content/AdminPanel/vendor/jquery-easing/jquery.easing.min.js" ,"~/Content/AdminPanel/vendor/datatables/jquery.dataTables.min.js" , 
                "~/Content/AdminPanel/vendor/datatables/dataTables.bootstrap4.min.js",
                "~/Scripts/AdminPanel/sb-admin.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap/popper.js","~/Scripts/bootstrap/bootstrap.min.js", "~/Scripts/TemplatePlugins/OwlCarousel2-2.2.1/owl.carousel.js", "~/Scripts/TemplateScripts/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/TemplateStyles/bootstrap4/bootstrap.min.css", "~/Content/TemplateStyles/responsive.css",
                     "~/Scripts/TemplatePlugins/OwlCarousel2-2.2.1/owl.carousel.css", 
                     "~/Scripts/TemplatePlugins/OwlCarousel2-2.2.1/owl.theme.default.css",
                      "~/Scripts/TemplatePlugins/OwlCarousel2-2.2.1/animate.css"));

            bundles.Add(new StyleBundle("~/Fonts/ccs").Include(
               "~/Content/AdminPanel/vendor/fontawesome-free/css/all.min.css",
               "~/Content/font-awesome-4.7.0/css/font-awesome.css"));


            

        }
    }
}
