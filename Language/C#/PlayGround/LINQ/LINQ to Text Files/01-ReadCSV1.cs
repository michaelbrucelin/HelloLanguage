using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = from line in File.ReadAllLines("./books.csv")
                        where !line.StartsWith("#")
                        let parts = line.Split(',')
                        select new
                        {
                            ISBN = parts[0],
                            Title = parts[1],
                            Publisher = parts[3],
                            Authors = from authorFullName in parts[2].Split(';')
                                      let authorNameParts = authorFullName.Split(' ')
                                      select new
                                      {
                                          FirstName = authorNameParts[0],
                                          LastName = authorNameParts[1]
                                      }
                        };

            ObjectDumper.Write(books, 1);

            Console.ReadKey();
        }
    }
}

/*
这里使用了File.ReadAllLines()方法一次性将全部数据加载到内存中，对大文件支持并不好，并且也失去了LINQ延迟查询的特性。

ISBN=0735621632         Title=CLR via C#        Publisher=Microsoft Press       Authors=...
    Authors: FirstName=Jeffrey      LastName=Richter
ISBN=0321127420         Title=Patterns Of Enterprise Application Architecture   Publisher=Addison-Wesley        Authors=...
    Authors: FirstName=Martin       LastName=Fowler
ISBN=0321200683         Title=Enterprise Integration Patterns   Publisher=Addison-Wesley        Authors=...
    Authors: FirstName=Gregor       LastName=Hohpe
ISBN=0321125215         Title=Domain-Driven Design      Publisher=Addison-Wesley Professional   Authors=...
    Authors: FirstName=Eric         LastName=Evans
ISBN=1932394613         Title=Ajax In Action    Publisher=Manning Publications  Authors=...
    Authors: FirstName=Dave         LastName=Crane
    Authors: FirstName=Eric         LastName=Pascarello
    Authors: FirstName=Darren       LastName=James
*/