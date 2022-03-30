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

using LinqBooks.DataAccess;
using LinqBooks.Entities;
using LinqBooks.Web.Controls;

#endregion Imports

namespace LinqBooks.Web
{
  public partial class Subjects : System.Web.UI.Page
  {
    private LinqBooksDataContext _DataContext;

    protected void Page_Load(object sender, EventArgs e)
    {
      _DataContext = new LinqBooksDataContext();

      if (!IsPostBack)
      {
        DisplaySubjects();
      }
    }

    private void DisplaySubjects()
    {
      SubjectDataAccessObject dao = new SubjectDataAccessObject();

      GridViewSubjects.DataSource = dao.GetSubjectsWithBooksLoaded();
      GridViewSubjects.DataBind();

      ddlSubject.Items.Clear();
      ddlSubject.Items.Add(new ListItem("(select a value)", "0"));
      ddlSubject.DataSource = dao.GetSubjects();
      ddlSubject.DataTextField = "Name";
      ddlSubject.DataValueField = "Name";
      ddlSubject.DataBind();
    }

    protected void GridViewSubjects_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.DataItem == null)
        return;

      Subject subject = (Subject)e.Row.DataItem;
      BookList bookList = (BookList)e.Row.FindControl("BookList");
      bookList.Books = subject.Books;
      bookList.DataBind();
    }

    protected void btnShowAddSubject_Click(object sender, EventArgs e)
    {
      divAddSubject.Visible = true;
      btnShowAddSubject.Visible = false;
    }

    protected void btnAddSubject_Click(object sender, EventArgs e)
    {
      // Create new subject
      Subject subject = new Subject();
      subject.ID = Guid.NewGuid();
      subject.Name = txtName.Text;

      // Add subject
      _DataContext.Subjects.InsertOnSubmit(subject);
      _DataContext.SubmitChanges();

      // Update display
      DisplaySubjects();

      divAddSubject.Visible = false;
      btnShowAddSubject.Visible = true;
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
      String subjectName = ddlSubject.SelectedValue;
      if (String.IsNullOrEmpty(subjectName) || (subjectName == "0"))
      {
        BookListDalSample.Visible = false;
      }
      else
      {
        var dao = new BookDataAccessObject();
        BookListDalSample.Books = dao.GetBooksBySubjectName(subjectName);
        BookListDalSample.DataBind();
        BookListDalSample.Visible = true;
      }
    }
  }
}