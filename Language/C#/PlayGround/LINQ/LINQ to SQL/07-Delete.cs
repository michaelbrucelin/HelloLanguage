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

            Table<Book> books = dataContext.GetTable<Book>();

            Book newBook = new Book()
            {
                BookId = new Guid("00000000-0000-0000-0000-000000000001"),
                Price = 40,
                PublicationDate = DateTime.Today,
                Title = "Linq In Action (second edition)",
                PublisherId = new Guid("4ab0856e-51f3-4b67-9355-8b11510119ba"),
                SubjectId = new Guid("a0e2a5d7-88c6-4dfe-a416-10eadb978b0b")
            };

            books.InsertOnSubmit(newBook);
            dataContext.SubmitChanges();

            books.DeleteOnSubmit(newBook);
            dataContext.SubmitChanges();

            Console.ReadKey();
        }
    }
}

/*
删除一个通过程序新增的记录。
看翻译后的DELETE SQL语句，如果数据库的表没有主键，即存在完全相同的两条记录，是不是会导致将两条记录都删除，这里没做验证？
进行关系映射的时候已经强制必须含有主键了。

INSERT INTO [Book]([ID], [Isbn], [Notes], [PageCount], [Price], [PubDate], [Summary], [Title], [Subject], [Publisher])
VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)
-- @p0: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [00000000-0000-0000-0000-000000000001]
-- @p1: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [Null]
-- @p2: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [Null]
-- @p3: Input Int (Size = -1; Prec = 0; Scale = 0) [0]
-- @p4: Input Decimal (Size = -1; Prec = 29; Scale = 4) [40]
-- @p5: Input DateTime (Size = -1; Prec = 0; Scale = 0) [2022/4/9 0:00:00]
-- @p6: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [Null]
-- @p7: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [Linq In Action (second edition)]
-- @p8: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [a0e2a5d7-88c6-4dfe-a416-10eadb978b0b]
-- @p9: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [4ab0856e-51f3-4b67-9355-8b11510119ba]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

DELETE FROM [Book] WHERE ([ID] = @p0) AND ([Isbn] IS NULL) AND ([Notes] IS NULL) AND ([PageCount] = @p1) AND ([Price] = @p2) AND ([PubDate] = @p3) AND ([Summary] IS NULL) AND ([Title] = @p4) AND ([Subject] = @p5) AND ([Publisher] = @p6)
-- @p0: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [00000000-0000-0000-0000-000000000001]
-- @p1: Input Int (Size = -1; Prec = 0; Scale = 0) [0]
-- @p2: Input Decimal (Size = -1; Prec = 29; Scale = 4) [40]
-- @p3: Input DateTime (Size = -1; Prec = 0; Scale = 0) [2022/4/9 0:00:00]
-- @p4: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [Linq In Action (second edition)]
-- @p5: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [a0e2a5d7-88c6-4dfe-a416-10eadb978b0b]
-- @p6: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [4ab0856e-51f3-4b67-9355-8b11510119ba]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0
*/