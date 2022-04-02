using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Data.SqlClient;

namespace LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped
{
  /// <summary>
  /// Subject class definition from listing 6.3
  /// </summary>
  public class Subject
  {
    public Guid SubjectId { get; set; }
    public String Description { get; set; }
    public String Name { get; set; }

    public static IEnumerable<Subject> GetSubjects()
    {
      List<Subject> subjects = new List<Subject>();
      using (SqlConnection connection = new SqlConnection(LinqInAction.Chapter06to08.Common.Properties.Settings.Default.liaConnectionString))
      {
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT ID, Name, Description FROM dbo.Subject";
        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            Subject newSubject = new Subject();
            if (!reader.IsDBNull(0)) { newSubject.SubjectId = reader.GetGuid(0); }
            if (!reader.IsDBNull(1)) { newSubject.Description = reader.GetString(1); }
            if (!reader.IsDBNull(2)) { newSubject.Name = reader.GetString(2); }
            subjects.Add(newSubject);
          }
        }
      }
      return subjects;
    }
  }
}
namespace LinqInAction.Chapter06to08.Common.SampleClasses.Ch6
{
  /// <summary>
  /// Subject class definition from listing 6.3
  /// </summary>
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
      DataContext context = new DataContext(LinqInAction.Chapter06to08.Common.Properties.Settings.Default.liaConnectionString);
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