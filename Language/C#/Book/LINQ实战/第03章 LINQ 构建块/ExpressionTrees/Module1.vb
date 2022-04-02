Imports System.Linq.Expressions

Module Module1

  Sub Main()
    ' Lambda expression used to declare a delegate
    Dim isOddDelegate As Func(Of Integer, Boolean) = Function(i) (i And 1) = 1

    Console.WriteLine("With a lambda expression used to declare a delegate:")
    For i = 0 To 9
      If isOddDelegate(i) Then
        Console.WriteLine(i & " is odd")
      Else
        Console.WriteLine(i & " is even")
      End If
    Next

    Console.WriteLine()

    ' Lambda expression used to declare an expression tree
    Dim isOddExpression As Expression(Of Func(Of Integer, Boolean)) = Function(i) (i And 1) = 1

    ' Expression tree created by hand
    Dim param As ParameterExpression = Expression.Parameter(GetType(Integer), "i")
    Dim isOdd As Expression(Of Func(Of Integer, Boolean)) = _
        Expression.Lambda(Of Func(Of Integer, Boolean))( _
        Expression.Equal( _
          Expression.And( _
            param, _
            Expression.Constant(1, GetType(Integer))), _
          Expression.Constant(1, GetType(Integer))), _
        New ParameterExpression() {param})

    ' Compiling an expression tree down to a delegate
    Dim isOddCompiledExpression As Func(Of Integer, Boolean) = isOddExpression.Compile()

    Console.WriteLine("With a compiled expression tree:")
    For i = 0 To 9
      If isOddCompiledExpression(i) Then
        Console.WriteLine(i & " is odd")
      Else
        Console.WriteLine(i & " is even")
      End If
    Next
  End Sub

End Module