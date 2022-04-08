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
                            on publisher equals book.Publisher
                        select new
                        {
                            Publisher = publisher.Name,
                            Book = book.Title
                        };

            ObjectDumper.Write(query, 1);
        }
    }
}

/*
内连接
与组连接的唯一区别在于没有使用into子句将元素分组，而是将右表中的每个元素投影到了左表中的每个元素上

Publisher=FunBooks          Book=Funny Stories
Publisher=FunBooks          Book=Bonjour mon Amour
Publisher=Joe Publishing    Book=LINQ rules
Publisher=Joe Publishing    Book=C# on Rails
Publisher=Joe Publishing    Book=All your base are belong to us
*/