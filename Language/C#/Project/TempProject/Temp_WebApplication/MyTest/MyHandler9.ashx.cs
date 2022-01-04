using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Temp_WebApplication.MyTest
{
    /// <summary>
    /// MyHandler9 的摘要说明
    /// 验证验证码
    /// </summary>
    public class MyHandler9 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}