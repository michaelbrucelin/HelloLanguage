using System;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Data Source=.;Initial Catalog=LIA;Integrated Security=true;";

            // DataContext dataContext = new DataContext(connStr);
            MyDataContext dataContext = new MyDataContext(connStr);
            dataContext.Log = Console.Out;

            Guid publisherId = new Guid("855cb02e-dc29-473d-9f40-6c3405043fa3");
            var query = from book in dataContext.fnGetPublishersBooks(publisherId)
                        select new
                        {
                            book.Title,
                            OtherBookCount = dataContext.fnBookCountForPublisher(book.PublisherId) - 1
                        };

            ObjectDumper.Write(query);

            Console.ReadKey();
        }
    }
}

/*
执行表值函数。
需要先创建表值函数与对象之间的关系（见MyDataContext.cs），才可以使用。

SELECT [t0].[Title], (CONVERT(Int,[dbo].[fnBookCountForPublisher]([t0].[Publisher]))) - @p1 AS [OtherBookCount]
FROM [dbo].[fnGetPublishersBooks](@p0) AS [t0]
-- @p0: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [855cb02e-dc29-473d-9f40-6c3405043fa3]
-- @p1: Input Int (Size = -1; Prec = 0; Scale = 0) [1]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

Title=All your base are belong to us    OtherBookCount=2
Title=C# on Rails                       OtherBookCount=2
Title=LINQ rules                        OtherBookCount=2
*/