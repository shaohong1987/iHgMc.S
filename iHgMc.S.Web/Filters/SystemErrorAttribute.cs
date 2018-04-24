using System.Collections.Generic;
using System.Web.Mvc;
using iHgMc.S.Web.Models;
using iHgMc.S.Web.Models.Enum;
using iHgMc.S.Web.Utils;

namespace iHgMc.S.Web.Filters
{
    public class SystemErrorAttribute : HandleErrorAttribute
    {
        
        public override void OnException(ExceptionContext filterContext)
        {
            HgMc.ExceptionQueue.Enqueue(new LogMessage
            {
                Name = filterContext.Exception.Source,
                Message = filterContext.Exception.ToString(),
                Type = LogType.Error
            });
            base.OnException(filterContext);
            //处理错误消息，将其跳转到一个页面
            filterContext.HttpContext.Response.Redirect("~/Error.html");
        }
    }
}