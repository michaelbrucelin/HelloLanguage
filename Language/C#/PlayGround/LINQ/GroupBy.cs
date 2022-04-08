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
            var query = SampleData.Books
                .GroupBy(i => i.Publisher, j => j.Title)
                .Select(i => new
                {
                    Publisher = i.Key.Name,
                    Books = i,
                    Count = i.Count()
                });

            // 与上面的代码等价
            // var query = SampleData.Books
            //                 .GroupBy(i => i.Publisher)
            //                 .Select(i => new
            //                 {
            //                     Publisher = i.Key.Name,
            //                     Books = i.Select(j => j.Title),
            //                     Count = i.Count()
            //                 });

            ObjectDumper.Write(query, 1);
        }
    }
}

/*
分组查询

Publisher=FunBooks          Books=...    Count=2
    Books: Funny Stories
    Books: Bonjour mon Amour
Publisher=Joe Publishing    Books=...    Count=3
    Books: LINQ rules
    Books: C# on Rails
    Books: All your base are belong to us
*/