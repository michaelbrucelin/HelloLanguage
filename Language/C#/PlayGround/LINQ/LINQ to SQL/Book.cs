using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    [Table(Name = "dbo.Book")]
    public class Book
    {
        [Column(Name = "ID", IsPrimaryKey = true)]
        public Guid BookId { get; set; }

        [Column]
        public String Isbn { get; set; }

        [Column(CanBeNull = true)]
        public string Notes { get; set; }

        [Column]
        public Int32 PageCount { get; set; }

        [Column]
        public Decimal Price { get; set; }

        [Column(Name = "PubDate")]
        public DateTime PublicationDate { get; set; }

        [Column(CanBeNull = true)]
        public String Summary { get; set; }

        [Column]
        public String Title { get; set; }

        [Column(Name = "Subject")]
        public Guid SubjectId { get; set; }

        [Column(Name = "Publisher")]
        public Guid PublisherId { get; set; }

        public override String ToString()
        {
            return Title;
        }
    }
}
