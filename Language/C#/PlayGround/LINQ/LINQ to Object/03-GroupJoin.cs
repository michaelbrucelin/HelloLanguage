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
与group by类似，按左表的元素进行分组，然后把右表的元素放到分组的元素的集合中
相当于group RightTableElement by LeftTableElement
与group by不同的是，group by操作的是一个序列，而group join操作的是两个序列

Publisher=FunBooks          Books=...    Count=2
    Books: Funny Stories
    Books: Bonjour mon Amour
Publisher=I Publisher       Books=...    Count=0
Publisher=Joe Publishing    Books=...    Count=3
    Books: LINQ rules
    Books: C# on Rails
    Books: All your base are belong to us
*/