Module HelloLinqToXml
  ' A custom class like the one below is not required if we use an anonymous type.
  ' See the collection initializer used in Main.
  'Public Class Book
  '  Public Publisher As String
  '  Public Title As String
  '  Public Year As Integer

  '  'Public Sub New(ByVal title As String, ByVal publisher As String, _
  '  '        ByVal year As Integer)
  '  '  Me.Title = title
  '  '  Me.Publisher = publisher
  '  '  Me.Year = year
  '  'End Sub
  'End Class

  Sub Main()
    ' Our book collection
    ' Without using an anonymous type
    'Dim books As Book() = { _
    '  New Book("Ajax in Action", "Manning", 2005), _
    '  New Book("Windows Forms in Action", "Manning", 2006), _
    '  New Book("RSS and Atom in Action", "Manning", 2006) _
    '}
    ' Without using an anonymous type but with a collection initializer
    'Dim books As Book() = { _
    '  New Book With {.Title = "Ajax in Action", .Publisher = "Manning", .Year = 2005}, _
    '  New Book With {.Title = "Windows Forms in Action", .Publisher = "Manning", .Year = 2006}, _
    '  New Book With {.Title = "RSS and Atom in Action", .Publisher = "Manning", .Year = 2006} _
    '}
    ' With an anonymous type
    Dim books() = { _
      New With {.Title = "Ajax in Action", .Publisher = "Manning", .Year = 2005}, _
      New With {.Title = "Windows Forms in Action", .Publisher = "Manning", .Year = 2006}, _
      New With {.Title = "RSS and Atom in Action", .Publisher = "Manning", .Year = 2006} _
    }

    ' Build the XML fragment based on the collection
    Dim xml As XElement = New XElement("books", _
      From book In books _
      Where book.Year = 2006 _
      Select New XElement("book", _
        New XAttribute("title", book.Title), _
        New XElement("publisher", book.Publisher) _
      ) _
    )

    ' Dump the XML to the console
    Console.WriteLine(xml)
  End Sub

End Module