<Query Kind="Statements" />


// 1. HashSet中值的顺序是添加进去的顺序，但是没找到资料证明这一点
HashSet<int> hashset = new HashSet<int>();
hashset.Add(10);
hashset.Add(6);
hashset.Add(8);
hashset.Add(10);
hashset.Dump("HashSet");

SortedSet<int> sortedset = new SortedSet<int>();
sortedset.Add(10);
sortedset.Add(6);
sortedset.Add(8);
sortedset.Add(10);
sortedset.Dump("SortedSet");


// 2. 引用类型以地址为准
HashSet<int[]> hash = new HashSet<int[]>();
hash.Add(new int[] { 1, 2, 3 });
hash.Add(new int[] { 1, 2, 3 });
int[] arr = new int[] { 1, 2, 3 };
hash.Add(arr);
hash.Add(arr);
hash.Add(arr);
hash.Count.Dump("hash.Count");


// 3. 
HashSet<int>[,] states = new HashSet<int>[3, 3];
states[1, 1].Add(1024);
Console.WriteLine(1024);
