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

// bit shift with int64
Console.WriteLine("bit shift with int64");
Console.WriteLine(1<<36);
Console.WriteLine(1L<<36);
