// This code has been provided by Andrew Conrad from Microsoft
// See http://blogs.msdn.com/aconrad/archive/2007/09/07/science-project.aspx

using System;
using System.Collections.Generic;
using System.Data;

namespace LinqInAction.Chapter14
{
  public static class DataSetLinqOperators
  {
    /// <summary>
    /// Creates a <see cref="DataTable"/> that contains the data from a source sequence.
    /// </summary>
    /// <remarks>
    /// The initial schema of the DataTable is based on schema of the type T. All public property and fields are turned into DataColumns.
    ///  If the source sequence contains a sub-type of T, the table is automatically expanded for any addition public properties or fields.
    /// </remarks>
    public static DataTable ToDataTable<T>(this IEnumerable<T> source)
    {
      return new ObjectShredder<T>().Shred(source, null, null);
    }

    /// <summary>
    /// Loads the data from a source sequence into an existing <see cref="DataTable"/>.
    /// </summary>
    /// <remarks>
    /// The schema of <paramref name="table" /> must be consistent with the schema of the type T (all public property and fields are mapped to DataColumns).
    /// If the source sequence contains a sub-type of T, the table is automatically expanded for any addition public properties or fields.
    /// </remarks>
    public static DataTable LoadSequence<T>(this IEnumerable<T> source,
      DataTable table, LoadOption? options)
    {
      if (table == null)
        throw new ArgumentNullException("table");
      return new ObjectShredder<T>().Shred(source, table, options);
    }
  }
}