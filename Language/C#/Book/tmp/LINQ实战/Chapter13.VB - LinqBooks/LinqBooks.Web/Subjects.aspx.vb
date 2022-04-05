Imports LinqBooks.DataAccess
Imports LinqBooks.Entities

Partial Public Class Subjects
  Inherits System.Web.UI.Page

  Private _DataContext As LinqBooksDataContext

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    _DataContext = New LinqBooksDataContext()

    If Not IsPostBack Then
      DisplaySubjects()
    End If
  End Sub

  Private Sub DisplaySubjects()
    Dim dao = New SubjectDataAccessObject()

    GridViewSubjects.DataSource = dao.GetSubjectsWithBooksLoaded()
    GridViewSubjects.DataBind()

    ddlSubject.Items.Clear()
    ddlSubject.Items.Add(New ListItem("(select a value)", "0"))
    ddlSubject.DataSource = dao.GetSubjects()
    ddlSubject.DataTextField = "Name"
    ddlSubject.DataValueField = "Name"
    ddlSubject.DataBind()
  End Sub

  Protected Sub GridViewSubjects_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
    If e.Row.DataItem Is Nothing Then
      Return
    End If

    Dim subject = CType(e.Row.DataItem, Subject)
    Dim bookList = CType(e.Row.FindControl("BookList"), BookList)
    bookList.Books = subject.Books
    bookList.DataBind()
  End Sub

  Protected Sub btnShowAddSubject_Click(ByVal sender As Object, ByVal e As EventArgs)
    divAddSubject.Visible = True
    btnShowAddSubject.Visible = False
  End Sub

  Protected Sub btnAddSubject_Click(ByVal sender As Object, ByVal e As EventArgs)
    ' Create new subject
    Dim subject = New Subject()
    subject.ID = Guid.NewGuid()
    subject.Name = txtName.Text

    ' Add subject
    _DataContext.Subjects.InsertOnSubmit(subject)
    _DataContext.SubmitChanges()

    ' Update display
    DisplaySubjects()

    divAddSubject.Visible = False
    btnShowAddSubject.Visible = True
  End Sub

  Protected Sub ddlSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    Dim subjectName = ddlSubject.SelectedValue
    If String.IsNullOrEmpty(subjectName) Or (subjectName = "0") Then
      BookListDalSample.Visible = False
    Else
      Dim dao = New BookDataAccessObject()
      BookListDalSample.Books = dao.GetBooksBySubjectName(subjectName)
      BookListDalSample.DataBind()
      BookListDalSample.Visible = True
    End If
  End Sub
End Class