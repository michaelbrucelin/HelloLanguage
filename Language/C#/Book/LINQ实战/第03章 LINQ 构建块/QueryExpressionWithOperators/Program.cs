using System;
using System.Linq;
using LinqInAction.LinqBooks.Common;

class Program
{
    static void Main(string[] args)
    {
        // Query expression with operators
        var authors1 = from distinctAuthor in (from book in SampleData.Books
                                               where book.Title.Contains("LINQ")
                                               from author in book.Authors.Take(1)
                                               select author)
                                               .Distinct()
                       select new { distinctAuthor.FirstName, distinctAuthor.LastName };

        Console.WriteLine("Query expression with operators:");
        foreach (var author in authors1)
            Console.WriteLine(author);

        Console.WriteLine();

        // Same query without query expression
        var authors2 = SampleData.Books
                        .Where(book => book.Title.Contains("LINQ"))
                        .SelectMany(book => book.Authors.Take(1))
                        .Distinct()
                        .Select(author => new { author.FirstName, author.LastName });

        Console.WriteLine("Without query expression:");
        foreach (var author in authors2)
            Console.WriteLine(author);
    }
}