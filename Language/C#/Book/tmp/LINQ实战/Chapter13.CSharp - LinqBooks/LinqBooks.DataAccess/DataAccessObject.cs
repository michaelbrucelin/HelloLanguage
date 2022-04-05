#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LinqBooks.Entities;

#endregion Imports

namespace LinqBooks.DataAccess
{
  public class DataAccessObject
  {
    protected LinqBooksDataContext DataContext = new LinqBooksDataContext();
  }
}
