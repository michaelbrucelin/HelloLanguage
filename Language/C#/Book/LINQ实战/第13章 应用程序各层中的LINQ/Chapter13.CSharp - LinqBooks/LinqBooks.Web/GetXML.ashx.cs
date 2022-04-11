#region Imports

using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

using LinqBooks.Web.LinqBooksDataSetTableAdapters;

#endregion Imports

namespace LinqBooks.Web
{
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  public class GetXml : IHttpHandler
  {
    public void ProcessRequest(HttpContext context)
    {
      LinqBooksDataSet dataSet = new LinqBooksDataSet();
      new SubjectTableAdapter().Fill(dataSet.Subject);
      new PublisherTableAdapter().Fill(dataSet.Publisher);
      new BookTableAdapter().Fill(dataSet.Book);
      new AuthorTableAdapter().Fill(dataSet.Author);
      new BookAuthorTableAdapter().Fill(dataSet.BookAuthor);
      new UserTableAdapter().Fill(dataSet.User);
      new ReviewTableAdapter().Fill(dataSet.Review);

      context.Response.AddHeader("Content-Disposition", "attachment; filename=Linqbooks.xml");
      context.Response.ContentType = "text/xml";
      dataSet.WriteXml(context.Response.Output);
    }

    public bool IsReusable
    {
      get { return true; }
    }
  }
}
