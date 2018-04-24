using System.Threading;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using iHgMc.S.Web.Models.Enum;
using iHgMc.S.Web.Utils;
using log4net;

namespace iHgMc.S.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Log();
        }

        private static void Log()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    if (HgMc.ExceptionQueue!=null&&HgMc.ExceptionQueue.Count > 0)
                    {
                        var msg = HgMc.ExceptionQueue.Dequeue();
                        if (msg != null)
                        {
                            var logger = LogManager.GetLogger(msg.Name);
                            switch (msg.Type)
                            {
                                case LogType.Error:
                                    logger.Error(msg.Message);
                                    break;
                                case LogType.Debug:
                                    logger.Debug(msg.Message);
                                    break;
                                case LogType.Info:
                                    logger.Info(msg.Message);
                                    break;
                            }
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
        }
    }
}
