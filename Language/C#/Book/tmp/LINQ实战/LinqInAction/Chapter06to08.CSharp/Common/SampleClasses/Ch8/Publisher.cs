using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqInAction.Chapter06to08.Common.SampleClasses.Ch8
{
  partial class Publisher : System.ComponentModel.IDataErrorInfo
  {
    const string UrlPattern = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";

    partial void OnCreated()
    {
      this.ID = Guid.NewGuid();
      this.Name = string.Empty;
      this.WebSite = string.Empty;
    }
    private string CheckRules(string columnName)
    {
      switch (columnName)
      {
        case "Name":
          if (this.Name != null)
          {
            if (this.Name.Length == 0) { return "Required"; }
            if (this.Name.Length >= 50) { return "Too long"; }
          }
          break;
        case "WebSite":
          if (this.WebSite != null)
          {
            if (this.WebSite.Length >= 200) { return "Too long"; }
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.WebSite, UrlPattern))
            { return "Not a valid URL"; }
          }
          break;
      }
      //All rules are ok, return an empty string
      return string.Empty;
    }

    #region IDataErrorInfo Members

    public string Error
    {
      get
      {
        return CheckRules("Name") +
          CheckRules("WebSite");
      }
    }

    public string this[string columnName]
    {
      get { return CheckRules(columnName); }
    }

    #endregion
  }
}