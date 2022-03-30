Module XmlLiterals

  Public Class Book
    Public Publisher As String
    Public Title As String
    Public Year As Integer

    Public Sub New(ByVal title As String, ByVal publisher As String, _
        ByVal year As Integer)
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

    ' Build an XML fragment using XML literals
    Dim xml As XElement = _
      <books>
        <%= From book In books _
          Where book.Year = 2006 _
          Select _
          <book title=<%= book.Title %>>
            <publisher><%= book.Publisher %></publisher>
          </book> _
        %>
      </books>

    ' Display the result XML
    Console.WriteLine(xml)
  End Sub

End Module