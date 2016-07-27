using System.Web;
using System.Web.Optimization;

namespace Residencias
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker").Include(
                        "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker-es").Include(
                        "~/Scripts/locales/bootstrap-datepicker.es.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-datepicker").Include(
                        "~/Content/bootstrap-datepicker3.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-select").Include(
                        "~/Scripts/bootstrap-select.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-select-es").Include(
                        "~/Scripts/i18n/defaults-es_MX.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-select").Include(
                        "~/Content/bootstrap-select.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                        "~/Scripts/moment.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        //"~/Content/bootstrap.simplex.css",
                        "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                        "~/Content/themes/base/[a-z]*", new CssRewriteUrlTransform())
                        .IncludeDirectory("~/Content/themes/base/images", "[a-z]*")
                        .Include("~/Content/themes/flat/jquery-ui-{version}.css", new CssRewriteUrlTransform())
                        .IncludeDirectory("~/Content/themes/flat/images", "[a-z]*"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                        "~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/workschedule").Include(
                        "~/Scripts/workschedule.js"));

            bundles.Add(new ScriptBundle("~/bundles/moodle").Include(
                        "~/Scripts/moodle.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
