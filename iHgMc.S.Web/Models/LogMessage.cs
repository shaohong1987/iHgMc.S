using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iHgMc.S.Web.Models.Enum;

namespace iHgMc.S.Web.Models
{
    public class LogMessage
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public LogType Type { get; set; }
    }
}