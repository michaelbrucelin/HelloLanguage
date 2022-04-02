Imports System.Runtime.CompilerServices

Module NonSequenceOperator
  <Extension()> _
  Public Function GroupJoin(Of TOuter, TInner, TKey, TResult)( _
    ByVal outer As TOuter, ByVal inner As IEnumerable(Of TInner), _
    ByVal outerKeySelector As Func(Of TOuter, TKey), ByVal innerKeySelector As Func(Of TInner, TKey), _
    ByVal resultSelector As Func(Of TOuter, IEnumerable(Of TInner), TResult)) _
    As TResult

    ' Validation of arguments ignored for simplicity
    Dim lookup As ILookup(Of TKey, TInner) = inner.ToLookup(innerKeySelector)
    Dim outerKey = outerKeySelector(outer)
    Return resultSelector(outer, lookup(outerKey))
  End Function

#Region "MyEnumerator"

  Class MyEnumerator(Of TOuter, TInner, TKey, TResult)
    Implements IEnumerator(Of TResult)

    Private enumerator As IEnumerator(Of IGrouping(Of TKey, TInner)) = Nothing
    Private innerLookup As ILookup(Of TKey, TInner)
    Private outer As TOuter
    Private outerKey As TKey
    Private resultSelector As Func(Of TOuter, IEnumerable(Of TInner), TResult)

    Public Sub New(ByVal innerLookup As ILookup(Of TKey, TInner), _
                   ByVal outerKey As TKey, _
                   ByVal outer As TOuter, _
                   ByVal resultSelector As Func(Of TOuter, IEnumerable(Of TInner), TResult))
      Me.innerLookup = innerLookup
      Me.outer = outer
      Me.outerKey = outerKey
      Me.resultSelector = resultSelector
      Me.enumerator = innerLookup.GetEnumerator()
    End Sub

    Public ReadOnly Property Current() As TResult _
      Implements System.Collections.Generic.IEnumerator(Of TResult).Current
      Get
        If enumerator Is Nothing Then
          Throw New InvalidOperationException()
        End If
        Dim grouping As IGrouping(Of TKey, TInner) = enumerator.Current
        Return resultSelector(outer, innerLookup(outerKey))
      End Get
    End Property

    Public ReadOnly Property CurrentNonGeneric() As Object _
      Implements System.Collections.IEnumerator.Current
      Get
        Return Current
      End Get
    End Property

    Public Function MoveNext() As Boolean _
      Implements System.Collections.IEnumerator.MoveNext
      If enumerator Is Nothing Then
        Throw New InvalidOperationException()
      End If
      Return enumerator.MoveNext
    End Function

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
      If enumerator Is Nothing Then
        Throw New InvalidOperationException()
      End If
      enumerator.Reset()
    End Sub

    Private disposedValue As Boolean = False    ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: free other state (managed objects).
        End If

        ' TODO: free your own state (unmanaged objects).
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class

#End Region

#Region "MyEnumerable"

  Class MyEnumerable(Of TOuter, TInner, TKey, TResult)
    Implements IEnumerable(Of TResult)

    Private innerLookup As ILookup(Of TKey, TInner)
    Private outer As TOuter
    Private outerKey As TKey
    Private resultSelector As Func(Of TOuter, IEnumerable(Of TInner), TResult)

    Public Sub New(ByVal innerLookup As ILookup(Of TKey, TInner), _
                   ByVal outerKey As TKey, _
                   ByVal outer As TOuter, _
                   ByVal resultSelector As Func(Of TOuter, IEnumerable(Of TInner), TResult))
      Me.innerLookup = innerLookup
      Me.outer = outer
      Me.outerKey = outerKey
      Me.resultSelector = resultSelector
    End Sub

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of TResult) _
      Implements System.Collections.Generic.IEnumerable(Of TResult).GetEnumerator
      Return New MyEnumerator(Of TOuter, TInner, TKey, TResult)(innerLookup, outerKey, outer, resultSelector)
    End Function

    Public Function GetEnumeratorNonGeneric() As System.Collections.IEnumerator _
      Implements System.Collections.IEnumerable.GetEnumerator
      Return GetEnumerator()
    End Function
  End Class

#End Region

End Module