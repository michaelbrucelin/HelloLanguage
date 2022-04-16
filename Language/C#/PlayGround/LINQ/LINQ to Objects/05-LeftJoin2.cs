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
                        from book in publisherBooks.DefaultIfEmpty()
                        select new
                        {
                            Publisher = publisher.Name,
                            Book = book == default(Book) ? "(no books)" : book.Title
                        };

            ObjectDumper.Write(query, 1);
        }
    }
}

/*
左外连接
DefaultIfEmpty操作符能够为空序列提供一个默认的元素
DefaultIfEmpty使用到了泛型中的default关键词
    对于引用类型将返回null
    对于值类型则返回0
    对于结构体类型，则会根据其成员类型将它们相应地初始化为null（引用类型）或0（值类型）

Publisher=FunBooks          Book=Funny Stories
Publisher=FunBooks          Book=Bonjour mon Amour
Publisher=Joe Publishing    Book=LINQ rules
Publisher=Joe Publishing    Book=C# on Rails
Publisher=Joe Publishing    Book=All your base are belong to us
Publisher=I Publisher       Book=(no books)
*/