Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml
Imports LinqBooks.Entities

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class RSS
  Inherits System.Web.Services.WebService

  <WebMethod()> _
  Public Function GetReviews() As XmlDocument
    Dim dataContext = New LinqBooksDataContext()

    Dim xml = _
      <rss version="2.0">
        <channel>
          <title>LinqBooks reviews</title>
          <%= From review In dataContext.Reviews _
            Select _
            <item>
              <title>Review of "<%= review.BookObject.Title %>" by <%= review.UserObject.Name %></title>
              <description><%= review.Comments %></description>
              <link>http://example.com/Book.aspx?ID="<%= review.BookObject.ID.ToString() %></link>
            </item> _
          %>
        </channel>
      </rss>

    Dim result = New XmlDocument()
    result.Load(xml.CreateReader())
    Return result
  End Function

End Class