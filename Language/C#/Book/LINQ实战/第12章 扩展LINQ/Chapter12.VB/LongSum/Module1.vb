Module Module1

    Sub Main()
    ' Standard Sum operator (throws an OverflowException)
    'Enumerable.Sum(New Integer() {Integer.MaxValue, 1})
    'Console.WriteLine("Standard Sum operator: " & (New Integer() {Integer.MaxValue, 1}).Sum())

    ' Custom LongSum operator
    SumExtensions.LongSum(New Integer() {Integer.MaxValue, 1})
    Console.WriteLine("Custom LongSum operator: " & (New Integer() {Integer.MaxValue, 1}).LongSum())
  End Sub

End Module
