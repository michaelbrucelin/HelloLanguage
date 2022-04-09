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

            // DataContext是LINQ to SQL的核心，它负责：1. 连接管理；2. 查询语句的翻译与执行；3. 对象识别；4. 跟踪对象变化
            DataContext dataContext = new DataContext(connStr);
            dataContext.Log = Console.Out;  // 启用Log属性，所有将要提交给数据库的SQL语句都会被发送到指定的输出流中

            var query = from book in dataContext.GetTable<Book>()
                        where book.Price > 30
                        select new { book.Title, book.Price };

            Console.WriteLine($"翻译后的SQL语句为：{Environment.NewLine}{dataContext.GetCommand(query).CommandText}{Environment.NewLine}");

            ObjectDumper.Write(query);

            Console.ReadKey();
        }
    }
}

/*
翻译后的SQL语句为：
SELECT [t0].[Title], [t0].[Price]
FROM [Book] AS [t0]
WHERE [t0].[Price] > @p0

SELECT [t0].[Title], [t0].[Price]
FROM [Book] AS [t0]
WHERE [t0].[Price] > @p0
-- @p0: Input Decimal (Size = -1; Prec = 33; Scale = 4) [30]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

Title=All your base are belong to us    Price=88.1000
Title=C# on Rails                       Price=90.6500
Title=Funny Stories                     Price=85.5000
Title=LINQ rules                        Price=62.0000
Title=Bonjour mon Amour                 Price=71.0000
*/