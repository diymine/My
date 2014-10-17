using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;

namespace Test.MVCSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // NLogのログ出力先をローカルストレージに設定
            //var localResource = Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.GetLocalResource("ApplicationLog");
            //GlobalDiagnosticsContext.Set(@"ApplicationLogPath", localResource.RootPath);
            GlobalDiagnosticsContext.Set(@"ApplicationLogPath", @"c:\log");
            LogManager.ReconfigExistingLoggers();
        }
    }
}
