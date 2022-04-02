Module Module1

  Sub DisplayProcesses(ByVal match As Func(Of Process, Boolean))
    Dim processes = New List(Of Object)()
    For Each process In System.Diagnostics.Process.GetProcesses()
      If match(process) Then
        processes.Add(New With {Key process.Id, _
          .Name = process.ProcessName, .Memory = process.WorkingSet64})
      End If
    Next

    ObjectDumper.Write(processes)
  End Sub

  Sub TestKeyedAnonymousTypes()
    Dim v1 = New With {Key .Id = 123, .Name = "Fabrice"}
    Dim v2 = New With {Key .Id = 123, .Name = "Céline"}
    Dim v3 = New With {Key .Id = 456, .Name = "Fabrice"}
    Console.WriteLine(v1.Equals(v2))
    Console.WriteLine(v1.Equals(v3))
  End Sub

  Sub Main()
    DisplayProcesses(Function(process) process.WorkingSet64 >= 20 * 1024 * 1024)
    TestKeyedAnonymousTypes()
  End Sub

End Module