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
            // 1. 使用Add方法为XElement添加内容
            XElement doc1 = new XElement("books");
            doc1.Add(new XElement("book",
                new XAttribute("publicationDate", "May 2006"),
                new XElement("author", "Chris Sells"),
                new XElement("title", "Windows Forms Programming")
                )
            );
            Console.WriteLine("doc1:");
            Console.WriteLine(doc1);

            // 2. 添加IEnumerable对象
            // 没有自动添加为4本书，而是只添加了1本书。。。
            var books = new List<string>() { "C# in Action", "Java in Action", "LINQ in Action", "Pandas in Action" };
            XElement doc2 = new XElement("books");
            doc2.Add(new XElement("book", books));
            Console.WriteLine("doc2:");
            Console.WriteLine(doc2);

            // 这样可以实现
            XElement doc3 = new XElement("books");
            doc3.Add(books.Select(i => new XElement("book", i)));
            Console.WriteLine("doc3:");
            Console.WriteLine(doc3);

            // 3. 将一个XML文档中的元素添加到另一个XML文档中
            XElement existingBooks = XElement.Load("./existingBooks.xml");
            XElement doc4 = new XElement("books");
            doc4.Add(existingBooks.Elements("book"));
            Console.WriteLine("doc4:");
            Console.WriteLine(doc4);

            Console.ReadKey();
        }
    }
}

/*
向XML中添加内容

doc1:
<books>
    <book publicationDate="May 2006">
        <author>Chris Sells</author>
        <title>Windows Forms Programming</title>
    </book>
</books>

doc2:
<books>
    <book>C# in ActionJava in ActionLINQ in ActionPandas in Action</book>
</books>

doc3:
<books>
    <book>C# in Action</book>
    <book>Java in Action</book>
    <book>LINQ in Action</book>
    <book>Pandas in Action</book>
</books>

doc4:
<books>
    <book>CLR via C#</book>
    <book>Essentail .NET</book>
    <book>Refactoring</book>
    <book>Domain Driven Design</book>
    <book>Patterns of Enterprise Application Architecture</book>
    <book>Extreme Programming Explained</book>
    <book>Pragmatic Unit Testing with C#</book>
    <book>Head First Design Patterns</book>
</books>
*/