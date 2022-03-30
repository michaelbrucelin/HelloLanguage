Imports System.Runtime.CompilerServices
Imports LinqInAction.LinqBooks.Common

Namespace QueryOperators
  Public Module SomeModule
    <Extension()> _
    Public Function TotalPrice(ByVal books As IEnumerable(Of Book)) As Decimal
      If books Is Nothing Then
        Throw New ArgumentNullException("books")
      End If

      Dim result As Decimal = 0
      For Each book As Book In books
        If Not book Is Nothing Then
          result += book.Price
        End If
      Next
      Return result
    End Function

    ''' <summary>
    ''' Domain-specific implementation of Min.
    ''' Here we work on a sequence of <see cref="Book"/> objects and return a <see cref="Book"/>.
    ''' </summary>
    ''' <remarks>We consider the result is the book that has the lowest number of pages.</remarks>
    <Extension()> _
    Public Function Min(ByVal source As IEnumerable(Of Book)) As Book
      If source Is Nothing Then
        Throw New ArgumentNullException("source")
      End If

      Dim result As Book = Nothing
      For Each book As Book In source
        If result Is Nothing Then
          result = book
        ElseIf book.PageCount < result.PageCount Then
          result = book
        End If
      Next
      Return result
    End Function

    ''' <summary>
    ''' Returns a publisher's books from a sequence of books.
    ''' </summary>
    <Extension()> _
    Public Function Books(ByVal publisher As Publisher, _
      ByVal sourceBooks As IEnumerable(Of Book)) As IEnumerable(Of Book)
      Return sourceBooks.Where(Function(book) publisher.ReferenceEquals(book.Publisher, publisher))
    End Function

    <Extension()> _
    Public Function IsExpensive(ByVal book As Book) As Boolean
      If book Is Nothing Then
        Throw New ArgumentNullException("book")
      End If

      ' Consider a book as expensive if its price is high or
      ' the number of pages is low considering the price
      Return (book.Price > 50) Or ((book.Price / book.PageCount) > 0.1)
    End Function
  End Module
End Namespace