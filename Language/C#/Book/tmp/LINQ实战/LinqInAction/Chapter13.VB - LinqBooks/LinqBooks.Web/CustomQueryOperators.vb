Imports System.Runtime.CompilerServices
Imports LinqBooks.Entities

Public Module CustomQueryOperators

  <Extension()> _
  Public Function MaxElement(Of TElement, TData As IComparable(Of TData))( _
    ByVal source As IEnumerable(Of TElement), _
    ByVal selector As Func(Of TElement, TData)) As TElement

    If source Is Nothing Then
      Throw New ArgumentNullException("source")
    End If
    If selector Is Nothing Then
      Throw New ArgumentNullException("selector")
    End If

    Dim firstElement As Boolean = True
    Dim result As TElement ' = default(TElement)
    Dim maxValue As TData ' = default(TData)
    For Each element In source
      Dim candidate = selector(element)
      If firstElement Or (CType(candidate, IComparable).CompareTo(maxValue) > 0) Then
        firstElement = False
        maxValue = candidate
        result = element
      End If
    Next
    Return result
  End Function

  <Extension()> _
  Public Function TotalPrice(ByVal books As IEnumerable(Of Book)) As Decimal
    If books Is Nothing Then
      Throw New ArgumentNullException("books")
    End If

    Dim result As Decimal = 0
    For Each book As Book In books
      If Not book Is Nothing AndAlso book.Price.HasValue Then
        result += book.Price.Value
      End If
    Next
    Return result
  End Function
End Module