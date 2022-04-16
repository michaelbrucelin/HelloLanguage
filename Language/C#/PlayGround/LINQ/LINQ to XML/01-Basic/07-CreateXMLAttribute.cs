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
            XElement book = new XElement("book",
                new XAttribute("publicationDate", "October 2005"),
                new XElement("title", "Ajax in Action")
            );
            Console.WriteLine(book);

            Console.ReadKey();
        }
    }
}

/*
创建XML的属性信息

<book publicationDate="October 2005">
    <title>Ajax in Action</title>
</book>
*/