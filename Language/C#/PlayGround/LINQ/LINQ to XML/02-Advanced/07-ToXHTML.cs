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
            XElement booksXml = XElement.Load(@"./books.xml");
            var books = from book in booksXml.Descendants("book")
                        select new
                        {
                            Title = (string)book.Element("title"),
                            Publisher = (string)book.Element("publisher"),
                            Authors = String.Join(", ", book.Descendants("author").Select(a => (string)a).ToArray()),
                            Rating = (int)book.Element("rating")
                        };

            XElement html = new XElement("html",
                new XElement("body",
                    new XElement("h1", "LINQ Books Library"),
                    from book in booksXml.Descendants("book")
                    select new XElement("div",
                                        new XElement("b", (string)book.Element("title")),
                                        " By: " + String.Join(", ", book.Descendants("author").Select(b => (string)b).ToArray()) +
                                        " Published By: " + (string)book.Element("publisher") +
                                        " Rating: " + (string)book.Element("rating")
                    )
                )
            );

            Console.WriteLine(html);

            Console.ReadKey();
        }
    }
}

/*
将XML转为XHTML

<html>
    <body>
        <h1>LINQ Books Library</h1>
        <div>
            <b>LINQ in Action</b> By: Fabrice Marguerie, Steve Eichert, Jim Wooley Published By: Manning Rating: 4
        </div>
        <div>
            <b>Ajax in Action</b> By: Dave Crane Published By: Manning Rating: 3
        </div>
        <div>
            <b>Enterprise Application Architecture</b> By: Martin Fowler Published By: APress Rating: 5
        </div>
    </body>
</html>
*/