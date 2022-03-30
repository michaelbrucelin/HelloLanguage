#region Imports

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

using LinqBooks.Entities;

#endregion Imports

namespace LinqBooks.DataAccess
{
  public class SubjectDataAccessObject : DataAccessObject
  {
    /// <summary>
    /// Returns the list of all subjects in the database ordered by name.
    /// </summary>
    public List<Subject> GetSubjects()
    {
      return DataContext.Subjects.OrderBy(subject => subject.Name).ToList();
    }

    /// <summary>
    /// Returns the list of all subjects in the database ordered by name,
    /// with associated books loaded.
    /// </summary>
    /// <remarks>Deferred loading is disabled</remarks>
    public List<Subject> GetSubjectsWithBooksLoaded()
    {
      LinqBooksDataContext dataContext = new LinqBooksDataContext();

      // Disable lazy loading
      dataContext.DeferredLoadingEnabled = false;

      // Specify that the books should be loaded with each subject 
      DataLoadOptions loadOptions = new DataLoadOptions();
      loadOptions.LoadWith<Subject>(subject => subject.Books);
      dataContext.LoadOptions = loadOptions;

      // Query all subjects ordered by name
      var query = dataContext.Subjects.OrderBy(subject => subject.Name);

      return query.ToList();
    }
  }
}