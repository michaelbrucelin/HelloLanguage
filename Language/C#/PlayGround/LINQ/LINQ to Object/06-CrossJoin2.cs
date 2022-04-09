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
                        from book in SampleData.Books
                        select new
                        {
                            Correct = publisher == book.Publisher ? "√" : "×",
                            Publisher = publisher.Name,
                            Book = book.Title
                        };

            ObjectDumper.Write(query, 1);
        }
    }
}

/*
交叉连接，即笛卡尔积

Correct=√    Publisher=FunBooks          Book=Funny Stories
Correct=×    Publisher=FunBooks          Book=LINQ rules
Correct=×    Publisher=FunBooks          Book=C# on Rails
Correct=×    Publisher=FunBooks          Book=All your base are belong to us
Correct=√    Publisher=FunBooks          Book=Bonjour mon Amour
Correct=×    Publisher=Joe Publishing    Book=Funny Stories
Correct=√    Publisher=Joe Publishing    Book=LINQ rules
Correct=√    Publisher=Joe Publishing    Book=C# on Rails
Correct=√    Publisher=Joe Publishing    Book=All your base are belong to us
Correct=×    Publisher=Joe Publishing    Book=Bonjour mon Amour
Correct=×    Publisher=I Publisher       Book=Funny Stories
Correct=×    Publisher=I Publisher       Book=LINQ rules
Correct=×    Publisher=I Publisher       Book=C# on Rails
Correct=×    Publisher=I Publisher       Book=All your base are belong to us
Correct=×    Publisher=I Publisher       Book=Bonjour mon Amour
*/