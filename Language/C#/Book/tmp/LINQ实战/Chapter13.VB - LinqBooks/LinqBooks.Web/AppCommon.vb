Imports LinqBooks.Entities

Module AppCommon

  Public ReadOnly Property User() As User
    Get
      Dim membershipUser = Membership.GetUser()
      If membershipUser Is Nothing Then
        Throw New Exception("No current user.")
      End If

      Dim userId = CType(membershipUser.ProviderUserKey, Guid)
      If userId.Equals(HttpContext.Current.Application("UserId")) Then
        Return CType(HttpContext.Current.Application("User"), User)
      End If

      Dim dataContext = New LinqBooksDataContext()
      Dim result As User = dataContext.Users.SingleOrDefault(Function(u) u.ID = userId)
      If result Is Nothing Then
        Throw New Exception("Current user not recognized by the application.")
      End If

      HttpContext.Current.Application("UserId") = userId
      HttpContext.Current.Application("User") = result
      Return result
    End Get
  End Property

End Module