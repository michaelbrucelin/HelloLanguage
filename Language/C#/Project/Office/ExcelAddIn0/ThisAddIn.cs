using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace ExcelAddIn0
{
    public partial class ThisAddIn
    {
        public Excel.Application ExcelApp;

        public UserControl0 uc0;
        public Microsoft.Office.Tools.CustomTaskPane ctp0;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            ExcelApp = Globals.ThisAddIn.Application;
            //ExcelApp.ActiveCell.Value = "hello world";

            uc0 = new UserControl0();
            ctp0 = Globals.ThisAddIn.CustomTaskPanes.Add(uc0, "vsto taskpane");
            ctp0.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
            ctp0.Visible = true;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        //XML Ribbon，启用后通过可视化工具添加的功能区就看不见了，不清楚是为什么
        //protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        //{
        //    return new RibbonXML();
        //}

        #region VSTO 生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
