Imports System.Reflection
Imports System.IO

Public Class SampleItem
    Private _Chapter As Integer
    Private _ListingNumber As Integer
    Private _Description As String
    Private _Method As MethodInfo

    'Public Sub New(ByVal method As MethodInfo)
    '    _Method = method
    '    _Description = method.Name
    'End Sub

    Public Property Chapter() As Integer
        Get
            Return _Chapter
        End Get
        Set(ByVal value As Integer)
            _Chapter = value
        End Set
    End Property

    Public Property ListingNumber() As Integer
        Get
            Return _ListingNumber
        End Get
        Set(ByVal value As Integer)
            _ListingNumber = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Public Property Method() As MethodInfo
        Get
            Return _Method
        End Get
        Set(ByVal value As MethodInfo)
            _Method = value
        End Set
    End Property

End Class

Public Class SampleClass
    Implements IEnumerable(Of SampleItem), IEnumerable

    Private _MethodList As New List(Of SampleItem)
    Private _Title As String

    Public Sub New()
        Dim ClassType As Type = MyBase.GetType
        _Title = ClassType.Name

        Dim items = From _method As MethodInfo In ClassType.GetMethods(BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.DeclaredOnly), _
                    _attrib As SampleAttribute In _method.GetCustomAttributes(False).OfType(Of SampleAttribute)() _
                   Select New SampleItem With { _
                                               .Method = _method, _
                                               .Description = _attrib.Description, _
                                               .Chapter = _attrib.Chapter, _
                                               .ListingNumber = _attrib.ListingNumber _
                                               }

        _MethodList.AddRange(items)

    End Sub

    Public Function GetEnumerator1() As System.Collections.Generic.IEnumerator(Of SampleItem) Implements System.Collections.Generic.IEnumerable(Of SampleItem).GetEnumerator
        Return _MethodList.GetEnumerator
    End Function

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return _MethodList.GetEnumerator
    End Function

    Default Public ReadOnly Property item(ByVal index As Integer) As SampleItem
        Get
            Return _MethodList(index)
        End Get
    End Property

    Public ReadOnly Property Title() As String
        Get
            Return _Title
        End Get
    End Property

    Public ReadOnly Property OutputStreamWriter() As StreamWriter
        Get
            Return _OutputStreamWriter
        End Get
    End Property
    Private ReadOnly _OutputStreamWriter As StreamWriter = New StreamWriter(New MemoryStream)

End Class