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
            XElement books = new XElement("books",
                new XElement("book",
                    new XElement("title", "LINQ in Action"),
                    new XElement("author", "Steve Eichert"),
                    new XElement("author", "Jim Wooley"),
                    new XElement("author", "Fabrice Marguerie")
                )
            );
            books.Save(@"./books_new.XML");

            Console.ReadKey();
        }
    }
}

/*
保存XML
XElement与XDocument类均提供了Save方法，能够将XML保存到文件、XmlTestWriter或XmlWriter中。
*/