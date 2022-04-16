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

            DataTable publisherTable = ds.Tables[0];
            DataTable bookTable = ds.Tables[1];

            // 创建出版社与图书之间的关系
            ds.Relations.Add("PublisherBooks", publisherTable.Columns["ID"], bookTable.Columns["Publisher"]);

            // 有了关系之后，可以使用DataRow.GetChildRows()得到与join相同的结果
            // 还有GetParentRows()与GetParentRows()方法，这里就不演示了
            var publisherBooks = from publisher in publisherTable.AsEnumerable()
                                 from book in publisher.GetChildRows("PublisherBooks")
                                 select new
                                 {
                                     Publisher = publisher.Field<string>("Name"),
                                     Book = book.Field<string>("Title")
                                 };

            // 可以直接将publisherBooks.ToList()绑定到DataGridView上

            Console.ReadKey();
        }
    }
}