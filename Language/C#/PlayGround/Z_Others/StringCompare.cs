using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Program
    {
        /// <summary>
        /// char与string的比较方法
        /// char默认按照ASCII码表排序，实际上不是ASCII，而是每个char的Unicode码位。
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            {   // char
                Console.WriteLine("char");
                char[] chars = new char[] { '(', '2', '<', 'Z', 'x', ')', '=', '[', 'y', '*', '>', '\\', 'z', '!', '+', '?', ']', '{', '"', ',', '6', '@', '^', '|', '\'',
                                            '#', '-', 'A', '_', '}', '$', '.',  'B', '`', '~', '%', '/', '9', 'C', 'a', '&', '0', ':', 'X', 'b', '1', ';', 'Y', 'c' };

                Array.Sort(chars);
                foreach (char c in chars) Console.Write($"{c} "); Console.WriteLine();
                // ! " # $ % & ' ( ) * + , - . / 0 1 2 6 9 : ; < = > ? @ A B C X Y Z [ \ ] ^ _ ` a b c x y z { | } ~
                // 可以看出来char类型默认的排序就是按照ASCII码表排序的
            }

            {   // string
                Console.WriteLine("string");
                string[] strs = new string[] { "(", "2", "<", "Z", "x", ")", "=", "[", "y", "*", ">", "\\", "z", "!", "+", "?", "]", "{", "\"", ",", "6", "@", "^", "|", "'",
                                               "#", "-", "A", "_", "}", "$", ".",  "B", "`", "~", "%", "/", "9", "C", "a", "&", "0", ":", "X",  "b", "1", ";", "Y", "c" };

                string[] copy = strs.ToArray(); Array.Sort(copy);
                foreach (string s in copy) Console.Write($"{s} "); Console.WriteLine();
                // ' - ! " # $ % & ( ) * , . / : ; ? @ [ \ ] ^ _ ` { | } ~ + < = > 0 1 2 6 9 a A b B c C x X y Y z Z
                // 按照一种莫名奇妙的顺序排序的，查阅文档知按照CultureInfo排序

                Console.Write("default:                ");                            // 与默认一样，按照CultureInfo排序，即StringComparison.CurrentCulture
                var query = strs.OrderBy(s => s);
                foreach (string s in query) Console.Write($"{s} "); Console.WriteLine();

                Console.Write("string.Compare(s1, s2): ");                            // 与默认一样，按照CultureInfo排序，即StringComparison.CurrentCulture
                var compare = Comparer<string>.Create((s1, s2) => string.Compare(s1, s2));
                query = strs.OrderBy(c => c, compare);
                foreach (string s in query) Console.Write($"{s} "); Console.WriteLine();

                Console.Write("s1.CompareTo(s2):       ");                            // 与默认一样，按照CultureInfo排序，即StringComparison.CurrentCulture
                compare = Comparer<string>.Create((s1, s2) => s1.CompareTo(s2));
                query = strs.OrderBy(c => c, compare);
                foreach (string s in query) Console.Write($"{s} "); Console.WriteLine();

                Console.Write("StringComparer.Ordinal.Compare(s1, s2):           ");  // 按照ASCII码排序
                compare = Comparer<string>.Create((s1, s2) => StringComparer.Ordinal.Compare(s1, s2));
                query = strs.OrderBy(c => c, compare);
                foreach (string s in query) Console.Write($"{s} "); Console.WriteLine();

                Console.Write("StringComparer.OrdinalIgnoreCase.Compare(s1, s2): ");  // 按照ASCII码排序，不区分大小写（将小写提前，即大小写中间的放后面）
                compare = Comparer<string>.Create((s1, s2) => StringComparer.OrdinalIgnoreCase.Compare(s1, s2));
                query = strs.OrderBy(c => c, compare);
                foreach (string s in query) Console.Write($"{s} "); Console.WriteLine();
                // ! " # $ % & ' ( ) * + , - . / 0 1 2 6 9 : ; < = > ? @ A a B b C c x X y Y Z z [ \ ] ^ _ ` { | } ~
            }

            Console.ReadKey();
        }
    }
}
