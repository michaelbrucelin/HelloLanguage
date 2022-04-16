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

            books.Element("book").Remove();       // 移除第一个book元素
            books.Elements("books").Remove();     // 移除全部book元素

            books.SetElementValue("book", null);  // 这样也可以删除元素

            books.Element("book").Element("author").Value = string.Empty;  // 这样可以删除元素的内容，但是元素的标签还在

            Console.ReadKey();
        }
    }
}

/*
从XML文档中移除内容
*/