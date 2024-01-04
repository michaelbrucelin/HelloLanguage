<Query Kind="Statements" />


string s = "abcdefghijklmnopqrstuvwxyz";
// s[^0].Dump("s[^0]");        // Exception: Index was outside the bounds of the array.
s[^1].Dump("s[^1]");           //                          z
s[1..].Dump("s[1..]");         //  bcdefghijklmnopqrstuvwxyz
s[..26].Dump("s[..26]");       // abcdefghijklmnopqrstuvwxyz
s[1..26].Dump("s[1..26]");     //  bcdefghijklmnopqrstuvwxyz
// s[1..27].Dump("s[1..27]");  // Exception: Index and length must refer to a location within the string. (Parameter 'length')
s[1..^0].Dump("s[1..^0]");     //  bcdefghijklmnopqrstuvwxyz
s[1..^1].Dump("s[1..^1]");     //  bcdefghijklmnopqrstuvwxy
s[2..^2].Dump("s[2..^2]");     //   cdefghijklmnopqrstuvwx
s[3..9].Dump("s[3..9]");       //    defghi

List<int> list = Enumerable.Range(0, 100).ToList();
list[^1].Dump("list[^1]");     // 99
list[^10].Dump("list[^10]");   // 90
