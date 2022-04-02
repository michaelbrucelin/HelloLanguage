Imports System.Linq.Expressions
Imports System.Reflection

Class AmazonBookExpressionVisitor
  Private _Criteria As AmazonBookQueryCriteria

  Public Function ProcessExpression(ByVal expression As Expression) As AmazonBookQueryCriteria
    _Criteria = New AmazonBookQueryCriteria()
    VisitExpression(expression)
    Return _Criteria
  End Function

  Private Sub VisitExpression(ByVal expression As Expression)
    If expression.NodeType = ExpressionType.[AndAlso] Then
      VisitAndAlso(DirectCast(expression, BinaryExpression))
    ElseIf expression.NodeType = ExpressionType.Equal Then
      VisitEqual(DirectCast(expression, BinaryExpression))
    ElseIf expression.NodeType = ExpressionType.LessThanOrEqual Then
      VisitLessThanOrEqual(DirectCast(expression, BinaryExpression))
    ElseIf TypeOf expression Is MethodCallExpression Then
      VisitMethodCall(DirectCast(expression, MethodCallExpression))
    ElseIf TypeOf expression Is LambdaExpression Then
      VisitExpression(DirectCast(expression, LambdaExpression).Body)
    End If
  End Sub

  Private Sub VisitAndAlso(ByVal [andAlso] As BinaryExpression)
    VisitExpression([andAlso].Left)
    VisitExpression([andAlso].Right)
  End Sub

  Private Sub VisitEqual(ByVal expression As BinaryExpression)
    ' Handle book.Publisher == "xxx"
    If (expression.Left.NodeType = ExpressionType.Call) AndAlso (DirectCast(expression.Left, MethodCallExpression).Method.Name = "CompareString") Then
      Dim compareString = DirectCast(expression.Left, MethodCallExpression)
      Dim argument1 = compareString.Arguments(0)
      Dim argument2 = compareString.Arguments(1)
      If argument1.NodeType = ExpressionType.MemberAccess Then
        Dim memberExpr As MemberExpression = DirectCast(argument1, MemberExpression)
        If memberExpr.Expression.Type Is GetType(AmazonBook) Then
          If memberExpr.Member.Name = "Publisher" Then
            If argument2.NodeType = ExpressionType.Constant Then
              _Criteria.Publisher = DirectCast(DirectCast(argument2, ConstantExpression).Value, String)
            ElseIf argument2.NodeType = ExpressionType.MemberAccess Then
              _Criteria.Publisher = DirectCast(GetMemberValue(DirectCast(argument2, MemberExpression)), String)
            Else
              Throw New NotSupportedException("Expression type not supported: " + argument2.NodeType.ToString())
            End If
          Else
            Throw New NotSupportedException("Member not supported: " + memberExpr.Member.Name)
          End If
        Else
          Throw New NotSupportedException("Type not supported: " + memberExpr.Expression.Type.FullName)
        End If
      Else
        Throw New NotSupportedException("Member access expected")
      End If
    ElseIf (TypeOf expression.Left Is UnaryExpression) AndAlso (DirectCast(expression.Left, UnaryExpression).Operand.Type Is GetType(BookCondition)) Then
      ' Handle book.Condition == BookCondition.*
      If expression.Right.NodeType = ExpressionType.Constant Then
        _Criteria.Condition = DirectCast(DirectCast(expression.Right, ConstantExpression).Value, BookCondition)
      ElseIf expression.Right.NodeType = ExpressionType.MemberAccess Then
        _Criteria.Condition = DirectCast(GetMemberValue(DirectCast(expression.Right, MemberExpression)), BookCondition)
      Else
        Throw New NotSupportedException("Expression type not supported for book condition: " + expression.Right.NodeType.ToString())
      End If
    End If
  End Sub

  Private Sub VisitLessThanOrEqual(ByVal expression As BinaryExpression)
    ' Handle book.Price <= xxx
    If (expression.Left.NodeType = ExpressionType.MemberAccess) AndAlso (DirectCast(expression.Left, MemberExpression).Member.Name = "Price") Then
      If expression.Right.NodeType = ExpressionType.Constant Then
        _Criteria.MaximumPrice = CDec(DirectCast(expression.Right, ConstantExpression).Value)
      ElseIf expression.Right.NodeType = ExpressionType.MemberAccess Then
        _Criteria.MaximumPrice = CDec(GetMemberValue(DirectCast(expression.Right, MemberExpression)))
      Else
        Throw New NotSupportedException("Expression type not supported for price: " + expression.Right.NodeType.ToString())
      End If
    End If
  End Sub

  Private Sub VisitMethodCall(ByVal expression As MethodCallExpression)
    If (expression.Method.DeclaringType Is GetType(Queryable)) AndAlso (expression.Method.Name = "Where") Then
      'this.Visit(m.Arguments[0]);
      'LambdaExpression lambda = (LambdaExpression)StripQuotes(m.Arguments[1]);
      'this.Visit(lambda.Body);
      VisitExpression(DirectCast(expression.Arguments(1), UnaryExpression).Operand)
    ElseIf (expression.Method.DeclaringType Is GetType(String)) AndAlso (expression.Method.Name = "Contains") Then
      ' Handle book.Title.Contains("xxx")
      If expression.[Object].NodeType = ExpressionType.MemberAccess Then
        Dim memberExpr As MemberExpression = DirectCast(expression.[Object], MemberExpression)
        If memberExpr.Expression.Type Is GetType(AmazonBook) Then
          If memberExpr.Member.Name = "Title" Then
            Dim argument As Expression

            argument = expression.Arguments(0)
            If argument.NodeType = ExpressionType.Constant Then
              _Criteria.Title = DirectCast(DirectCast(argument, ConstantExpression).Value, String)
            ElseIf argument.NodeType = ExpressionType.MemberAccess Then
              _Criteria.Title = DirectCast(GetMemberValue(DirectCast(argument, MemberExpression)), String)
            Else
              Throw New NotSupportedException("Expression type not supported: " + argument.NodeType.ToString())
            End If
          End If
        End If
      End If
    Else
      Throw New NotSupportedException("Method not supported: " + expression.Method.Name)
    End If
  End Sub

#Region "Helpers"

  Private Function GetMemberValue(ByVal memberExpression As MemberExpression) As Object
    Dim memberInfo As MemberInfo
    Dim obj As Object

    If memberExpression Is Nothing Then
      Throw New ArgumentNullException("memberExpression")
    End If

    ' Get object
    If TypeOf memberExpression.Expression Is ConstantExpression Then
      obj = DirectCast(memberExpression.Expression, ConstantExpression).Value
    ElseIf TypeOf memberExpression.Expression Is MemberExpression Then
      obj = GetMemberValue(DirectCast(memberExpression.Expression, MemberExpression))
    Else
      Throw New NotSupportedException("Expression type not supported: " + memberExpression.Expression.[GetType]().FullName)
    End If

    ' Get value
    memberInfo = memberExpression.Member
    If TypeOf memberInfo Is PropertyInfo Then
      Dim [property] As PropertyInfo = DirectCast(memberInfo, PropertyInfo)
      Return [property].GetValue(obj, Nothing)
    ElseIf TypeOf memberInfo Is FieldInfo Then
      Dim field As FieldInfo = DirectCast(memberInfo, FieldInfo)
      Return field.GetValue(obj)
    Else
      Throw New NotSupportedException("MemberInfo type not supported: " + memberInfo.[GetType]().FullName)
    End If
  End Function

#End Region

End Class