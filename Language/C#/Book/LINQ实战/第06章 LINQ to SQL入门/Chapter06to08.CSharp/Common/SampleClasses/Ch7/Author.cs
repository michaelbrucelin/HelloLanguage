using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace LinqInAction.Chapter06to08.Common.SampleClasses.Ch7
{
    [Table(Name = "dbo.Author")]
    public class Author
    {
        private System.Guid _ID;
        [Column(Storage = "_ID", Name = "ID", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true, CanBeNull = false)]
        public System.Guid ID { get { return _ID; } set { _ID = value; } }
        [Column(Name = "LastName", DbType = "VarChar(50) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string LastName { get; set; }
        [Column(Name = "FirstName", DbType = "VarChar(30) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string FirstName { get; set; }
        [Column(Name = "WebSite", DbType = "VarChar(200)", UpdateCheck = UpdateCheck.Never)]
        public string WebSite { get; set; }
        [Column(Name = "TimeStamp", DbType = "rowversion NOT NULL", IsDbGenerated = true, IsVersion = true, CanBeNull = false, UpdateCheck = UpdateCheck.Always)]
        public byte[] TimeStamp { get; set; }

        private EntitySet<BookAuthor> _BookAuthors = null;

        [Association(Name = "FK_BookAuthor_Author", Storage = "_BookAuthors", OtherKey = "Author", ThisKey = "ID")]
        public EntitySet<BookAuthor> BookAuthors
        {
            get
            {
                return this._BookAuthors;
            }
            set
            {
                this._BookAuthors.Assign(value);
            }
        }
    }
}