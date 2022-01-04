using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Temp_WebApplication.MyTest
{
    /// <summary>
    /// MyHandlerVerifyCodeGenerator 的摘要说明
    /// 生成一个验证码
    /// </summary>
    public class MyHandlerVerifyCodeGenerator : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/jpeg";
            using (Bitmap bitmap = new Bitmap(200, 50))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Random random = new Random();
                    int verifyCode = random.Next();
                    //HttpContext.Current.Session.Add("VerifyCode", verifyCode.ToString().PadLeft(8, '0'));
                    context.Session["VerifyCode"] = verifyCode.ToString().PadLeft(8, '0');

                    //验证码
                    graphics.DrawString(verifyCode.ToString().PadLeft(8, '0'), new Font("华文新魏", 16), Brushes.Red, new PointF(16, 16));
                    //混淆图案
                    graphics.DrawEllipse(Pens.Red, new Rectangle(16, 16, 16, 16));
                    Pen pen = (Pen)Pens.Red.Clone();
                    pen.Width = 3;
                    graphics.DrawEllipse(pen, new Rectangle(32, 32, 32, 32));

                    //图片以流的形式发送给请求端
                    bitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                }
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