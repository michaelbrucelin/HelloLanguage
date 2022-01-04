using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Temp_WebApplication.MyTest
{
    /// <summary>
    /// MyHandler2 的摘要说明
    /// text自增
    /// </summary>
    public class MyHandler2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string zizeng;
            if (context.Request["ispostback"] == "true")
            {
                zizeng = (Convert.ToInt32(context.Request["txtZiZeng"]) + 1).ToString();
            }
            else
            {
                zizeng = "0";
            }

            string content = File.ReadAllText(context.Server.MapPath("MyHtmlPage2.html"));
            context.Response.Write(content.Replace("@txtZiZeng", zizeng));
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