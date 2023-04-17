<Query Kind="Statements">
  <NuGetReference>LinqToExcel</NuGetReference>
</Query>


// Process Excel
// 放弃尝试，目测是LinqToExcel库不支持.NetCore，只支持.NetFramework
string path = @"D:\我的桌面\desktop\230410\";
string file = @"QUICKCOM-STANDARD-20230406-FULL.xls";
string filepath = Path.Combine(path, file);
var excel = new LinqToExcel.ExcelQueryFactory(filepath);
// var sheet = excel.Worksheet("STANDARD rate");
var sheet = excel.Worksheet(0);  // sheetname: "STANDARD rate"
foreach (var element in sheet)
{
	element.Dump();
}
