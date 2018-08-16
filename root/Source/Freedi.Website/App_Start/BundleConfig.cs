using System.Web;
using System.Web.Optimization;

namespace Freedi.Website
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/TemplateScripts/jquery-3.2.1.min.js"));
             bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js", "~/Scripts/jquery.validate.unobtrusive.js"));

    
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Content/TemplateStyles/bootstrap4/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/custom-validator").Include(
                                 "~/Scripts/script-custom-validator.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/TemplateStyles/bootstrap4/bootstrap.min.css"));
        }
    }
}
