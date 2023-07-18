<Query Kind="Statements" />


string str = new string('X', 8).Replace("X", "bc");
Regex.IsMatch(str, @"(.{2})\1{6,}").Dump();
Regex.IsMatch(str, @"(.{2})\1{7,}").Dump();
Regex.IsMatch(str, @"(.{2})\1{8,}").Dump();
Regex.IsMatch(str, @"(.{2})\1{9,}").Dump();

