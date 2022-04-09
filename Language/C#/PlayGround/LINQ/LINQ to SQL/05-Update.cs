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

            var subjects = dataContext.GetTable<Subject>();
            var books = dataContext.GetTable<Book>();
            var query = from book in dataContext.GetTable<Book>()
                        where book.Price > 30
                        select book;

            foreach (Book book in query)
            {
                book.Price -= 5;
            }
            dataContext.SubmitChanges();

            Console.WriteLine($"翻译后的SQL语句为：{Environment.NewLine}{dataContext.GetCommand(query).CommandText}{Environment.NewLine}");

            ObjectDumper.Write(query, 1);

            Console.ReadKey();
        }
    }
}

/*
返回整行数据（测试只返回需要更改的列无效），然后操作对象，最后提交更改，就将本地对对象的更改同步到数据库中

SELECT [t0].[ID] AS [BookId], [t0].[Isbn], [t0].[Notes], [t0].[PageCount], [t0].[Price], [t0].[PubDate] AS [PublicationDate], [t0].[Summary], [t0].[Title], [t0].[Subject] AS [SubjectId], [t0].[Publisher] AS [PublisherId]
FROM [Book] AS [t0]
WHERE [t0].[Price] > @p0
-- @p0: Input Decimal (Size = -1; Prec = 33; Scale = 4) [30]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

UPDATE [Book]
SET [Price] = @p8
WHERE ([ID] = @p0) AND ([Isbn] = @p1) AND ([Notes] IS NULL) AND ([PageCount] = @p2) AND ([Price] = @p3) AND ([PubDate] = @p4) AND ([Summary] IS NULL) AND ([Title] = @p5) AND ([Subject] = @p6) AND ([Publisher] = @p7)
-- @p0: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [0737c167-e3d9-4a46-9247-2d0101ab18d1]
-- @p1: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [0-333-77777-2]
-- @p2: Input Int (Size = -1; Prec = 0; Scale = 0) [1205]
-- @p3: Input Decimal (Size = -1; Prec = 29; Scale = 4) [88.1000]
-- @p4: Input DateTime (Size = -1; Prec = 0; Scale = 0) [2005/5/5 0:00:00]
-- @p5: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [All your base are belong to us]
-- @p6: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [c603e018-7e60-4cf2-b147-fb13e9be3d72]
-- @p7: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [855cb02e-dc29-473d-9f40-6c3405043fa3]
-- @p8: Input Decimal (Size = -1; Prec = 29; Scale = 4) [83.1000]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

UPDATE [Book]
SET [Price] = @p8
WHERE ([ID] = @p0) AND ([Isbn] = @p1) AND ([Notes] IS NULL) AND ([PageCount] = @p2) AND ([Price] = @p3) AND ([PubDate] = @p4) AND ([Summary] IS NULL) AND ([Title] = @p5) AND ([Subject] = @p6) AND ([Publisher] = @p7)
-- @p0: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [09017e35-ca66-40b8-80a4-ba5253716e33]
-- @p1: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [2-444-77777-2]
-- @p2: Input Int (Size = -1; Prec = 0; Scale = 0) [50]
-- @p3: Input Decimal (Size = -1; Prec = 29; Scale = 4) [71.0000]
-- @p4: Input DateTime (Size = -1; Prec = 0; Scale = 0) [1973/2/18 0:00:00]
-- @p5: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [Bonjour mon Amour]
-- @p6: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [92f10ca6-7970-473d-9a25-1ff6cab8f682]
-- @p7: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [4ab0856e-51f3-4b67-9355-8b11510119ba]
-- @p8: Input Decimal (Size = -1; Prec = 29; Scale = 4) [66.0000]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

UPDATE [Book]
SET [Price] = @p8
WHERE ([ID] = @p0) AND ([Isbn] = @p1) AND ([Notes] IS NULL) AND ([PageCount] = @p2) AND ([Price] = @p3) AND ([PubDate] = @p4) AND ([Summary] IS NULL) AND ([Title] = @p5) AND ([Subject] = @p6) AND ([Publisher] = @p7)
-- @p0: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [4f3b0ac1-3746-4067-a810-79a9ce02a7bf]
-- @p1: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [0-000-77777-2]
-- @p2: Input Int (Size = -1; Prec = 0; Scale = 0) [101]
-- @p3: Input Decimal (Size = -1; Prec = 29; Scale = 4) [85.5000]
-- @p4: Input DateTime (Size = -1; Prec = 0; Scale = 0) [2004/11/10 0:00:00]
-- @p5: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [Funny Stories]
-- @p6: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [a0e2a5d7-88c6-4dfe-a416-10eadb978b0b]
-- @p7: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [4ab0856e-51f3-4b67-9355-8b11510119ba]
-- @p8: Input Decimal (Size = -1; Prec = 29; Scale = 4) [80.5000]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

UPDATE [Book]
SET [Price] = @p8
WHERE ([ID] = @p0) AND ([Isbn] = @p1) AND ([Notes] IS NULL) AND ([PageCount] = @p2) AND ([Price] = @p3) AND ([PubDate] = @p4) AND ([Summary] IS NULL) AND ([Title] = @p5) AND ([Subject] = @p6) AND ([Publisher] = @p7)
-- @p0: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [5a361453-13ee-4eca-9694-a0cea8cdbac2]
-- @p1: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [0-111-77777-2]
-- @p2: Input Int (Size = -1; Prec = 0; Scale = 0) [300]
-- @p3: Input Decimal (Size = -1; Prec = 29; Scale = 4) [62.0000]
-- @p4: Input DateTime (Size = -1; Prec = 0; Scale = 0) [2007/9/2 0:00:00]
-- @p5: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [LINQ rules]
-- @p6: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [a0e2a5d7-88c6-4dfe-a416-10eadb978b0b]
-- @p7: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [855cb02e-dc29-473d-9f40-6c3405043fa3]
-- @p8: Input Decimal (Size = -1; Prec = 29; Scale = 4) [57.0000]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

UPDATE [Book]
SET [Price] = @p8
WHERE ([ID] = @p0) AND ([Isbn] = @p1) AND ([Notes] IS NULL) AND ([PageCount] = @p2) AND ([Price] = @p3) AND ([PubDate] = @p4) AND ([Summary] IS NULL) AND ([Title] = @p5) AND ([Subject] = @p6) AND ([Publisher] = @p7)
-- @p0: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [b1c7670c-fdf5-45e5-8f06-3b7994b6a346]
-- @p1: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [0-222-77777-2]
-- @p2: Input Int (Size = -1; Prec = 0; Scale = 0) [256]
-- @p3: Input Decimal (Size = -1; Prec = 29; Scale = 4) [90.6500]
-- @p4: Input DateTime (Size = -1; Prec = 0; Scale = 0) [2007/4/1 0:00:00]
-- @p5: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) [C# on Rails]
-- @p6: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [a0e2a5d7-88c6-4dfe-a416-10eadb978b0b]
-- @p7: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [855cb02e-dc29-473d-9f40-6c3405043fa3]
-- @p8: Input Decimal (Size = -1; Prec = 29; Scale = 4) [85.6500]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

翻译后的SQL语句为：
SELECT [t0].[ID] AS [BookId], [t0].[Isbn], [t0].[Notes], [t0].[PageCount], [t0].[Price], [t0].[PubDate] AS [PublicationDate], [t0].[Summary], [t0].[Title], [t0].[Subject] AS [SubjectId], [t0].[Publisher] AS [PublisherId]
FROM [Book] AS [t0]
WHERE [t0].[Price] > @p0

SELECT [t0].[ID] AS [BookId], [t0].[Isbn], [t0].[Notes], [t0].[PageCount], [t0].[Price], [t0].[PubDate] AS [PublicationDate], [t0].[Summary], [t0].[Title], [t0].[Subject] AS [SubjectId], [t0].[Publisher] AS [PublisherId]
FROM [Book] AS [t0]
WHERE [t0].[Price] > @p0
-- @p0: Input Decimal (Size = -1; Prec = 33; Scale = 4) [30]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

BookId=0737c167-e3d9-4a46-9247-2d0101ab18d1  Isbn=0-333-77777-2  Notes=null  PageCount=1205  Price=83.1000  PublicationDate=2005/5/5    Summary=null  Title=All your base are belong to us
    SubjectId=c603e018-7e60-4cf2-b147-fb13e9be3d72  PublisherId=855cb02e-dc29-473d-9f40-6c3405043fa3
BookId=b1c7670c-fdf5-45e5-8f06-3b7994b6a346  Isbn=0-222-77777-2  Notes=null  PageCount=256   Price=85.6500  PublicationDate=2007/4/1    Summary=null  Title=C# on Rails
    SubjectId=a0e2a5d7-88c6-4dfe-a416-10eadb978b0b  PublisherId=855cb02e-dc29-473d-9f40-6c3405043fa3
BookId=4f3b0ac1-3746-4067-a810-79a9ce02a7bf  Isbn=0-000-77777-2  Notes=null  PageCount=101   Price=80.5000  PublicationDate=2004/11/10  Summary=null  Title=Funny Stories
    SubjectId=a0e2a5d7-88c6-4dfe-a416-10eadb978b0b  PublisherId=4ab0856e-51f3-4b67-9355-8b11510119ba
BookId=5a361453-13ee-4eca-9694-a0cea8cdbac2  Isbn=0-111-77777-2  Notes=null  PageCount=300   Price=57.0000  PublicationDate=2007/9/2    Summary=null  Title=LINQ rules
    SubjectId=a0e2a5d7-88c6-4dfe-a416-10eadb978b0b  PublisherId=855cb02e-dc29-473d-9f40-6c3405043fa3
BookId=09017e35-ca66-40b8-80a4-ba5253716e33  Isbn=2-444-77777-2  Notes=null  PageCount=50    Price=66.0000  PublicationDate=1973/2/18   Summary=null  Title=Bonjour mon Amour
    SubjectId=92f10ca6-7970-473d-9a25-1ff6cab8f682  PublisherId=4ab0856e-51f3-4b67-9355-8b11510119ba
*/