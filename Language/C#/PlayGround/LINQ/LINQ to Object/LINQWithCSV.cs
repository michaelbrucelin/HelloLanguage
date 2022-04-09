using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"..\SampleData\books.csv"))
            {
                var books = from line in reader.Lines()
                            where !line.StartsWith("#")
                            let parts = line.Split(',')
                            select new
                            {
                                ISBN = parts[0],
                                Title = parts[1],
                                Publisher = parts[3],
                                Authors = from authorFullName in parts[2].Split(';')
                                          let authorNameParts = authorFullName.Split(' ')
                                          select new
                                          {
                                              FirstName = authorNameParts[0],
                                              LastName = authorNameParts[1]
                                          }
                            };

                ObjectDumper.Write(books, 1);
            }

            Console.ReadLine();
        }
    }

    public static class MyLinqExtensions
    {
        public static IEnumerable<string> Lines(this StreamReader source)
        {
            string line;

            if (source == null)
                throw new ArgumentNullException("source");

            while ((line = source.ReadLine()) != null)
                yield return line;
        }
    }
}