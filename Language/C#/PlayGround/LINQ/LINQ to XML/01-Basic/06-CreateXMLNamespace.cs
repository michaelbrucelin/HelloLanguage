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
            // 1. 通过完全展开的XName创建XElement
            XElement book1 = new XElement("{http://linqinaction.net}book");
            Console.WriteLine("books1:");
            Console.WriteLine(book1);

            // 2. 通过XNamespace和局部名称创建XElement
            XNamespace ns2 = "http://linqinaction.net";
            XElement book2 = new XElement(ns2 + "book");
            Console.WriteLine("books2:");
            Console.WriteLine(book2);

            // 3. 使用同一个XNamespace对象创建多个XElement
            XNamespace ns3 = "http://linqinaction.net";
            XElement book3 = new XElement(ns3 + "book",
                new XElement(ns3 + "title", "LINQ in Action"),
                new XElement(ns3 + "author", "Fabrice Marguerie"),
                new XElement(ns3 + "author", "Steve Eichert"),
                // new XElement(ns3 + "author", "Jim Wooley"),
                new XElement("author", "Jim Wooley"),
                new XElement(ns3 + "publisher", "Manning")
            );
            Console.WriteLine("books3:");
            Console.WriteLine(book3);

            // 4. 将前缀与命名空间关联起来
            XNamespace ns4 = "http://linqinaction.net";
            XElement book4 = new XElement(ns4 + "book",
                new XAttribute(XNamespace.Xmlns + "l", ns4)
            );
            Console.WriteLine("books4:");
            Console.WriteLine(book4);

            Console.ReadKey();
        }
    }
}

/*
创建XML的命名空间以及前缀

books1:
<book xmlns="http://linqinaction.net" />

books2:
<book xmlns="http://linqinaction.net" />

books3:
<book xmlns="http://linqinaction.net">
    <title>LINQ in Action</title>
    <author>Fabrice Marguerie</author>
    <author>Steve Eichert</author>
    <author xmlns="">Jim Wooley</author>
    <publisher>Manning</publisher>
</book>

books4:
<l:book xmlns:l="http://linqinaction.net" />
*/