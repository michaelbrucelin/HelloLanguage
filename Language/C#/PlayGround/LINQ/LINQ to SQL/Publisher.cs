using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace TestCSharp
{
    [Table(Name = "dbo.Publisher")]
    public class Publisher
    {
        [Column(Name = "ID", IsPrimaryKey = true)]
        public Guid ID { get; set; }

        [Column]
        public String Name { get; set; }

        [Column(DbType = "Image", UpdateCheck = UpdateCheck.Never)]
        public byte[] Logo { get; set; }

        [Column(DbType = "VarChar(200)", CanBeNull = false)]
        public string WebSite { get; set; }

        public override String ToString()
        {
            return Name;
        }
    }
}
