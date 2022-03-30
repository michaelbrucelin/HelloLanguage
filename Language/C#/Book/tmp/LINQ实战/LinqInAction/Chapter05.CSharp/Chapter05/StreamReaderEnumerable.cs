using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LinqInAction.Chapter05
{
  /// <summary>
  /// Contains operators for LINQ to Text Files
  /// </summary>
  public static class StreamReaderEnumerable
  {
    public static IEnumerable<String> Lines(this StreamReader source)
    {
      String line;

      if (source == null)
        throw new ArgumentNullException("source");

      while ((line = source.ReadLine()) != null)
        yield return line;
    }
  }
}