Imports System.Data.Linq.Mapping
Imports System.Data.Linq
Imports System.Data.SqlClient

Namespace SampleClasses.Ch6.Unmapped
    ''' <summary>
    ''' Subject class definition from listing 6.3
    ''' </summary>
    Public Class Subject

        Private _SubjectId As Guid
        Public Property SubjectId() As Guid
            Get
                Return _SubjectId
            End Get
            Set(ByVal value As Guid)
                _SubjectId = value
            End Set
        End Property


        Private _Description As String
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property


        Private _Name As String
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Public Shared Function GetSubjects() As IEnumerable(Of Subject)
            Dim subjects As New List(Of Subject)
            Using connection As New System.Data.SqlClient.SqlConnection(My.Settings.liaConnectionString)
                connection.Open()
                Using command As SqlCommand = connection.CreateCommand()
                    command.CommandText = "SELECT ID, Name, Description FROM dbo.Subject"
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While (reader.Read())
                            Dim newSubject As New Subject()
                            If Not reader.IsDBNull(0) Then newSubject.SubjectId = reader.GetGuid(0)
                            If Not reader.IsDBNull(1) Then newSubject.Description = reader.GetString(1)
                            If Not reader.IsDBNull(2) Then newSubject.Name = reader.GetString(2)
                            subjects.Add(newSubject)
                        End While
                    End Using
                End Using
            End Using
            Return subjects
        End Function
    End Class
End Namespace

Namespace SampleClasses.Ch6
    ''' <summary>
    ''' Subject class definition from listing 6.3
    ''' </summary>
    <Table()> _
    Public Class Subject
        Public Sub New()
            Me._Books = New EntitySet(Of Book)(AddressOf Me.attach_Books, AddressOf Me.detach_Books)
        End Sub

        Private _SubjectId As Guid
        <Column(IsPrimaryKey:=True, Name:="ID")> _
        Public Property SubjectId() As Guid
            Get
                Return _SubjectId
            End Get
            Set(ByVal value As Guid)
                _SubjectId = value
            End Set
        End Property


        Private _Description As String
        <Column()> _
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property


        Private _Name As String
        <Column()> _
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property


        Public Shared Function GetSubjects() As IEnumerable(Of Subject)
            Dim context As New DataContext(My.Settings.liaConnectionString)
            Return context.GetTable(Of Subject)()
        End Function

        Private _Books As EntitySet(Of Book)

        <Association(Name:="Subject_Book", Storage:="_Books", OtherKey:="SubjectId")> _
        Public Property Books() As EntitySet(Of Book)
            Get
                Return _Books
            End Get
            Set(ByVal value As EntitySet(Of Book))
                _Books.Assign(value)
            End Set
        End Property

        Private Sub attach_Books(ByVal entity As Book)
            '        entity.Subject1 = Me
        End Sub

        Private Sub detach_Books(ByVal entity As Book)
            ' entity.Subject1 = nothing
        End Sub
    End Class
End Namespace