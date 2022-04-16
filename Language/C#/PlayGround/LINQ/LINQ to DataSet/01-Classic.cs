using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("Publishers");
            ds.Tables.Add("Books");

            // 1. 使用DataTable.Select()方法
            DataRow[] drs1 = ds.Tables[0].Select("LEN(COL01) > 5");
            DataRow[] drs2 = ds.Tables[1].Select("(Price > 15) AND (Title LIKE '*i*')", "Title DESC");

            // 2. 使用System.Data.DataView类，DataView可以用来过滤并排序DataTable
            // 与DataTable.Select()方法相比，DataView的一个优势是其依然了DataTable中的元数据，这样就可以直接绑定到DataGridView上
            DataView dv1 = new DataView(ds.Tables[0], "LEN(COL01) > 5", String.Empty, DataViewRowState.Unchanged);
            DataView dv2 = new DataView(ds.Tables[1], "(Price > 15) AND (Title LIKE '*i*')", "Title DESC", DataViewRowState.Unchanged);

            // 3. DataTable.Select()与DataView可以配合使用
            // 在出版社和图书之间创建关系
            ds.Relations.Add("PublisherBooks", ds.Tables[0].Columns["ID"], ds.Tables[1].Columns["Publisher"]);
            // 仅列出拥有图书的出版商
            DataView dv = new DataView(ds.Tables[0], "COUNT(CHILD(PublisherBooks).Title) > 0", String.Empty, DataViewRowState.Unchanged);

            Console.ReadKey();
        }
    }
}

/*
传统的查询DataSet的方式
这种查询方式比较有限，而且无法得到编译时的语法检查。
*/