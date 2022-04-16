/*
如果只是使用ToList()的方式将数据绑定到UI控件，那么控件中对数据的编辑就无法更新回DataSet中，同时DataSet中的任何数据更改也无法反映到查询结果与UI控件中。
可以使用CopyToDataTable()与AsDataView()来解决这个问题。
AsDataView()方法支持在UI控件和LINQ to DataSet查询结果之间实现双向绑定。
*/