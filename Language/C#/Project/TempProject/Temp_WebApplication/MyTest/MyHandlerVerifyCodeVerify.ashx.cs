using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;

namespace Temp_WebApplication.MyTest
{
    /// <summary>
    /// MyHandlerVerifyCodeVerify 的摘要说明
    /// </summary>
    public class MyHandlerVerifyCodeVerify : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string userVerifyCode = context.Request["txtVerifyCode"];
            //string verifyCode = HttpContext.Current.Session["VerifyCode"].ToString();
            string verifyCode = context.Session["VerifyCode"].ToString();

            context.Response.Write($"User Input Verify Code is:\t{userVerifyCode}");
            context.Response.Write(Environment.NewLine);
            context.Response.Write($"Server Generate Verify Code is:\t{verifyCode}");
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