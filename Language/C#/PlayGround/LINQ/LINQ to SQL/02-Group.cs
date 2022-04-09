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
                            Books = from bk in groupedBooks select bk.Title
                        };

            Console.WriteLine($"翻译后的SQL语句为：{Environment.NewLine}{dataContext.GetCommand(query).CommandText}{Environment.NewLine}");

            ObjectDumper.Write(query, 1);

            Console.ReadKey();
        }
    }
}

/*
分析代码并观察下面的结果，可以看出，LINQ to SQL并没有一步到位的取出这个分组的数据，而是先仅返回分组的键，然后再根据键逐个去取数据。

翻译后的SQL语句为：
SELECT [t1].[Subject] AS [SubjectId]
FROM (
    SELECT [t0].[Subject]
    FROM [Book] AS [t0]
    GROUP BY [t0].[Subject]
    ) AS [t1]
ORDER BY [t1].[Subject]

SELECT [t1].[Subject] AS [SubjectId]
FROM (
    SELECT [t0].[Subject]
    FROM [Book] AS [t0]
    GROUP BY [t0].[Subject]
    ) AS [t1]
ORDER BY [t1].[Subject]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

SELECT [t0].[Title]
FROM [Book] AS [t0]
WHERE @x1 = [t0].[Subject]
-- @x1: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [a0e2a5d7-88c6-4dfe-a416-10eadb978b0b]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

SubjectId=a0e2a5d7-88c6-4dfe-a416-10eadb978b0b  Books=...
    Books: C# on Rails
    Books: Funny Stories
    Books: LINQ rules
SELECT [t0].[Title]
FROM [Book] AS [t0]
WHERE @x1 = [t0].[Subject]
-- @x1: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [92f10ca6-7970-473d-9a25-1ff6cab8f682]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

SubjectId=92f10ca6-7970-473d-9a25-1ff6cab8f682  Books=...
    Books: Bonjour mon Amour
SELECT [t0].[Title]
FROM [Book] AS [t0]
WHERE @x1 = [t0].[Subject]
-- @x1: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [c603e018-7e60-4cf2-b147-fb13e9be3d72]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

SubjectId=c603e018-7e60-4cf2-b147-fb13e9be3d72  Books=...
    Books: All your base are belong to us
*/