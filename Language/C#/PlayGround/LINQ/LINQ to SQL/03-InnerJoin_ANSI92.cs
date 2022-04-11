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

            var subjects = dataContext.GetTable<Subject>();
            var books = dataContext.GetTable<Book>();

            // 类似于SQL ANSI 92标准的写法
            var query = from subject in subjects
                        join book in books on subject.SubjectId equals book.SubjectId
                        select new { subject.Name, book.Title, book.Price };

            Console.WriteLine($"翻译后的SQL语句为：{Environment.NewLine}{dataContext.GetCommand(query).CommandText}{Environment.NewLine}");

            ObjectDumper.Write(query, 1);

            Console.ReadKey();
        }
    }
}

/*
内连接，对应SQL ANSI 92标准的写法

翻译后的SQL语句为：
SELECT [t0].[Name], [t1].[Title], [t1].[Price]
FROM [Subject] AS [t0]
INNER JOIN [Book] AS [t1] ON [t0].[ID] = [t1].[Subject]

SELECT [t0].[Name], [t1].[Title], [t1].[Price]
FROM [Subject] AS [t0]
INNER JOIN [Book] AS [t1] ON [t0].[ID] = [t1].[Subject]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

Name=Science fiction       Title=All your base are belong to us  Price=88.1000
Name=Software development  Title=C# on Rails                     Price=90.6500
Name=Software development  Title=Funny Stories                   Price=85.5000
Name=Software development  Title=LINQ rules                      Price=62.0000
Name=Novel                 Title=Bonjour mon Amour               Price=71.0000
*/