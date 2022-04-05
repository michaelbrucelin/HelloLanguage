Class AmazonBookQueryCriteria

  Private _condition As BookCondition?

  Public Property Condition() As BookCondition?
    Get
      Return _condition
    End Get
    Set(ByVal value As BookCondition?)
      _condition = value
    End Set
  End Property

  Private _maximumPrice As Decimal?

  Public Property MaximumPrice() As Decimal?
    Get
      Return _maximumPrice
    End Get
    Set(ByVal value As Decimal?)
      _maximumPrice = value
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

  Private _title As String

  Public Property Title() As String
    Get
      Return _title
    End Get
    Set(ByVal value As String)
      _title = value
    End Set
  End Property
End Class