<Query Kind="Statements" />


string s = "abcdefghijklmnopqrstuvwxyz";
Console.WriteLine(s[1..]);    // bcdefghijklmnopqrstuvwxyz
Console.WriteLine(s[1..^0]);  // bcdefghijklmnopqrstuvwxyz
Console.WriteLine(s[1..^1]);  // bcdefghijklmnopqrstuvwxy
