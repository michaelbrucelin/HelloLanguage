Partial Public Class Author

  Public ReadOnly Property FullName() As String
    Get
      Return LastName.ToUpper() & " " & FirstName
    End Get
  End Property
End Class