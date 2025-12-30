<Query Kind="Statements">
  <NuGetReference>LinqToExcel</NuGetReference>
</Query>

-- 安装安装nuget包ExcelDataReader
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
string excel = @"C:\Users\Q1953\数据\Software\DuckDB\QUICKCOM-STANDARD-20251225-FULL.xlsx";

using var stream = File.Open(excel, FileMode.Open, FileAccess.Read);
using var reader = ExcelReaderFactory.CreateReader(stream);

var rows = new List<Dictionary<string, object>>();

string[] headers = null;
while (reader.Read())
{
	if (headers == null)
	{
		headers = new string[reader.FieldCount];
		for (int i = 0; i < reader.FieldCount; i++) headers[i] = reader.GetValue(i)?.ToString();
	}
	else
	{
		var row = new Dictionary<string, object>();
		for (int i = 0; i < reader.FieldCount; i++) row[headers[i]] = reader.GetValue(i);
		rows.Add(row);
	}
}

var query = rows.Where(r => r["CODES"].ToString().StartsWith("93"));
foreach (string col in headers) Console.Write($"{col}\t");
Console.WriteLine();
foreach (var row in query)
{
	foreach (string col in headers) Console.Write($"{row[col]}\t"); Console.WriteLine();
}