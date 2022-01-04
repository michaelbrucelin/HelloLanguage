using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Temp_WebApplication.MyTest
{
    public partial class MyWebForm1 : System.Web.UI.Page
    {
        //ViewState
        //这样就可以实现将label的值传递到web服务器上，写起来很简单，其实asp.net后面做多东西来实现这件事
        //运行，使用浏览器查看源代码，会发现aps.net新增了一个type为hidden的input标签，其中value是一个加密的字符串，这个字符串就是ViewState
        //ViewState可以解密，里面就是html的数据，实现的原理和MyHTMLPage1中自己手动实现的原理差不多
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  //这个IsPostBack是asp.net自带的，MyHtmlPage1中的ispostback功能和原理都一样
                Label1.Text = "0";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(Label1.Text);
            i++;
            Label1.Text = i.ToString();
        }
    }
}