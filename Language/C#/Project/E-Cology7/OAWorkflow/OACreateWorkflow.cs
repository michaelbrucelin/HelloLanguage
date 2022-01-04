using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAWorkflow
{
    public class OACreateWorkflow
    {
        public OACreateWorkflow()
        { }

        #region 创建只有主表没有明细表的流程
        /// <summary>
        /// 创建只有主表没有明细表的流程
        /// </summary>
        /// <param name="workflowid"></param>
        /// <param name="createrId"></param>
        /// <param name="title"></param>
        /// <param name="mainDic"></param>
        /// <returns></returns>
        public static string CreateWorkflow(string workflowid, string createrId, string title, Dictionary<string, string> mainDic)
        {
            return CreateWorkflow("0", workflowid, createrId, title, mainDic);
        }
        #endregion

        #region 创建带明细表（单一明细表）的流程
        /// <summary>
        /// 创建带明细表（单一明细表）的流程
        /// </summary>
        /// <param name="workflowid"></param>
        /// <param name="createrId"></param>
        /// <param name="title"></param>
        /// <param name="mainDic"></param>
        /// <param name="detailDics"></param>
        /// <returns></returns>
        public static string CreateWorkflow(string workflowid, string createrId, string title, Dictionary<string, string> mainDic, Dictionary<string, string>[] detailDics)
        {
            return CreateWorkflow("0", workflowid, createrId, title, mainDic, detailDics);
        }
        #endregion

        #region 创建只有主表没有明细表，指定紧急程度的流程
        /// <summary>
        /// 创建只有主表没有明细表，指定紧急程度的流程
        /// </summary>
        /// <param name="level">紧急程度，"0"—正常，"1"-重要，"2"-紧急</param>
        /// <param name="workflowid">流程在OA workflow_base表中的id</param>
        /// <param name="createrId">创建人在OA Hrmresource表中的id</param>
        /// <param name="title">流程标题</param>
        /// <param name="mainDic">明细表字段信息</param>
        /// <returns>新流程的requestid 如果小于0表示失败 -1：创建流程失败 -2：用户没有流程创建权限 -3：创建流程基本信息失败 -4：保存表单主表信息失败 -5：更新紧急程度失败 -6：流程操作者失败 -7：流转至下一节点失败 -8：节点附加操作失败</returns>
        public static string CreateWorkflow(string level, string workflowid, string createrId, string title, Dictionary<string, string> mainDic)
        {
            OA.RequestInfo requestInfo = new OA.RequestInfo();
            if (level == "0" || level == "1" || level == "2")
            {
                requestInfo.requestlevel = level;
            }
            else
            {
                requestInfo.requestlevel = "0";
            }
            requestInfo.workflowid = workflowid;
            requestInfo.creatorid = createrId;
            requestInfo.description = title;
            requestInfo.remindtype = "0";
            requestInfo.mainTableInfo = GetMainTableInfo(mainDic);

            OA.RequestService requestService = new OA.RequestService();

            return requestService.createRequest(requestInfo);
        }
        #endregion

        #region 创建带明细表（单一明细表），指定紧急程度的流程
        /// <summary>
        /// 创建带明细表（单一明细表），指定紧急程度的流程
        /// </summary>
        /// <param name="level">紧急程度，"0"—正常，"1"-重要，"2"-紧急</param>
        /// <param name="workflowid">流程在OA workflow_base表中的id</param>
        /// <param name="createrId">创建人在OA Hrmresource表中的id</param>
        /// <param name="title">流程标题</param>
        /// <param name="mainDic">主表字段信息</param>
        /// <param name="detailDics">明细表字段信息</param>
        /// <returns>新流程的requestid 如果小于0表示失败 -1：创建流程失败 -2：用户没有流程创建权限 -3：创建流程基本信息失败 -4：保存表单主表信息失败 -5：更新紧急程度失败 -6：流程操作者失败 -7：流转至下一节点失败 -8：节点附加操作失败</returns>
        public static string CreateWorkflow(string level, string workflowid, string createrId, string title, Dictionary<string, string> mainDic, Dictionary<string, string>[] detailDics)
        {
            OA.RequestInfo requestInfo = new OA.RequestInfo();
            if (level == "0" || level == "1" || level == "2")
            {
                requestInfo.requestlevel = level;
            }
            else
            {
                requestInfo.requestlevel = "0";
            }
            requestInfo.workflowid = workflowid;
            requestInfo.creatorid = createrId;
            requestInfo.description = title;
            requestInfo.remindtype = "0";
            requestInfo.mainTableInfo = GetMainTableInfo(mainDic);
            requestInfo.detailTableInfo = GetDetailTableInfo(detailDics);

            OA.RequestService requestService = new OA.RequestService();

            return requestService.createRequest(requestInfo);
        }
        #endregion

        #region 创建流程返回值信息
        /// <summary>
        /// 创建流程返回值信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string WorkflowCreateState(string input)
        {
            int inputInt;
            string result = "未知错误";
            if (int.TryParse(input, out inputInt) && inputInt > 0)
            {
                result = "成功";
            }
            else
            {
                switch (input)
                {
                    case "-1":
                        result = "创建流程失败";
                        break;
                    case "-2":
                        result = "用户没有流程创建权限";
                        break;
                    case "-3":
                        result = "创建流程基本信息失败";
                        break;
                    case "-4":
                        result = "保存表单主表信息失败";
                        break;
                    case "-5":
                        result = "更新紧急程度失败";
                        break;
                    case "-6":
                        result = "流程操作者失败";
                        break;
                    case "-7":
                        result = "流转至下一节点失败";
                        break;
                    case "-8":
                        result = "节点附加操作失败";
                        break;
                    default:
                        result = "未知错误";
                        break;
                }
            }

            return result;
        }
        #endregion

        #region 返回明细表信息，包含每个字段的数据库column name和对应的值
        /// <summary>
        /// 返回明细表信息，包含每个字段的数据库column name和对应的值
        /// </summary>
        /// <param name="mainDic"></param>
        /// <returns>OA.MainTableInfo</returns>
        private static OA.MainTableInfo GetMainTableInfo(Dictionary<string, string> mainDic)
        {
            int fieldCount = mainDic.Count;
            List<OA.Property> mainList = new List<OA.Property>();
            foreach (KeyValuePair<string, string> item in mainDic)
            {
                OA.Property p = new OA.Property()
                {
                    name = item.Key,
                    value = item.Value
                };
                mainList.Add(p);
            }
            OA.Property[] mainFields = mainList.ToArray();
            OA.MainTableInfo mainTableInfo = new OA.MainTableInfo() { property = mainFields };

            return mainTableInfo;
        }
        #endregion

        #region 返回明细表信息，包含每个字段的数据库column name和对应的值（只有一个明细表，多个明细表没做）
        /// <summary>
        /// 返回明细表信息，包含每个字段的数据库column name和对应的值（只有一个明细表，多个明细表没做）
        /// </summary>
        /// <param name="detailDics"></param>
        /// <returns>OA.DetailTableInfo</returns>
        private static OA.DetailTableInfo GetDetailTableInfo(Dictionary<string, string>[] detailDics)
        {
            OA.Row[] rows = new OA.Row[detailDics.Length];
            List<OA.Cell> fieldList = new List<OA.Cell>();
            for (int i = 0; i < detailDics.Length; i++)
            {
                fieldList.Clear();
                foreach (KeyValuePair<string, string> item in detailDics[i])
                {
                    OA.Cell cell = new OA.Cell()
                    {
                        name = item.Key,
                        value = item.Value
                    };
                    fieldList.Add(cell);
                }
                rows[i] = new OA.Row();
                rows[i].cell = fieldList.ToArray();
            }

            OA.DetailTable[] detailTables = new OA.DetailTable[1];
            detailTables[0] = new OA.DetailTable() { id = "1", row = rows };

            OA.DetailTableInfo detailTableInfo = new OA.DetailTableInfo();
            detailTableInfo.detailTable = detailTables;

            return detailTableInfo;
        }
        #endregion
    }
}
