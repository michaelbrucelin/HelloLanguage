Module Module1

  Function Square(ByVal n As Double) As Double
    Console.WriteLine("Computing Square(" & n & ")...")
    Return Math.Pow(n, 2)
  End Function

  Sub Main()
    Dim numbers As Integer() = {1, 2, 3}

    Dim query = _
      From n In numbers _
      Select Square(n)

    For Each n In query
      Console.WriteLine(n)
    Next

    For i = 0 To numbers.Length - 1
      numbers(i) = numbers(i) + 10
    Next

    Console.WriteLine("- Collection updated -")

    For Each n In query
      Console.WriteLine(n)
    Next
  End Sub

End Module