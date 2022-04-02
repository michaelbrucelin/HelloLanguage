Imports System.Runtime.CompilerServices
Imports LinqInAction.LinqBooks.Common

Namespace QueryOperators
  Public Module SomeModule
    ''' <summary>
    ''' Domain-specific implementation of Where.
    ''' Here we work on a sequence of <see cref="Book"/> objects.
    ''' </summary>
    <Extension()> _
    Public Function Where( _
      ByVal source As IEnumerable(Of Book), ByVal predicate As Func(Of Book, Boolean)) As IEnumerable(Of Book)
      Return New WhereEnumerable(source, predicate)
    End Function

    ''' <summary>
    ''' Domain-specific implementation of Select.
    ''' Here we work on a sequence of <see cref="Book"/> objects.
    ''' </summary>
    <Extension()> _
    Public Function [Select](Of TResult)( _
      ByVal source As IEnumerable(Of Book), ByVal selector As Func(Of Book, TResult)) As IEnumerable(Of TResult)
      Return New SelectEnumerable(Of TResult)(source, selector)
    End Function

#Region "WhereEnumerator"

    Class WhereEnumerator
      Implements IEnumerator(Of Book)

      Private predicate As Func(Of Book, Boolean)
      Private source As IEnumerable(Of Book)
      Private sourceEnumerator As IEnumerator(Of Book) = Nothing

      Public Sub New(ByVal source As IEnumerable(Of Book), ByVal predicate As Func(Of Book, Boolean))
        Me.predicate = predicate
        Me.source = source
        Me.sourceEnumerator = source.GetEnumerator()
      End Sub

      Public ReadOnly Property Current() As Book _
        Implements System.Collections.Generic.IEnumerator(Of Book).Current
        Get
          If sourceEnumerator Is Nothing Then
            Throw New InvalidOperationException()
          End If
          Do
            Dim book As Book = sourceEnumerator.Current
            Console.WriteLine( _
                "processing book ""{0}"" in the domain specific Where", _
                book.Title)
            If predicate(book) Then
              Return book
            End If
          Loop While sourceEnumerator.MoveNext()
          Return Nothing
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
        If sourceEnumerator Is Nothing Then
          Throw New InvalidOperationException()
        End If
        Return sourceEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        If sourceEnumerator Is Nothing Then
          Throw New InvalidOperationException()
        End If
        sourceEnumerator.Reset()
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

#Region "WhereEnumerable"

    Class WhereEnumerable
      Implements IEnumerable(Of Book)

      Private predicate As Func(Of Book, Boolean)
      Private source As IEnumerable(Of Book)

      Public Sub New(ByVal source As IEnumerable(Of Book), ByVal predicate As Func(Of Book, Boolean))
        Me.source = source
        Me.predicate = predicate
      End Sub

      Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Book) _
        Implements System.Collections.Generic.IEnumerable(Of Book).GetEnumerator
        Return New WhereEnumerator(source, predicate)
      End Function

      Public Function GetEnumeratorNonGeneric() As System.Collections.IEnumerator _
        Implements System.Collections.IEnumerable.GetEnumerator
        Return GetEnumerator()
      End Function
    End Class

#End Region

#Region "SelectEnumerator"

    Class SelectEnumerator(Of TResult)
      Implements IEnumerator(Of TResult)

      Private selector As Func(Of Book, TResult)
      Private source As IEnumerable(Of Book)
      Private sourceEnumerator As IEnumerator(Of Book) = Nothing

      Public Sub New(ByVal source As IEnumerable(Of Book), ByVal selector As Func(Of Book, TResult))
        Me.selector = selector
        Me.source = source
        Me.sourceEnumerator = source.GetEnumerator()
      End Sub

      Public ReadOnly Property Current() As TResult _
        Implements System.Collections.Generic.IEnumerator(Of TResult).Current
        Get
          If sourceEnumerator Is Nothing Then
            Throw New InvalidOperationException()
          End If
          Dim book As Book = sourceEnumerator.Current
          Console.WriteLine( _
              "processing book ""{0}"" in the domain specific Select", _
              book.Title)
          Return selector(book)
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
        If sourceEnumerator Is Nothing Then
          Throw New InvalidOperationException()
        End If
        Return sourceEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        If sourceEnumerator Is Nothing Then
          Throw New InvalidOperationException()
        End If
        sourceEnumerator.Reset()
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

#Region "SelectEnumerable"

    Class SelectEnumerable(Of TResult)
      Implements IEnumerable(Of TResult)

      Private selector As Func(Of Book, TResult)
      Private source As IEnumerable(Of Book)

      Public Sub New(ByVal source As IEnumerable(Of Book), ByVal selector As Func(Of Book, TResult))
        Me.source = source
        Me.selector = selector
      End Sub

      Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of TResult) _
        Implements System.Collections.Generic.IEnumerable(Of TResult).GetEnumerator
        Return New SelectEnumerator(Of TResult)(source, selector)
      End Function

      Public Function GetEnumeratorNonGeneric() As System.Collections.IEnumerator _
        Implements System.Collections.IEnumerable.GetEnumerator
        Return GetEnumerator()
      End Function
    End Class

#End Region

  End Module
End Namespace