using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Temp_WebApplication.MyTest
{
    /// <summary>
    /// MyHandler5 的摘要说明
    /// Cookie
    /// </summary>
    public class MyHandler5 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string cookieKey = context.Request["cookieKey"];
            string cookieValue = context.Request["cookieValue"];

            if (string.IsNullOrEmpty(cookieKey))
            {
                context.Response.Write("Invailid Request");
            }
            else if (string.IsNullOrEmpty(cookieValue))
            {
                //这里虽然捕获了异常，但是调试时仍然没有跳转到try catch中
                try
                {
                    cookieValue = context.Request.Cookies[cookieKey].Value;
                    context.Response.Write($"Cookie {cookieKey}`s value is {cookieValue}.");
                }
                catch (Exception ex)
                {
                    context.Response.Write(ex.Message);
                }
            }
            else
            {
                context.Response.SetCookie(new HttpCookie(cookieKey, cookieValue));
                context.Response.Write($"Cookie {{{cookieKey}:{cookieValue}}} is set.");
            }
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