using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Temp_WebApplication.MyTest
{
    public partial class MyWebForm8 : System.Web.UI.Page
    {
        //使用asp.net的Session实现自增
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["value"] = 0;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(Session["value"]);
            val++;
            Session["value"] = val;
            TextBox1.Text = val.ToString();
        }
    }
}