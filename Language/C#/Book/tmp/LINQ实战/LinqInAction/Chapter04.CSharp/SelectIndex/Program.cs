using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using LinqInAction.LinqBooks.Common;

static class TestSelectIndex
{
    static void Main()
    {
        var books = SampleData.Books
            .Select((book, index) => new { index, book.Title })
            .OrderBy(book => book.Title);
        ObjectDumper.Write(books);
    }
}