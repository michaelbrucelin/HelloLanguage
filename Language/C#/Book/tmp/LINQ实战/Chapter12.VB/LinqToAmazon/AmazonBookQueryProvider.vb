Imports System.Linq.Expressions

Public Class AmazonBookQueryProvider
  Inherits QueryProvider

  Public Overloads Overrides Function GetQueryText(ByVal expression As Expression) As String
    Dim criteria As AmazonBookQueryCriteria

    ' Retrieve criteria
    criteria = New AmazonBookExpressionVisitor().ProcessExpression(expression)

    ' Generate URL
    Dim url As String = AmazonHelper.BuildUrl(criteria)

    Return url
  End Function

  Public Overloads Overrides Function Execute(ByVal expression As Expression) As Object
    Dim url As String = GetQueryText(expression)
    Dim results As IEnumerable(Of AmazonBook) = AmazonHelper.PerformWebQuery(url)
    Return results
  End Function
End Class