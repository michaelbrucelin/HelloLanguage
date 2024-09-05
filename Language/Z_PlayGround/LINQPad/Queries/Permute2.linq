<Query Kind="Statements" />

static void Main()
{
	char[] sequence = { 'a', 'b', 'a', 'd' };
	Array.Sort(sequence);  // 排序数组以便重复检测
	Permute(sequence, 0, sequence.Length - 1);
}

static void Permute(char[] arr, int l, int r)
{
	if (l == r)
	{
		Console.WriteLine(new string(arr));
	}
	else
	{
		HashSet<char> seen = new HashSet<char>();                 // 用于记录已经出现过的元素
		for (int i = l; i <= r; i++) if (!seen.Contains(arr[i]))  // 如果当前元素未出现过
			{
				seen.Add(arr[i]);                                 // 记录当前元素
				Swap(arr, l, i);
				Permute(arr, l + 1, r);
				Swap(arr, l, i);                                  // 交换回原来的位置
			}
	}

	void Swap(char[] arr, int i, int j)
	{
		char temp = arr[i]; arr[i] = arr[j]; arr[j] = temp;
	}
}

Main();
