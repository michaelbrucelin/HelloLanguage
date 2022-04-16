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
            XElement book = new XElement("");

            book.SetAttributeValue("pubDate", "October 1, 2006");

            book.SetAttributeValue("pubDate", null);
            book.Attribute("pubDate").Remove();

            Console.ReadKey();
        }
    }
}

/*
操作属性
*/