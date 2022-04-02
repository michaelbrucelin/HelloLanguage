Namespace SampleClasses.Ch7
    ''' <summary>
    ''' Book definition used in listing 7.6
    ''' </summary>
    Public Class Book

        Private _BookId As Guid
        Public Property BookId() As Guid
            Get
                Return _BookId
            End Get
            Set(ByVal value As Guid)
                _BookId = value
            End Set
        End Property

        Private _Isbn As String
        Public Property Isbn() As String
            Get
                Return _Isbn
            End Get
            Set(ByVal value As String)
                _Isbn = value
            End Set
        End Property

        Private _Notes As String
        Public Property Notes() As String
            Get
                Return _Notes
            End Get
            Set(ByVal value As String)
                _Notes = value
            End Set
        End Property

        Private _PageCount As Integer
        Public Property PageCount() As Integer
            Get
                Return _PageCount
            End Get
            Set(ByVal value As Integer)
                _PageCount = value
            End Set
        End Property

        Private _Price As Decimal
        Public Property Price() As Decimal
            Get
                Return _Price
            End Get
            Set(ByVal value As Decimal)
                _Price = value
            End Set
        End Property

        Private _PublicationDate As DateTime
        Public Property PublicationDate() As DateTime
            Get
                Return _PublicationDate
            End Get
            Set(ByVal value As DateTime)
                _PublicationDate = value
            End Set
        End Property

        Private _Summary As String
        Public Property Summary() As String
            Get
                Return _Summary
            End Get
            Set(ByVal value As String)
                _Summary = value
            End Set
        End Property

        Private _Title As String
        Public Property Title() As String
            Get
                Return _Title
            End Get
            Set(ByVal value As String)
                _Title = value
            End Set
        End Property

        Private _SubjectId As Guid
        Public Property SubjectId() As Guid
            Get
                Return _SubjectId
            End Get
            Set(ByVal value As Guid)
                _SubjectId = value
            End Set
        End Property

        Private _PublisherId As Guid
        Public Property PublisherId() As Guid
            Get
                Return _PublisherId
            End Get
            Set(ByVal value As Guid)
                _PublisherId = value
            End Set
        End Property
    End Class
End Namespace
