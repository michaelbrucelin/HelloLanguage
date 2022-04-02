Module Module1

    Sub Main()
    ' Method syntax (dot-notation)
    Dim processes1 = _
      Process.GetProcesses() _
        .Where(Function(Process) Process.WorkingSet64 > 20 * 1024 * 1024) _
        .OrderByDescending(Function(Process) Process.WorkingSet64) _
        .Select(Function(Process) New With {Process.Id, .Name = Process.ProcessName})

    Console.WriteLine("With method syntax:")
    For Each process In processes1
      Console.WriteLine(process)
    Next

    Console.WriteLine()

    ' Query expression
    Dim processes2 = _
      From process In process.GetProcesses() _
      Where process.WorkingSet64 > 20 * 1024 * 1024 _
      Order By process.WorkingSet64 Descending _
      Select New With {process.Id, .Name = process.ProcessName}

    Console.WriteLine("With query expression:")
    For Each process In processes2
      Console.WriteLine(process)
    Next
  End Sub

End Module