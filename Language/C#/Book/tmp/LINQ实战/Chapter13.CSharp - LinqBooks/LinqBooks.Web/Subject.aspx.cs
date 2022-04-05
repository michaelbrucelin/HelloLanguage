#region Imports

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using LinqBooks.Entities;
using LinqBooks.Web.Controls;

#endregion Imports

namespace LinqBooks.Web
{
  public partial class SubjectPage : System.Web.UI.Page
  {
    LinqBooksDataContext _DataContext;
    Guid _SubjectId;

    protected void Page_Load(object sender, EventArgs e)
    {
      String tmpString;

      tmpString = Request.QueryString["ID"];
      if (String.IsNullOrEmpty(tmpString))
        throw new ArgumentNullException("ID");
      _SubjectId = new Guid(tmpString);

      _DataContext = new LinqBooksDataContext();

      var query =
        from subject in _DataContext.Subjects
        where subject.ID == _SubjectId
        select subject;
      DetailsView1.DataSource = query;
      DetailsView1.DataBind();
    }

    protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
      Subject subject = (Subject)DetailsView1.DataItem;
      BookList bookList = (BookList)DetailsView1.FindControl("BookList");
      bookList.Books = subject.Books;
      bookList.DataBind();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      using (TransactionScope transaction = new TransactionScope())
      {
        Subject subject = _DataContext.Subjects.Single(p => p.ID == _SubjectId);
        _DataContext.Subjects.DeleteOnSubmit(subject);
        _DataContext.SubmitChanges();

        transaction.Complete();
      }

      Response.Redirect("~/Subjects.aspx");
    }
  }
}