#region Imports

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using LinqBooks.Entities;
using LinqInAction.Chapter12.LinqToAmazon;

#endregion Imports

namespace LinqBooks.Web
{
  public partial class AddBooks : System.Web.UI.Page
  {
    private LinqBooksDataContext _DataContext;

    protected void Page_Load(object sender, EventArgs e)
    {
      _DataContext = new LinqBooksDataContext();

      if (!IsPostBack)
      {
        ddlPublisher.DataSource = _DataContext.Publishers.OrderBy(publisher => publisher.Name);
        ddlPublisher.DataValueField = "ID";
        ddlPublisher.DataTextField = "Name";
        ddlPublisher.DataBind();

        ddlSubjectByHand.DataSource = _DataContext.Subjects.OrderBy(subject => subject.Name);
        ddlSubjectByHand.DataValueField = "ID";
        ddlSubjectByHand.DataTextField = "Name";
        ddlSubjectByHand.DataBind();

        ddlSubjectFromAmazon.DataSource = _DataContext.Subjects.OrderBy(subject => subject.Name);
        ddlSubjectFromAmazon.DataValueField = "ID";
        ddlSubjectFromAmazon.DataTextField = "Name";
        ddlSubjectFromAmazon.DataBind();
      }
    }

    protected void btnAddByHand_Click(object sender, EventArgs e)
    {
      Book book = new Book();
      book.ID = Guid.NewGuid();
      book.Title = txtTitle.Text;
      book.Isbn = txtIsbn.Text;
      book.Notes = txtNotes.Text;
      if (!String.IsNullOrEmpty(txtPageCount.Text))
        book.PageCount = Int32.Parse(txtPageCount.Text);
      if (!String.IsNullOrEmpty(txtPrice.Text))
        book.Price = Decimal.Parse(txtPrice.Text);
      if (PubDate.SelectedDate != DateTime.MinValue)
        book.PubDate = PubDate.SelectedDate;
      book.Publisher = new Guid(ddlPublisher.SelectedValue);
      if (ddlSubjectByHand.SelectedIndex > 0)
        book.Subject = new Guid(ddlSubjectByHand.SelectedValue);
      book.Summary = txtSummary.Text;

      _DataContext.Books.InsertOnSubmit(book);
      _DataContext.SubmitChanges();

      Response.Redirect("~/Books.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
      var query =
        from book in new AmazonBookSearch()
        where
          book.Title.Contains(txtSearchKeywords.Text) &&
          (book.Publisher == txtSearchPublisher.Text) &&
          (book.Price <= 25) &&
          (book.Condition == BookCondition.New)
        orderby book.Title
        select book;

      GridViewAmazonBooks.DataSource = query;
      GridViewAmazonBooks.DataBind();

      divImport.Visible = GridViewAmazonBooks.Rows.Count > 0;
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
      foreach (GridViewRow row in GridViewAmazonBooks.Rows)
      {
        CheckBox chkImport = (CheckBox)row.FindControl("chkImport");
        if (!chkImport.Checked)
          continue;

        // Retrieve data
        String title = row.Cells[1].Text;
        String publisherName = row.Cells[2].Text;
        String isbn = row.Cells[3].Text;
        Decimal? price = !String.IsNullOrEmpty(row.Cells[5].Text) ? Decimal.Parse(row.Cells[5].Text) : (Decimal?)null;
        Int32 pageCount = Int32.Parse(row.Cells[6].Text);

        // Find publisher
        Guid publisherId = _DataContext.Publishers.Where(p => p.Name == publisherName).Select(p => p.ID).SingleOrDefault();
        // Create publisher if not found
        if (publisherId == Guid.Empty)
        {
          publisherId = Guid.NewGuid();
          Publisher publisher = new Publisher();
          publisher.ID = publisherId;
          publisher.Name = publisherName;
          _DataContext.Publishers.InsertOnSubmit(publisher);
        }

        // Add book
        Book book = new Book();
        book.ID = Guid.NewGuid();
        book.Title = title;
        book.Isbn = isbn;
        book.PageCount = pageCount;
        book.Price = price;
        book.Publisher = publisherId;
        if (ddlSubjectFromAmazon.SelectedIndex > 0)
          book.Subject = new Guid(ddlSubjectFromAmazon.SelectedValue);
        _DataContext.Books.InsertOnSubmit(book);
      }

      _DataContext.SubmitChanges();

      Response.Redirect("~/Books.aspx");
    }
  }
}