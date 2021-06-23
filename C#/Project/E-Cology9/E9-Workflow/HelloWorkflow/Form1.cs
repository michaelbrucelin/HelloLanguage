using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E9_Workflow;

namespace HelloWorkflow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Test test = new Test();

            //string result = test.TestWithDetail();
            //MessageBox.Show(result);

            string result = test.Test0();
            MessageBox.Show(result);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Workflow wf = new Workflow();

            #region 使用json创建流程
            //            string data1 = @"{
            //  'creater': 58,
            //  'requestName': '费用报销申请—张三—1900-01-01',
            //  'requestLevel': '1',

            //  'baseInfo': {
            //    'workflowId': '4'
            //  },

            //  'mainTableInfo': {
            //    'requestRecords': [
            //      {
            //        'workflowRequestTableFields': [
            //          { 'fieldName': 'chrm', 'fieldValue': '133', 'view': true, 'edit': true },
            //          { 'fieldName': 'cdept', 'fieldValue': '22', 'view': true, 'edit': true },
            //          { 'fieldName': 'cdate', 'fieldValue': '2021-01-01', 'view': true, 'edit': true },
            //          { 'fieldName': 'managerCnt', 'fieldValue': '2', 'view': true, 'edit': true },
            //          { 'fieldName': 'reason', 'fieldValue': 'hello world', 'view': true, 'edit': true },
            //          { 'fieldName': 'bxfs', 'fieldValue': '1', 'view': true, 'edit': true }
            //        ]
            //      }
            //    ]
            //  },

            //  'detailTableInfos': [
            //    {
            //      'workflowRequestTableRecords': [
            //        {
            //          'workflowRequestTableFields': [
            //            { 'fieldName': 'bxlx', 'fieldValue': '0', 'view': true, 'edit': true },
            //            { 'fieldName': 'fjs', 'fieldValue': '0', 'view': true, 'edit': true },
            //            { 'fieldName': 'shenbaobz', 'fieldValue': '0', 'view': true, 'edit': true },
            //            { 'fieldName': 'shenbaoje', 'fieldValue': '100', 'view': true, 'edit': true }
            //          ]
            //        },
            //        {
            //          'workflowRequestTableFields': [
            //            { 'fieldName': 'bxlx', 'fieldValue': '1', 'view': true, 'edit': true },
            //            { 'fieldName': 'fjs', 'fieldValue': '0', 'view': true, 'edit': true },
            //            { 'fieldName': 'shenbaobz', 'fieldValue': '1', 'view': true, 'edit': true },
            //            { 'fieldName': 'shenbaoje', 'fieldValue': '200', 'view': true, 'edit': true }
            //          ]
            //        }
            //      ]
            //    }
            //  ]
            //}";
            //            string data2 = @"{
            //  'creater': 58,
            //  'requestName': '内部留言—张三—1900-01-01',
            //  'requestLevel': '1',

            //  'baseInfo': {
            //    'workflowId': '2'
            //  },

            //  'mainTableInfo': {
            //    'requestRecords': [
            //      {
            //        'workflowRequestTableFields': [
            //          { 'fieldName': 'chrm', 'fieldValue': '133', 'view': true, 'edit': true },
            //          { 'fieldName': 'cdept', 'fieldValue': '22', 'view': true, 'edit': true },
            //          { 'fieldName': 'cdate', 'fieldValue': '2021-01-01', 'view': true, 'edit': true },
            //          { 'fieldName': 'toTell', 'fieldValue': '58,26,133,148', 'view': true, 'edit': true },
            //          { 'fieldName': 'content', 'fieldValue': '君不见 黄河之水天上来 奔流到海不复回<br>君不见 高堂明镜悲白发 朝如青丝暮成雪', 'view': true, 'edit': true }
            //        ]
            //      }
            //    ]
            //  }
            //}";

            //            var result = wf.CreateWF(data2);
            //            MessageBox.Show(result.desc);
            #endregion

            #region 使用对象创建流程
            //Dictionary<string, string> mainTable = new Dictionary<string, string>();
            //mainTable.Add("chrm", "133");
            //mainTable.Add("cdept", "22");
            //mainTable.Add("cdate", "2020-01-01");
            //mainTable.Add("toTell", "58,26");
            //mainTable.Add("content", "hello world");

            Dictionary<string, string> mainTable = new Dictionary<string, string>();
            mainTable.Add("chrm", "133");
            mainTable.Add("cdept", "22");
            mainTable.Add("cdate", "2020-01-01");
            mainTable.Add("managerCnt", "2");
            mainTable.Add("reason", "hello world");
            mainTable.Add("costType", "1");
            mainTable.Add("bxfs", "1");
            mainTable.Add("beizhu", "hello world");

            List<Dictionary<string, string>>[] detailTables = new List<Dictionary<string, string>>[1];
            Dictionary<string, string> r1 = new Dictionary<string, string>();
            r1.Add("bxlx", "0");
            r1.Add("fjs", "1");
            r1.Add("shenbaobz", "0");
            r1.Add("shenbaoje", "123");
            Dictionary<string, string> r2 = new Dictionary<string, string>();
            r2.Add("bxlx", "1");
            r2.Add("fjs", "2");
            r2.Add("shenbaobz", "1");
            r2.Add("shenbaoje", "100");
            Dictionary<string, string> r3 = new Dictionary<string, string>();
            r3.Add("bxlx", "0");
            r3.Add("fjs", "3");
            r3.Add("shenbaobz", "0");
            r3.Add("shenbaoje", "64");
            detailTables[0] = new List<Dictionary<string, string>>() { r1, r2, r3 };

            var result = wf.CreateWF("4", "create by object", "2", 58, mainTable, detailTables);
            MessageBox.Show(result.desc);
            #endregion
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Workflow wf = new Workflow();

            bool result = wf.DeleteWF(Convert.ToInt32(txtReqId.Text), 58);

            MessageBox.Show(result.ToString());
        }

        private void txtReqId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
