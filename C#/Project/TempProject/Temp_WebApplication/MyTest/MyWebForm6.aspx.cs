using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Temp_WebApplication.MyTest
{
    public partial class MyWebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //private int i = 0;  //这样的话，每次点击按钮都输出1，而不会自增
        private static int i = 0;  //将变量声明为静态变量，就可以实现自增

        protected void Button1_Click(object sender, EventArgs e)
        {
            i++;
            Label1.Text = i.ToString();
        }
    }
}