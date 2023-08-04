<Query Kind="Statements" />


IEnumerable<char> GetCharFromStrArr(string[] strs)
{
	for (int i = 0; i < strs.Length; i++)
	{
		for (int j = 0; j < strs[i].Length; j++)
			yield return strs[i][j];
		yield return 'O';
	}
}

string[] strs = new string[] { "hello", "world", "hello", "China" };

// 迭代器的使用
//foreach (char c in GetCharFromStrArr(strs))
//{
//	c.Dump();
//}

// 迭代器更细致的使用
var sequence = GetCharFromStrArr(strs);
var iterator = sequence.GetEnumerator();
while (iterator.MoveNext())
{
	iterator.Current.Dump();
}
