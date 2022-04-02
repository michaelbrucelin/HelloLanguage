Module Module1

  ' There is no instruction equivalent to yield return in VB.NET.
  ' Without this shortcut, VB.NET developers have to implement the IEnumerable(Of T) interface by hand to create enumerators

#Region "MyEnumerator"

  Class MyEnumerator
    Implements IEnumerator(Of Integer)

    Private index As Integer = 0

    Public ReadOnly Property Current() As Integer _
      Implements System.Collections.Generic.IEnumerator(Of Integer).Current
      Get
        Console.WriteLine("Returning " & index.ToString())
        Return index
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
      If index < 3 Then
        index = index + 1
        Return True
      Else
        Return False
      End If
    End Function

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
      index = 0
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

  Class MyEnumerable
    Implements IEnumerable(Of Integer)

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Integer) _
      Implements System.Collections.Generic.IEnumerable(Of Integer).GetEnumerator
      Return New MyEnumerator()
    End Function

    Public Function GetEnumeratorNonGeneric() As System.Collections.IEnumerator _
      Implements System.Collections.IEnumerable.GetEnumerator
      Return GetEnumerator()
    End Function
  End Class

#End Region

  Sub Main()

    For Each number In New MyEnumerable()
      Console.WriteLine(number)
    Next
  End Sub

End Module