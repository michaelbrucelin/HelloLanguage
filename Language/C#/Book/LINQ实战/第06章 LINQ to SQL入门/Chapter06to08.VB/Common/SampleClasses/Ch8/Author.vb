Namespace SampleClasses.Ch8

    Partial Public Class Author
        Public ReadOnly Property FormattedName() As String
            Get
                Return Me.FirstName & " " & Me.LastName
            End Get
        End Property
    End Class
End Namespace
