using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    //在字符串拆分函数中使用的结构
    struct row_item
    {
        public string item;
        public int pos;
    }

    //FillRowMethod
    public static void ArrSplitFillRow(Object obj, out int pos, out string item)
    {
        pos = ((row_item)obj).pos;
        item = ((row_item)obj).item;
    }
}
