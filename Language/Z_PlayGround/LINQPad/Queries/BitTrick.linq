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

// 常用位运算整理
int n = 123456789;
Convert.ToString(n, 2).Dump();
// Convert.ToString(n >> 1, 2).Dump();        // 去掉最后1位，n/2
// Convert.ToString(n << 1, 2).Dump();        // 在最后补0，n*2
// Convert.ToString((n << 1) + 1, 2).Dump();  // 在最后补1，n*2+1
Convert.ToString(n | (1 << (7 - 1)), 2).Dump();     // 右数第k(7)位置1
Convert.ToString(n & (~(1 << (7 - 1))), 2).Dump();  // 右数第k(7)位置0
Convert.ToString(n ^ (1 << (7 - 1)), 2).Dump();     // 右数第k(7)位取反
Convert.ToString(n & ((1 << 7) - 1), 2).Dump();     // 取左数末k(7)位
