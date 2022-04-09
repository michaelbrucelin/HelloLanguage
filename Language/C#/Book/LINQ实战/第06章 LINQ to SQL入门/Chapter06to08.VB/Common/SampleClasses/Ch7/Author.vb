Imports System.Data.Linq.Mapping
Imports System.Data.Linq

Namespace SampleClasses.Ch7

    <Table(Name:="dbo.Author")> _
    Public Class Author

        Private _ID As System.Guid
        <Column(Storage:="_ID", Name:="ID", DbType:="UniqueIdentifier NOT NULL", IsPrimaryKey:=True, CanBeNull:=False)> _
        Public Property ID() As System.Guid
            Get
                Return _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property

        Private _LastName As String
        <Column(Name:="LastName", DbType:="VarChar(50) NOT NULL", CanBeNull:=False, UpdateCheck:=UpdateCheck.Never)> _
        Public Property LastName() As String
            Get
                Return _LastName
            End Get
            Set(ByVal value As String)
                _LastName = value
            End Set
        End Property

        Private _FirstName As String
        <Column(Name:="FirstName", DbType:="VarChar(30) NOT NULL", CanBeNull:=False, UpdateCheck:=UpdateCheck.Never)> _
        Public Property FirstName() As String
            Get
                Return _FirstName
            End Get
            Set(ByVal value As String)
                _FirstName = value
            End Set
        End Property

        Private _WebSite As String
        <Column(Name:="WebSite", DbType:="VarChar(200)", UpdateCheck:=UpdateCheck.Never)> _
        Public Property WebSite() As String
            Get
                Return _WebSite
            End Get
            Set(ByVal value As String)
                _WebSite = value
            End Set
        End Property

        Private _TimeStamp As Byte()
        <Column(Name:="TimeStamp", DbType:="rowversion NOT NULL", IsDbGenerated:=True, IsVersion:=True, CanBeNull:=False, UpdateCheck:=UpdateCheck.Always)> _
        Public Property TimeStamp() As Byte()
            Get
                Return _TimeStamp
            End Get
            Set(ByVal value As Byte())
                _TimeStamp = value
            End Set
        End Property

        Private _BookAuthors As EntitySet(Of BookAuthor)
        <Association(Name:="FK_BookAuthor_Author", Storage:="_BookAuthors", OtherKey:="Author", ThisKey:="ID")> _
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
