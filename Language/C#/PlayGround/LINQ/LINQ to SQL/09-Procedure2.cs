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

            Guid bookId = new Guid("0737c167-e3d9-4a46-9247-2d0101ab18d1");
            var query = dataContext.GetBook(bookId, Thread.CurrentPrincipal.Identity.Name);

            ObjectDumper.Write(query);

            Console.ReadKey();
        }
    }
}

/*
执行存储过程，返回单一结果集。
需要先创建存储过程与对象之间的关系（见MyDataContext.cs），才可以使用。

EXEC @RETURN_VALUE = [dbo].[GetBook] @BookId = @p0, @UserName = @p1
-- @p0: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [0737c167-e3d9-4a46-9247-2d0101ab18d1]
-- @p1: Input NVarChar (Size = 4000; Prec = 0; Scale = 0) []
-- @RETURN_VALUE: Output Int (Size = -1; Prec = 0; Scale = 0) [Null]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

BookId=0737c167-e3d9-4a46-9247-2d0101ab18d1  Isbn=0-333-77777-2  Notes=null  PageCount=1205  Price=88.1000  PublicationDate=2005/5/5  Summary=null  Title=All your base are belong to us
    SubjectId=c603e018-7e60-4cf2-b147-fb13e9be3d72  PublisherId=855cb02e-dc29-473d-9f40-6c3405043fa3
*/