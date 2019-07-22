using System.Web;
using System.Web.Optimization;

namespace ASP_Work
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //jquery基本功能
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));//t1

            //jquery的非介入式ajax
            bundles.Add(new ScriptBundle("~/bundles/jquery/unobtrusive-ajax").Include(
                         "~/Scripts/jquery.unobtrusive*"));//n2

            //jquery客户端验证
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //jqueryUI脚本
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                         "~/Scripts/jquery-ui-{version}.js",
                         "~/Scripts/jquery-ui-datepicker-cn.js"
                         ));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //Bootstrap和respond脚本
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //模板默认使用的CSS文件
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //jqueryUI的CSS文件
            bundles.Add(new StyleBundle("~/Content/themes/base/jquery-ui").Include(
                      "~/Content/themes/base/all.css"));

            //true表示自动进行捆绑【将js全部捆绑到一个文件中】和缩小【自动选择.min.*的文件】。
            //    这种方式由于缩小了文件大小和加载文件的次数，因此加载速度稍快，但调试困难。
            //false表示不进行捆绑和缩小。
            BundleTable.EnableOptimizations = true;
        }
    }
}
