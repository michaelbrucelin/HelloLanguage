using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;
using AmazonCommon;
using NUnit.Framework;

namespace LinqInAction.Chapter09and10
{
    [TestFixture]
    public class Chapter10
    {
        private string url;
        private XNamespace ns = Amazon.AmazonNS;

        public Chapter10()
        {
            var parameters = new Dictionary<String, String>() {
                { "Service", Amazon.ServiceName},
                { "Version", Amazon.ServiceVersion },
                { "Operation", "TagLookup" },
                { "TagName", "dotnet" },
                { "Count", "20" },
                { "ResponseGroup", "Tags,Small" }
            };
            var signHelper = new SignedRequestHelper(Amazon.AccessKey, Amazon.SecretKey, "ecs.amazonaws.com");
            url = signHelper.Sign(parameters);
        }

        [Test]
        public void Attributes()
        {

            XElement book = XElement.Parse("<book publicationDate=\"4/14/1978\" title=\"Beauty\"/>");
            IEnumerable<XAttribute> allAttributes = book.Attributes();
            foreach (XAttribute attribute in allAttributes)
            {
                Console.WriteLine(attribute);
            }

            IEnumerable<XAttribute> allPubDateAttributes = book.Attributes("publicationDate");
            foreach (XAttribute pubDateAttribute in allPubDateAttributes)
            {
                Console.WriteLine((DateTime)pubDateAttribute);
            }
        }

        [Test]
        public void Descendants()
        {
            XElement books = XElement.Load("categorizedBooks.xml");
            foreach (XElement bookElement in books.Descendants("book"))
            {
                Debug.WriteLine((string)bookElement);
            }
        }

        [Test]
        public void DescendantsVsSelfAndDescendants()
        {
            XElement root = XElement.Load("categorizedBooks.xml");
            IEnumerable<XElement> categories = root.Descendants("category");

            Debug.WriteLine("Descendants");
            foreach (XElement categoryElement in categories)
            {
                Debug.WriteLine(" - " + (string)categoryElement.Attribute("name"));
            }

            categories = root.DescendantsAndSelf("category");
            Debug.WriteLine("DescendantsAndSelf");
            foreach (XElement categoryElement in categories)
            {
                Debug.WriteLine(" - " + (string)categoryElement.Attribute("name"));
            }
        }

        [Test]
        public void DescendantsWithQueryExpressions()
        {
            XElement root = XElement.Load("categorizedBooks.xml");
            var books = from book in root.Descendants("book")
                        select (string)book;

            foreach (string book in books)
            {
                Console.WriteLine(book);
            }
        }

        [Test]
        public void Ancestors()
        {
            XElement root = XElement.Load("categorizedBooks.xml");
            XElement dddBook = root.Descendants("book")
                                   .Where(book => (string)book == "Domain Driven Design")
                                   .First();

            // reverse the order since we want the topmost category first
            IEnumerable<XElement> ancestors = dddBook.Ancestors("category").Reverse();

            // join each category with a /
            string categoryPath = String.Join("/", ancestors.Reverse().Select(e => (string)e.Attribute("name")).ToArray());

            Debug.WriteLine((string)dddBook + " is in the : " + categoryPath + " category.");

        }

        [Test]
        public void Element()
        {
            XElement root = XElement.Load("categorizedBooks.xml");
            XElement dotNetCategory = root.Element("category");
            Console.WriteLine(dotNetCategory);
        }

        [Test]
        public void ElementsBeforeSelf()
        {
            XElement root = XElement.Load("categorizedBooks.xml");
            XElement dddBook = root.Descendants("book")
                                    .Where(book => (string)book == "Domain Driven Design")
                                    .First();

            IEnumerable<XElement> beforeSelf = dddBook.ElementsBeforeSelf();
            foreach (XElement element in beforeSelf)
            {
                Console.WriteLine((string)element);
            }

        }

        [Test]
        public void XPath()
        {
            XElement root = XElement.Load("categorizedBooks.xml");
            XElement dotNetCategory = root.XPathSelectElements("//category[@name='.NET']").First();
            Console.WriteLine(dotNetCategory);
        }

        [Test]
        public void XPathSelectElements()
        {
            XElement root = XElement.Load("categorizedBooks.xml");
            var books = from book in root.XPathSelectElements("//book")
                        select book;

            foreach (XElement book in books)
            {
                Console.WriteLine((string)book);
            }
        }

        [Test]
        public void SelectOperator()
        {
            XElement tags = XElement.Load(url);
            var titles = tags.Descendants(ns + "Title").Select(titleElement => (string)titleElement);
            foreach (string title in titles)
            {
                Console.WriteLine(title);
            }
        }

        [Test]
        public void SelectQueryExpression()
        {
            XElement tags = XElement.Load(url);
            var titles = from title in tags.Descendants(ns + "Title")
                         select (string)title;

            foreach (string title in titles)
            {
                Console.WriteLine(title);
            }
        }

        [Test]
        public void Where()
        {
            XElement tags = XElement.Load(url);

            var wpfBooks = from book in tags.Descendants(ns + "Item")
                           let bookAttributes = book.Element(ns + "ItemAttributes")
                           let title = ((string)bookAttributes.Element(ns + "Title"))
                           where title.Contains("Windows Presentation Foundation")
                           select title;

            foreach (string title in wpfBooks)
            {
                Console.WriteLine(title);
            }

        }

        [Test]
        public void OrderBy()
        {
            XElement tags = XElement.Load(url);
            var titles = from book in tags.Descendants(ns + "Item")
                         let bookAttributes = book.Element(ns + "ItemAttributes")
                         let title = (string)bookAttributes.Element(ns + "Title")
                         orderby title
                         select title;

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }


        [Test]
        public void GroupBy()
        {
            XElement tags = XElement.Load(url);
            var groups = from book in tags.Descendants(ns + "Item")
                         let bookAttributes = book.Element(ns + "ItemAttributes")
                         let title = (string)bookAttributes.Element(ns + "Title")
                         let publisher = (string)bookAttributes.Element(ns + "Manufacturer")
                         orderby publisher, title
                         group title by publisher;

            foreach (var group in groups)
            {
                Console.WriteLine(group.Count() + " book(s) published by " + group.Key);
                foreach (var title in group)
                {
                    Console.WriteLine(" - " + title);
                }
            }
        }

        [Test]
        public void Transformation()
        {
            XElement xml =
                new XElement("html",
                    new XElement("body",
                            new XElement("h1", "LINQ Books Library"),
                            new XElement("div",
                                    new XElement("b", "LINQ in Action"),
                                    "\n" +
                                    "      By: Fabrice Marguerie, Steve Eichert\n" +
                                    "      Published By: Manning\n" +
                                    "    "
                            ),
                            new XElement("div",
                                    new XElement("b", "AJAX in Action"),
                                    "\n" +
                                    "      By: Dave Crane\n" +
                                    "      Published By: Manning\n" +
                                    "    "
                            ),
                            new XElement("div",
                                    new XElement("b", "Patterns of Enterprise Application Architecture"),
                                    "\n" +
                                    "      By: Martin Fowler\n" +
                                    "      Published By: APress\n" +
                                    "    "
                            )
                    )
            );

            XElement booksXml = XElement.Load("books.xml");
            var books = from book in booksXml.Descendants("book")
                        select new
                        {
                            Title = (string)book.Element("title"),
                            Publisher = (string)book.Element("publisher"),
                            Authors = String.Join(", ", book.Descendants("author").Select(b => (string)b).ToArray())
                        };

            foreach (var book in books)
            {
                Debug.WriteLine(book.Title);
                Debug.WriteLine(book.Publisher);
                Debug.WriteLine(book.Authors);
            }

            XElement html =
                new XElement("html",
                    new XElement("body",
                            new XElement("h1", "LINQ Books Library"),
                            from book in booksXml.Descendants("book")
                            select new XElement("div",
                                new XElement("b", (string)book.Element("title")),
                                "\n" +
                                "      By: " + String.Join(", ", book.Descendants("author").Select(b => (string)b).ToArray()) + "\n" +
                                "      Published By: " + (string)book.Element("publisher") + "\n" +
                                "    "
                            )
                    )
            );

            Debug.WriteLine(html);
        }

        [Test]
        public void TransformationWithXSLT()
        {
            string xsl = @"<?xml version='1.0' encoding='UTF-8' ?>
<xsl:stylesheet version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>
    <xsl:template match='books'>
        <html>
            <title>Book Catalog</title>
            <ul>
                <xsl:apply-templates select='book'/>
            </ul>
        </html>
    </xsl:template>
    <xsl:template match='book'>
        <li>
            <xsl:value-of select='title'/> by <xsl:apply-templates select='author'/>
        </li>
    </xsl:template>
    <xsl:template match='author'>
        <xsl:if test='position() > 1'>, </xsl:if>
        <xsl:value-of select='.'/>
    </xsl:template>
</xsl:stylesheet>";

            XElement books = XElement.Load("books.xml");
            XDocument output = new XDocument();
            using (XmlWriter writer = output.CreateWriter())
            {
                XslCompiledTransform xslTransformer = new XslCompiledTransform();
                xslTransformer.Load(XmlReader.Create(new StringReader(xsl)));
                xslTransformer.Transform(books.CreateReader(), writer);
            }
            //   Console.WriteLine(output);

            Console.WriteLine(XElement.Load("books.xml").XslTransform(xsl));
        }


    }
    public static class XmlExtensions
    {
        public static XDocument XslTransform(this XNode node, string xsl)
        {
            XDocument output = new XDocument();
            using (XmlWriter writer = output.CreateWriter())
            {
                XslCompiledTransform xslTransformer = new XslCompiledTransform();
                xslTransformer.Load(XmlReader.Create(new StringReader(xsl)));
                xslTransformer.Transform(node.CreateReader(), writer);
            }
            return output;
        }
    }
}