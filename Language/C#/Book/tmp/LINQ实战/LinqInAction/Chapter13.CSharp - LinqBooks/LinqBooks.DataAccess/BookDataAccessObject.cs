#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LinqBooks.Entities;

#endregion Imports

namespace LinqBooks.DataAccess
{
  public class BookDataAccessObject : DataAccessObject
  {
    public List<Book> GetBooksBySubjectName(String subjectName)
    {
      var query =
        from book in DataContext.Books
        where book.SubjectObject.Name == subjectName
        select book;
      return query.ToList();
    }
  }
}