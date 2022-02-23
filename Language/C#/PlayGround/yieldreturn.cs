using System.Collections.Generic;
using System.Linq;

namespace PlayGround
{
    public class YieldReturn
    {
        public static void Main()
        {
            Enumerable.Range(1, 10).ToList().ForEach(i => System.Console.WriteLine(i));
        }

        public static IEnumerable<string> GeneratedStrings()
        {
            int i = 0;
            while (i++ < int.MaxValue)
                yield return i.ToString();
        }
    }
}