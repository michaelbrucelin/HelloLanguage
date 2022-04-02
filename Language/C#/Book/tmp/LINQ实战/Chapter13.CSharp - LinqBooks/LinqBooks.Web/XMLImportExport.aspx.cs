 #region Imports

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using LinqBooks.Entities;

#endregion Imports

namespace LinqBooks.Web
{
  public partial class XmlImportExport : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
      LinqBooksDataSet dataSet;

      dataSet = new LinqBooksDataSet();
      dataSet.ReadXml(uploadXml.FileContent);
      Session["DataSet"] = dataSet;

      DisplayData();
    }

    private void DisplayData()
    {
      LinqBooksDataContext dataContext;
      LinqBooksDataSet dataSet;

      dataContext = new LinqBooksDataContext();
      IEnumerable<String> knownTitles = dataContext.Books.Select(book => book.Title);

      dataSet = (LinqBooksDataSet)Session["DataSet"];
      var queryExisting =
        from book in dataSet.Book
        where knownTitles.Contains(book.Title)
        orderby book.Title
        select new {
                 Title = book.Title,
                 Publisher = book.PublisherRow.Name,
                 ISBN = book.Field<String>("Isbn"),
                 Subject = book.SubjectRow.Name
               };
      GridViewDataSetExisting.DataSource = queryExisting;
      GridViewDataSetExisting.DataBind();

      var queryNew =
        from book in dataSet.Book
        where !knownTitles.Contains(book.Title)
        orderby book.Title
        select new {
                 Id = book.ID,
                 Title = book.Title,
                 Publisher = book.PublisherRow.Name,
                 ISBN = book.Field<String>("Isbn"),
                 Subject = book.SubjectRow.Name
               };
      GridViewDataSetNew.DataSource = queryNew;
      GridViewDataSetNew.DataBind();

      divData.Visible = true;
      btnImport.Visible = GridViewDataSetNew.Rows.Count > 0;
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
      LinqBooksDataContext dataContext;
      LinqBooksDataSet dataSet;

      dataContext = new LinqBooksDataContext();
      dataSet = (LinqBooksDataSet)Session["DataSet"];

      foreach (GridViewRow gridRow in GridViewDataSetNew.Rows)
      {
        CheckBox chkImport = (CheckBox)gridRow.FindControl("chkImport");
        if (!chkImport.Checked)
          continue;

        // Retrieve data
        Guid bookId = (Guid)GridViewDataSetNew.DataKeys[gridRow.RowIndex].Value;

        // Find book
        LinqBooksDataSet.BookRow bookRow = dataSet.Book.FindByID(bookId);

        #region Find or create publisher

        Guid publisherId =
          dataContext.Publishers
            .Where(p => p.Name == bookRow.PublisherRow.Name)
            .Select(p => p.ID)
            .SingleOrDefault();
        if (publisherId == Guid.Empty)
        {
          publisherId = bookRow.Publisher;
          Publisher publisher = new Publisher();
          publisher.ID = publisherId;
          publisher.Name = bookRow.PublisherRow.Name;
          dataContext.Publishers.InsertOnSubmit(publisher);
        }

        #endregion Find or create publisher

        #region Find or create authors

        foreach (LinqBooksDataSet.BookAuthorRow bookAuthorRow in bookRow.GetBookAuthorRows())
        {
          Guid authorId = dataContext.Authors
            .Where(a => (a.FirstName == bookAuthorRow.AuthorRow.FirstName) && (a.LastName == bookAuthorRow.AuthorRow.LastName))
            .Select(s => s.ID)
            .SingleOrDefault();
          if (authorId == Guid.Empty)
          {
            authorId = bookAuthorRow.Author;
            Author author = new Author();
            author.ID = authorId;
            author.FirstName = bookAuthorRow.AuthorRow.FirstName;
            author.LastName = bookAuthorRow.AuthorRow.LastName;
            dataContext.Authors.InsertOnSubmit(author);
          }

          BookAuthor bookAuthor = new BookAuthor();
          bookAuthor.Author = authorId;
          bookAuthor.Book = bookRow.ID;
          dataContext.BookAuthors.InsertOnSubmit(bookAuthor);
        }

        #endregion Find or create authors

        #region Find or create subject

        Guid subjectId =
          dataContext.Subjects
            .Where(s => s.Name == bookRow.SubjectRow.Name)
            .Select(s => s.ID)
            .SingleOrDefault();
        if (subjectId == Guid.Empty)
        {
          subjectId = bookRow.Subject;
          Subject subject = new Subject();
          subject.ID = subjectId;
          subject.Name = bookRow.SubjectRow.Name;
          dataContext.Subjects.InsertOnSubmit(subject);
        }

        #endregion Find or create subject

        #region Create book

        Book book = new Book();
        book.ID = bookRow.ID;
        book.Title = bookRow.Title;
        book.Isbn = bookRow.Isbn;
        book.Price = bookRow.Field<Decimal?>("Price");
        book.Publisher = publisherId;
        book.Subject = subjectId;
        dataContext.Books.InsertOnSubmit(book);

        #endregion Create book
      }

      dataContext.SubmitChanges();

      Response.Redirect("~/Books.aspx");
    }
  }
}