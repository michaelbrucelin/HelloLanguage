<Query Kind="Statements" />

static List<int> AllIndexesOf(string str, string value, bool overlap = false)
{
	if (string.IsNullOrEmpty(value))
		throw new ArgumentException("the string to find may not be empty", "value");

	List<int> indexes = new List<int>();
	int step = (overlap ? 1 : value.Length);
	for (int index = 0; ; index += step)
	{
		index = str.IndexOf(value, index);
		if (index == -1) return indexes;
		indexes.Add(index);
	}
}

string str = "leetcodeleetcodeleetcode";
string sub = "leet";
// str.IndexOf(sub).Dump();
// Regex.Matches(str, sub).Cast<Match>().Select(m => m.Index).Dump();
AllIndexesOf(str, sub, true).Dump();

str = "aaaaaaaaaaaaaaaa";
sub = "aaa";
// str.IndexOf(sub).Dump();
// Regex.Matches(str, sub).Cast<Match>().Select(m => m.Index).Dump();
AllIndexesOf(str, sub, true).Dump();


StringBuilder sb = new StringBuilder();
sb.Append("this");
sb.Append(" ");
sb.Append("a");
sb.Append(" ");
sb.Append("test");
sb.Append(" ");
sb.Append("sentence.");
sb.Append(" ");

sb.ToString().Dump();
sb.Length.Dump();      // 22
