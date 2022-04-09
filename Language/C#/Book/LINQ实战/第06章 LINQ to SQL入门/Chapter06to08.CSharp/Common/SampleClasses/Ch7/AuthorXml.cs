using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace LinqInAction.Chapter06to08.Common.SampleClasses.Ch7
{
    public class AuthorXml
    {
        private System.Guid _Id;
        private EntitySet<BookAuthor> _BookAuthors = null;

        public System.Guid ID
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string WebSite { get; set; }
        public byte[] TimeStamp { get; set; }

        public global::System.Data.Linq.EntitySet<BookAuthor> BookAuthors
        {
            get { return this._BookAuthors; }
            set { this._BookAuthors.Assign(value); }
        }
    }
}