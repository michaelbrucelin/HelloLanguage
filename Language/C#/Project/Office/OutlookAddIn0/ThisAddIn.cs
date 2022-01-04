using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace OutlookAddIn0
{
    public partial class ThisAddIn
    {
        Outlook.Inspectors inspectors;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            inspectors = this.Application.Inspectors;
            //创建新邮件的事件
            inspectors.NewInspector += new Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);
            //发送邮件事件
            this.Application.ItemSend += new Outlook.ApplicationEvents_11_ItemSendEventHandler(Application_ItemSend);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // 备注: Outlook不会再触发这个事件。如果具有
            //    在 Outlook 关闭时必须运行，详请参阅 https://go.microsoft.com/fwlink/?LinkId=506785
        }

        //当用户创建新邮件时，此事件处理程序会将文本添加到邮件的主题行和正文，并增加一个自定义邮件头
        private void Inspectors_NewInspector(Outlook.Inspector Inspector)
        {
            Outlook.MailItem mailItem = Inspector.CurrentItem as Outlook.MailItem;
            if (mailItem != null)
            {
                if (mailItem.EntryID == null)  //创建新邮件
                {
                    mailItem.Recipients.Add("491601759@qq.com");
                    mailItem.Recipients.Add("gongwei.jiang@quanxinhe.cn");
                    //mailItem.Recipients.Add("407153144@qq.com");
                    mailItem.Subject = "This text was added by using code" + DateTime.Now.ToString(" HHmm");
                    mailItem.Body = "This text was added by using code" + DateTime.Now.ToString(" HHmm");

                    const string headerSchema = "http://schemas.microsoft.com/mapi/string/{00020386-0000-0000-C000-000000000046}/";
                    mailItem.PropertyAccessor.SetProperty($"{headerSchema}X-Header-Test", "Test");
                }
                else  //打开邮件
                {
                    const string headersSchema = "http://schemas.microsoft.com/mapi/proptag/0x007D001E";
                    string headers = mailItem.PropertyAccessor.GetProperty(headersSchema);
                    MessageBox.Show(headers);
                }
            }
            else
            {
                MessageBox.Show("这是什么场景？");
            }
        }

        //当用户发送邮件时，拦截事件，做处理
        private void Application_ItemSend(object Item, ref bool Cancel)
        {
            if (MessageBox.Show("确认发送吗", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Cancel = false;
            }
            else
            {
                Cancel = true;
            }
        }

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
