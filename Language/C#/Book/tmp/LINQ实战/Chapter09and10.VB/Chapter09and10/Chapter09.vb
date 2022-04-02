Imports System
Imports System.Linq
Imports System.Collections.Generic
Imports System.Text
Imports NUnit.Framework
Imports System.Xml.Linq
Imports System.Diagnostics
Imports System.Xml

<TestFixture()> Public Class Chapter09
  Dim bookXml As XElement = <books>
                              <book>
                                <title>LINQ in Action</title>
                                <author>Steve Eichert</author>
                              </book>
                            </books>

  <Test()> Sub CreatingXmlWithDOM()
    Dim doc As XmlDocument = New XmlDocument()
    Dim books As XmlElement = doc.CreateElement("books")
    Dim author1 As XmlElement = doc.CreateElement("author")
    author1.InnerText = "Fabrice Marguerie"
    Dim author2 As XmlElement = doc.CreateElement("author")
    author2.InnerText = "Steve Eichert"
    Dim author3 As XmlElement = doc.CreateElement("author")
    author3.InnerText = "Jim Wooley"
    Dim title As XmlElement = doc.CreateElement("title")
    title.InnerText = "LINQ in Action"
    Dim book As XmlElement = doc.CreateElement("book")
    book.AppendChild(author1)
    book.AppendChild(author2)
    book.AppendChild(author3)
    book.AppendChild(title)
    books.AppendChild(book)
    doc.AppendChild(books)
  End Sub


  <Test()> Sub CreatingXmlWithLinqToXml()
    Console.WriteLine(New XElement("books", _
     New XElement("book", _
     New XElement("author", "Fabrice Marguerie"), _
     New XElement("author", "Steve Eichert"), _
     New XElement("author", "Jim Wooley"), _
     New XElement("title", "LINQ in Action"), _
     New XElement("publisher", "Manning") _
     ) _
     ) _
    )
  End Sub


  <Test()> Sub NamespacesWithDOM()
    Dim doc As XmlDocument = New XmlDocument()
    doc.Load("http://iqueryable.com/rss.aspx")

    Dim ns As XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
    ns.AddNamespace("dc", "http://purl.org/dc/elements/1.1/")
    ns.AddNamespace("slash", "http://purl.org/rss/1.0/modules/slash/")
    ns.AddNamespace("wfw", "http://wellformedweb.org/CommentAPI/")

    Dim commentNodes As XmlNodeList = doc.SelectNodes("//slash:comments", ns)

    For Each node As XmlNode In commentNodes
      Console.WriteLine(node.InnerText)
    Next

    Dim titleNodes As XmlNodeList = doc.SelectNodes("/rss/channel/item/title")
    For Each node As XmlNode In titleNodes
      Console.WriteLine(node.InnerText)
    Next
  End Sub

  <Test()> Sub NamespacesWithLINQtoXml()
    Dim rss As XElement = XElement.Load("http://iqueryable.com/rss.aspx")
    Dim dc As XNamespace = "http://purl.org/dc/elements/1.1/"
    Dim slash As XNamespace = "http://purl.org/rss/1.0/modules/slash/"
    Dim wfw As XNamespace = "http://wellformedweb.org/CommentAPI/"

    Dim comments As IEnumerable(Of XElement) = rss.Descendants(slash + "comments")
    For Each comment As XElement In comments
      Console.WriteLine(CType(comment, Int32))
    Next

    Dim titles As IEnumerable(Of XElement) = rss.Descendants("title")
    For Each title As XElement In titles
      Console.WriteLine(CType(title, String))
    Next
  End Sub

  <Test()> Sub Load()
    Dim x As XElement = XElement.Load("books.xml")
    Dim x2 As XElement = XElement.Load("http://msdn.microsoft.com/rss.xml", LoadOptions.PreserveWhitespace)
  End Sub

  <Test()> Sub LoadFromXmlReader()
    Using reader As XmlReader = XmlReader.Create("books.xml")
      While reader.Read
        If reader.NodeType = XmlNodeType.Element Then
          Exit While
        End If
      End While

      Dim booksXml As XElement = XElement.Load(reader)
      Console.WriteLine(booksXml)
    End Using
  End Sub

  <Test()> Sub LoadFromXmlReader_SpecificElement()
    Using reader As XmlReader = XmlTextReader.Create("books.xml")
      While reader.Read
        If reader.NodeType = XmlNodeType.Element And reader.Name = "book" Then
          Exit While
        End If
      End While
      Dim bookXml As XElement = CType(XNode.ReadFrom(reader), XElement)
      Console.WriteLine(bookXml)
    End Using
  End Sub

  <Test()> Sub LoadIntoXDocument()
    Dim msdnDoc As XDocument = XDocument.Load("http://msdn.microsoft.com/rss.xml")
  End Sub

  <Test()> Sub Parse()
    Dim x As XElement = XElement.Parse("<books>" & _
     "<book>" & _
      "<author>Don Box</author>" & _
      "<title>Essential .NET</title>" & _
     "</book>" & _
     "<book>" & _
      "<author>Martin Fowler</author>" & _
      "<title>Patterns of Enterprise Applicatoin Architecture</title>" & _
     "</book>" & _
     "</books>")

    Console.WriteLine(x)
  End Sub

  <Test()> Sub ParseWithLoadOptions()
    Dim X As XElement = XElement.Parse("<books/>", LoadOptions.PreserveWhitespace)
  End Sub

  <Test()> Sub ParseBadXml()
    Try
      Dim xml As XElement = XElement.Parse("<bad xml>")
    Catch e As System.Xml.XmlException
      ' log the exception
    End Try
  End Sub

  <Test()> Sub CreateWithFunctionalConstruction()
    Dim books As XElement = New XElement("books", _
     New XElement("book", _
     New XElement("author", "Don Box"), _
     New XElement("title", "Essential .NET") _
     ) _
     )

    Console.WriteLine(books)
  End Sub

  <Test()> Sub CreateWithImperative()
    Dim book As XElement = New XElement("book")
    book.Add(New XElement("author", "Don Box"))
    book.Add(New XElement("title", "Essential .NET"))

    Dim books As XElement = New XElement("books")
    books.Add(book)

    Console.WriteLine(books)
  End Sub

  <Test()> Sub CreateXElement()
    Dim book As XElement = New XElement("book")
    Console.WriteLine(book)

    Dim name As XElement = New XElement("name", "Steve Eichert")
    Console.WriteLine(name)
  End Sub

  <Test()> Sub CreateFromVariable()
    Dim usersName As String = "Fred"
    Dim name As XElement = New XElement("name", usersName)
    Console.WriteLine(name)
  End Sub

  <Test()> Sub CreateFromMethod()
    Dim name As XElement = New XElement("name", GetUsersName())
    Console.WriteLine(name)
  End Sub

  Function GetUsersName() As String
    Return "George"
  End Function

  <Test()> Sub CreateWithChildNodes()
    Dim books As XElement = New XElement("books", _
     New XElement("book", "LINQ in Action"), _
     New XElement("book", "Ajax in Action") _
     )

    Console.WriteLine(books)
  End Sub

  <Test()> Sub CreateXmlTree()
    Dim books As XElement = New XElement("books", _
     New XElement("book", _
     New XElement("title", "LINQ in Action"), _
     New XElement("authors", _
     New XElement("author", "Fabrice Marguerie"), _
     New XElement("author", "Steve Eichert"), _
     New XElement("author", "Jim Wooley") _
     ), _
     New XElement("publicationDate", "June 2007") _
     ), _
     New XElement("book", _
     New XElement("title", "Ajax in Action"), _
     New XElement("authors", _
     New XElement("author", "Dave Crane"), _
     New XElement("author", "Eric Pascarello"), _
     New XElement("author", "Darren James") _
     ), _
     New XElement("publicationDate", "October 2005") _
     ) _
     )

    Console.WriteLine(books)
  End Sub

  <Test()> Sub CreateWithFullExpandedName()
    ' create with full expanded XML Name
    Dim book As XElement = New XElement("{http://linqinaction.net}book")

    Console.WriteLine(book)
  End Sub

  <Test()> Sub CreateWithXNamespaceAndLocalName()
    ' create with XNamespace and local name
    Dim ns As XNamespace = "http://linqinaction.net"
    Dim book As XElement = New XElement(ns + "book")

    Console.WriteLine(book)
  End Sub

  <Test()> Sub UsingXNamespace()
    Dim ns As XNamespace = "http://linqinaction.net"
    Dim book As XElement = New XElement(ns + "book", _
     New XElement(ns + "title", "LINQ in Action"), _
     New XElement(ns + "author", "Fabrice Marguerie"), _
     New XElement(ns + "publisher", "Manning") _
    )

    Console.WriteLine(book)
  End Sub

  <Test()> Sub NamespacePrefix()
    Dim ns As XNamespace = "http://linqinaction.net"
    Dim book As XElement = New XElement(ns + "book", _
     New XAttribute(XNamespace.Xmlns + "l", ns) _
    )

    Console.WriteLine(book)
  End Sub

  <Test()> Sub CreateWithAttribute()
    Dim book As XElement = New XElement("book", _
     New XAttribute("publicationDate", "October 2005"), _
     New XElement("title", "Ajax in Action") _
    )

    Console.WriteLine(book)
  End Sub

  ' see Chapter10_VBOnly.vb for XmlLiterals examples

  <Test()> Sub CreateDocument()
    Dim doc As XDocument = New XDocument( _
     New XDeclaration("1.0", "utf-8", "yes"), _
     New XProcessingInstruction("XML-stylesheet", "friendly-rss.xsl"), _
     New XElement("rss", _
     New XElement("channel", "my channel") _
     ) _
     )

    Console.WriteLine(doc)

  End Sub

  <Test()> Sub DocumentWithXProcessingInstruction()
    Dim d As XDocument = New XDocument( _
     New XProcessingInstruction("XML-stylesheet", "href='http://iqueryable.com/friendly-rss.xsl' type='text/xsl' media='screen'"), _
     New XElement("rss", New XAttribute("version", "2.0"), _
     New XElement("channel", _
     New XElement("item", "my item") _
     ) _
     ) _
     )

    Console.WriteLine(d)
  End Sub

  <Test()> Sub DocumentWithXDocumentType()
    Dim html As XDocument = New XDocument( _
     New XDocumentType("HTML", "-//W3C//DTD HTML 4.01//EN", _
      "http://www.w3.org/TR/html4/strict.dtd", Nothing), _
     New XElement("html", _
     New XElement("body", "This is the body!") _
     ) _
     )

    Console.WriteLine(html)
  End Sub


  <Test()> Sub AddContent()
    Dim book As XElement = New XElement("book")
    book.Add(New XElement("author", "Dr. Seuss"))
    Console.WriteLine(book)
  End Sub

  <Test()> Sub AddAttribute()
    Dim book As XElement = New XElement("book")
    book.Add(New XAttribute("publicationDate", "October 2005"))
    Console.WriteLine(book)
  End Sub

  <Test()> Sub AddVariableNumberOfContentItems()
    Dim books As XElement = New XElement("books")
    books.Add(New XElement("book", _
     New XAttribute("publicationDate", "May 2006"), _
     New XElement("author", "Chris Sells"), _
     New XElement("title", "Windows Forms Programming") _
     ) _
    )

    Console.WriteLine(books)

  End Sub

  <Test()> Sub AddFromExistingDocument()
    Dim existingBooks As XElement = XElement.Load("existingBooks.xml")
    Dim books As XElement = New XElement("books")
    books.Add(existingBooks.Elements("book"))

    Console.WriteLine(books)

    Dim newBook As XElement = New XElement("book", "LINQ in Action")
    Dim firstBook As XElement = books.Element("book")
    firstBook.AddAfterSelf(newBook)

    Console.WriteLine(books)
  End Sub


  <Test()> Sub RemoveFirstElement()
    Dim books As XElement = XElement.Load("existingBooks.xml")
    books.Element("book").Remove()  'remove the first book
    Console.WriteLine(books)
  End Sub

  <Test()> Sub RemoveAllElements()
    Dim books As XElement = XElement.Load("existingBooks.xml")
    books.Elements("book").Remove() ' remove all books
    Console.WriteLine(books)
  End Sub

  <Test()> Sub RemoveElementWithSetElementValue()
    Dim books As XElement = XElement.Load("existingBooks.xml")
    books.SetElementValue("book", Nothing)
    Console.WriteLine(books)
  End Sub

  <Test()> Sub RemoveContent()
    Dim books As XElement = <books>
                              <book>
                                <author>Foo Man Choo</author>
                              </book>
                            </books>


    books.Element("book").Element("author").Value = String.Empty
    Console.WriteLine(books)

  End Sub



  <Test()> Sub UpdatingAnElementWithSetElementValue()
    Dim books As XElement = <books>
                              <book>
                                <title>LINQ in Action</title>
                                <author>Steve Eichert</author>
                              </book>
                            </books>

    books.Element("book").SetElementValue("author", "Bill Gates")

    Console.WriteLine(books)
  End Sub

  <Test(), ExpectedException()> Sub SetElementValueWithXElement()
    Dim books As XElement = <books>
                              <book>
                                <title>LINQ in Action</title>
                                <author>Steve Eichert</author>
                              </book>
                            </books>

    books.Element("book").SetElementValue("author", New XElement("foo"))
  End Sub

  <Test()> Sub ReplaceNodes()
    Dim books As XElement = <books>
                              <book>
                                <title>LINQ in Action</title>
                                <author>Steve Eichert</author>
                              </book>
                            </books>

    books.Element("book").Element("author").ReplaceNodes(New XElement("foo"))

    Console.WriteLine(books)
  End Sub

  <Test()> Sub ReplaceNodesWithIEnumerableOfXElements()
    Dim books As XElement = <books>
                              <book>
                                <title>LINQ in Action</title>
                                <author>Steve Eichert</author>
                              </book>
                            </books>

    books.Element("book").ReplaceNodes( _
     New XElement("title", "Ajax in Action"), _
     New XElement("author", "Dave Crane") _
    )

    Console.WriteLine(books)
  End Sub

  <Test()> Sub ReplaceWith()
    Dim books As XElement = <books>
                              <book>
                                <title>LINQ in Action</title>
                                <author>Steve Eichert</author>
                              </book>
                            </books>


    Dim titles = books.Descendants("title").ToList()
    For Each title As XElement In titles
      title.ReplaceWith(New XElement("book_title", CType(title, String)))
    Next

    Console.WriteLine(books)
  End Sub



  <Test()> Sub CreateElementWithAttribute()
    Dim book As XElement = New XElement("book", New XAttribute("pubDate", "July 31, 2006"))
    Console.WriteLine(book)
  End Sub

  <Test()> Sub ImperativeAddOfAttribute()
    Dim book As XElement = New XElement("book")
    book.Add(New XAttribute("pubDate", "July 31, 2006"))
    Console.WriteLine(book)
  End Sub

  <Test()> Sub SetAttributeValue()
    Dim book As XElement = New XElement("book", New XAttribute("pubDate", "July 31, 2006"))
    book.SetAttributeValue("pubDate", "October 1, 2006")

    Console.WriteLine(book)
  End Sub

  <Test()> Sub RemoveAttribute()
    Dim book As XElement = New XElement("book", New XAttribute("pubDate", "July 31, 2006"))
    book.Attribute("pubDate").Remove()

    Console.WriteLine(book)
  End Sub


  <Test()> Sub Save()
    Dim books As XElement = New XElement("books", _
     New XElement("book", _
     New XElement("title", "LINQ in Action"), _
     New XElement("author", "Steve Eichert") _
     ) _
    )
    books.Save("saved-books.XML", SaveOptions.DisableFormatting)
  End Sub

  <Test()> Sub SetElementValue()
    bookXml.Element("book").SetElementValue("author", "Bill Gates")
    Console.WriteLine(bookXml)
  End Sub
End Class