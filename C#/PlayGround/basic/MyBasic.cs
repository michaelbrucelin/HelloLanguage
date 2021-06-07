
using System.Collections.Generic;

namespace MyTestNameSpace
{
    public class MyBasic
    {
        public static IEnumerable<string> GeneratedStrings()
        {
            int i = 0;
            while (i++ < int.MaxValue)
                yield return i.ToString();
        }
    }
}