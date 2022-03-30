Imports System.Web
Imports System.Web.Services

Public Class GetXML
  Implements System.Web.IHttpHandler

  Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
    Dim dataSet = New LinqBooksDataSet()
    Dim subjectTableAdapter = New LinqBooksDataSetTableAdapters.SubjectTableAdapter()
    subjectTableAdapter.Fill(dataSet.Subject)
    Dim publisherTableAdapter = New LinqBooksDataSetTableAdapters.PublisherTableAdapter()
    publisherTableAdapter.Fill(dataSet.Publisher)
    Dim bookTableAdapter = New LinqBooksDataSetTableAdapters.BookTableAdapter()
    bookTableAdapter.Fill(dataSet.Book)
    Dim authorTableAdapter = New LinqBooksDataSetTableAdapters.AuthorTableAdapter()
    authorTableAdapter.Fill(dataSet.Author)
    Dim bookAuthorTableAdapter = New LinqBooksDataSetTableAdapters.BookAuthorTableAdapter()
    bookAuthorTableAdapter.Fill(dataSet.BookAuthor)
    Dim userTableAdapter = New LinqBooksDataSetTableAdapters.UserTableAdapter()
    userTableAdapter.Fill(dataSet.User)
    Dim reviewTableAdapter = New LinqBooksDataSetTableAdapters.ReviewTableAdapter()
    reviewTableAdapter.Fill(dataSet.Review)

    context.Response.AddHeader("Content-Disposition", "attachment; filename=Linqbooks.xml")
    context.Response.ContentType = "text/xml"
    dataSet.WriteXml(context.Response.Output)
  End Sub

  ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
    Get
      Return True
    End Get
  End Property
End Class