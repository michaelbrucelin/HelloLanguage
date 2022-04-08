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
                            .Join(SampleData.Books, left => left, right => right.Publisher, (left, right) => new
                            {
                                Publisher = left.Name,
                                Book = right.Title
                            });

            ObjectDumper.Write(query, 1);
        }
    }
}

/*
内连接

Publisher=FunBooks          Book=Funny Stories
Publisher=FunBooks          Book=Bonjour mon Amour
Publisher=Joe Publishing    Book=LINQ rules
Publisher=Joe Publishing    Book=C# on Rails
Publisher=Joe Publishing    Book=All your base are belong to us
*/