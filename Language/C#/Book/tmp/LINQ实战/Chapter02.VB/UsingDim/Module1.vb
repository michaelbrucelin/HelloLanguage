Module Module1

  Class ProcessData
    Public Id As Int32
    Public Memory As Int64
    Public Name As String
  End Class

  Sub DisplayProcesses()
    Dim processes = New List(Of ProcessData)()
    For Each process In System.Diagnostics.Process.GetProcesses()
      Dim data = New ProcessData()
      data.Id = process.Id
      data.Name = process.ProcessName
      data.Memory = process.WorkingSet64
      processes.Add(data)
    Next

    ' Print out the list of processes to the console
    ObjectDumper.Write(processes)
  End Sub

  Sub Main()
    DisplayProcesses()
  End Sub

End Module
