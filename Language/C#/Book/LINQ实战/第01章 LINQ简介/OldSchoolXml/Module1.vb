Imports System.Xml

Module Module1

  Class Book
    Public Title As String
    Public Publisher As String
    Public Year As Integer

    Public Sub New(ByVal title As String, ByVal publisher As String, ByVal year As Integer)
      Me.Title = title
      Me.Publisher = publisher
      Me.Year = year
    End Sub

  End Class

  Sub Main()
    ' Our book collection
    Dim books As Book() = { _
      New Book("Ajax in Action", "Manning", 2005), _
      New Book("Windows Forms in Action", "Manning", 2006), _
      New Book("RSS and Atom in Action", "Manning", 2006) _
    }

    ' Build the XML fragment based on the collection
    Dim doc As XmlDocument = New XmlDocument()
    Dim root As XmlElement = doc.CreateElement("books")
    For Each book As Book In books
      If book.Year = 2006 Then
        Dim element As XmlElement = doc.CreateElement("book")
        element.SetAttribute("title", book.Title)

        Dim publisher As XmlElement = doc.CreateElement("publisher")
        publisher.InnerText = book.Publisher
        element.AppendChild(publisher)

        root.AppendChild(element)
      End If
    Next
    doc.AppendChild(root)

    ' Display the result XML
    doc.Save(Console.Out)
  End Sub

End Module
