' The code in this file comes from Matt Warren's series of blog posts on how to build a LINQ provider
' http://blogs.msdn.com/mattwar/archive/2007/08/09/linq-building-an-iqueryable-provider-part-i.aspx
' Converted to VB

Imports System.Linq.Expressions

Public Class Query(Of T)
  Implements IQueryable(Of T)
  Implements IQueryable
  Implements IEnumerable(Of T)
  Implements IEnumerable
  Implements IOrderedQueryable(Of T)
  Implements IOrderedQueryable
  Private m_provider As QueryProvider
  Private m_expression As Expression

  Public Sub New(ByVal provider As QueryProvider)
    If provider Is Nothing Then
      Throw New ArgumentNullException("provider")
    End If
    Me.m_provider = provider
    Me.m_expression = Expression.Constant(Me)
  End Sub

  Public Sub New(ByVal provider As QueryProvider, ByVal expression As Expression)
    If provider Is Nothing Then
      Throw New ArgumentNullException("provider")
    End If
    If expression Is Nothing Then
      Throw New ArgumentNullException("expression")
    End If
    If Not GetType(IQueryable(Of T)).IsAssignableFrom(expression.Type) Then
      Throw New ArgumentOutOfRangeException("expression")
    End If
    Me.m_provider = provider
    Me.m_expression = expression
  End Sub

  Private ReadOnly Property Expression() As Expression Implements IQueryable.Expression
    Get
      Return Me.m_expression
    End Get
  End Property

  Private ReadOnly Property ElementType() As Type Implements IQueryable.ElementType
    Get
      Return GetType(T)
    End Get
  End Property

  Private ReadOnly Property Provider() As IQueryProvider Implements IQueryable.Provider
    Get
      Return Me.m_provider
    End Get
  End Property

  Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
    Return DirectCast(Me.m_provider.Execute(Me.m_expression), IEnumerable(Of T)).GetEnumerator()
  End Function

  Private Function GetEnumeratorNonGeneric() As IEnumerator Implements IEnumerable.GetEnumerator
    Return DirectCast(Me.m_provider.Execute(Me.m_expression), IEnumerable).GetEnumerator()
  End Function

  Public Overloads Overrides Function ToString() As String
    Return Me.m_provider.GetQueryText(Me.m_expression)
  End Function
End Class