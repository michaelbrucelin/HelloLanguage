using System;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;

namespace TempTestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Data Source=.;Initial Catalog=LIA;Integrated Security=true;";

            DataContext dataContext = new DataContext(connStr);
            dataContext.Log = Console.Out;

            var query = from book in dataContext.GetTable<Book>()
                        group book by book.SubjectId into groupedBooks
                        orderby groupedBooks.Key
                        select new
                        {
                            SubjectId = groupedBooks.Key,
                            BookCount = groupedBooks.Count(),
                            TotalPrice = groupedBooks.Sum(b => b.Price),
                            LowPrice = groupedBooks.Min(b => b.Price),
                            HighPrice = groupedBooks.Max(b => b.Price),
                            AveragePrice = groupedBooks.Average(b => b.Price)
                        };

            Console.WriteLine($"翻译后的SQL语句为：{Environment.NewLine}{dataContext.GetCommand(query).CommandText}{Environment.NewLine}");

            ObjectDumper.Write(query, 1);

            Console.ReadKey();
        }
    }
}

/*
对比前一次翻译的SQL语句，这次group分组后，其他的信息都是聚合值，而没有每个分组的明细，所以这次是一次性取回全部结果，而不只是分组信息。

翻译后的SQL语句为：
SELECT [t1].[Subject] AS [SubjectId], [t1].[value] AS [BookCount], [t1].[value2] AS [TotalPrice], [t1].[value3] AS [LowPrice], [t1].[value4] AS [HighPrice], [t1].[value5] AS [AveragePrice]
FROM (
    SELECT COUNT(*) AS [value], SUM([t0].[Price]) AS [value2], MIN([t0].[Price]) AS [value3], MAX([t0].[Price]) AS [value4], AVG([t0].[Price]) AS [value5], [t0].[Subject]
    FROM [Book] AS [t0]
    GROUP BY [t0].[Subject]
    ) AS [t1]
ORDER BY [t1].[Subject]

SELECT [t1].[Subject] AS [SubjectId], [t1].[value] AS [BookCount], [t1].[value2] AS [TotalPrice], [t1].[value3] AS [LowPrice], [t1].[value4] AS [HighPrice], [t1].[value5] AS [AveragePrice]
FROM (
    SELECT COUNT(*) AS [value], SUM([t0].[Price]) AS [value2], MIN([t0].[Price]) AS [value3], MAX([t0].[Price]) AS [value4], AVG([t0].[Price]) AS [value5], [t0].[Subject]
    FROM [Book] AS [t0]
    GROUP BY [t0].[Subject]
    ) AS [t1]
ORDER BY [t1].[Subject]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

SubjectId=a0e2a5d7-88c6-4dfe-a416-10eadb978b0b  BookCount=3  TotalPrice=238.1500  LowPrice=62.0000  HighPrice=90.6500  AveragePrice=79.3833
SubjectId=92f10ca6-7970-473d-9a25-1ff6cab8f682  BookCount=1  TotalPrice=71.0000   LowPrice=71.0000  HighPrice=71.0000  AveragePrice=71.0000
SubjectId=c603e018-7e60-4cf2-b147-fb13e9be3d72  BookCount=1  TotalPrice=88.1000   LowPrice=88.1000  HighPrice=88.1000  AveragePrice=88.1000
*/