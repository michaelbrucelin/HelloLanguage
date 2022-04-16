using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load(@"./categorizedBooks.xml");
            var books = from book in root.XPathSelectElements("//book")
                        select book;
            foreach (XElement book in books)
            {
                Console.WriteLine((string)book);
            }

            Console.ReadKey();
        }
    }
}

/*
在LINQ to XML中使用XPath

CLR via C#
Essential .NET
Refactoring
Domain Driven Design
Patterns of Enterprise Application Architecture
Extreme Programming Explained
Pragmatic Unit Testing with C#
Head First Design Patterns
*/