using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF = E9_Workflow.E9WorkflowService;

namespace E9_Workflow
{
#if false
    public class Test
    {
        private readonly Random random = new Random();

        public string Test0()
        {
            string data = @"{
  'creater': 58,
  'requestName': '费用报销申请—张三—19000101',
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

            QRequestInfo QRInfo = JsonConvert.DeserializeObject<QRequestInfo>(data);

            WF.WorkflowServicePortTypeClient wfclient = new WF.WorkflowServicePortTypeClient();
            WF.WorkflowRequestInfo requestInfo = new WF.WorkflowRequestInfo();

            requestInfo.requestName = QRInfo.requestName;
            requestInfo.requestLevel = QRInfo.requestLevel;
            requestInfo.workflowBaseInfo = QRInfo.baseInfo;
            requestInfo.workflowMainTableInfo = QRInfo.mainTableInfo;
            requestInfo.workflowDetailTableInfos = QRInfo.detailTableInfos;

            string result = wfclient.doCreateWorkflowRequest(requestInfo, QRInfo.creater);

            return result;
        }

        /// <summary>
        /// 测试发一个没有明细的流程
        /// </summary>
        /// <returns></returns>
        public string TestWithoutDetail()
        {
            // 创建一个内部留言流程
            WF.WorkflowServicePortTypeClient wfclient = new WF.WorkflowServicePortTypeClient();  // 创建流程的类
            WF.WorkflowRequestInfo requestInfo = new WF.WorkflowRequestInfo();                   // 流程信息

            WF.WorkflowBaseInfo wfInfo = new WF.WorkflowBaseInfo();  // 流程信息—基础信息
            wfInfo.workflowId = "2";

            WF.WorkflowRequestTableRecord r1 = new WF.WorkflowRequestTableRecord();  // 主表单字段信息
            r1.workflowRequestTableFields = new WF.WorkflowRequestTableField[] {
                new WF.WorkflowRequestTableField(){ fieldName = "chrm", fieldValue = "133", view = true, edit = true },  // 如果不设置view与edit属性，发出去字段值是空的
                new WF.WorkflowRequestTableField(){ fieldName = "cdept", fieldValue = "22", view = true, edit = true },
                new WF.WorkflowRequestTableField(){ fieldName = "cdate", fieldValue = DateTime.Now.ToString("yyyy-MM-dd"), view = true, edit = true },
                new WF.WorkflowRequestTableField(){ fieldName = "toTell", fieldValue = "58,26,133,148", view = true, edit = true },
                new WF.WorkflowRequestTableField(){ fieldName = "content", fieldValue="道可道 非常道 名可名 非常名<br>无 名天地之始 有 名万物之母", view = true, edit = true }
            };

            //WF.WorkflowRequestTableRecord r2 = new WF.WorkflowRequestTableRecord();
            //r2.workflowRequestTableFields = new WF.WorkflowRequestTableField[] {
            //    new WF.WorkflowRequestTableField(){ fieldName = "chrm", fieldValue = "133", view = true, edit = true },
            //    new WF.WorkflowRequestTableField(){ fieldName = "cdept", fieldValue = "22", view = true, edit = true },
            //    new WF.WorkflowRequestTableField(){ fieldName = "cdate", fieldValue = DateTime.Now.ToString("yyyy-MM-dd"), view = true, edit = true },
            //    new WF.WorkflowRequestTableField(){ fieldName = "toTell", fieldValue = "58,26,133,148", view = true, edit = true },
            //    new WF.WorkflowRequestTableField(){ fieldName = "content", fieldValue="天行健 君子当自强不息<br>地势坤 君子当厚德载物", view = true, edit = true }
            //};

            WF.WorkflowMainTableInfo mainTable = new WF.WorkflowMainTableInfo();    // 主表单信息
            mainTable.requestRecords = new WF.WorkflowRequestTableRecord[] { r1 };  // 尽管主表单只有一份信息，但是这个位置仍然被设计成数组，不确认为什么要这么设计
                                                                                    // 尝试过给2份主表单信息，仍然只有第一份信息（数组第一项）有效
                                                                                    //mainTable.requestRecords = new WF.WorkflowRequestTableRecord[] { r1, r2 };

            //E9WF.WorkflowDetailTableInfo detailTable = new E9WF.WorkflowDetailTableInfo();
            //detailTable.workflowRequestTableRecords = new E9WF.WorkflowRequestTableRecord[10];

            requestInfo.requestName = "hello webservices " + DateTime.Now.ToString("yyyy-MM-dd");  // 流程标题
            requestInfo.requestLevel = "2";                                                        // 紧急程度：0正常 1重要 2紧急
            requestInfo.workflowBaseInfo = wfInfo;
            requestInfo.workflowMainTableInfo = mainTable;

            string result = wfclient.doCreateWorkflowRequest(requestInfo, 58);                     // 创建流程

            return result;
        }

        /// <summary>
        /// 测试发一个带有明细的流程
        /// </summary>
        /// <returns></returns>
        public string TestWithDetail()
        {
            // 创建一个费用报销流程
            WF.WorkflowServicePortTypeClient wfclient = new WF.WorkflowServicePortTypeClient();  // 创建流程的类
            WF.WorkflowRequestInfo requestInfo = new WF.WorkflowRequestInfo();                   // 流程信息

            WF.WorkflowBaseInfo wfInfo = new WF.WorkflowBaseInfo();  // 流程信息—基础信息
            wfInfo.workflowId = "4";

            WF.WorkflowMainTableInfo mainTable = new WF.WorkflowMainTableInfo();    // 主表单信息
            mainTable.requestRecords = new WF.WorkflowRequestTableRecord[] {        // 尽管主表单只有一份信息，但是这个位置仍然被设计成数组，不确认为什么要这么设计
                new WF.WorkflowRequestTableRecord(){                                // 主表单字段信息
                    workflowRequestTableFields = new WF.WorkflowRequestTableField[] {
                        new WF.WorkflowRequestTableField(){ fieldName = "chrm", fieldValue = "133", view = true, edit = true },  // 如果不设置view与edit属性，发出去字段值是空的
                        new WF.WorkflowRequestTableField(){ fieldName = "cdept", fieldValue = "22", view = true, edit = true },
                        new WF.WorkflowRequestTableField(){ fieldName = "cdate", fieldValue = DateTime.Now.ToString("yyyy-MM-dd"), view = true, edit = true },
                        new WF.WorkflowRequestTableField(){ fieldName = "managerCnt", fieldValue = "2", view = true, edit = true },
                        new WF.WorkflowRequestTableField(){ fieldName = "reason", fieldValue="道可道 非常道 名可名 非常名", view = true, edit = true },
                        new WF.WorkflowRequestTableField(){ fieldName = "costType", fieldValue=random.Next(0, 2).ToString(), view = true, edit = true },
                        new WF.WorkflowRequestTableField(){ fieldName = "bxfs", fieldValue=random.Next(0,12).ToString(), view = true, edit = true },
                        new WF.WorkflowRequestTableField(){ fieldName = "beizhu", fieldValue="无 名天地之始 有 名万物之母", view = true, edit = true }
                    }
                }
            };

            WF.WorkflowDetailTableInfo detailTable = new WF.WorkflowDetailTableInfo();       // 明细表信息
            detailTable.workflowRequestTableRecords = new WF.WorkflowRequestTableRecord[] {  // 明细行数据
                new WF.WorkflowRequestTableRecord(){  // 第一行数据
                    workflowRequestTableFields = new WF.WorkflowRequestTableField[]{
                        new WF.WorkflowRequestTableField(){ fieldName = "bxlx", fieldValue = random.Next(0, 3).ToString(), view = true, edit = true},
                        new WF.WorkflowRequestTableField(){ fieldName = "fjs", fieldValue = random.Next(0, 10).ToString(), view = true, edit = true},
                        new WF.WorkflowRequestTableField(){ fieldName = "shenbaobz", fieldValue = random.Next(0, 5).ToString(), view = true, edit = true},
                        new WF.WorkflowRequestTableField(){ fieldName = "shenbaoje", fieldValue = random.Next(100, 1000).ToString(), view = true, edit = true}
                    }
                },
                new WF.WorkflowRequestTableRecord(){  // 第二行数据
                    workflowRequestTableFields = new WF.WorkflowRequestTableField[]{
                        new WF.WorkflowRequestTableField(){ fieldName = "bxlx", fieldValue = random.Next(0, 3).ToString(), view = true, edit = true},
                        new WF.WorkflowRequestTableField(){ fieldName = "fjs", fieldValue = random.Next(0, 10).ToString(), view = true, edit = true},
                        new WF.WorkflowRequestTableField(){ fieldName = "shenbaobz", fieldValue = random.Next(0, 5).ToString(), view = true, edit = true},
                        new WF.WorkflowRequestTableField(){ fieldName = "shenbaoje", fieldValue = random.Next(100, 1000).ToString(), view = true, edit = true}
                    }
                },
                new WF.WorkflowRequestTableRecord(){  // 第三行数据
                    workflowRequestTableFields = new WF.WorkflowRequestTableField[]{
                        new WF.WorkflowRequestTableField(){ fieldName = "bxlx", fieldValue = random.Next(0, 3).ToString(), view = true, edit = true},
                        new WF.WorkflowRequestTableField(){ fieldName = "fjs", fieldValue = random.Next(0, 10).ToString(), view = true, edit = true},
                        new WF.WorkflowRequestTableField(){ fieldName = "shenbaobz", fieldValue = random.Next(0, 5).ToString(), view = true, edit = true},
                        new WF.WorkflowRequestTableField(){ fieldName = "shenbaoje", fieldValue = random.Next(100, 1000).ToString(), view = true, edit = true}
                    }
                }
            };

            requestInfo.requestName = "hello webservices " + DateTime.Now.ToString("yyyy-MM-dd");     // 流程标题
            requestInfo.requestLevel = "2";                                                           // 紧急程度：0正常 1重要 2紧急
            requestInfo.workflowBaseInfo = wfInfo;
            requestInfo.workflowMainTableInfo = mainTable;
            requestInfo.workflowDetailTableInfos = new WF.WorkflowDetailTableInfo[] { detailTable };  // 这里只有一个明细表

            string result = wfclient.doCreateWorkflowRequest(requestInfo, 58);                        // 创建流程

            return result;
        }
    }
#endif
}
