Imports System.Linq
Imports System.Data.Linq
Imports System.Data.Linq.Mapping

Module HelloLinqToSql

#Region "Contact class"

  <Table(Name:="Contacts")> _
  Class Contact

    Private _ContactID As Integer
    Private _Name As String
    Private _City As String

    <Column(IsPrimaryKey:=True)> _
    Public Property ContactID() As Integer
      Get
        Return _ContactID
      End Get
      Set(ByVal value As Integer)
        _ContactID = value
      End Set
    End Property

    <Column(Name:="ContactName")> _
    Public Property Name() As String
      Get
        Return _Name
      End Get
      Set(ByVal value As String)
        _Name = value
      End Set
    End Property

    <Column()> _
    Public Property City() As String
      Get
        Return _City
      End Get
      Set(ByVal value As String)
        _City = value
      End Set
    End Property
  End Class

#End Region

  Sub Main()
    ' Get access to the database
    Dim path As String = System.IO.Path.GetFullPath("..\..\..\..\Data\northwnd.mdf")
    Dim db As DataContext = New DataContext(path)

    ' Query for contacts from Paris
    Dim contacts = _
      From contact In db.GetTable(Of Contact)() _
      Where contact.City = "Paris" _
      Select contact

    ' Display the list of matching contacts
    For Each contact In contacts
      Console.WriteLine("Bonjour " + contact.Name)
    Next
  End Sub

End Module