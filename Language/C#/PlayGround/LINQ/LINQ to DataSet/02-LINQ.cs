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

            DataTable bookTable = ds.Tables[1];

            var filteredBooks = from book in bookTable.AsEnumerable()
                                where book.Field<string>("Title").StartsWith("L")
                                select new
                                {
                                    Title = book.Field<string>("Title"),
                                    Price = book.Field<decimal?>("Price")
                                };

            // 可以直接将filteredBooks.ToList()绑定到DataGridView上

            Console.ReadKey();
        }
    }
}

/*
使用LINQ查询DataSet中的数据
*/