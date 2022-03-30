#region Imports

using System;
using System.Data;
using System.Configuration;
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
  static class AppCommon
  {
    public static User User
    {
      get
      {
        MembershipUser membershipUser = Membership.GetUser();
        if (membershipUser == null)
          throw new Exception("No current user.");

        Guid userId = (Guid)membershipUser.ProviderUserKey;
        if (userId.Equals(HttpContext.Current.Application["UserId"]))
          return (User)HttpContext.Current.Application["User"];

        LinqBooksDataContext dataContext = new LinqBooksDataContext();
        User user = dataContext.Users.SingleOrDefault(u => u.ID == userId);
        if (user == null)
          throw new Exception("Current user not recognized by the application.");

        HttpContext.Current.Application["UserId"] = userId;
        HttpContext.Current.Application["User"] = user;
        return user;
      }
    }
  }
}