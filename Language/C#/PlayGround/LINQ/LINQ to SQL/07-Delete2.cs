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

            Table<Book> books = dataContext.GetTable<Book>();

            var query = from book in dataContext.GetTable<Book>()
                        where book.BookId == new Guid("00000000-0000-0000-0000-000000000000")
                        select book;

            books.DeleteOnSubmit(query.First());
            dataContext.SubmitChanges();

            Console.ReadKey();
        }
    }
}

/*
删除一个数据库原有的记录。

SELECT TOP (1) [t0].[ID] AS [BookId], [t0].[Isbn], [t0].[Notes], [t0].[PageCount], [t0].[Price], [t0].[PubDate] AS [PublicationDate], [t0].[Summary], [t0].[Title], [t0].[Subject] AS [SubjectId], [t0].[Publisher] AS [PublisherId]
FROM [Book] AS [t0]
WHERE [t0].[ID] = @p0
-- @p0: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [00000000-0000-0000-0000-000000000000]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

DELETE FROM [Book] WHERE ([ID] = @p0) AND ([Isbn] IS NULL) AND ([Notes] IS NULL) AND ([PageCount] = @p1) AND ([Price] = @p2) AND ([PubDate] = @p3) AND ([Summary] IS NULL) AND ([Title] = @p4) AND ([Subject] = @p5) AND ([Publisher] = @p6)
-- @p0: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [00000000-0000-0000-0000-000000000000]
-- @p1: Input Int (Size = -1; Prec = 0; Scale = 0) [0]
-- @p2: Input Decimal (Size = -1; Prec = 29; Scale = 4) [40.0000]
-- @p3: Input DateTime (Size = -1; Prec = 0; Scale = 0) [2022/4/9 0:00:00]
-- @p4: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [Linq In Action]
-- @p5: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [a0e2a5d7-88c6-4dfe-a416-10eadb978b0b]
-- @p6: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [4ab0856e-51f3-4b67-9355-8b11510119ba]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0
*/