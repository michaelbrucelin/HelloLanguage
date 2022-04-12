using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    [Table(Name = "dbo.Author")]
    public class Author
    {
        [Column(Name = "ID", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true, CanBeNull = false)]
        public Guid ID { get; set; }

        [Column(Name = "LastName", DbType = "VarChar(50) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string LastName { get; set; }

        [Column(Name = "FirstName", DbType = "VarChar(30) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string FirstName { get; set; }

        [Column(Name = "WebSite", DbType = "VarChar(200)", UpdateCheck = UpdateCheck.Never)]
        public string WebSite { get; set; }

        [Column(Name = "TimeStamp", DbType = "rowversion NOT NULL", IsDbGenerated = true, IsVersion = true, CanBeNull = false, UpdateCheck = UpdateCheck.Always)]
        public byte[] TimeStamp { get; set; }
    }
}
