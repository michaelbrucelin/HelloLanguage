Imports System.IO
Imports System.Runtime.CompilerServices

''' <summary>
''' Contains operators for LINQ to Text Files
''' </summary>
Module StreamReaderOperators

#Region "StreamReaderEnumerator"

  Class StreamReaderEnumerator
    Implements IEnumerator(Of String)

    Private currentLine As String
    Private source As StreamReader

    Public Sub New(ByVal source As StreamReader)
      Me.source = source
    End Sub

    Public ReadOnly Property Current() As String _
      Implements System.Collections.Generic.IEnumerator(Of String).Current
      Get
        Return Me.currentLine
      End Get
    End Property

    Public ReadOnly Property CurrentNonGeneric() As Object _
      Implements System.Collections.IEnumerator.Current
      Get
        Return Current
      End Get
    End Property

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
      currentLine = source.ReadLine()
      Return Not currentLine Is Nothing
    End Function

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset

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

#Region "StreamReaderEnumerable"

  Class StreamReaderEnumerable
    Implements IEnumerable(Of String)

    Private source As StreamReader
    Public Sub New(ByVal source As StreamReader)
      Me.source = source
    End Sub
    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of String) _
      Implements System.Collections.Generic.IEnumerable(Of String).GetEnumerator
      Return New StreamReaderEnumerator(source)
    End Function
    Public Function GetEnumeratorNonGeneric() As System.Collections.IEnumerator _
      Implements System.Collections.IEnumerable.GetEnumerator
      Return GetEnumerator()
    End Function
  End Class

#End Region

  <Extension()> _
  Public Function Lines(ByVal source As StreamReader) As IEnumerable(Of String)
    If source Is Nothing Then
      Throw New ArgumentNullException("source")
    End If

    Return New StreamReaderEnumerable(source)
  End Function

End Module
