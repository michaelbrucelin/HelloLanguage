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
            var query = from publisher in SampleData.Publishers
                        join book in SampleData.Books
                            on publisher equals book.Publisher into publisherBooks
                        orderby publisher.Name
                        select new
                        {
                            Publisher = publisher.Name,
                            Books = from book_in in publisherBooks select book_in.Title,
                            Count = publisherBooks.Count()
                        };

            ObjectDumper.Write(query, 1);
        }
    }
}

/*
组连接
与内连接的唯一区别在于额外使用了into子句
使用了into之后的join就是组连接，与group by类似，按左表的元素进行分组，然后把右表的元素放到分组的元素的集合中
相当于group RightTableElement by LeftTableElement

Publisher=FunBooks          Books=...    Count=2
    Books: Funny Stories
    Books: Bonjour mon Amour
Publisher=I Publisher       Books=...    Count=0
Publisher=Joe Publishing    Books=...    Count=3
    Books: LINQ rules
    Books: C# on Rails
    Books: All your base are belong to us
*/