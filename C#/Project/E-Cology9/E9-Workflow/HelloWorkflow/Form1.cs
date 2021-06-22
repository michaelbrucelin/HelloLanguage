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

            string data1 = @"{
  'creater': 58,
  'requestName': '费用报销申请—张三—1900-01-01',
  'requestLevel': '1',

  'baseInfo': {
    'workflowId': '4'
  },

  'mainTableInfo': {
    'requestRecords': [
      {
        'workflowRequestTableFields': [
          { 'fieldName': 'chrm', 'fieldValue': '133', 'view': true, 'edit': true },
          { 'fieldName': 'cdept', 'fieldValue': '22', 'view': true, 'edit': true },
          { 'fieldName': 'cdate', 'fieldValue': '2021-01-01', 'view': true, 'edit': true },
          { 'fieldName': 'managerCnt', 'fieldValue': '2', 'view': true, 'edit': true },
          { 'fieldName': 'reason', 'fieldValue': 'hello world', 'view': true, 'edit': true },
          { 'fieldName': 'bxfs', 'fieldValue': '1', 'view': true, 'edit': true }
        ]
      }
    ]
  },

  'detailTableInfos': [
    {
      'workflowRequestTableRecords': [
        {
          'workflowRequestTableFields': [
            { 'fieldName': 'bxlx', 'fieldValue': '0', 'view': true, 'edit': true },
            { 'fieldName': 'fjs', 'fieldValue': '0', 'view': true, 'edit': true },
            { 'fieldName': 'shenbaobz', 'fieldValue': '0', 'view': true, 'edit': true },
            { 'fieldName': 'shenbaoje', 'fieldValue': '100', 'view': true, 'edit': true }
          ]
        },
        {
          'workflowRequestTableFields': [
            { 'fieldName': 'bxlx', 'fieldValue': '1', 'view': true, 'edit': true },
            { 'fieldName': 'fjs', 'fieldValue': '0', 'view': true, 'edit': true },
            { 'fieldName': 'shenbaobz', 'fieldValue': '1', 'view': true, 'edit': true },
            { 'fieldName': 'shenbaoje', 'fieldValue': '200', 'view': true, 'edit': true }
          ]
        }
      ]
    }
  ]
}";
            string data2 = @"{
  'creater': 58,
  'requestName': '内部留言—张三—1900-01-01',
  'requestLevel': '1',

  'baseInfo': {
    'workflowId': '2'
  },

  'mainTableInfo': {
    'requestRecords': [
      {
        'workflowRequestTableFields': [
          { 'fieldName': 'chrm', 'fieldValue': '133', 'view': true, 'edit': true },
          { 'fieldName': 'cdept', 'fieldValue': '22', 'view': true, 'edit': true },
          { 'fieldName': 'cdate', 'fieldValue': '2021-01-01', 'view': true, 'edit': true },
          { 'fieldName': 'toTell', 'fieldValue': '58,26,133,148', 'view': true, 'edit': true },
          { 'fieldName': 'content', 'fieldValue': '君不见 黄河之水天上来 奔流到海不复回<br>君不见 高堂明镜悲白发 朝如青丝暮成雪', 'view': true, 'edit': true }
        ]
      }
    ]
  }
}";

            var result = wf.CreateWF(data2);
            MessageBox.Show(result.desc);
        }
    }
}
