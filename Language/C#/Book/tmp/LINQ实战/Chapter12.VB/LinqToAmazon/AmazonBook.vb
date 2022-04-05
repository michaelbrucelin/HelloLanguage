Public Enum BookCondition
  All
  [New]
  Used
  Refurbished
  Collectible
End Enum

Public Class AmazonBook
  Private _authors As IList(Of String)

  Public Property Authors() As IList(Of String)
    Get
      Return _authors
    End Get
    Set(ByVal value As IList(Of String))
      _authors = value
    End Set
  End Property

  Private _condition As BookCondition

  Public Property Condition() As BookCondition
    Get
      Return _condition
    End Get
    Set(ByVal value As BookCondition)
      _condition = value
    End Set
  End Property

  Private _isbn As String

  Public Property Isbn() As String
    Get
      Return _isbn
    End Get
    Set(ByVal value As String)
      _isbn = value
    End Set
  End Property

  Private _pageCount As UInteger

  Public Property PageCount() As UInteger
    Get
      Return _pageCount
    End Get
    Set(ByVal value As UInteger)
      _pageCount = value
    End Set
  End Property

  Private _publisher As String

  Public Property Publisher() As String
    Get
      Return _publisher
    End Get
    Set(ByVal value As String)
      _publisher = value
    End Set
  End Property

  Private _price As Decimal

  Public Property Price() As Decimal
    Get
      Return _price
    End Get
    Set(ByVal value As Decimal)
      _price = value
    End Set
  End Property

  Private _title As String

  Public Property Title() As String
    Get
      Return _title
    End Get
    Set(ByVal value As String)
      _title = value
    End Set
  End Property

  Private _year As Integer

  Public Property Year() As UInteger
    Get
      Return _year
    End Get
    Set(ByVal value As UInteger)
      _year = value
    End Set
  End Property
End Class