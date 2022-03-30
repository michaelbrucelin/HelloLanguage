<AttributeUsage((AttributeTargets.Method Or AttributeTargets.Class), AllowMultiple:=False)> _
Public NotInheritable Class SampleAttribute
    Inherits Attribute
    ' Fields
    Private _Chapter As Integer
    Private _Listing As Integer
    Private _Description As String

    ' Methods
    Public Sub New(ByVal chapter As Integer, ByVal listingNumber As Integer, ByVal description As String)
        _Chapter = chapter
        _Listing = listingNumber
        _Description = description
    End Sub

    ' Properties
    Public ReadOnly Property Chapter() As Integer
        Get
            Return _Chapter
        End Get
    End Property

    Public ReadOnly Property ListingNumber() As Integer
        Get
            Return _Listing
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return _Description
        End Get
    End Property
End Class
