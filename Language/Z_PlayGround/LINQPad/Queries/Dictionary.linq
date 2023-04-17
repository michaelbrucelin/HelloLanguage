<Query Kind="Statements" />


// 1. Dictionary中值的顺序是添加进去的顺序，但是没找到资料证明这一点
Dictionary<int, int> dic = new Dictionary<int, int>();
dic.Add(1, 1);
dic.Add(100, 100);
dic.Add(2, 2);
dic.Keys.Dump("dic.Keys");

SortedDictionary<int, int> sdic = new SortedDictionary<int, int>();
sdic.Add(1, 1);
sdic.Add(100, 100);
sdic.Add(2, 2);
sdic.Keys.Dump("sdic.Keys");


// 2. 字典可以正确地在foreach中被移除
Dictionary<int, int> dic = new Dictionary<int, int>();
for (int i = 0; i < 10; i++) dic.Add(i, i);
dic.Count.Dump("dic.Count");
dic.Keys.Dump("dic.Keys");
foreach (int key in dic.Keys) if ((key & 1) != 0) dic.Remove(key);
dic.Count.Dump("dic.Count");
dic.Keys.Dump("dic.Keys");
