using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace InsuranceSecure
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles, string basePath)
        {
            var styleBundles =
                from bundleDir in Directory.EnumerateDirectories(Path.Combine(basePath, "css"), "*")
                let name = Path.GetFileName(bundleDir)
                select
                    new StyleBundle("~/css/" + name + ".min.css")
                    .IncludeDirectory("~/css/" + name + "/", "*.css", true);

            var scriptBundles =
                from bundleDir in Directory.EnumerateDirectories(Path.Combine(basePath, "js"), "*")
                let name = Path.GetFileName(bundleDir)
                select
                    new ScriptBundle($"~/js/{name}.min.js")
                    .IncludeDirectory($"~/js/{name}/", "*.js", true);

            var allBundles = styleBundles.Concat(scriptBundles);

            foreach (var bundle in allBundles)
            {
                bundles.Add(bundle);
            }
        }
    }
}
