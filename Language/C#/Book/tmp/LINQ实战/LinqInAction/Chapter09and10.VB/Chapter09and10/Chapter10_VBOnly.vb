Imports LinqInAction.LinqBooks.Common
Imports NUnit.Framework
Imports System.Collections
Imports System
Imports System.Linq
Imports System.Xml.Linq

<TestFixture()> Public Class Chapter10_VBOnly
  <Test()> Sub TestCreatingXMLWithLiterals()
    Dim rss = _
     <?xml version="1.0" encoding="utf-8"?>
     <rss version="2.0">
       <channel>
         <title>Book Reviews</title>
         <description>LinqBook Book Reviews</description>
         <%= From book In SampleData.Books _
           Where Not IsNothing(book.Reviews) AndAlso book.Reviews.Count > 0 _
           Select _
           From review In book.Reviews _
           Select _
           <item>
             <title>Review of <%= book.Title %> by <%= review.User.Name %></title>
             <pubDate>Sun, 23, 2006, 02:19:00 GMT</pubDate>
             <description><%= review.Comments %></description>
           </item> %>
       </channel>
     </rss>

    Dim xml As New XElement("book", _
     New XElement("title", "Naked Conversations"), _
     New XElement("author", "Robert Scoble"), _
     New XElement("author", "Shel Israel"), _
     New XElement("publisher", "Wiley") _
    )

  End Sub

  <Test()> Sub Elements()

    Dim rss = XElement.Load("rss.xml")

    Dim items = rss.Element("channel").Elements("item")

    For Each item As XElement In items
      Console.WriteLine(CType(item.Element("title"), String))
    Next
  End Sub

  <Test()> Sub ChildAxisProperty()
    Dim rss As XElement = XElement.Load("rss.xml")
    Dim items = rss.<channel>(0).<item>

    For Each item As XElement In items
      Console.WriteLine(CType(item.<title>.Value, String))
    Next
  End Sub

  <Test()> Sub DescendantsAxisProperty()

    Dim rss As XElement = XElement.Load("rss.xml")
    Dim items = rss...<item>

    For Each item As XElement In items
      Console.WriteLine(item.<title>.Value)
    Next
  End Sub

  <Test()> Sub ValueExtensionProperty()
    Dim books As XElement = <books>
                              <book>LINQ in Action</book>
                              <book>Art of Unit Testing</book>
                            </books>

    Console.WriteLine(books.<book>.Value) ' Outputs LINQ in Action

  End Sub

  <Test()> Sub AttributeAxisProperty()
    Dim book As XElement = <book publisher='Manning'>LINQ in Action</book>

    Console.WriteLine(book.@publisher)
  End Sub
End Class