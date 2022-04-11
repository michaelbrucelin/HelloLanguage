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

            Guid publisherId = new Guid("851e3294-145d-4fff-a190-3cab7aa95f76");
            var query = dataContext.BookCountForPublisher(publisherId).ToString();

            // ObjectDumper.Write(query);
            Console.WriteLine(String.Format("Books found: {0}", query));

            Console.ReadKey();
        }
    }
}

/*
执行存储过程，返回单一值（标量值）。
需要先创建存储过程与对象之间的关系（见MyDataContext.cs），才可以使用。

EXEC @RETURN_VALUE = [dbo].[BookCountForPublisher] @PublisherId = @p0
-- @p0: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [851e3294-145d-4fff-a190-3cab7aa95f76]
-- @RETURN_VALUE: Output Int (Size = -1; Prec = 0; Scale = 0) [Null]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

Books found: 0
*/