using System;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Data Source=.;Initial Catalog=LIA;Integrated Security=true;";

            DataContext dataContext = new DataContext(connStr);
            dataContext.Log = Console.Out;

            var query = dataContext.GetTable<Book>()
                            .Where(i => i.Price > 30)
                            .Select(i => new { i.Title, i.Price })
                            .Skip(2)
                            .Take(2);

            Console.WriteLine($"翻译后的SQL语句为：{Environment.NewLine}{dataContext.GetCommand(query).CommandText}{Environment.NewLine}");

            ObjectDumper.Write(query);

            Console.ReadKey();
        }
    }
}

/*
翻译后的SQL语句为：
SELECT [t1].[Title], [t1].[Price]
FROM (
    SELECT ROW_NUMBER() OVER (ORDER BY [t0].[Title], [t0].[Price]) AS [ROW_NUMBER], [t0].[Title], [t0].[Price]
    FROM [Book] AS [t0]
    WHERE [t0].[Price] > @p0
    ) AS [t1]
WHERE [t1].[ROW_NUMBER] BETWEEN @p1 + 1 AND @p1 + @p2
ORDER BY [t1].[ROW_NUMBER]

SELECT [t1].[Title], [t1].[Price]
FROM (
    SELECT ROW_NUMBER() OVER (ORDER BY [t0].[Title], [t0].[Price]) AS [ROW_NUMBER], [t0].[Title], [t0].[Price]
    FROM [Book] AS [t0]
    WHERE [t0].[Price] > @p0
    ) AS [t1]
WHERE [t1].[ROW_NUMBER] BETWEEN @p1 + 1 AND @p1 + @p2
ORDER BY [t1].[ROW_NUMBER]
-- @p0: Input Decimal (Size = -1; Prec = 33; Scale = 4) [30]
-- @p1: Input Int (Size = -1; Prec = 0; Scale = 0) [2]
-- @p2: Input Int (Size = -1; Prec = 0; Scale = 0) [2]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

Title=C# on Rails       Price=90.6500
Title=Funny Stories     Price=85.5000
*/