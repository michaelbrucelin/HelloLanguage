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
            var query = from book in SampleData.Books
                        group book.Title by book.Publisher into publisherBooks
                        select new
                        {
                            Publisher = publisherBooks.Key.Name,
                            Books = publisherBooks,
                            Count = publisherBooks.Count()
                        };


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