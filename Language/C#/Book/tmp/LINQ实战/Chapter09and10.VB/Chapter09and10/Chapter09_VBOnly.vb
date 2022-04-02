Imports LinqInAction.LinqBooks.Common
Imports NUnit.Framework
Imports System.Collections
Imports System
Imports System.Linq
Imports System.Xml.Linq

<TestFixture()> Public Class Chapter09_VBOnly
  <Test()> Sub CreateWithFunctionalConstruction()
    Dim book As New XElement("book", _
     New XElement("title", "Naked Conversations"), _
     New XElement("author", "Robert Scoble"), _
     New XElement("author", "Shel Israel"), _
     New XElement("publisher", "Wiley") _
     )

    Console.WriteLine(book)

  End Sub

  <Test()> Sub CreateWithXmlLiterals()
    Dim book As XElement = <book>
                             <title>Naked Conversations</title>
                             <author>Robert Scoble</author>
                             <author>Shel Israel</author>
                             <publisher>Wiley</publisher>
                           </book>

    Console.WriteLine(book)
  End Sub

  <Test()> Sub CreateWithXmlLiteralsAndExpressions()
    Dim title As String = "NHibernate in Action"
    Dim author As String = "Pierre Kuate"
    Dim publisher As String = "Manning"

    Dim book As XElement = <book>
                             <title><%= title %></title>
                             <author><%= author %></author>
                             <publisher><%= publisher %></publisher>
                           </book>

    Console.WriteLine(book)
  End Sub

  <Test()> Sub CreateXmlLiteralsWithExpressionForTagName()
    Dim elementName As String = "book_tag"
    Dim title As String = "NHibernate in Action"
    Dim author As String = "Pierre Kuate"
    Dim publisher As String = "Manning"

    Dim book As XElement = <<%= elementName %>>
                             <title><%= title %></title>
                             <author><%= author %></author>
                             <publisher><%= publisher %></publisher>
                           </>

    Console.WriteLine(book)
  End Sub

  <Test()> Sub XmlLiteralsEmptyEndTag()
    Dim xml As XElement = <book>
                            <title>Windows Workflow Foundation</title>
                          </book>

  End Sub

  <Test()> Sub XmlLiteralsExpressionInAttribute()
    Dim linkXml = <link updatedDate=<%= Now() %>>http://www.linqinaction.net/</link>
    Console.WriteLine(linkXml)
  End Sub
End Class