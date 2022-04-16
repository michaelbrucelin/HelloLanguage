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
                    new XElement("authors",
                        new XElement("author", "Fabrice Marguerie"),
                        new XElement("author", "Steve Eichert"),
                        new XElement("author", "Jim Wooley")
                    ),
                    new XElement("publicationDate", "January 2008")
                ),
                new XElement("book",
                    new XElement("title", "Ajax in Action"),
                    new XElement("authors",
                        new XElement("author", "Dave Crane"),
                        new XElement("author", "Eric Pascarello"),
                        new XElement("author", "Darren James")
                    ),
                    new XElement("publicationDate", "October 2005")
                )
            );

            Console.WriteLine(books);

            Console.ReadKey();
        }
    }
}

/*
创建XML

<books>
    <book>
        <title>LINQ in Action</title>
        <authors>
            <author>Fabrice Marguerie</author>
            <author>Steve Eichert</author>
            <author>Jim Wooley</author>
        </authors>
        <publicationDate>January 2008</publicationDate>
    </book>
    <book>
        <title>Ajax in Action</title>
        <authors>
            <author>Dave Crane</author>
            <author>Eric Pascarello</author>
            <author>Darren James</author>
        </authors>
        <publicationDate>October 2005</publicationDate>
    </book>
</books>
*/