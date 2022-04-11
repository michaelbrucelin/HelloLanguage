' The code in this file comes from Matt Warren's series of blog posts on how to build a LINQ provider
' http://blogs.msdn.com/mattwar/archive/2007/08/09/linq-building-an-iqueryable-provider-part-i.aspx
' Converted to VB

Imports System.Linq.Expressions
Imports System.Reflection

Public MustInherit Class QueryProvider
  Implements IQueryProvider
  Protected Sub New()
  End Sub

  Private Function CreateQuery(Of S)(ByVal expression As Expression) As IQueryable(Of S) Implements IQueryProvider.CreateQuery
    Return New Query(Of S)(Me, expression)
  End Function

  Private Function CreateQueryNonGeneric(ByVal expression As Expression) As IQueryable Implements IQueryProvider.CreateQuery
    Dim elementType As Type = TypeSystem.GetElementType(expression.Type)
    Try
      Return DirectCast(Activator.CreateInstance(GetType(Query(Of )).MakeGenericType(elementType), New Object() {Me, expression}), IQueryable)
    Catch tie As TargetInvocationException
      Throw tie.InnerException
    End Try
  End Function

  Private Function Execute(Of S)(ByVal expression As Expression) As S Implements IQueryProvider.Execute
    Return DirectCast(Me.Execute(expression), S)
  End Function

  Private Function ExecuteNonGeneric(ByVal expression As Expression) As Object Implements IQueryProvider.Execute
    Return Me.Execute(expression)
  End Function

  Public MustOverride Function GetQueryText(ByVal expression As Expression) As String
  Public MustOverride Function Execute(ByVal expression As Expression) As Object
End Class