' Original author: Troy Magennis
' http://aspiring-technology.com/blogs/troym/archive/2006/10/06/24.aspx
' Ported to VB

Imports System.Runtime.CompilerServices

Module SumExtensions
  ''' <summary>
  ''' Returns the numerical Sum of all of the Integer's in the source sequence.
  ''' </summary>
  ''' <param name="source">Source sequence of Integer's</param>
  ''' <returns>The Sum of all the elements in the source sequence.</returns>
  <Extension()> _
  Public Function LongSum(ByVal source As IEnumerable(Of Integer)) As Long
    If source Is Nothing Then
      Throw New ArgumentNullException("source")
    End If

    Dim sum As Long = 0
    For Each v In source
      sum += v
    Next
    Return sum
  End Function

  ''' <summary>
  ''' Returns the numerical Sum of all of the Integer?'s in the source sequence.
  ''' </summary>
  ''' <param name="source">Source sequence of Integer?'s</param>
  ''' <returns>The Sum of all the elements in the source sequence.</returns>
  <Extension()> _
  Public Function LongSum(ByVal source As IEnumerable(Of Integer?)) As Long?
    If source Is Nothing Then
      Throw New ArgumentNullException("source")
    End If

    Dim sum As Long? = 0
    For Each v In source
      If Not v Is Nothing Then
        sum += v
      End If
    Next
    Return sum
  End Function

  ''' <summary>
  ''' Returns the numerical Sum of all of the Integer?'s in the source sequence.
  ''' </summary>
  ''' <param name="source">Source sequence of Integer?'s</param>
  ''' <param name="selector">Selector function.</param>
  ''' <returns>The Sum of all the elements in the source sequence.</returns>
  <Extension()> _
  Public Function LongSum(Of T)(ByVal source As IEnumerable(Of T), ByVal selector As Func(Of T, Integer)) As Long
    Return LongSum(Enumerable.Select(source, selector))
  End Function

  ''' <summary>
  ''' Returns the numerical Sum of all of the Integer?'s in the source sequence.
  ''' </summary>
  ''' <param name="source">Source sequence of int?'s</param>
  ''' <param name="selector">Selector function.</param>
  ''' <returns>The Sum of all the elements in the source sequence.</returns>
  <Extension()> _
  Public Function LongSum(Of T)(ByVal source As IEnumerable(Of T), ByVal selector As Func(Of T, Integer?)) As Long?
    Return LongSum(Enumerable.Select(source, selector))
  End Function
End Module