using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Xml.Linq;
using System.Diagnostics;
using System.Xml;

namespace LinqInAction.Chapter09and10
{
  [TestFixture]
  public class Chapter09
  {
    string bookXml = @"<books>
												<book>
													<title>LINQ in Action</title>
													<author>Steve Eichert</author>
												</book>
											</books>";

    [Test]
    public void CreatingXmlWithDOM()
    {
      XmlDocument doc = new XmlDocument();
      XmlElement books = doc.CreateElement("books");
      XmlElement author1 = doc.CreateElement("author");
      author1.InnerText = "Fabrice Marguerie";
      XmlElement author2 = doc.CreateElement("author");
      author2.InnerText = "Steve Eichert";
      XmlElement author3 = doc.CreateElement("author");
      author3.InnerText = "Jim Wooley";
      XmlElement title = doc.CreateElement("title");
      title.InnerText = "LINQ in Action";
      XmlElement book = doc.CreateElement("book");
      book.AppendChild(author1);
      book.AppendChild(author2);
      book.AppendChild(author3);
      book.AppendChild(title);
      books.AppendChild(book);
      doc.AppendChild(books);
    }

    [Test]
    public void CreatingXmlWithLinqToXml()
    {
      Console.WriteLine(
        new XElement("books",
          new XElement("book",
            new XElement("author", "Fabrice Marguerie"),
            new XElement("author", "Steve Eichert"),
            new XElement("author", "Jim Wooley"),
            new XElement("title", "LINQ in Action"),
            new XElement("publisher", "Manning")
          )
        )
      );
    }

    [Test]
    public void NamespacesWithDOM()
    {
      XmlDocument doc = new XmlDocument();
      doc.Load("http://iqueryable.com/rss.aspx");

      XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
      ns.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
      ns.AddNamespace("slash", "http://purl.org/rss/1.0/modules/slash/");
      ns.AddNamespace("wfw", "http://wellformedweb.org/CommentAPI/");

      XmlNodeList commentNodes = doc.SelectNodes("//slash:comments", ns);
      foreach (XmlNode node in commentNodes)
      {
        Console.WriteLine(node.InnerText);
      }

      XmlNodeList titleNodes = doc.SelectNodes("/rss/channel/item/title");
      foreach (XmlNode node in titleNodes)
      {
        Console.WriteLine(node.InnerText);
      }
    }

    [Test]
    public void NamespacesWithLINQtoXml()
    {
      XElement rss = XElement.Load("http://iqueryable.com/rss.aspx");
      XNamespace dc = "http://purl.org/dc/elements/1.1/";
      XNamespace slash = "http://purl.org/rss/1.0/modules/slash/";
      XNamespace wfw = "http://wellformedweb.org/CommentAPI/";

      IEnumerable<XElement> comments = rss.Descendants(slash + "comments");
      foreach (XElement comment in comments)
      {
        Console.WriteLine((int)comment);
      }

      IEnumerable<XElement> titles = rss.Descendants("title");
      foreach (XElement title in titles)
      {
        Console.WriteLine((string)title);
      }

    }

    [Test]
    public void Load()
    {
      XElement x = XElement.Load("books.xml");
      XElement x2 = XElement.Load("http://msdn.microsoft.com/rss.xml", LoadOptions.PreserveWhitespace);
    }

    [Test]
    public void LoadFromXmlReader()
    {
      using (XmlReader reader = XmlReader.Create("books.xml"))
      {
        while (reader.Read())
        {
          if (reader.NodeType == XmlNodeType.Element)
            break;
        }
        XElement booksXml = XElement.Load(reader);
        Console.WriteLine(booksXml);
      }
    }

    [Test]
    public void LoadFromXmlReader_SpecificElement()
    {
      using (XmlReader reader = XmlTextReader.Create("books.xml"))
      {
        while (reader.Read())
        {
          if (reader.NodeType == XmlNodeType.Element && reader.Name == "book")
            break;
        }
        XElement bookXml = (XElement)XNode.ReadFrom(reader);
        Console.WriteLine(bookXml);
      }
    }

    [Test]
    public void LoadIntoXDocument()
    {
      XDocument msdnDoc = XDocument.Load("http://msdn.microsoft.com/rss.xml");
    }

    [Test]
    public void Parse()
    {
      XElement x = XElement.Parse(@"<books>
																	 <book>
																		 <author>Don Box</author>
																		 <title>Essential .NET</title>
																	 </book>
																	 <book>
																		 <author>Martin Fowler</author>
																		 <title>Patterns of Enterprise Application Architecture</title>
																	 </book>
																</books>");

      Console.WriteLine(x);
    }

    [Test]
    public void ParseWithLoadOptions()
    {
      XElement x = XElement.Parse("<books/>", LoadOptions.PreserveWhitespace);
    }

    [Test]
    public void ParseBadXml()
    {
      try
      {
        XElement xml = XElement.Parse("<bad xml>");
      }
      catch (System.Xml.XmlException)
      {
        // log the exception
      }
    }

    [Test]
    public void CreateWithFunctionalConstruction()
    {
      XElement books = new XElement("books",
                        new XElement("book",
                          new XElement("author", "Don Box"),
                          new XElement("title", "Essential .NET")
                        )
                      );

      Console.WriteLine(books);
    }

    [Test]
    public void CreateWithImperative()
    {
      XElement book = new XElement("book");
      book.Add(new XElement("author", "Don Box"));
      book.Add(new XElement("title", "Essential .NET"));

      XElement books = new XElement("books");
      books.Add(book);

      Console.WriteLine(books);
    }

    [Test]
    public void CreateXElement()
    {
      XElement book = new XElement("book");
      Console.WriteLine(book);

      XElement name = new XElement("name", "Steve Eichert");
      Console.WriteLine(name);
    }

    [Test]
    public void CreateFromVariable()
    {
      string usersName = "Fred";
      XElement name = new XElement("name", usersName);
      Console.WriteLine(name);
    }

    [Test]
    public void CreateFromMethod()
    {
      XElement name = new XElement("name", GetUsersName());
      Console.WriteLine(name);
    }

    private string GetUsersName() { return "George"; }

    [Test]
    public void CreateWithChildNodes()
    {
      XElement books = new XElement("books",
                          new XElement("book", "LINQ in Action"),
                          new XElement("book", "Ajax in Action")
                        );

      Console.WriteLine(books);
    }

    [Test]
    public void CreateXmlTree()
    {
      XElement books = new XElement("books",
                        new XElement("book",
                          new XElement("title", "LINQ in Action"),
                          new XElement("authors",
                            new XElement("author", "Fabrice Marguerie"),
                            new XElement("author", "Steve Eichert"),
                            new XElement("author", "Jim Wooley")
                          ),
                          new XElement("publicationDate", "June 2007")
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
    }

    [Test]
    public void CreateWithFullExpandedName()
    {
      // create with full expanded XML Name
      XElement book = new XElement("{http://linqinaction.net}book");

      Console.WriteLine(book);
    }

    [Test]
    public void CreateWithXNamespaceAndLocalName()
    {
      // create with XNamespace and local name
      XNamespace ns = "http://linqinaction.net";
      XElement book = new XElement(ns + "book");

      Console.WriteLine(book);
    }

    [Test]
    public void UsingXNamespace()
    {
      XNamespace ns = "http://linqinaction.net";
      XElement book = new XElement(ns + "book",
        new XElement(ns + "title", "LINQ in Action"),
        new XElement(ns + "author", "Fabrice Marguerie"),
        new XElement(ns + "author", "Steve Eichert"),
        new XElement(ns + "author", "Jim Wooley"),
        new XElement(ns + "publisher", "Manning")
      );

      Console.WriteLine(book);
    }

    [Test]
    public void NamespacePrefix()
    {
      XNamespace ns = "http://linqinaction.net";
      XElement book = new XElement(ns + "book",
        new XAttribute(XNamespace.Xmlns + "l", ns)
      );

      Console.WriteLine(book);
    }

    [Test]
    public void CreateWithAttribute()
    {
      XElement book = new XElement("book",
        new XAttribute("publicationDate", "October 2005"),
        new XElement("title", "Ajax in Action")
      );

      Console.WriteLine(book);
    }

    // see VB XmlLiterals examples

    [Test]
    public void CreateDocument()
    {
      XDocument doc = new XDocument(
                      new XDeclaration("1.0", "utf-8", "yes"),
                      new XProcessingInstruction("XML-stylesheet", "friendly-rss.xsl"),
                      new XElement("rss",
                        new XElement("channel", "my channel")
                      )
                    );

      Console.WriteLine(doc);

    }

    [Test]
    public void DocumentWithXProcessingInstruction()
    {
      XDocument d = new XDocument(
                      new XProcessingInstruction("XML-stylesheet", "href='http://iqueryable.com/friendly-rss.xsl' type='text/xsl' media='screen'"),
                      new XElement("rss", new XAttribute("version", "2.0"),
                        new XElement("channel",
                          new XElement("item", "my item")
                        )
                      )
                    );

      Console.WriteLine(d);
    }

    [Test]
    public void DocumentWithXDocumentType()
    {
      XDocument html = new XDocument(
                        new XDocumentType("HTML", "-//W3C//DTD HTML 4.01//EN",
                                          "http://www.w3.org/TR/html4/strict.dtd", null),
                        new XElement("html",
                          new XElement("body", "This is the body!")
                        )
                      );

      Console.WriteLine(html);
    }

    #region Adding Content to XML
    [Test]
    public void AddContent()
    {
      XElement book = new XElement("book");
      book.Add(new XElement("author", "Dr. Seuss"));
      Console.WriteLine(book);
    }

    [Test]
    public void AddAttribute()
    {
      XElement book = new XElement("book");
      book.Add(new XAttribute("publicationDate", "October 2005"));
      Console.WriteLine(book);
    }

    [Test]
    public void AddVariableNumberOfContentItems()
    {
      XElement books = new XElement("books");
      books.Add(new XElement("book",
                  new XAttribute("publicationDate", "May 2006"),
                  new XElement("author", "Chris Sells"),
                  new XElement("title", "Windows Forms Programming")
                )
      );

      Console.WriteLine(books);

    }

    [Test]
    public void AddFromExistingDocument()
    {
      XElement existingBooks = XElement.Load("existingBooks.xml");
      XElement books = new XElement("books");
      books.Add(existingBooks.Elements("book"));

      Console.WriteLine(books);

      XElement newBook = new XElement("book", "LINQ in Action");
      XElement firstBook = books.Element("book");
      firstBook.AddAfterSelf(newBook);

      Console.WriteLine(books);

    }
    #endregion

    #region Removing Content from XML
    [Test]
    public void RemoveFirstElement()
    {
      XElement books = XElement.Load("existingBooks.xml");
      books.Element("book").Remove();  // remove the first book
      Console.WriteLine(books);
    }

    [Test]
    public void RemoveAllElements()
    {
      XElement books = XElement.Load("existingBooks.xml");
      books.Elements("book").Remove(); // remove all books
      Console.WriteLine(books);
    }

    [Test]
    public void RemoveElementWithSetElementValue()
    {
      XElement books = XElement.Load("existingBooks.xml");
      books.SetElementValue("book", null);
      Console.WriteLine(books);
    }

    [Test]
    public void RemoveContent()
    {
      XElement books = XElement.Parse(@"<books>
																				<book>
																					<author>Foo Man Choo</author>
																				</book>
																			</books>");


      books.Element("book").Element("author").Value = String.Empty;
      Console.WriteLine(books);

    }
    #endregion

    #region Updating XML
    [Test]
    public void UpdatingAnElementWithSetElementValue()
    {
      XElement books = XElement.Parse(@"<books>
																					<book>
																						<title>LINQ in Action</title>
																						<author>Steve Eichert</author>
																					</book>
																				</books>");

      books.Element("book").SetElementValue("author", "Bill Gates");

      Console.WriteLine(books);
    }

    [Test, ExpectedException]
    public void SetElementValueWithXElement()
    {
      XElement books = XElement.Parse(@"<books>
																					<book>
																						<title>LINQ in Action</title>
																						<author>Steve Eichert</author>
																					</book>
																				</books>");

      books.Element("book").SetElementValue("author", new XElement("foo"));
    }

    [Test]
    public void ReplaceNodes()
    {
      XElement books = XElement.Parse(@"<books>
																					<book>
																						<title>LINQ in Action</title>
																						<author>Steve Eichert</author>
																					</book>
																				</books>");

      books.Element("book").Element("author").ReplaceNodes(new XElement("foo"));

      Console.WriteLine(books);
    }

    [Test]
    public void ReplaceNodesWithIEnumerableOfXElements()
    {
      XElement books = XElement.Parse(@"<books>
																					<book>
																						<title>LINQ in Action</title>
																						<author>Steve Eichert</author>
																					</book>
																				</books>");

      books.Element("book").ReplaceNodes(
        new XElement("title", "Ajax in Action"),
        new XElement("author", "Dave Crane")
      );

      Console.WriteLine(books);
    }

    [Test]
    public void ReplaceWith()
    {
      XElement books = XElement.Parse(@"<books>
																					<book>
																						<title>LINQ in Action</title>
																						<author>Steve Eichert</author>
																					</book>
																				</books>");


      var titles = books.Descendants("title").ToList();
      foreach (XElement title in titles)
      {
        title.ReplaceWith(new XElement("book_title", (string)title));
      }

      Console.WriteLine(books);
    }
    #endregion

    #region Attributes
    [Test]
    public void CreateElementWithAttribute()
    {
      XElement book = new XElement("book", new XAttribute("pubDate", "July 31, 2006"));
      Console.WriteLine(book);
    }

    [Test]
    public void ImperativeAddOfAttribute()
    {
      XElement book = new XElement("book");
      book.Add(new XAttribute("pubDate", "July 31, 2006"));
      Console.WriteLine(book);
    }

    [Test]
    public void SetAttributeValue()
    {
      XElement book = new XElement("book", new XAttribute("pubDate", "July 31, 2006"));
      book.SetAttributeValue("pubDate", "October 1, 2006");

      Console.WriteLine(book);
    }

    [Test]
    public void RemoveAttribute()
    {
      XElement book = new XElement("book", new XAttribute("pubDate", "July 31, 2006"));
      book.Attribute("pubDate").Remove();

      Console.WriteLine(book);
    }
    #endregion

    [Test]
    public void Save()
    {
      XElement books = new XElement("books",
        new XElement("book",
          new XElement("title", "LINQ in Action"),
          new XElement("author", "Fabrice Marguerie"),
          new XElement("author", "Steve Eichert"),
          new XElement("author", "Jim Wooley")
        )
      );
      books.Save(@"books.XML", SaveOptions.DisableFormatting);
    }

    [Test]
    public void SetElementValue()
    {
      XElement books = XElement.Parse(bookXml);
      books.Element("book").SetElementValue("author", "Bill Gates");
      Console.WriteLine(books);
    }
  }
}