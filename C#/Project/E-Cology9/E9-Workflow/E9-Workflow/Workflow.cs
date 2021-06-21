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
        /// 返回主表信息，包含每个字段的数据库column name和对应的值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public WF.WorkflowMainTableInfo GetMainTableInfo(Dictionary<string, string> data)
        {
            WF.WorkflowMainTableInfo main = new WF.WorkflowMainTableInfo();

            return main;
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
