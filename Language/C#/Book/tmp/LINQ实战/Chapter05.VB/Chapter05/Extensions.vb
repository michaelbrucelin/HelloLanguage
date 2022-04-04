Imports System.Runtime.CompilerServices

Module Extensions
  <Extension()> _
    Public Sub ForEach(Of T)(ByVal source As IEnumerable(Of T), ByVal func As Action(Of T))
    For Each item In source
      func(item)
    Next
  End Sub

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
      If firstElement Or (candidate.CompareTo(maxValue) > 0) Then
        firstElement = False
        maxValue = candidate
        result = element
      End If
    Next
    Return result
  End Function
End Module