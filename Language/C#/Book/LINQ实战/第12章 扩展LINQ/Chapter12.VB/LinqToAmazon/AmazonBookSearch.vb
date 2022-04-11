Imports System.Linq.Expressions

Public Class AmazonBookSearch
  Implements IEnumerable(Of AmazonBook)
  Private _Criteria As AmazonBookQueryCriteria

#Region "Query operators"

  Public Function Where(ByVal predicate As Expression(Of Func(Of AmazonBook, Boolean))) As AmazonBookSearch
    _Criteria = New AmazonBookExpressionVisitor().ProcessExpression(predicate)
    Return Me
  End Function

  Public Function [Select](Of TResult)(ByVal selector As Expression(Of Func(Of AmazonBook, TResult))) As AmazonBookSearch
    Return Me
  End Function

#End Region

#Region "IEnumerable Members"

  Private Function GetEnumerator() As IEnumerator(Of AmazonBook) Implements IEnumerable(Of AmazonBook).GetEnumerator
    Return DirectCast(DirectCast(Me, IEnumerable).GetEnumerator(), IEnumerator(Of AmazonBook))
  End Function

#End Region

#Region "IEnumerable Members"

  Private Function GetEnumeratorNonGeneric() As IEnumerator Implements IEnumerable.GetEnumerator
    ' Execute query
    Dim url As String = AmazonHelper.BuildUrl(_Criteria)
    Dim books As IEnumerable(Of AmazonBook) = AmazonHelper.PerformWebQuery(url)

    Return books.GetEnumerator()
  End Function

#End Region
End Class