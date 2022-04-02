using System;
using System.Collections.Generic;
using System.Linq;
using LinqInAction.LinqBooks.Common;

static class TestArray
{
    static void Main()
    {
        Book[] books = {
            new Book { Title="LINQ in Action" },
            new Book { Title="LINQ for Fun" },
            new Book { Title="Extreme LINQ" } };

        var titles = books
            .Where(book => book.Title.Contains("Action"))
            .Select(book => book.Title);

        ObjectDumper.Write(titles);
    }
}