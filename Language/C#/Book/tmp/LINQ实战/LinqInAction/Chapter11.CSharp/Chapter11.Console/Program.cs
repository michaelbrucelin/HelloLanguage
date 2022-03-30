using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Xml;
using System.Xml.Xsl;

namespace Chapter11 {
	class Program {
		static void Main(string[] args) {

			ReadFromXmlReader();

			CreateHtmlWithDTD();
			//      XElement x = XElement.Parse(@"<books>
			//  <book>
			//    <title>Linq in Action</title>
			//    <author>Steve Eichert</author>c v'f/',/.,/;.;'.;[pm ,m v//  </book>
			//</books>");

			//      x.Element("book").Element("author").ReplaceContent(new XElement("foo"));
			//      x.Element("book").SetElement("title", null);
			//      Console.WriteLine(x);

			//      var titles = x.Descendants("title").ToList();
			//      foreach(XElement title in titles) {
			//        title.ReplaceWith(new XElement("book_title", (string) title));
			//      }
			//      Console.WriteLine(x);


			XNamespace ns = "http://linqinaction.net";
			XElement book = new XElement(ns + "book",
				new XAttribute(XNamespace.Xmlns + "l", ns)
			);
			Console.WriteLine(book);
			//XElement books = XElement.Load("books.xml");
			//foreach(XElement e in books.Descendants("publisher").ToList()) {
			//  e.ReplaceWith(new XElement("foo", "bar"));	
			//}
			//Console.WriteLine(books.ToString());
			//Querying();
			//Console.WriteLine("------");
			//Constructing();
			//Console.WriteLine("------");
			//Transformation();
		}

		private static void CreateHtmlWithDTD() {
			XDocument doc = new XDocument(
				new XDocumentType("HTML", "-//W3C//DTD HTML 4.01//EN", 	"http://www.w3.org/TR/html4/strict.dtd", null),
				new XElement("html",
					new XElement("body", "This is the body!")	
				)
			);
			Console.WriteLine(doc);
		}

		private static void ReadFromXmlReader() {
			XmlReader reader = XmlReader.Create("books.xml");
			while(reader.Read()) {
				if(reader.NodeType == XmlNodeType.Element)
					break;
			}
            
			XElement booksXml = XElement.Load(reader);
			Console.WriteLine(booksXml);
		}

		private static void Transformation() {
			XElement books = XElement.Load("books.xml");
			XElement xml = new XElement("html",
					new XElement("title", "Book Catalog"),
					new XElement("body",
							new XElement("ul",
									from b in books.Elements("book")
									select new XElement("li", (string) b.Element("title") + " by " + 
										String.Join(", ", (from a in b.Elements("author") select (string) a).ToArray())
									)
							)
					)
			);
			xml.Save("books.html");


			var xsl = new XslCompiledTransform();
			xsl.Load("booksToXHTML.xslt");
			xsl.Transform("books.xml", "books-xslt.html");
		}

		private static void Constructing() {
      XmlDocument doc = new XmlDocument();
      XmlElement books = doc.CreateElement("books");
      XmlElement firstBook = doc.CreateElement("book");
      XmlElement title = doc.CreateElement("title");
      title.InnerText = "Linq in Action";

      XmlElement author1 = doc.CreateElement("author");
      author1.InnerText = "Fabrice Marguerie";

      XmlElement author2 = doc.CreateElement("author");
      author2.InnerText = "Steve Eichert";

      XmlElement publisher = doc.CreateElement("publisher");
      publisher.InnerText = "Manning";

      firstBook.AppendChild(title);
      firstBook.AppendChild(author1);
      firstBook.AppendChild(author2);
      firstBook.AppendChild(publisher);

      books.AppendChild(firstBook);
      doc.AppendChild(books);
      doc.Save("book-dom.xml");


      XElement xml = new XElement("books",
        new XElement("book",
            new XElement("title", "Linq in Action"),
            new XElement("author", "Fabrice Marguerie"),
            new XElement("author", "Steve Eichert"),
            new XElement("publisher", "Manning"),
						new XElement("rating", "5")
        ),
        new XElement("book",
            new XElement("title", "Ajax in Action"),
            new XElement("author", "Foo"),
            new XElement("publisher", "Manning"),
            new XElement("rating", "3")
        ),
        new XElement("book",
            new XElement("title", "Enterprise Application Architecture"),
            new XElement("author", "Martin Fowler"),
            new XElement("publisher", "APress"),
            new XElement("rating", "5")
        )
    );


    }

		private static void Querying() {
			XElement books = XElement.Load("books.xml");

			var manningBooks =
						from b in books.Elements("book")
						where (string) b.Element("publisher") == "Manning"
						orderby (string) b.Element("title")
						select b.Element("title");

			foreach (string title in manningBooks) {
				Console.WriteLine(title);
			}

			List<string> titles = new List<string>();
			XmlDocument doc = new XmlDocument();
			doc.Load("books.xml");
			XmlNodeList nodes = doc.SelectNodes("/books/book");
			foreach (XmlNode node in nodes) {
				if (node.SelectSingleNode("publisher").InnerText == "Manning") {
					titles.Add(node.SelectSingleNode("title").InnerText);
				}
				titles.Sort();
			}
			foreach (string title in titles) {
				Console.WriteLine(title);
			}
		}
	}
}
