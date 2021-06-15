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
        public string Test()
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
    }
}
