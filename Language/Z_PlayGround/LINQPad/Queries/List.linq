<Query Kind="Statements" />


// 1. LinkedList不是环形链表
LinkedList<int> link = new LinkedList<int>();
for (int i = 0; i < 8; i++) link.AddLast(i);
var ptr = link.First;
for (int i = 0; i < 18; i++)
{
	Console.WriteLine(ptr.Value); ptr = ptr.Next;
}


// 2. 列表在foreach中不可以被移除，会异常
List<int> list = new List<int>();
for (int i = 0; i < 10; i++) list.Add(i);
list.Count.Dump("list.Count");
list.Dump("list");
foreach (int key in list) if ((key & 1) != 0) list.Remove(key);
list.Count.Dump("list.Count");
list.Dump("list");


// 3. List.Remove()只Remove掉第一个匹配的值，如果列表中不存在匹配的值，也不会异常
List<int> list = new List<int>();
list.AddRange(Enumerable.Range(0, 10));
list.Dump("list");                       // [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 ]
list.AddRange(Enumerable.Range(5, 10));
list.Dump("list");                       // [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 ]
list.Remove(7);
list.Dump("list");                       // [ 0, 1, 2, 3, 4, 5, 6, 8, 9, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 ]
list.Remove(100);
list.Dump("list");


// 4. 
SortedList<int, int> list = new SortedList<int, int>();
list.Add(5, 5);
list.Add(4, 4);
list.Add(1, 1);
list.Add(2, 2);
list.Add(0, 0);
list.Add(2, 2);  // 报错
Console.WriteLine($"{list.Values[0]}, {list.Values[1]}, {list.Values[2]}, {list.Values[3]}, {list.Values[4]}");
