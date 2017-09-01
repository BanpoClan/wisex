using System.Web;
using System.Web.Optimization;

namespace Wisex
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #region JS

            //控制面板通用js
            bundles.Add(new ScriptBundle("~/JS/backend/BaseScripts").Include(
                "~/Template/backend/js/jquery-1.10.2.min.js",
                "~/Template/backend/js/jquery-migrate.js",
                "~/Template/backend/js/bootstrap.min.js",
                "~/Template/backend/js/modernizr.min.js",
                "~/Template/backend/js/jquery.nicescroll.js",
                "~/Template/backend/js/slidebars.min.js",
                "~/Template/backend/js/switchery/switchery.min.js",
                "~/Template/backend/js/switchery/switchery-init.js",
                "~/Template/backend/js/sparkline/jquery.sparkline.js",
                "~/Template/backend/js/sparkline/sparkline-init.js",
                "~/Template/backend/js/jquery.validate.min.js",
                "~/Template/backend/js/json2.js",
                "~/Template/backend/js/scripts.js"));

            bundles.Add(new ScriptBundle("~/Template/backend/JS/Layer/BaseLayer").Include(
                "~/Template/backend/js/layer/layer.js"));

            bundles.Add(new ScriptBundle("~/JS/backend/Wisex").Include(
                "~/Template/backend/js/wisex.js"));

            bundles.Add(new ScriptBundle("~/JS/backend/WisexMenu").Include(
                "~/Template/backend/js/wisex.menu.js"));



            //DataTable
            bundles.Add(new ScriptBundle("~/JS/backend/DataTable").Include(
                "~/Template/backend/js/data-table/js/jquery.dataTables.min.js",
                "~/Template/backend/js/data-table/js/dataTables.tableTools.min.js",
                "~/Template/backend/js/data-table/js/bootstrap-dataTable.js",
                "~/Template/backend/js/data-table/js/dataTables.colVis.min.js",
                "~/Template/backend/js/data-table/js/dataTables.responsive.min.js",
                "~/Template/backend/js/data-table/js/dataTables.scroller.min.js",
                "~/Template/backend/js/wisex.tables.js"));

            //DataTable Demo Page
            bundles.Add(new ScriptBundle("~/JS/backend/DataTableDemo").Include(
                "~/Template/backend/js/data-table/js/jquery.dataTables.min.js",
                "~/Template/backend/js/data-table/js/dataTables.tableTools.min.js",
                "~/Template/backend/js/data-table/js/bootstrap-dataTable.js",
                "~/Template/backend/js/data-table/js/dataTables.colVis.min.js",
                "~/Template/backend/js/data-table/js/dataTables.responsive.min.js",
                "~/Template/backend/js/data-table/js/dataTables.scroller.min.js",
                "~/Template/backend/js/data-table-init.js"));

            //tree
            bundles.Add(new ScriptBundle("~/JS/backend/Tree").Include(
                "~/Template/backend/js/fuelux/js/tree.min.js"));

            //login page
            bundles.Add(new ScriptBundle("~/JS/backend/Login").Include(
                "~/Template/backend/js/jquery-1.10.2.min.js",
                "~/Template/backend/js/bootstrap.min.js",
                "~/Template/backend/js/jquery.validate.min.js",
                "~/Template/backend/js/wisex.login.valid.js"));

            //select2 js
            bundles.Add(new ScriptBundle("~/JS/backend/Select").Include(
                "~/Template/backend/js/select2.js",
                "~/Template/backend/js/select2-init.js"));

            //nesttable js
            bundles.Add(new ScriptBundle("~/JS/backend/Nestable").Include(
                "~/Template/backend/js/nestable/jquery.nestable.js"));

            //tagsinput js
            bundles.Add(new ScriptBundle("~/JS/backend/Tags").Include(
                "~/Template/backend/js/tags-input.js",
                "~/Template/backend/js/tags-input-init.js"));

            //fileinput js
            bundles.Add(new ScriptBundle("~/JS/backend/File").Include(
                "~/Template/backend/js/bootstrap-fileinput-master/js/fileinput.js",
                "~/Template/backend/js/file-input-init.js"));

            //email js
            bundles.Add(new ScriptBundle("~/JS/backend/Email").Include(
                "~/Template/backend/js/bootstrap-wysihtml5/wysihtml5-0.3.0.js",
                "~/Template/backend/js/bootstrap-wysihtml5/bootstrap-wysihtml5.js",
                "~/Template/backend/js/bootstrap-fileinput-master/js/fileinput.js",
                "~/Template/backend/js/file-input-init.js"));

            //editor js
            bundles.Add(new ScriptBundle("~/JS/backend/Editor").Include(
                "~/Template/backend/js/bootstrap-wysihtml5/wysihtml5-0.3.0.js",
                "~/Template/backend/js/bootstrap-wysihtml5/bootstrap-wysihtml5.js",
                "~/Template/backend/js/summernote/dist/summernote.min.js"));

            //icheck js
            bundles.Add(new ScriptBundle("~/JS/backend/FormValidate").Include(
                "~/Template/backend/js/jquery.validate.min.js",
                "~/Template/backend/js/form-validation-init.js",
                "~/Template/backend/js/icheck/skins/icheck.min.js"));

            //Advance demo js
            bundles.Add(new ScriptBundle("~/JS/backend/Advance").Include(
                "~/Template/backend/js/bootstrap-datepicker/js/bootstrap-datepicker.js",
                "~/Template/backend/js/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js",
                "~/Template/backend/js/bootstrap-daterangepicker/moment.min.js",
                "~/Template/backend/js/bootstrap-daterangepicker/daterangepicker.js",
                "~/Template/backend/js/bootstrap-colorpicker/js/bootstrap-colorpicker.js",
                "~/Template/backend/js/bootstrap-timepicker/js/bootstrap-timepicker.js",
                "~/Template/backend/js/picker-init.js",
                "~/Template/backend/js/icheck/skins/icheck.min.js",
                "~/Template/backend/js/icheck-init.js",
                "~/Template/backend/js/tags-input.js",
                "~/Template/backend/js/tags-input-init.js",
                "~/Template/backend/js/touchspin.js",
                "~/Template/backend/js/spinner-init.js",
                "~/Template/backend/js/dropzone.js",
                "~/Template/backend/js/select2.js",
                "~/Template/backend/js/select2-init.js"));

            //flot chart demo
            bundles.Add(new ScriptBundle("~/JS/backend/Chart").Include(
                "~/Template/backend/js/sparkline/jquery.sparkline.js",
                "~/Template/backend/js/sparkline/sparkline-init.js",
                "~/Template/backend/js/flot-chart/jquery.flot.js",
                "~/Template/backend/js/flot-chart/jquery.flot.resize.js",
                "~/Template/backend/js/flot-chart/jquery.flot.tooltip.min.js",
                "~/Template/backend/js/flot-chart/jquery.flot.pie.js",
                "~/Template/backend/js/flot-chart/jquery.flot.selection.js",
                "~/Template/backend/js/flot-chart/jquery.flot.selection.js",
                "~/Template/backend/js/flot-chart/jquery.flot.stack.js",
                "~/Template/backend/js/flot-chart/jquery.flot.crosshair.js",
                "~/Template/backend/js/flot-chart-init.js"));

            //morris chart demo
            bundles.Add(new ScriptBundle("~/JS/backend/ChartMorris").Include(
                "~/Template/backend/js/morris-chart/morris.js",
                "~/Template/backend/js/morris-chart/raphael-min.js",
                "~/Template/backend/js/morris-init.js"));

            //chartjs demo
            bundles.Add(new ScriptBundle("~/JS/backend/ChartJs").Include(
                "~/Template/backend/js/chart-js/chart.js",
                "~/Template/backend/js/chartJs-init.js"));

            bundles.Add(new ScriptBundle("~/JS/Front/Web/Home").Include(
                "~/Template/front/web/js/jquery.js",
                "~/Template/front/web/js/bootstrap.min.js",
                "~/Template/front/web/js/jquery.prettyPhoto.js",
                "~/Template/front/web/js/jquery.isotope.min.js",
                "~/Template/front/web/js/main.js",
                "~/Template/front/web/js/wow.min.js"));

            #endregion

            #region CSS

            //Base Styles
            bundles.Add(new StyleBundle("~/Template/backend/Css/BaseStyles").Include(
                "~/Template/backend/css/style.css",
                "~/Template/backend/css/style-responsive.css"));

            //Data Table
            bundles.Add(new StyleBundle("~/Template/backend/Css/DataTable").Include(
                "~/Template/backend/js/data-table/css/jquery.dataTables.css",
                "~/Template/backend/js/data-table/css/dataTables.tableTools.css",
                "~/Template/backend/js/data-table/css/dataTables.colVis.min.css",
                "~/Template/backend/js/data-table/css/dataTables.responsive.css",
                "~/Template/backend/js/data-table/css/dataTables.scroller.css"));

            //tree
            bundles.Add(new StyleBundle("~/Template/backend/Css/TreeStyle").Include(
                "~/Template/backend/js/fuelux/css/tree-style.css"));

            //select2
            bundles.Add(new StyleBundle("~/Template/backend/Css/SelectStyle").Include(
                "~/Template/backend/css/select2.css",
                "~/Template/backend/css/select2-bootstrap.css"));

            //Nestable
            bundles.Add(new StyleBundle("~/Template/backend/Css/Nestable").Include(
                "~/Template/backend/js/nestable/jquery.nestable.css"));
            //Tagsinput
            bundles.Add(new StyleBundle("~/Template/backend/Css/Tags").Include(
                "~/Template/backend/css/tagsinput.css"));

            //FileInput
            bundles.Add(new StyleBundle("~/Template/backend/Css/File").Include(
                "~/Template/backend/js/bootstrap-fileinput-master/css/fileinput.css"));

            //Email
            bundles.Add(new StyleBundle("~/Template/backend/Css/Email").Include(
                "~/Template/backend/js/bootstrap-wysihtml5/bootstrap-wysihtml5.css",
                "~/Template/backend/js/bootstrap-fileinput-master/css/fileinput.css"));

            //Editor
            bundles.Add(new StyleBundle("~/Template/backend/Css/Editor").Include(
                "~/Template/backend/js/summernote/dist/summernote.css",
                "~/Template/backend/js/bootstrap-wysihtml5/bootstrap-wysihtml5.css"));

            //icheck Demo
            bundles.Add(new StyleBundle("~/Template/backend/Css/FormValidate").Include(
                "~/Template/backend/js/icheck/skins/all.css"));

            //morris chart Demo
            bundles.Add(new StyleBundle("~/Template/backend/Css/ChartMorris").Include(
                "~/Template/backend/js/morris-chart/morris.css"));

            //Advance Demo
            bundles.Add(new StyleBundle("~/Template/backend/Css/Advance").Include(
                "~/Template/backend/js/icheck/skins/all.css",
                "~/Template/backend/css/tagsinput.css",
                //"~/Template/backend/css/dropzone.css",
                "~/Template/backend/css/select2.css",
                "~/Template/backend/css/select2-bootstrap.css",
                "~/Template/backend/css/bootstrap-touchspin.css",
                "~/Template/backend/js/bootstrap-datepicker/css/datepicker.css",
                "~/Template/backend/js/bootstrap-timepicker/compiled/timepicker.css",
                "~/Template/backend/js/bootstrap-colorpicker/css/colorpicker.css",
                "~/Template/backend/js/bootstrap-daterangepicker/daterangepicker-bs3.css",
                "~/Template/backend/js/bootstrap-datetimepicker/css/datetimepicker.css"));



            //front web/index
            bundles.Add(new StyleBundle("~/css/front/web/home").Include(
                "~/Template/front/web/css/bootstrap.min.css",
                "~/Template/front/web/css/font-awesome.min.css",
                "~/Template/front/web/css/animate.min.css",
                "~/Template/front/web/css/prettyPhoto.css",
                "~/Template/front/web/css/main.css",
                "~/Template/front/web/css/responsive.css"));

            #endregion
        }
    }
}
