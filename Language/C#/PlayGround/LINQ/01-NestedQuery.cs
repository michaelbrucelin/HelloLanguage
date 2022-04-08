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
                                            .Select(j => j.Title),
                                Count = SampleData.Books
                                            .Where(j => j.Publisher.Name == i.Name)
                                            .Count()
                            });

            ObjectDumper.Write(query, 1);
        }
    }
}

/*
嵌套查询
实现类似分组（group）的效果

Publisher=FunBooks          Books=...    Count=2
    Books: Funny Stories
    Books: Bonjour mon Amour
Publisher=I Publisher       Books=...    Count=0
Publisher=Joe Publishing    Books=...    Count=3
    Books: LINQ rules
    Books: C# on Rails
    Books: All your base are belong to us
*/