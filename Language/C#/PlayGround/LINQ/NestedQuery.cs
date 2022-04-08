using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var query = SampleData.Publishers
                            .OrderBy(i => i.Name)
                            .Select(i => new
                            {
                                Publisher = i.Name,
                                Books = SampleData.Books
                                            .Where(j => j.Publisher.Name == i.Name)
                                            .Select(j => j.Title)
                            });

            ObjectDumper.Write(query, 1);
        }
    }
}

/*
嵌套查询
实现类似分组（group）的效果

Publisher=FunBooks          Books=...
    Books: Funny Stories
    Books: Bonjour mon Amour
Publisher=I Publisher       Books=...
Publisher=Joe Publishing    Books=...
    Books: LINQ rules
    Books: C# on Rails
    Books: All your base are belong to us
*/