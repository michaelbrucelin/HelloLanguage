using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp0
{
    public static class MyUtilsMetadata
    {
        //MainForm，保存在此处用于其他child form调用
        public static MainForm MainForm;
        //MainForm Handle，保存在此处用于其他child form调用
        public static IntPtr MainFormHandle;

        //用于某个页面多开窗口使用，记录某一个页面已经开了多少了个窗口
        //maxFrmCnt表示同一个页面最多可以额外打开多少个窗口
        //字典中每一项记录着一个页面额外打开窗口的具体情况，其中的Value（数组）相当于的一个位图，默认为false，true就表示这个“位”已经有额外的窗口打开了
        public static int maxFrmCnt = 9;
        public static Dictionary<string, bool[]> frmCntDic = new Dictionary<string, bool[]>();

        //用于在生成MainForm TreeView的静态xml时，直接重新加载TreeView，而不用关闭重新打开，在这里共享该方法；
        public static Action LoadMainFormTreeView;
    }

    public class MyUtilsTabPageMetadata
    {
        public string FormName { get; set; }
        public int FormIndex { get; set; }
    }

    public class MyUtilsFormMetadata
    {
        public int Index { get; set; }
    }
}
