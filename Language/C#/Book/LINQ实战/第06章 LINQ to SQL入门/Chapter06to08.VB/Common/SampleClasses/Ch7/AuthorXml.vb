Imports System.Linq
Imports System.Data.Linq

Namespace SampleClasses.Ch7
    Public Class AuthorXml
        Private _Id As Guid
        Private _BookAuthors As EntitySet(Of BookAuthor)

        Public Property ID() As System.Guid
            Get
                Return _Id
            End Get
            Set(ByVal value As System.Guid)
                _Id = value
            End Set
        End Property

        Private _LastName As String
        Public Property LastName() As String
            Get
                Return _LastName
            End Get
            Set(ByVal value As String)
                _LastName = value
            End Set
        End Property

        Private _FirstName As String
        Public Property FirstName() As String
            Get
                Return _FirstName
            End Get
            Set(ByVal value As String)
                _FirstName = value
            End Set
        End Property

        Private _WebSite As String
        Public Property WebSite() As String
            Get
                Return _WebSite
            End Get
            Set(ByVal value As String)
                _WebSite = value
            End Set
        End Property

        Private _TimeStamp As Byte()
        Public Property TimeStamp() As Byte()
            Get
                Return _TimeStamp
            End Get
            Set(ByVal value As Byte())
                _TimeStamp = value
            End Set
        End Property

        Public Property BookAuthors() As EntitySet(Of BookAuthor)
            Get
                Return _BookAuthors
            End Get
            Set(ByVal value As EntitySet(Of BookAuthor))
                _BookAuthors.Assign(value)
            End Set
        End Property
    End Class
End Namespace