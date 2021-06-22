using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF = E9_Workflow.E9WorkflowService;

namespace E9_Workflow
{
    public class Workflow
    {
        /// <summary>
        /// 使用json创建流程
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public (bool result, string desc) CreateWF(string json)
        {
            QRequestInfo QRInfo = JsonConvert.DeserializeObject<QRequestInfo>(json);

            WF.WorkflowServicePortTypeClient wfclient = new WF.WorkflowServicePortTypeClient();
            WF.WorkflowRequestInfo requestInfo = new WF.WorkflowRequestInfo();

            requestInfo.requestName = QRInfo.requestName;
            requestInfo.requestLevel = QRInfo.requestLevel;
            requestInfo.workflowBaseInfo = QRInfo.baseInfo;
            requestInfo.workflowMainTableInfo = QRInfo.mainTableInfo;

            if (QRInfo.detailTableInfos != null && QRInfo.detailTableInfos.Length > 0)
                requestInfo.workflowDetailTableInfos = QRInfo.detailTableInfos;

            string result = wfclient.doCreateWorkflowRequest(requestInfo, QRInfo.creater);

            return GetWFCreateState(result);
        }

        /// <summary>
        /// 使用对象创建流程
        /// </summary>
        /// <param name="title"></param>
        /// <param name="creater"></param>
        /// <param name="wfid"></param>
        /// <param name="mainTable"></param>
        /// <param name="detailTable"></param>
        /// <returns></returns>
        public (bool result, string desc) CreateWF(string title, int creater, string wfid,
            Dictionary<string, string> mainTable, List<Dictionary<string, string>> detailTable = null)
        {
            return CreateWF(title, "0", creater, wfid, mainTable, detailTable);
        }

        /// <summary>
        /// 使用对象创建流程
        /// </summary>
        /// <param name="title"></param>
        /// <param name="level"></param>
        /// <param name="creater"></param>
        /// <param name="wfid"></param>
        /// <param name="mainTable"></param>
        /// <param name="detailTable"></param>
        /// <returns></returns>
        public (bool result, string desc) CreateWF(string title, string level, int creater, string wfid,
            Dictionary<string, string> mainTable, List<Dictionary<string, string>> detailTable = null)
        {
            QRequestInfo QRInfo = JsonConvert.DeserializeObject<QRequestInfo>(title);

            WF.WorkflowServicePortTypeClient wfclient = new WF.WorkflowServicePortTypeClient();
            WF.WorkflowRequestInfo requestInfo = new WF.WorkflowRequestInfo();

            requestInfo.requestName = QRInfo.requestName;
            requestInfo.requestLevel = QRInfo.requestLevel;
            requestInfo.workflowBaseInfo = QRInfo.baseInfo;
            requestInfo.workflowMainTableInfo = QRInfo.mainTableInfo;

            if (QRInfo.detailTableInfos != null && QRInfo.detailTableInfos.Length > 0)
                requestInfo.workflowDetailTableInfos = QRInfo.detailTableInfos;

            string result = wfclient.doCreateWorkflowRequest(requestInfo, QRInfo.creater);

            return GetWFCreateState(result);
        }

        /// <summary>
        /// 返回参数的json形式
        /// </summary>
        /// <returns></returns>
        public string GetJsonSchema()
        {
            string result = @"{
  'creater': 58,
  'requestName': '流程标题：费用报销申请—张三—19000101',
  'requestLevel': '紧急程度：0正常 1重要 2紧急',

  'baseInfo': {
    'workflowId': '4'
  },

  'mainTableInfo': {
    'requestRecords': [
      {
        'workflowRequestTableFields': [
          {
            'fieldName': 'chrm',
            'fieldValue': '133',
            'view': true,
            'edit': true
          },
          {
            'fieldName': 'cdept',
            'fieldValue': '22',
            'view': true,
            'edit': true
          },
          {
            'fieldName': 'cdate',
            'fieldValue': '1900-01-01',
            'view': true,
            'edit': true
          }
        ]
      }
    ]
  },

  'detailTableInfos': [
    {
      'workflowRequestTableRecords': [
        {
          'workflowRequestTableFields': [
            {
              'fieldName': 'bxlx',
              'fieldValue': '0',
              'view': true,
              'edit': true
            },
            {
              'fieldName': 'fjs',
              'fieldValue': '0',
              'view': true,
              'edit': true
            },
            {
              'fieldName': 'shbbz',
              'fieldValue': '￥',
              'view': true,
              'edit': true
            },
            {
              'fieldName': 'shbje',
              'fieldValue': '100',
              'view': true,
              'edit': true
            }
          ]
        },
        {
          'workflowRequestTableFields': [
            {
              'fieldName': 'bxlx',
              'fieldValue': '1',
              'view': true,
              'edit': true
            },
            {
              'fieldName': 'fjs',
              'fieldValue': '0',
              'view': true,
              'edit': true
            },
            {
              'fieldName': 'shbbz',
              'fieldValue': '￥',
              'view': true,
              'edit': true
            },
            {
              'fieldName': 'shbje',
              'fieldValue': '200',
              'view': true,
              'edit': true
            }
          ]
        }
      ]
    }
  ]
}
";
            return result;
        }

        /// <summary>
        /// 返回流程主表单信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private WF.WorkflowMainTableInfo GetMainTableInfo(Dictionary<string, string> data)
        {
            List<WF.WorkflowRequestTableField> fieldsList = new List<WF.WorkflowRequestTableField>();
            foreach (var item in data)
            {
                fieldsList.Add(new WF.WorkflowRequestTableField()
                {
                    fieldName = item.Key,
                    fieldValue = item.Value,
                    view = true,
                    edit = true
                });
            }

            WF.WorkflowRequestTableRecord records = new WF.WorkflowRequestTableRecord();
            records.workflowRequestTableFields = fieldsList.ToArray();

            WF.WorkflowMainTableInfo mainTable = new WF.WorkflowMainTableInfo();
            mainTable.requestRecords = new WF.WorkflowRequestTableRecord[] { records };

            return mainTable;
        }

        private WF.WorkflowDetailTableInfo GetDetailTableInfo(List<Dictionary<string, string>>[] data)
        {
            WF.WorkflowDetailTableInfo[] tables = new WF.WorkflowDetailTableInfo[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                List<WF.WorkflowRequestTableRecord> records = new List<WF.WorkflowRequestTableRecord>();


                WF.WorkflowDetailTableInfo table = new WF.WorkflowDetailTableInfo();
                table.workflowRequestTableRecords = records.ToArray();
                tables[i] = table;
            }


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
        }

        /// <summary>
        /// 创建流程返回值信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private (bool result, string desc) GetWFCreateState(string input)
        {
            int inputInt;
            string desc;

            if (!int.TryParse(input, out inputInt))
                return (false, input);

            if (inputInt > 0)
            {
                return (true, input);
            }
            else
            {
                switch (input)
                {
                    case "-1":
                        desc = "创建流程失败";
                        break;
                    case "-2":
                        desc = "用户没有流程创建权限";
                        break;
                    case "-3":
                        desc = "创建流程基本信息失败";
                        break;
                    case "-4":
                        desc = "保存表单主表信息失败";
                        break;
                    case "-5":
                        desc = "更新流程紧急程度失败";
                        break;
                    case "-6":
                        desc = "流程操作者失败";
                        break;
                    case "-7":
                        desc = "流转至下一节点失败";
                        break;
                    case "-8":
                        desc = "节点附加操作失败";
                        break;
                    case "-9":
                        desc = "附件文档未创建";
                        break;
                    default:
                        desc = input;
                        break;
                }
            }

            return (false, desc);
        }
    }

    public class QRequestInfo
    {
        public int creater;
        public string requestName;
        public string requestLevel;
        public WF.WorkflowBaseInfo baseInfo;
        public WF.WorkflowMainTableInfo mainTableInfo;
        public WF.WorkflowDetailTableInfo[] detailTableInfos;
    }
}
