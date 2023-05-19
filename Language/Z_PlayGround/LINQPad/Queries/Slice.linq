<Query Kind="Statements" />


string s = "abcdefghijklmnopqrstuvwxyz";
s[1..].Dump("s[1..]");      // bcdefghijklmnopqrstuvwxyz
s[1..^0].Dump("s[1..^0]");  // bcdefghijklmnopqrstuvwxyz
s[1..^0].Dump("s[1..]");    // bcdefghijklmnopqrstuvwxyz
s[1..^1].Dump("s[1..^1]");  // bcdefghijklmnopqrstuvwxy

List<int> list = Enumerable.Range(0, 100).ToList();
list[^1].Dump("list[^1]");
list[^10].Dump("list[^10]");
