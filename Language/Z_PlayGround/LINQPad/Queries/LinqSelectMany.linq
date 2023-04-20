<Query Kind="Statements" />


string[][] strs = new string[][] {
	new string[] { "A1" },
	new string[] { "B1", "B2" },
	new string[] { "C1", "C2", "C3" }
};
var flat = strs.SelectMany(arr => arr);
flat.Dump();


int[] nums = new int[] { 13, 25, 83, 77 };
var query = nums.Select(i => i.ToString().ToCharArray())
                .SelectMany(c => c);
query.Dump();
