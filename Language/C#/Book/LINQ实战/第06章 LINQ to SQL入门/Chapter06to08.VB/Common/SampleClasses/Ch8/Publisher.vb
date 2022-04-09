Imports System.ComponentModel
Namespace SampleClasses.Ch8
    Public Class Publisher
        Implements IDataErrorInfo

        Const UrlPattern As String = "^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$"

        Private Sub OnCreated()
            ID = Guid.NewGuid()
            Name = String.Empty
            WebSite = String.Empty
        End Sub

        Private Function CheckRules(ByVal columnName As String) As String
            Select Case columnName
                Case "Name"
                    If Me.Name IsNot Nothing Then
                        If (Me.Name.Length = 0) Then Return "Required"
                        If (Me.Name.Length >= 50) Then Return "Too long"
                    End If
                Case "WebSite"
                    If Me.WebSite IsNot Nothing Then
                        If (Me.WebSite.Length >= 200) Then Return "Too long"
                        If Not System.Text.RegularExpressions.Regex.IsMatch(Me.WebSite, UrlPattern) Then _
                            Return "Not a valid URL"
                    End If
            End Select

            'All rules are ok, return an empty string
            Return String.Empty
        End Function

#Region "IDataErrorInfo Members"
        Public ReadOnly Property [Error]() As String Implements System.ComponentModel.IDataErrorInfo.Error
            Get
                Return CheckRules("Name") & CheckRules("WebSite")
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal columnName As String) As String Implements System.ComponentModel.IDataErrorInfo.Item
            Get
                Return CheckRules(columnName)
            End Get
        End Property

#End Region

    End Class
End Namespace