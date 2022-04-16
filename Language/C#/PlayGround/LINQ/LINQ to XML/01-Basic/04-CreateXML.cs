using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 函数式创建生成XElement
            XElement books1 = new XElement("books",
                new XElement("book",
                    new XElement("author", "Don Box"),
                    new XElement("title", "Essential .NET")
                )
            );
            Console.WriteLine("books1:");
            Console.WriteLine(books1);

            // 使用LINQ to XML提供的命令式代码结构来创建XML
            XElement book2 = new XElement("book");
            book2.Add(new XElement("author", "Don Box"));
            book2.Add(new XElement("title", "Essential .NET"));
            XElement books2 = new XElement("books");
            books2.Add(book2);
            Console.WriteLine("books2:");
            Console.WriteLine(books2);

            Console.ReadKey();
        }
    }
}

/*
创建XML

books1:
<books>
    <book>
        <author>Don Box</author>
        <title>Essential .NET</title>
    </book>
</books>

books2:
<books>
    <book>
        <author>Don Box</author>
        <title>Essential .NET</title>
    </book>
</books>
*/