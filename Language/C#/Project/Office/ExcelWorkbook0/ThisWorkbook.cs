using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Office.Tools.Excel;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace ExcelWorkbook0
{
    public partial class ThisWorkbook
    {
        UserControlRed ucRed = new UserControlRed();
        UserControlGreen ucGreen = new UserControlGreen();
        UserControlBlue ucBlue = new UserControlBlue();

        private void ThisWorkbook_Startup(object sender, System.EventArgs e)
        {
            //Globals.ThisWorkbook.Worksheets[1].Range["C3"] = 9;
            BasicHelper.ExcelApp = this.Application;
            BasicHelper.cmdbar = BasicHelper.ExcelApp.CommandBars["task pane"];
            BasicHelper.actpane = this.ActionsPane;
            BasicHelper.actpane.Visible = true;

            //添加控件
            TextBox txt1 = new TextBox();
            txt1.Text = "vsto";
            BasicHelper.actpane.Controls.Add(txt1);
            Button btn1 = new Button();
            btn1.Text = "vsto";
            btn1.Click += Btn1_Click;
            BasicHelper.actpane.Controls.Add(btn1);

            //添加用户控件
            BasicHelper.actpane.Controls.Add(ucRed);
            BasicHelper.actpane.Controls.Add(ucGreen);
            BasicHelper.actpane.Controls.Add(ucBlue);
            BasicHelper.actpane.StackOrder = Microsoft.Office.Tools.StackStyle.FromTop;

            BasicHelper.cmdbar.Position = Office.MsoBarPosition.msoBarRight;
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("vsto");
        }

        private void ThisWorkbook_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO 设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisWorkbook_Startup);
            this.Shutdown += new System.EventHandler(ThisWorkbook_Shutdown);
        }

        #endregion

    }
}
