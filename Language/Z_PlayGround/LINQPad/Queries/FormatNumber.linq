<Query Kind="Statements" />


for (int hh = 0; hh < 24; hh++) for (int mm = 0; mm < 59; mm++)
	{
		// $"{hh:D2}:{mm:D2}".Dump();   // 00:00
		// $"{hh,-10}:{mm,10}".Dump();  // 0         :         0
		$"{hh.ToString().PadRight(10, ' ')}:{mm.ToString().PadLeft(10, ' ')}".Dump();   // 0         :         0
		// $"{hh.ToString().PadRight(0, ' ')}:{mm.ToString().PadLeft(0, ' ')}".Dump();  // 0:0
	}
