using System;
using System.Collections.Generic;
using System.Linq;

static class TestString
{
    static void Main()
    {
        var count = "Non-letter characters in this string: 8"
            .Where(c => !Char.IsLetter(c))
            .Count();
        Console.WriteLine(count);
    }
}
