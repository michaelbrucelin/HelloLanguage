using System;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TempTestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Data Source=.;Initial Catalog=LIA;Integrated Security=true;";

            DataContext dataContext = new DataContext(connStr);
            dataContext.Log = Console.Out;

            Guid bookId = new Guid("0737c167-e3d9-4a46-9247-2d0101ab18d1");
            var query = dataContext.GetBook(bookId, Thread.CurrentPrincipal.Identity.Name);

            ObjectDumper.Write(query);

            Console.ReadKey();
        }
    }
}

/*
需要先创建存储过程与对象之间的关系，才可以使用，这里就不演示了，只将调用的示例放在这里，个人感觉还不如使用ADO.NET算了。
*/