<Query Kind="Statements" />

static void Main()
{
	char[] sequence = { 'a', 'b', 'c', 'd' };
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
		for (int i = l; i <= r; i++)
		{
			Swap(arr, l, i);
			Permute(arr, l + 1, r);
			Swap(arr, l, i);
		}
	}

	void Swap(char[] arr, int i, int j)
	{
		char temp = arr[i]; arr[i] = arr[j]; arr[j] = temp;
	}
}

Main();
