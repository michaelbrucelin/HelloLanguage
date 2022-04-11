Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports NUnit.Framework
Imports System.Linq
Imports System.Xml.Linq
Imports System.Diagnostics
Imports System.Xml.XPath
Imports System.Xml
Imports System.Xml.Xsl
Imports System.IO
Imports System.Runtime.CompilerServices
Imports AmazonCommon

<TestFixture()> Public Class Chapter10

  Private url As String
  Private ns As XNamespace = Amazon.AmazonNS

  Public Sub New()
    Dim parameters = New Dictionary(Of String, String)()
    parameters("Service") = Amazon.ServiceName
    parameters("Version") = Amazon.ServiceVersion
    parameters("Operation") = "TagLookup"
    parameters("TagName") = "dotnet"
    parameters("Count") = "20"
    parameters("ResponseGroup") = "Tags,Small"
    Dim signHelper = New SignedRequestHelper(Amazon.AccessKey, Amazon.SecretKey, "ecs.amazonaws.com")
    url = signHelper.Sign(parameters)
  End Sub


  <Test()> Sub Attributes()

    Dim book As XElement = <book publicationDate="4/14/1978" title="Beauty"/>
    Dim allAttributes As IEnumerable(Of XAttribute) = book.Attributes()
    For Each attribute As XAttribute In allAttributes
      Console.WriteLine(attribute)
    Next

    Dim allPubDateAttributes As IEnumerable(Of XAttribute) = book.Attributes("publicationDate")
    For Each pubDateAttribute As XAttribute In allPubDateAttributes
      Console.WriteLine(CType(pubDateAttribute, DateTime))
    Next

  End Sub

  <Test()> Sub Descendants()
    Dim books As XElement = XElement.Load("categorizedBooks.xml")
    For Each bookElement As XElement In books.Descendants("book")
      Debug.WriteLine(CType(bookElement, String))
    Next
  End Sub



  <Test()> Sub DescendantsVsSelfAndDescendants()
    Dim root As XElement = XElement.Load("categorizedBooks.xml")
    Dim categories As IEnumerable(Of XElement) = root.Descendants("category")

    Console.WriteLine("Descendants")
    For Each categoryElement As XElement In categories
      Debug.WriteLine(" - " + CType(categoryElement.Attribute("name"), String))
    Next

    categories = root.DescendantsAndSelf("category")
    Debug.WriteLine("DescendantsAndSelf")
    For Each categoryElement As XElement In categories
      Debug.WriteLine(" - " + CType(categoryElement.Attribute("name"), String))
    Next
  End Sub

  <Test()> Sub DescendantsWithQueryExpressions()
    Dim root As XElement = XElement.Load("categorizedBooks.xml")
    Dim books = From book In root.Descendants("book") _
     Select CType(book, String)

    For Each book As String In books
      Console.WriteLine(book)
    Next
  End Sub

  <Test()> Sub Ancestors()
    Dim root As XElement = XElement.Load("categorizedBooks.xml")
    Dim dddBook As XElement = root.Descendants("book") _
     .Where(Function(book As XElement) CType(book, String) = "Domain Driven Design") _
     .First()

    ' reverse the order since we want the topmost category first
    Dim ancestors As IEnumerable(Of XElement) = dddBook.Ancestors("category").Reverse()

    ' join each category with a /
    Dim categoryPath As String = String.Join("/", ancestors.Reverse().Select(Function(e As XElement) CType(e.Attribute("name"), String)).ToArray())

    Console.WriteLine(CType(dddBook, String) + " is in the : " + categoryPath + " category.")

  End Sub

  <Test()> Sub Element()
    Dim root As XElement = XElement.Load("categorizedBooks.xml")
    Dim dotNetCategory As XElement = root.Element("category")
    Console.WriteLine(dotNetCategory)
  End Sub

  <Test()> Sub ElementsBeforeSelf()
    Dim root As XElement = XElement.Load("categorizedBooks.xml")
    Dim dddBook As XElement = root.Descendants("book") _
     .Where(Function(book As XElement) CType(book, String) = "Domain Driven Design") _
     .First()

    Dim beforeSelf As IEnumerable(Of XElement) = dddBook.ElementsBeforeSelf()
    For Each element As XElement In beforeSelf
      Console.WriteLine(CType(element, String))
    Next

  End Sub

  <Test()> Sub XPath()
    Dim root As XElement = XElement.Load("categorizedBooks.xml")
    Dim dotNetCategory As XElement = root.XPathSelectElements("//category[@name='.NET']").First()
    Console.WriteLine(dotNetCategory)
  End Sub

  <Test()> Sub XPathSelectElements()
    Dim root As XElement = XElement.Load("categorizedBooks.xml")
    Dim books = From book In root.XPathSelectElements("//book") _
     Select book

    For Each book As XElement In books
      Console.WriteLine(CType(book, String))
    Next
  End Sub

  <Test()> Sub SelectOperator()
    Dim tags As XElement = XElement.Load(url)
    Dim titles = tags.Descendants(ns + "Title").Select(Function(titleElement As XElement) CType(titleElement, String))
    For Each title As String In titles
      Console.WriteLine(title)
    Next
  End Sub

  <Test()> Sub SelectQueryExpression()
    Dim tags As XElement = XElement.Load(url)
    Dim titles = From title In tags.Descendants(ns + "Title") _
     Select CType(title, String)

    For Each title As String In titles
      Console.WriteLine(title)
    Next
  End Sub

  <Test()> Sub Where()
    Dim tags As XElement = XElement.Load(url)

    Dim wpfBooks = From book In tags.Descendants(ns + "Item") _
     Let bookAttributes = book.Element(ns + "ItemAttributes") _
     Let title = CType(bookAttributes.Element(ns + "Title"), String) _
     Where title.Contains("Windows Presentation Foundation") _
     Select title

    For Each title As String In wpfBooks
      Console.WriteLine(title)
    Next

  End Sub

  <Test()> Sub OrderBy()
    Dim tags As XElement = XElement.Load(url)
    Dim titles = From book In tags.Descendants(ns + "Item") _
     Let bookAttributes = book.Element(ns + "ItemAttributes") _
     Let title = CType(bookAttributes.Element(ns + "Title"), String) _
     Order By title _
     Select title

    For Each title As String In titles
      Console.WriteLine(title)
    Next
  End Sub


  <Test()> Sub GroupBy()
    Dim tags As XElement = XElement.Load(url)
    Dim groups = From book In tags.Descendants(ns + "Item") _
     Let bookAttributes = book.Element(ns + "ItemAttributes") _
     Let title = CType(bookAttributes.Element(ns + "Title"), String) _
     Let publisher = CType(bookAttributes.Element(ns + "Manufacturer"), String) _
     Order By publisher, title _
     Group title By Key = publisher Into Group _
     Select Key, Group

    For Each group In groups
      Console.WriteLine(group.Group.Count().ToString & " book(s) published by " & group.Key)
      For Each title As String In group.Group
        Console.WriteLine(" - " + title)
      Next
    Next
  End Sub

  <Test()> Sub Transformation()
    Dim xml As XElement = _
     New XElement("html", _
     New XElement("body", _
     New XElement("h1", "LINQ Books Library"), _
     New XElement("div", _
     New XElement("b", "LINQ in Action"), _
     "\n" + _
     "      By: Fabrice Marguerie, Steve Eichert\n" + _
     "      Published By: Manning\n" + _
     "    " _
     ), _
     New XElement("div", _
     New XElement("b", "AJAX in Action"), _
     "\n" + _
     "      By: Dave Crane\n" + _
     "      Published By: Manning\n" + _
     "    " _
     ), _
     New XElement("div", _
     New XElement("b", "Patterns of Enterprise Application Architecture"), _
     "\n" + _
     "      By: Martin Fowler\n" + _
     "      Published By: APress\n" + _
     "    " _
     ) _
     ) _
    )

    Dim booksXml As XElement = XElement.Load("books.xml")
    Dim books = From book In booksXml.Descendants("book") _
     Select New With { _
     .Title = CType(book.Element("title"), String), _
     .Publisher = CType(book.Element("publisher"), String), _
     .Authors = String.Join(", ", book.Descendants("author").Select(Function(b) CType(b, String)).ToArray()) _
     }

    For Each book In books
      Console.WriteLine(book.Title)
      Console.WriteLine(book.Publisher)
      Console.WriteLine(book.Authors)
    Next

    Dim html As XElement = _
     New XElement("html", _
     New XElement("body", _
     New XElement("h1", "LINQ Books Library"), _
     From book In booksXml.Descendants("book") _
     Select New XElement("div", _
     New XElement("b", CType(book.Element("title"), String), _
     "\n" + _
     "      By: " + String.Join(", ", book.Descendants("author").Select(Function(b) CType(b, String)).ToArray()) + "\n" + _
     "      Published By: " + CType(book.Element("publisher"), String) + "\n" + _
     "    " _
     ) _
     ) _
     ) _
     )

    Console.WriteLine(html)
  End Sub


  <Test()> Sub TransformationWithXSLT()
    Dim xsl As XDocument = <?xml version='1.0' encoding='UTF-8'?>
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
                           </xsl:stylesheet>

    Dim books As XElement = XElement.Load("books.xml")
    Dim output As XDocument = New XDocument()

    Using writer As XmlWriter = output.CreateWriter()
      Dim xslTransformer As XslCompiledTransform = New XslCompiledTransform()
      xslTransformer.Load(XmlReader.Create(New StringReader(xsl.ToString())))
      xslTransformer.Transform(books.CreateReader(), writer)
    End Using

    Console.WriteLine(output)

    Console.WriteLine("With Extension Method")
    Console.WriteLine(XElement.Load("books.xml").XslTransform(xsl.ToString()))
  End Sub


End Class

Module XmlExtensions
  <Extension()> _
  Function XslTransform(ByVal node As XNode, ByVal xsl As String) As XDocument
    Dim output As XDocument = New XDocument()
    Using writer As XmlWriter = output.CreateWriter()
      Dim xslTransformer As XslCompiledTransform = New XslCompiledTransform()
      xslTransformer.Load(XmlReader.Create(New StringReader(xsl)))
      xslTransformer.Transform(node.CreateReader(), writer)
    End Using
    Return output
  End Function
End Module