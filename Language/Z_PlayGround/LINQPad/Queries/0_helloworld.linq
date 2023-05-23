<Query Kind="Statements" />


// for循环中更改list
List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
for (int i = 0; i < list.Count; i++)
{
	Console.WriteLine($"list[{i}]: {list[i]}");
	if (i < 3) list.Add(100);
}

// LinkedList
LinkedList<int> deque = new LinkedList<int>();
// deque

// StringBuilder的Length属性是字符串的长度
StringBuilder sb = new StringBuilder();
sb.Append("abc");
sb.Append("xyz");
Console.WriteLine($"sb.length: {sb.Length}");  // 6

{
	// 将字符串拆分为数组，同时保留拆分符号
	//string str = "{a,b}{c,{d,e}{f,g}}";
	//string[] strs;
	//int id = 0;
	//Console.WriteLine($"======== {++id} ========");
	//strs = Regex.Split(str, @","); for (int i = 0; i < strs.Length; i++) Console.WriteLine($"{i}\t{strs[i]}");
	//Console.WriteLine($"======== {++id} ========");
	//strs = Regex.Split(str, @"(,)"); for (int i = 0; i < strs.Length; i++) Console.WriteLine($"{i}\t{strs[i]}");
	//Console.WriteLine($"======== {++id} ========");
	//strs = Regex.Split(str, @",{}"); for (int i = 0; i < strs.Length; i++) Console.WriteLine($"{i}\t{strs[i]}");
	//Console.WriteLine($"======== {++id} ========");
	//strs = Regex.Split(str, @"([,{}])"); for (int i = 0; i < strs.Length; i++) Console.WriteLine($"{i}\t{strs[i]}");
	//Console.WriteLine($"======== {++id} ========");
	//strs = Regex.Split(str, @"(?=>[,{}])"); for (int i = 0; i < strs.Length; i++) Console.WriteLine($"{i}\t{strs[i]}");
	//Console.WriteLine($"======== {++id} ========");
	//strs = Utils.SplitAndKeep(str, new char[] { ',', '{', '}' }).ToArray();
	//for (int i = 0; i < strs.Length; i++) Console.WriteLine($"{i}\t{strs[i]}");
}

{
	//Console.WriteLine(int.Parse("03"));        // 3，不异常
	//Console.WriteLine(Convert.ToInt32("03"));  // 3，不异常
	//Console.WriteLine($"10 % 4 = {10 % 4}");
	//Console.WriteLine($"10 % 4 = {Math.DivRem(10, 4).Quotient},{Math.DivRem(10, 4).Remainder}");
	//Console.WriteLine($"10 %-4 = {10 % -4}");
	//Console.WriteLine($"10 %-4 = {Math.DivRem(10, -4).Quotient},{Math.DivRem(10, -4).Remainder}");
}

{
	//Console.WriteLine(Convert.ToString(-1, 2));
	//Console.WriteLine(Convert.ToString(-2, 2));
	//Console.WriteLine(Convert.ToString(-3, 2));

	//Console.WriteLine(Convert.ToString(-2, 2));
	//Console.WriteLine(Convert.ToString((-2 >> 0), 2));
	//Console.WriteLine(Convert.ToString(((-2 >> 0) & 1), 2));
	//Console.WriteLine(Convert.ToString((-2 >> 1), 2));
	//Console.WriteLine(Convert.ToString(((-2 >> 1) & 1), 2));
	//Console.WriteLine(Convert.ToString((-2 >> 2), 2));
	//Console.WriteLine(Convert.ToString(((-2 >> 2) & 1), 2));
}

{
	//int n = 8257285, index = 4828516, maxSum = 850015631;
	////Console.WriteLine((n - index) * (n - index) + (index + 1) * (index + 1));
	////Console.WriteLine((maxSum + (((n - index) * (n - index) + (index + 1) * (index + 1) - n - 1) >> 1)) / n);
	//Console.WriteLine((maxSum + ((1L * (n - index) * (n - index) + 1L * (index + 1) * (index + 1) - n - 1) >> 1)) / n);
	//Console.WriteLine((int)((maxSum + ((1L * (n - index) * (n - index) + 1L * (index + 1) * (index + 1) - n - 1) >> 1)) / n));
}

{
	//// SelectMany
	//string[][] strs = new string[][] {
	//    new string[] { "A1" },
	//    new string[] { "B1", "B2" },
	//    new string[] { "C1", "C2", "C3" }
	//};
	//var flat1 = strs.SelectMany(arr => arr);
	//Console.WriteLine("break point1");

	////var flat2 = strs.Select((row, rid) => new { rid, row })
	////                .SelectMany(item => item.row.Select((val, cid) => (val, cid)), (item, element) => new { element.val, item.rid, element.cid });
	//var flat2 = strs.Select((row, rid) => (row, rid))
	//                .SelectMany(item => item.row.Select((val, cid) => (val, cid)), (item, element) => (element.val, item.rid, element.cid));
	//Console.WriteLine("break point2");
}

{
	// char数组的默认值  '\0'
	//char[] chars = new char[16];
	//if (chars[0] == '\0') Console.WriteLine("yes");
}

//const int MOD = 1000000007;
//long x = 1147483647;  // int x = 1147483647;  溢出
//Console.WriteLine(x * x % MOD);

//Console.WriteLine(int.MaxValue);  // 2147483647
//Console.WriteLine("abcdefg".IndexOf("de", 4));
//foreach (int i in Enumerable.Range(19968, 100)) Console.Write(Convert.ToChar(i));


//StringBuilder sb = new StringBuilder();
//sb.Append("hello"); sb.Append(','); sb.Append(' '); sb.Append("world"); sb.Append(".");
//for (int i = 0; i < sb.Length; i++) Console.WriteLine(sb[i]);

//string[][] strs = new string[][] { new string[] { "A1" }, new string[] { "B1", "B2" }, new string[] { "C1", "C2", "C3" } };
//var flat = strs.SelectMany(arr => arr);
//Console.WriteLine();

// Console.WriteLine("wjAC".CompareTo("Zpi"));
// Console.WriteLine(StringComparer.Ordinal.Compare("wjAC", "Zpi"));
// Console.WriteLine(StringComparer.Ordinal.Compare("abc", "ABC"));
// Console.WriteLine(string.Compare("abc", "ABC"));

//char c = 'A';
//Console.WriteLine((char)(c ^ 32));



//var list = PatternSplit("aa..*d");
//Utils.ArrayToString(list.Select(item => item.pattern).ToArray());
//Console.WriteLine(Utils.ArrayToString(PatternSplit("aa..*d")));

//Console.WriteLine(Math.Floor((2 - 3) / 2d));

//C#中的指针
//unsafe
//{
//    int x = 10, y = 100;
//    int* addx = &x;
//}

//Console.WriteLine(Utils.GenerateRandomIntArray(30, 0, 1000));

//List<int> list = Enumerable.Range(0, 10).ToList();
//Console.WriteLine(list[-1]);

// 检查整型是否溢出
//int x = int.MaxValue;
//Console.WriteLine(x);
//Console.WriteLine($"checked(x-1): {checked(x - 1)}");
//Console.WriteLine($"checked(x+1): {checked(x + 1)}");

{
	//bool[] arr = new bool[10];  // 默认值是false
	//Console.WriteLine(arr[8]);

	//char[] arr = new char[10];    // 默认值是0
	//Console.WriteLine(arr[8]);
	//Console.WriteLine((int)arr[8]);
	//Console.WriteLine(arr[8] == null);  // 没有意义的比较，int永远不为null
}

//(int a, int b)[] tuples = new (int, int)[10];
//Console.WriteLine($"a={tuples[0].a}, b={tuples[0].b}");  // 值元组有默认值，默认值为0

//Tuple<int, int, int> tuple = new Tuple<int, int, int>(1, 2, 3);
//Console.WriteLine(tuple.ToString());

//(int, int, int) tuple2 = (1, 2, 3);
//Console.WriteLine(tuple2.ToString());
