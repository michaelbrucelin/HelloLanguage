Module Module1

  Class ProcessData
    Public Id As Int32
    Public Memory As Int64
    Public Name As String
  End Class

  Sub DisplayProcesses(ByVal match As Func(Of Process, Boolean))
    ' implicitly-typed local variables
    Dim processes = New List(Of ProcessData)()
    For Each process In System.Diagnostics.Process.GetProcesses()
      If match(process) Then
        ' object initializers
        processes.Add(New ProcessData With {.Id = process.Id, _
            .Name = process.ProcessName, .Memory = process.WorkingSet64})
      End If
    Next

    ' extension methods
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

    ' anonymous types
    Dim results = New With { _
      .TotalMemory = processes.TotalMemory() / 1024 / 1024, _
      .Top2Memory = top2Memory, _
      .Processes = processes}
    ObjectDumper.Write(processes, 1)

    ObjectDumper.Write(processes)
  End Sub

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

  Sub Main()
    ' lambda expressions
    DisplayProcesses(Function(process) process.WorkingSet64 >= 20 * 1024 * 1024)
  End Sub

End Module