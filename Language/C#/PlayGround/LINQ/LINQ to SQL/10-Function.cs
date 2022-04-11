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

            var query = from publisher in dataContext.GetTable<Publisher>()
                        select new
                        {
                            publisher.Name,
                            BookCount = dataContext.fnBookCountForPublisher(publisher.ID)
                        };

            ObjectDumper.Write(query);

            Console.ReadKey();
        }
    }
}

/*
执行标量值函数。
需要先创建标量值函数与对象之间的关系（见MyDataContext.cs），才可以使用。

SELECT [t0].[Name], CONVERT(Int,[dbo].[fnBookCountForPublisher]([t0].[ID])) AS [BookCount]
FROM [dbo].[Publisher] AS [t0]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

Name=FunBooks          BookCount=2
Name=Joe Publishing    BookCount=3
Name=Manning Press     BookCount=0
*/