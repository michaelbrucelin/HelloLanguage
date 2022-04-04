Partial Public Class Subject
    Public ObjectId As Guid = Guid.NewGuid()

    Public Shared Sub UpdateSubject(ByVal changingSubject As Subject)
        Dim context As New LinqBooksDataContext()
        Dim existingSubject As Subject = context.Subjects.Where(Function(s) s.SubjectId = changingSubject.SubjectId).FirstOrDefault()
        existingSubject.Name = changingSubject.Name
        existingSubject.Description = changingSubject.Description
        context.SubmitChanges()
    End Sub

End Class
