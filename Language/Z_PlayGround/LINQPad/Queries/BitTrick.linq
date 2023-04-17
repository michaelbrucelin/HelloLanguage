<Query Kind="Statements" />


// 获取QWER
Console.WriteLine($"Q: {('Q' >> 1) & 3}");
Console.WriteLine($"W: {('W' >> 1) & 3}");
Console.WriteLine($"E: {('E' >> 1) & 3}");
Console.WriteLine($"R: {('R' >> 1) & 3}");

// bit shift with int64
Console.WriteLine("bit shift with int64");
Console.WriteLine(1 << 36);
Console.WriteLine(1L << 36);
