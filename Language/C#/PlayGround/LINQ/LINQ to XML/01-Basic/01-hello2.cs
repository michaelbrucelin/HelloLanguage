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
            var doc = new XElement("books",
                        new XElement("book",
                            new XElement("author", "Fabrice Marguerie"),
                            new XElement("author", "Steve Eichert"),
                            new XElement("author", "Jim Wooley"),
                            new XElement("title", "LINQ in Action"),
                            new XElement("publisher", "Manning")
                        )
                    );

            Console.WriteLine(doc);

            Console.ReadKey();
        }
    }
}

/*
使用LINQ to XML生成XML文档

<books>
    <book>
        <author>Fabrice Marguerie</author>
        <author>Steve Eichert</author>
        <author>Jim Wooley</author>
        <title>LINQ in Action</title>
        <publisher>Manning</publisher>
    </book>
</books>
*/