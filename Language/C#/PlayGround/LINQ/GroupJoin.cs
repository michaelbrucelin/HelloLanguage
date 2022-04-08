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
                            .GroupJoin(SampleData.Books, o => o, i => i.Publisher, (o, i) => new
                            {
                                Publisher = o.Name,
                                Books = i.Select(j => j.Title),
                                Count = i.Count()
                            });

            ObjectDumper.Write(query, 1);
        }
    }
}

/*
组连接

Publisher=FunBooks          Books=...    Count=2
    Books: Funny Stories
    Books: Bonjour mon Amour
Publisher=I Publisher       Books=...    Count=0
Publisher=Joe Publishing    Books=...    Count=3
    Books: LINQ rules
    Books: C# on Rails
    Books: All your base are belong to us
*/