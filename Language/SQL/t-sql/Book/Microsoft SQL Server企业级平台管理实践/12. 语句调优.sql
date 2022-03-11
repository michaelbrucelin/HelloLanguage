第12章  语句调优 – 知识准备
	为了说明问题方便，请先在AdventureWorks数据库里建立两张新的范例表格。
use adventureworks
go
drop table dbo.SalesOrderHeader_test
go
drop table dbo.SalesOrderDetail_test
go
select * into dbo.SalesOrderHeader_test
from Sales.SalesOrderHeader
go
select * into dbo.SalesOrderDetail_test
from Sales.SalesOrderDetail
go
create clustered index SalesOrderHeader_test_CL 
on dbo.SalesOrderHeader_test (SalesOrderID)
go
create index SalesOrderDetail_test_NCL
on dbo.SalesOrderDetail_test (SalesOrderID)
go


--下面我们再在dbo.SalesOrderHeader_test里加入9条订单记录，它们的编号是从75124到75132。这是九张特殊的订单，每条有12万多条详细记录。也就是说，dbo.SalesOrderDetail_test里会有90%的数据是属于这九张订单的。我们用下面这句话来得到模拟数据。
declare @i int
set @i = 1
while @i<=9
begin
insert into dbo.SalesOrderHeader_test
(RevisionNumber, OrderDate, DueDate,
ShipDate,Status, OnlineOrderFlag, SalesOrderNumber,PurchaseOrderNumber,
AccountNumber, CustomerID,ContactID, SalesPersonID, TerritoryID,
 BillToAddressID, ShipToAddressID, ShipMethodID, CreditCardID,
CreditCardApprovalCode, CurrencyRateID, SubTotal,TaxAmt,
Freight,TotalDue, Comment,rowguid,ModifiedDate)
select RevisionNumber, OrderDate, DueDate,
ShipDate,Status, OnlineOrderFlag, SalesOrderNumber,PurchaseOrderNumber,
AccountNumber, CustomerID,ContactID, SalesPersonID, TerritoryID,
 BillToAddressID, ShipToAddressID, ShipMethodID, CreditCardID,
CreditCardApprovalCode, CurrencyRateID, SubTotal,TaxAmt,
Freight,TotalDue, Comment,rowguid,ModifiedDate
from dbo.SalesOrderHeader_test
where SalesOrderID = 75123
insert into dbo.SalesOrderDetail_test
(SalesOrderID, CarrierTrackingNumber, OrderQty, ProductID,
SpecialOfferID,UnitPrice,UnitPriceDiscount,LineTotal,
rowguid,ModifiedDate)
select 75123+@i, CarrierTrackingNumber, OrderQty, ProductID,
SpecialOfferID,UnitPrice,UnitPriceDiscount,LineTotal,
rowguid, getdate()
from Sales.SalesOrderDetail
set @i = @i +1
end
go

--在后面的内容里，将用这两张表作例子。在12.1.1小节里，还会为SalesOrderDetail_test建立这两个索引。现在请不要创建它们。
create clustered index SalesOrderDetail_test_CL
on dbo.SalesOrderDetail_test (SalesOrderDetailID)
go
create index SalesOrderDetail_test_NCL_Price
on dbo.SalesOrderDetail_test (UnitPrice)
go


12.1 索引与统计信息
12.1.1 索引上的数据检索方法
A. 以dbo.SalesOrderDetail_test为例子。它的上面没有clustered index，只有一个在SalesOrderID上的nonclustered index。所以表格的每一行记录，不会按照任何顺序，随意地存放在Hash里。（详细的知识，请参见第一章的1.2.1小节。）
这时候如果用户要找所有单价大于200的销售详细记录，要运行的语句会是：
select SalesOrderDetailID, UnitPrice 
from dbo.SalesOrderDetail_test
where UnitPrice > 200

B. 如果这个表格上有clustered index，事情会怎样呢？还是以刚才那张表作例子，先给它在值是唯一的字段SalesOrderDetailID上建立一个clustered index。这样所有的数据都会按照Clustered Index的顺序存储。
create clustered index SalesOrderDetail_test_CL
on dbo.SalesOrderDetail_test (SalesOrderDetailID)
go

C. 现在在UnitPrice上面建一个nonclustered index，看看情况会有什么变化。
create index SalesOrderDetail_test_NCL_Price
on dbo.SalesOrderDetail_test (UnitPrice)
go

D.但是光用建立在UnitPrice上的索引不能告诉我们其它字段的值。如果在刚才那个查询里再增加几个字段返回，SQL Server就需要先在nonclustered index上找到所有UnitPrice大于200的记录，然后再根据SalesOrderDetailID的值找到存储在clustered index上的详细数据。这个过程可以称为”Bookmark Lookup”。
select SalesOrderID, SalesOrderDetailID, UnitPrice 
from dbo.SalesOrderDetail_test with (index (SalesOrderDetail_test_NCL_Price))
where UnitPrice > 200

12.1.2 统计信息的含义与作用
SalesOrderHeader_test保存的是每张订单的概要信息，一张订单只会有一条记录，所以SalesOrderID是不会重复的。现在这张表里，应该有31474条记录。SalesOrderID是一个int型的字段，所以字段长度是4。运行dbcc show_statistics(<table_name>, <index_or_statistics_name>)命令，可以得到统计信息内容:
dbcc show_statistics (SalesOrderHeader_test, SalesOrderHeader_test_CL )

所以下面这两句话虽然结构一模一样，但是因为参数值不同，SQL Server选择了不同的执行计划。这是因为SQL Server知道，前一个参数只会返回3行(EstimateRows)，而后一个会返回121317行。这里SQL Server“猜”得是完全正确的。
select b.SalesOrderID, b.OrderDate, a.*
from dbo.SalesOrderDetail_test a 
inner join dbo.SalesOrderHeader_test b
on a.SalesOrderID = b.SalesOrderID
where b.SalesOrderID = 72642
 
select b.SalesOrderID, b.OrderDate, a.*
from dbo.SalesOrderDetail_test a 
inner join dbo.SalesOrderHeader_test b
on a.SalesOrderID = b.SalesOrderID
where b.SalesOrderID = 75127

12.1.3 统计信息的维护和更新
A. 例如，当语句要在某个（或者某几个）字段上作过滤，或者要拿它（们）和另外一张表做联接(join)，SQL Server要估算最后从这张表会返回多少条记录。这时候就需要一个统计信息的支持。如果没有，SQL Server会自动创建一个。
我们可以在SalesOrderHeader_test上试试。
sp_helpstats SalesOrderHeader_test
go
-- 返回表格没有statistics（索引上的除外）
select count(*) from
dbo.SalesOrderHeader_test
where OrderDate = '2004-06-11 00:00:00.000'
go
-- 运行一句在OrderDate上有过滤条件的查询
sp_helpstats SalesOrderHeader_test
go

12.2 编译与重编译
A. 例如运行下面的指令，连续两次查询Sys.syscacheobjects视图：
dbcc freeproccache
go
select * from 
Sys.syscacheobjects
go
select * from Sys.syscacheobjects
go

B.例如下面，把同样一句话跑两遍，会发现只有一个执行计划，而且它被使用过两次(字段usecounts = 2)。
dbcc freeproccache
go
select * from Sys.syscacheobjects
go
select * from Sys.syscacheobjects
go

C.例如下面这个例子，同一句话运行了三遍。第一和第二遍用的是一样的参数值，所以第二次没有再做编译(有事件SP:CacheHit)。但是第三次的参数值不同，它就再编译了一遍(SP:CacheMiss和SP:CacheInsert)。
dbcc freeproccache
go
declare @dbid varchar(10)
set @dbid = '9'
exec('select * from Sys.syscacheobjects where dbid <= ' + @dbid)
set @dbid = '9'
exec('select * from Sys.syscacheobjects where dbid <= ' + @dbid)
set @dbid = '10'
exec('select * from Sys.syscacheobjects where dbid <= ' + @dbid)
go

D.对于一些比较简单的查询，SQL Server 2005自己就可以做自动参数化，把语句里的参数用一个变量代替，以提高执行计划的可重用性。例如运行下面这几条语句：
use adventureworks
go
dbcc freeproccache
go
SELECT ProductID, SalesOrderID 
FROM Sales.SalesOrderDetail  
WHERE ProductID > 1000 
go
SELECT ProductID, SalesOrderID 
FROM Sales.SalesOrderDetail  
WHERE ProductID > 2000 
go
select * from Sys.syscacheobjects
go

两条查询语句一模一样，只是参数的值不同。当察看缓存里的执行计划时，就能发现，SQL不但缓存了两条语句自己的执行计划，还缓存了一个参数化了的执行计划。
 
如果再运行一句类似的语句：
SELECT ProductID, SalesOrderID 
FROM Sales.SalesOrderDetail  
WHERE ProductID > 3000 
go

E.改用sp_executesql能够更有效地增加执行计划重用。用下面这个例子，两个查询结构一样，仅参数不同。
use adventureworks
go
dbcc freeproccache
go
EXEC sp_executesql N'SELECT p.ProductID, p.Name, p.ProductNumber
FROM Production.Product p  
INNER JOIN Production.ProductDescription pd  
ON p.ProductID = pd.ProductDescriptionID
WHERE p.ProductID = @a', N'@a int', 170 
go
EXEC sp_executesql N'SELECT p.ProductID, p.Name, p.ProductNumber
FROM Production.Product p  
INNER JOIN Production.ProductDescription pd  
ON p.ProductID = pd.ProductDescriptionID
WHERE p.ProductID = @a', N'@a int', 1201
go
select * from Sys.syscacheobjects
go

F.Keep Plan放宽了对临时表的重编译阀值，使得SQL Server象对普通表格一样对待临时表，不会在上面做额外的重编译。用户可以象下面这样使用它。
SELECT B.col4, sum(A.col1) 
FROM dbo.PermTable A INNER JOIN #TempTable B ON A.col1 = B.col2 
WHERE B.col3 < 100 
GROUP BY B.col4 
OPTION (KEEP PLAN)
KeepFixed Plan强制查询优化器不因统计信息的更改而重新编译查询。只有在基础表的结构发生变化后，或者有人运行过sp_recompile以后，才会发生重编译。用户可以象下面这样使用它。
SELECT c.TerritoryID, count(*) as Number, c.SalesPersonID 
FROM Sales.Store s INNER JOIN Sales.Customer c 
ON s.CustomerID = c.CustomerID 
WHERE s.Name LIKE '%Bike%' AND c.SalesPersonID > 285 
GROUP BY c.TerritoryID, c.SalesPersonID 
ORDER BY Number DESC 
OPTION (KEEPFIXED PLAN)

12.3读懂执行计划
A.现在请运行下面的语句，看看这两种方法会返回什么样的结果。
set showplan_all on
go
select a.SalesOrderID, a.OrderDate, a.CustomerID, 
b.SalesOrderDetailID, b.ProductID, b.OrderQty, b.UnitPrice 
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
where a.SalesOrderID = 43659
-- 只返回执行计划，没有结果集返回。
-- 执行计划里只有”EsitmateRows”，没有”Rows”（实际行数）。
go
set showplan_all off
go
set statistics profile on
go
select a.SalesOrderID, a.OrderDate, a.CustomerID, 
b.SalesOrderDetailID, b.ProductID, b.OrderQty, b.UnitPrice 
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
where a.SalesOrderID = 43659
-- 先返回结果集，再返回执行计划
-- 执行计划里有”EsitmateRows”，也有”Rows”（实际行数）。
go
set statistics profile off
go

B.现在来看看原先这句查询，如果是手工做的话，你会怎么做：
select a.SalesOrderID, a.OrderDate, a.CustomerID, 
b.SalesOrderDetailID, b.ProductID, b.OrderQty, b.UnitPrice 
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
where a.SalesOrderID = 43659

12.3.1联接（Join）
例如下面这同一句查询，因为有不同的join hint，选择的联接也有不同。
set statistics profile on
go
select count(b.SalesOrderID)
from dbo.SalesOrderHeader_test a 
inner loop join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
where a.SalesOrderID >43659 and a.SalesOrderID< 53660
go
select count(b.SalesOrderID)
from dbo.SalesOrderHeader_test a 
inner merge join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
where a.SalesOrderID >43659 and a.SalesOrderID< 53660
go
select count(b.SalesOrderID)
from dbo.SalesOrderHeader_test a 
inner hash join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
where a.SalesOrderID >43659 and a.SalesOrderID< 53660
go

12.3.2其他常见的运算操作
A. Aggrenation也分两种，Stream Aggregation（将数据集排成一个队列以后做运算）和Hash Aggregation（类似于Hash Join，需要SQL Server先建立Hash表，然后才能做运算）。例如：
set statistics profile on
go
select max(SalesOrderDetailID)
from dbo.SalesOrderDetail_test
-- Stream Aggregation
go
select SalesOrderID, count(SalesOrderDetailID)
from dbo.SalesOrderDetail_test
group by SalesOrderID
-- Stream Aggregation
go

select CustomerID, count(*)
from dbo.SalesOrderHeader_test
group by CustomerID
-- Hash Aggregation
go

B. Union All很简单，就是合并两个集合，不管里面是否有重复的数据。例如：
select distinct ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 776
union all
select distinct ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 776

但是Union就不同了。它不但要合并两个数据集，还要把其中重合的数据删除。所以SQL Server需要把合并以后的结果集进行一个排序。这是比较昂贵的。例如：
select distinct ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 776
union 
select distinct ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 776

C.	还是看这条语句。
select distinct ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 776
go
	它的并行执行计划很有意思。

12.4 读懂语句运行统计信息
12.4.1 Set statistics time on
A.请先来看看Set statistics time on会返回什么信息。先运行语句：
dbcc dropcleanbuffers
-- 清除buffer pool里的所有缓存的数据
dbcc freeproccache
go
-- 清除buffer pool里的所有缓存的执行计划
go
Set statistics time on
go
select distinct ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 777
union
select ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 777
go
Set statistics time off
go

B.	现在再做一遍语句，但是不清除任何缓存。
Set statistics time on
go
select distinct ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 776
union
select ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 776
go

12.4.2 Set statistics io on
A.还是以刚才那个查询作例子。
dbcc dropcleanbuffers
go
Set statistics io on
go
select distinct ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 777
go

B. 	然后再来运行一遍，不清空缓存。
Set statistics io on
go
select distinct ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 777
go

12.4.3 Set statistics profile on
A. 本章前面其实已经使用过了这个设置的返回结果来分析执行计划。现在再来完整地介绍一下。先从一个最简单的查询谈起。
Set statistics profile on
go
select distinct ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 777
go

B. 	让我们再运行一句稍微复杂一点的语句，看看结果会怎么样。
set statistics profile on
go
select count(b.SalesOrderID)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
where a.SalesOrderID >43659 and a.SalesOrderID< 53660
go
