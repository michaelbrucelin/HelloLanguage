using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Temp_WebApplication.MyTest
{
    /// <summary>
    /// MyHandler3 的摘要说明
    /// div自增
    /// </summary>
    public class MyHandler3 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string zizeng;
            if (context.Request["ispostback"] == "true")
            {
                if (context.Request["hidZiZeng"] == "@divZiZeng")
                    zizeng = "0";
                else
                    zizeng = (Convert.ToInt32(context.Request["hidZiZeng"]) + 1).ToString();
            }
            else
            {
                zizeng = "0";
            }

            string content = File.ReadAllText(context.Server.MapPath("MyHtmlPage3.html"));
            context.Response.Write(content.Replace("@divZiZeng", zizeng));
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