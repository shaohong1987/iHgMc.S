using System;
using System.Collections.Generic;
using System.Web;
using iHgMc.S.Web.Models;

namespace iHgMc.S.Web.Utils
{
    public static class HgMc
    {
        public static Queue<LogMessage> ExceptionQueue = new Queue<LogMessage>();
        //private static readonly string RootPath = HttpContext.Current.Request.PhysicalApplicationPath;

        //public static string LogPath()
        //{
        //    return RootPath + "Log\\Error\\" + DateTime.Now.ToString("yyyyMMdd") + ".log";
        //}
    }
}