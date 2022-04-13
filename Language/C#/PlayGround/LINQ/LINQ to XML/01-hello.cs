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
            XmlDocument doc = new XmlDocument();
            XmlElement books = doc.CreateElement("books");
            XmlElement author1 = doc.CreateElement("author");
            author1.InnerText = "Fabrice Marguerie";
            XmlElement author2 = doc.CreateElement("author");
            author2.InnerText = "Steve Eichert";
            XmlElement author3 = doc.CreateElement("author");
            author3.InnerText = "Jim Wooley";
            XmlElement title = doc.CreateElement("title");
            title.InnerText = "LINQ in Action";
            XmlElement book = doc.CreateElement("book");
            book.AppendChild(author1);
            book.AppendChild(author2);
            book.AppendChild(author3);
            book.AppendChild(title);
            books.AppendChild(book);
            doc.AppendChild(books);

            // Console.WriteLine(doc.InnerXml);
            Console.WriteLine(XDocument.Parse(doc.InnerXml));  // 转成XDocument是为了xml格式化，打印出来方便阅读

            Console.ReadKey();
        }
    }
}

/*
使用DOM生成XML文档

<books>
    <book>
        <author>Fabrice Marguerie</author>
        <author>Steve Eichert</author>
        <author>Jim Wooley</author>
        <title>LINQ in Action</title>
    </book>
</books>
*/