using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    //在字符串拆分函数中使用的结构
    struct this_row_item
    {
        public string infooldhtml;
        public string infonewhtml;
    }

    //FillRowMethod
    public static void InfoHtmlFillRow(Object obj, out string infoold, out string infonew)
    {
        infoold = ((this_row_item)obj).infooldhtml;
        infonew = ((this_row_item)obj).infonewhtml;
    }

    //拆分字符串数据并返回表
    //FillRowMethodName = "InfoHtmlFillRow"
    [SqlFunction(FillRowMethodName = "InfoHtmlFillRow",
     DataAccess = DataAccessKind.None,
     TableDefinition = "infooldhtml NVARCHAR(max), infonewhtml NVARCHAR(max)")]
    public static IEnumerable systemlog_infotohtml(SqlString infoold, SqlString infonew)
    {
        string infooldHtml = "", infonewHtml = "";
        if (infoold.IsNull)
        {
            infoold = string.Empty;
        }
        if (infonew.IsNull)
        {
            infonew = string.Empty;
        }

        char[] separator = new char[1];
        separator[0] = Convert.ToChar(0x0A);
        //separator[1] = Convert.ToChar(0x0D);

        if (infoold.Value.Length > 0)
        {
            string[] infooldArray = infoold.Value.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (infonew.Value.Length > 0)
            {
                string[] infonewArray = infonew.Value.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                int countold = infooldArray.Length;
                int countnew = infonewArray.Length;
                int countmin = Math.Min(countold, countnew);
                for (int i = 0; i < countmin; i++)
                {
                    if (infooldArray[i] == infonewArray[i])
                    {
                        infooldHtml += infooldArray[i] + "<br>";
                        infonewHtml += infonewArray[i] + "<br>";
                    }
                    else
                    {
                        infooldHtml += "<font color=\"#ff0000\">" + infooldArray[i] + "</font><br>";
                        infonewHtml += "<font color=\"#ff0000\">" + infonewArray[i] + "</font><br>";
                    }
                }
            }
            else
            {
                int count = infooldArray.Length;
                for (int i = 0; i < count; i++)
                {
                    infooldHtml += infooldArray[i] + "<br>";
                }
            }
        }
        else
        {
            if (infonew.Value.Length > 0)
            {
                string[] infonewArray = infonew.Value.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                int count = infonewArray.Length;
                for (int i = 0; i < count; i++)
                {
                    infonewHtml += infonewArray[i] + "<br>";
                }
            }
        }

        List<this_row_item> rows = new List<this_row_item>();
        this_row_item r = new this_row_item();
        r.infooldhtml = infooldHtml;
        r.infonewhtml = infonewHtml;
        rows.Add(r);

        return rows;
    }
}
