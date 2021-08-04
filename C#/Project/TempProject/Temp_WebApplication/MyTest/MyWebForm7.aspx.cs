using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Temp_WebApplication.MyTest
{
    public partial class MyWebForm7 : System.Web.UI.Page
    {
        //模拟Session
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //设置Session
        protected void btnSet_Click(object sender, EventArgs e)
        {
            lblTips.Text = string.Empty;

            if (string.IsNullOrEmpty(txtCookieId.Text) || string.IsNullOrEmpty(txtSessionValueKey.Text) || string.IsNullOrEmpty(txtSessionValueValue.Text))
            {
                lblTips.Text = "CookieId与SessionValue不允许为空";
                return;
            }

            if (string.IsNullOrEmpty(txtCookieValue.Text))
            {
                txtCookieValue.Text = Guid.NewGuid().ToString();
            }

            //设置Session
            IDictionary<string, object> session = MySession.GetSession(txtCookieValue.Text);
            session.Add(txtSessionValueKey.Text, txtSessionValueValue.Text);
            //设置Cookie
            Response.SetCookie(new HttpCookie(txtCookieId.Text, txtCookieValue.Text));
        }

        //获取Session
        protected void btnGet_Click(object sender, EventArgs e)
        {
            lblTips.Text = string.Empty;

            if (string.IsNullOrEmpty(txtCookieId.Text))
            {
                lblTips.Text = "CookieId与SessionValue不允许为空";
                return;
            }

            if (Request.Cookies[txtCookieId.Text] == null)
            {
                lblTips.Text = $"不存在Cookie：{txtCookieId.Text}";
                return;
            }

            txtCookieValue.Text = Request.Cookies[txtCookieId.Text].Value;
            IDictionary<string, object> session = MySession.GetSession(txtCookieValue.Text);
            if (session.Count == 0)
            {
                lblTips.Text = $"Session：{txtCookieValue.Text} 为空";
            }
            else
            {
                txtSessionValueKey.Text = string.Join(",", session.Keys);
                txtSessionValueValue.Text = string.Join(",", session.Values);
            }
        }
    }
}