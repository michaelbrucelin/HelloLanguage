#region Imports

using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Linq;

using LinqBooks.Entities;

#endregion Imports

namespace LinqBooks.Web
{
  /// <summary>
  /// Summary description for RSS
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class RSS : System.Web.Services.WebService
  {
    [WebMethod]
    public XmlDocument GetReviews()
    {
      LinqBooksDataContext dataContext = new LinqBooksDataContext();

      var xml =
        new XElement("rss",
          new XAttribute("version", "2.0"),
          new XElement("channel",
            new XElement("title", "LinqBooks reviews"),
            from review in dataContext.Reviews
            select new XElement("item",
              new XElement("title", "Review of \""+review.BookObject.Title+"\" by "+review.UserObject.Name),
              new XElement("description", review.Comments),
              new XElement("link", "http://example.com/Book.aspx?ID="+review.BookObject.ID.ToString())
            )
          )
        );

      XmlDocument result = new XmlDocument();
      result.Load(xml.CreateReader());
      return result;
    }
  }
}
