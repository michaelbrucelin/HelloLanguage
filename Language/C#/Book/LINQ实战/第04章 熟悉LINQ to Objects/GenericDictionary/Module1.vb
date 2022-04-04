Module Module1

  Sub Main()
    Dim frenchNumbers As Dictionary(Of Integer, String)
    frenchNumbers = New Dictionary(Of Integer, String)()
    frenchNumbers.Add(0, "zero")
    frenchNumbers.Add(1, "un")
    frenchNumbers.Add(2, "deux")
    frenchNumbers.Add(3, "trois")
    frenchNumbers.Add(4, "quatre")

    Dim evenFrenchNumbers = _
      From entry In frenchNumbers _
      Where (entry.Key Mod 2) = 0 _
      Select entry.Value

    ObjectDumper.Write(evenFrenchNumbers)
  End Sub

End Module