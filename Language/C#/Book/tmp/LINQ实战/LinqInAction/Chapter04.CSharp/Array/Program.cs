using System;
using System.Linq;

static class TestArray
{
    static void Main()
    {
        Object[] array = { "String", 12, true, 'a' };

        var types = array
            .Select(item => item.GetType().Name)
            .OrderBy(type => type);

        ObjectDumper.Write(types);
    }
}