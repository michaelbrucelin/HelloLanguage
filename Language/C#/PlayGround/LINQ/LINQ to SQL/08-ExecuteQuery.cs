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

            string sql = @"select ID, Title, Price from Book where Price > {0}";

            var query = dataContext.ExecuteQuery<Book>(sql, 30);

            ObjectDumper.Write(query);

            Console.ReadKey();
        }
    }
}

/*
LINQ to SQL也可以像ADO.NET一样直接执行SQL语句，不过测试时发现select返回的列必须包含主键。

select ID, Title, Price from Book where Price > @p0
-- @p0: Input Int (Size = -1; Prec = 0; Scale = 0) [30]
-- Context: SqlProvider(Sql2008) Model: AttributedMetaModel Build: 4.8.3761.0

BookId=0737c167-e3d9-4a46-9247-2d0101ab18d1  Isbn=null  Notes=null  PageCount=0  Price=88.1000  PublicationDate=0001/1/1  Summary=null  Title=All your base are belong to us
    SubjectId=00000000-0000-0000-0000-000000000000  PublisherId=00000000-0000-0000-0000-000000000000
BookId=b1c7670c-fdf5-45e5-8f06-3b7994b6a346  Isbn=null  Notes=null  PageCount=0  Price=90.6500  PublicationDate=0001/1/1  Summary=null  Title=C# on Rails
    SubjectId=00000000-0000-0000-0000-000000000000  PublisherId=00000000-0000-0000-0000-000000000000
BookId=4f3b0ac1-3746-4067-a810-79a9ce02a7bf  Isbn=null  Notes=null  PageCount=0  Price=85.5000  PublicationDate=0001/1/1  Summary=null  Title=Funny Stories
    SubjectId=00000000-0000-0000-0000-000000000000  PublisherId=00000000-0000-0000-0000-000000000000
BookId=5a361453-13ee-4eca-9694-a0cea8cdbac2  Isbn=null  Notes=null  PageCount=0  Price=62.0000  PublicationDate=0001/1/1  Summary=null  Title=LINQ rules
    SubjectId=00000000-0000-0000-0000-000000000000  PublisherId=00000000-0000-0000-0000-000000000000
BookId=09017e35-ca66-40b8-80a4-ba5253716e33  Isbn=null  Notes=null  PageCount=0  Price=71.0000  PublicationDate=0001/1/1  Summary=null  Title=Bonjour mon Amour
    SubjectId=00000000-0000-0000-0000-000000000000  PublisherId=00000000-0000-0000-0000-000000000000
*/