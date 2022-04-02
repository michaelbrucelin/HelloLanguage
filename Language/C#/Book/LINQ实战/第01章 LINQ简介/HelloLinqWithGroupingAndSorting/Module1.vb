Module Module1
  Sub Main()
    Dim words As String() = {"hello", "wonderful", "linq", "beautiful", "world"}

    ' Group words by length
    Dim groups = _
      From word In words _
      Order By word Ascending _
      Group By word.Length Into TheWords = Group _
      Order By Length Descending

    ' Print each group out
    For Each group In groups
      Console.WriteLine("Words of length " + group.Length.ToString())
      For Each word In group.TheWords
        Console.WriteLine("  " + word)
      Next
    Next
  End Sub
End Module