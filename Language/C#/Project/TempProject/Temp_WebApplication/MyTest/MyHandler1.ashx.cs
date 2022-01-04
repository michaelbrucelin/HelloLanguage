using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Temp_WebApplication
{
    /// <summary>
    /// MyHandler1 的摘要说明
    /// hello world
    /// </summary>
    public class MyHandler1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //判断用户是直接打开的处理程序，还是通过页面提交打开的处理程序
            {
                //string userName = context.Request["userName"];
                //if (string.IsNullOrEmpty(userName))
                //{
                //    context.Response.Write("直接打开的处理程序");
                //}
                //else
                //{
                //    context.Response.Write("页面提交打开的处理程序");
                //}
                //用上面的方法代码逻辑上没有问题，但是实际业务场景中，可能userName就是允许为空，所以并不合适，推荐使用下面的方式
                string ispostback = context.Request["ispostback"];
                if (ispostback == "true")
                {
                    context.Response.Write("页面提交打开的处理程序<br />");
                }
                else
                {
                    context.Response.Write("直接打开的处理程序<br />");
                }
            }

            //context.Response.ContentType = "text/plain";  //将字符串以纯文本的形式响应到页面上
            context.Response.ContentType = "text/html";     //将字符串以html的形式响应到页面上
            context.Response.Write($"Hello World<br />");

            string userName = context.Request["userName"];  //获取客户端提交上来的数据
            context.Response.Write($"接收到的用户名为：{userName}<br />");
            context.Response.Write("添加一个测试按钮：<input type='button' value='Hi' onclick='console.log(\"Hi\")' /><br />");

            //将请求页面的完整html显示在响应页面上，造成一种页面没有跳转的假象
            string content = File.ReadAllText(context.Server.MapPath("MyHtmlPage1.html"));
            content = content.Replace("@userName", userName);  //将接收到的参数替换到响应页面中
            context.Response.Write(content);
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