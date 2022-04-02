Module Module1

#Region "ProcessData class"

  Class ProcessData

    Private _Id As Int32
    Public Property Id() As Int32
      Get
        Return _Id
      End Get
      Set(ByVal value As Int32)
        _Id = value
      End Set
    End Property


    Private _Memory As Int64
    Public Property Memory() As Int64
      Get
        Return _Memory
      End Get
      Set(ByVal value As Int64)
        _Memory = value
      End Set
    End Property

    Private _Name As String
    Public Property Name() As String
      Get
        Return _Name
      End Get
      Set(ByVal value As String)
        _Name = value
      End Set
    End Property

  End Class

#End Region

  <System.Runtime.CompilerServices.Extension()> _
    Public Function TotalMemory( _
      ByVal processes As IEnumerable(Of ProcessData)) _
      As Int64

    Dim result As Int64 = 0
    For Each process In processes
      result += process.Memory
    Next
    Return result
  End Function

  Sub DisplayProcesses(ByVal match As Predicate(Of Process))
    Dim processes = New List(Of ProcessData)()
    For Each process In System.Diagnostics.Process.GetProcesses()
      If match(process) Then
        processes.Add(New ProcessData With {.Id = process.Id, _
          .Name = process.ProcessName, .Memory = process.WorkingSet64})
      End If
    Next

    Console.WriteLine("Total memory: {0} MB", _
        processes.TotalMemory() / 1024 / 1024)

    Dim top2Memory = _
      processes _
        .OrderByDescending(Function(process) process.Memory) _
        .Take(2) _
        .Sum(Function(process) process.Memory) / 1024 / 1024
    Console.WriteLine( _
      "Memory consumed by the two most hungry processes: {0} MB", _
      top2Memory)

    ObjectDumper.Write(processes)
  End Sub

  Sub Main()
    DisplayProcesses(Function(process) process.WorkingSet64 >= 20 * 1024 * 1024)
  End Sub

End Module