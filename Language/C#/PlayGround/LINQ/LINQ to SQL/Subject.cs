using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    [Table]
    public class Subject
    {
        public Subject()
        {
            this._Books = new EntitySet<Book>(new Action<Book>(this.attach_Books), new Action<Book>(this.detach_Books));
        }

        [Column(IsPrimaryKey = true, Name = "ID")]
        public Guid SubjectId { get; set; }

        [Column]
        public String Description { get; set; }

        [Column]
        public String Name { get; set; }

        public static IEnumerable<Subject> GetSubjects()
        {
            DataContext context = new DataContext("Data Source=.;Initial Catalog=LIA;Integrated Security=true;");
            return context.GetTable<Subject>();
        }

        private EntitySet<Book> _Books;

        [Association(Name = "Subject_Book", Storage = "_Books", OtherKey = "SubjectId")]
        public EntitySet<Book> Books
        {
            get
            {
                return this._Books;
            }
            set
            {
                this._Books.Assign(value);
            }
        }

        private void attach_Books(Book entity)
        {
            // entity.Subject1 = this;
        }

        private void detach_Books(Book entity)
        {
            // entity.Subject1 = null;
        }
    }
}