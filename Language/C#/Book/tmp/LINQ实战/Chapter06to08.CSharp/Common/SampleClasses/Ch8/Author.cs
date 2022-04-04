using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;

namespace LinqInAction.Chapter06to08.Common.SampleClasses.Ch8
{
    public partial class Author // : System.ComponentModel.IDataErrorInfo
    {
        public string FormattedName
        {
            get
            {
                return this.FirstName + ' ' + this.LastName;
            }
        }

        private string CheckRules(string columnName)
        {
            switch (columnName)
            {
                case "FirstName":
                    //required
                    if (this.FirstName.Length == 0) { return "Required "; }
                    //max length=20
                    if (this.FirstName.Length > 20) { return "Too long "; }
                    break;
                case "LastName":
                    //required
                    if (this.LastName.Length == 0) { return "Required "; }
                    //max length=20
                    if (this.LastName.Length > 20) { return "Too long "; }
                    break;
                case "WebSite":
                    //should be valid url
                    if (!System.Text.RegularExpressions.Regex.IsMatch(this.WebSite, "pattern")) { return "Not a valid URL "; }
                    break;
            }
            //All rules are ok, return an empty string
            return string.Empty;
        }
    }
}