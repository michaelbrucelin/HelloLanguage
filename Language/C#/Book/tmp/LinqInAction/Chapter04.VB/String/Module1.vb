Module Module1

  Sub Main()
    Dim count = _
      "Non-letter characters in this string: 8" _
        .Where(Function(c) Not Char.IsLetter(c)) _
        .Count()
    Console.WriteLine(count)
  End Sub

End Module