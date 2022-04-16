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

            var publisherBooks = from publisher in publisherTable.AsEnumerable()
                                 join book in bookTable.AsEnumerable()
                                    on publisher.Field<Guid>("ID") equals book.Field<Guid>("Publisher")
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