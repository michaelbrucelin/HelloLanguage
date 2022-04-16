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
            XElement books = new XElement("");

            // 1. SetElementValue()只支持简单内容，例如字符串
            books.Element("book").SetElementValue("author", "Bill Gates");

            // 2. ReplaceNodes()支持传入各种内容，并支持多个参数
            books.Element("book").Element("author").ReplaceNodes(new XElement("foo"));

            // 3. 将元素的子元素替换为新内容
            books.Element("book").ReplaceNodes(
                new XElement("title", "Ajax in Action"),
                new XElement("author", "Dave Crane")
            );

            // 4. 使用ReplaceWith()替换整个元素
            var titles = books.Descendants("title").ToList();
            foreach (XElement title in titles)
            {
                title.ReplaceWith(new XElement("book_title", (string)title));
            }

            Console.ReadKey();
        }
    }
}

/*
更新XML文档的内容
*/