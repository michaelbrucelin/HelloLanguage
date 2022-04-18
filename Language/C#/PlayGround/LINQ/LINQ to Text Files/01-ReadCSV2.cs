using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@".\books.csv"))
            {
                var books = from line in reader.Lines()
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
            }

            Console.ReadKey();
        }
    }

    public static class MyLinqExtensions
    {
        public static IEnumerable<string> Lines(this StreamReader source)
        {
            string line;

            if (source == null)
                throw new ArgumentNullException("source");

            while ((line = source.ReadLine()) != null)
                yield return line;
        }
    }
}

/*
这里使用了自己编写的扩展方法，对大文件有较好的支持，并且支持了LINQ的延迟查询的特性。

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