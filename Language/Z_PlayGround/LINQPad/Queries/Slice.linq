<Query Kind="Statements" />


string s = "abcdefghijklmnopqrstuvwxyz";
// s[^0].Dump("s[^0]");     // 异常：Index was outside the bounds of the array.
s[^1].Dump("s[^1]");        // z
s[1..].Dump("s[1..]");      // bcdefghijklmnopqrstuvwxyz
s[1..^0].Dump("s[1..^0]");  // bcdefghijklmnopqrstuvwxyz
s[1..^0].Dump("s[1..]");    // bcdefghijklmnopqrstuvwxyz
s[1..^1].Dump("s[1..^1]");  // bcdefghijklmnopqrstuvwxy
s[2..^2].Dump("s[2..^2]");  //  cdefghijklmnopqrstuvwx
s[3..9].Dump("s[3..9]");    //   defghi

List<int> list = Enumerable.Range(0, 100).ToList();
list[^1].Dump("list[^1]");    // 99
list[^10].Dump("list[^10]");  // 90
