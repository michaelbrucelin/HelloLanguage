13.1是否是因为做了物理IO而导致的性能不佳
例如运行下面这段话，因为它在运行之前使用dbcc dropcleanbuffers指令清除了Buffer Pool里所有缓存的页面，所以一定会做物理IO动作。开启set statistics io on 和set statistics time on，就能知道问题的答案。
dbcc dropcleanbuffers
-- 清除buffer pool里的所有缓存的数据页面
go
Set statistics io on
Go
Set statistics time on
Go
select distinct ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 777
go

立刻再运行一遍查询，不清空缓存区。
Set statistics io on
Go
Set statistics time on
Go
select distinct ProductID, UnitPrice
from dbo.SalesOrderDetail_test
where ProductID = 777
go

13.2是否是因为编译时间长而导致性能不佳

下面用一个存储过程，来模拟一句会有比较长的编译时间的语句。存储过程的主体是一个三张表的查询，其中有一个”in”子句。根据带入参数@i的值，脚本会为其带入相应个数的SaleOrdierID值。如果带入的值很多，”in”子句很长，语句本身就变得很长，SQL Server就要花比较多的时间和资源做编译。
drop proc LongCompile
go
create proc LongCompile (@i int) as
declare @cmd varchar(max)
declare @j int
set @j = 0
set @cmd = '
select count(b.SalesOrderID),sum(p.Weight)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID in ( 43659'
while @j <@i
begin
set @cmd = @cmd + ',' + str(@j + 43659) 
set @j = @j +1
end
set @cmd = @cmd + ')'
exec(@cmd)
go

13.3.1 预估cost的准确性
有一个查询，会返回约12万条记录。请运行它们三遍。第一遍是正常运行。第二遍运行之前，会先清空执行计划，然后设置语句只返回一条记录(set rowcount 1)。第三遍运行之前，不清空执行计划，但是设置语句返回所有记录(set rowcount 0)。按道理，第一遍运行和第三遍运行应该速度相当，因为它们都要返回12万条记录。第二遍会最快，因为它只要返回一条记录。
dbcc freeproccache
go
set rowcount 0
go
select p.ProductID, p.Weight
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID = 75124
go
dbcc freeproccache
go
set rowcount 1
go
select p.ProductID, p.Weight
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID = 75124
go
set rowcount 0
go
select p.ProductID, p.Weight
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID = 75124
go

13.3.2 是Index Seek还是Table Scan
如果某个数据检索动作实际返回的行数不多，但是SQL Server选择了scan的方法，那就要比较重视了，因为这种scan，会带来比较大的性能影响，会慢几十倍，几百倍，甚至上千倍。下面是一个例子。
select count(b.CarrierTrackingNumber)
from dbo.SalesOrderDetail_test b
where b.SalesOrderDetailID >10000 and b.SalesOrderDetailID <=10100
go
select count(b.CarrierTrackingNumber)
from dbo.SalesOrderDetail_test b
where convert(numeric(9,3),b.SalesOrderDetailID/100) =100
go

那scan就一定比seek差么？还是用这张表，再试一个例子。先创建一个存储过程，在SalesOrderDetail_test上返回指定的六个SalesOrderID的所有记录的count(b.CarrierTrackingNumber)值。
drop proc Scan_Seek
go
create proc Scan_Seek (@i int) as
select count(b.CarrierTrackingNumber)
from dbo.SalesOrderDetail_test b
where b.SalesOrderID >@i and b.SalesOrderID <@i + 7
go

用下面的脚本测试一下，还是使用13.3.1小节里的那个SQL Trace的事件。（图13-16）
sp_recompile Scan_Seek 
go
exec Scan_Seek 75124
go
sp_recompile Scan_Seek 
go
exec Scan_Seek 43659
go
exec Scan_Seek 75124
go

13.3.3 是Nested Loops还是Hash (Merge) Join
前面的一些例子，已经对这个问题有所体现。现在再来写一个例子，加深一下印象。同样还是一个存储过程。
Drop proc Sniff
Go
create proc Sniff (@i int) as
select count(b.SalesOrderID),sum(p.Weight)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID =@i 
go
	然后运行一下。
Dbcc freeproccache
go
exec Sniff 50000
go
exec Sniff 75124
go

如果清空执行计划缓存后直接运行它，则会快很多。只需要494毫秒。而在执行计划里，看到了Hash Match。Executes的值，都降成了1。（图13-20）
Dbcc freeproccache
go
exec Sniff 75124
go

13.3.4 Filter运算的位置
现在有两个查询。对用户来讲，它们是一样的，只不过第二个查询把p.ProductID加了个1以后再做比较。返回的结果集也会一样。
select count(b.ProductID)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where p.ProductID between 758 and 800
go
select count(b.ProductID)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where (p.ProductID + 1) between 759 and 801
go

13.4 Parameter Sniffing
在使用存储过程的时候，总是要使用到一些变量。变量有两种，一种是在存储过程的外面定义的。在调用存储过程的时候，必须要给它带入值。这种变量，SQL Server在编译的时候知道它的值是多少。例如：
create proc Sniff (@i int) as
select count(b.SalesOrderID),sum(p.Weight)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID =@i 
go
	这里的变量@i，就是要在调用的时候带入值的。
exec Sniff 50000
go
	还有一种变量是在存储过程里面定义的。它的值是在存储过程的语句执行的过程中得到的。所以对这种本地变量，SQL Server在编译的时候不知道它的值是多少。例如：
create proc Sniff2 (@i int) as
declare @j int
set @j = @i 
select count(b.SalesOrderID),sum(p.Weight)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID =@j 
go
	这里的变量@j，是SQL在运行的过程中算出来的。

13.4.1 什么是”Parameter Sniffing”
	带着第一个问题，请做下面这两个测试。
测试 1：（图13-25）
dbcc freeproccache
go
exec Sniff 50000
-- 发生编译，插入一个使用Nested Loops联结的执行计划
go
exec Sniff 75124
-- 发生执行计划重用，重用上面的Nested Loops的执行计划
go

测试2：（图13-26）
dbcc freeproccache
go
exec Sniff 75124
-- 发生编译，插入一个使用Hash Match联结的执行计划
go
exec Sniff 50000
-- 发生执行计划重用，重用上面的Hash Match的执行计划
go

13.4.2 本地变量的影响
	那对于有Parameter Sniffing问题的存储过程，如果使用本地变量，会怎么样呢？下面请看测试3。这次用不同的变量值时，都清空执行计划缓存，迫使其重编译。
dbcc freeproccache
go
exec Sniff 50000
go
dbcc freeproccache
go
exec Sniff 75124
go
dbcc freeproccache
go
exec Sniff2 50000
go
dbcc freeproccache
go
exec Sniff2 75124
go

13.4.3 Parametre Sniffing的解决方案
1. 用EXEC()的方式运行动态SQL语句
	如果在存储过程里不是直接运行语句，而是把语句带上变量，生成一个字符串，再让Exec()这样的命令做动态语句运行，那SQL Server就会在运行到这句话的时候，对动态语句进行编译。这时SQL Server已经知道了变量的值，会根据值生成优化的执行计划，从而绕过了parameter sniffing的问题。
	例如前面那个Sniff存储过程，就可以改成下面的样子。
create proc NoSniff (@i int) as
declare @cmd varchar(1000)
set @cmd = 'select count(b.SalesOrderID),sum(p.Weight)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID =' 
exec (@cmd + @i)
go
然后再用和图13 25一样的顺序调用，会得到比它更好的性能。（图13-32）
Dbcc freeproccache
go
exec NoSniff 50000
go
exec NoSniff 75124
go

3.1 "Recompile”
	"Recompile”这个查询提示告诉SQL Server，语句在每一次存储过程运行的时候，都要重新编译一下。这样就能够使SQL Server根据当前变量的值，选一个最好的执行计划。对前面的那个例子，我们可以这么改写。
drop proc NoSniff_QueryHint_Recompile
go
create proc NoSniff_QueryHint_Recompile (@i int) as
select count(b.SalesOrderID),sum(p.Weight)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID = @i
option (recompile)
go
Dbcc freeproccache
go
exec NoSniff_QueryHint_Recompile 50000
go
exec NoSniff_QueryHint_Recompile 75124
go

	和这种方法类似的，是在存储过程的定义里直接指定"recompile"，也能达到避免parameter sniffing的效果。
drop proc NoSniff_SPCreate_Recompile
go
create proc NoSniff_SPCreate_Recompile (@i int) 
with recompile
as
select count(b.SalesOrderID),sum(p.Weight)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID = @i
go
Dbcc freeproccache
go
exec NoSniff_SPCreate_Recompile 50000
go
exec NoSniff_SPCreate_Recompile 75124
go

3.2 指定Join运算（{ LOOP | MERGE | HASH } JOIN）
更常见的，是在特定的那个Join上使用Join Hint。这种方法成功的几率要高得多。例如：
drop proc NoSniff_QueryHint_JoinHint
go
create proc NoSniff_QueryHint_JoinHint (@i int) as
select count(b.SalesOrderID),sum(p.Weight)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner hash join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID = @i
go
Dbcc freeproccache
go
exec NoSniff_QueryHint_JoinHint 50000
go
exec NoSniff_QueryHint_JoinHint 75124
go

3.3 OPTIMIZE FOR ( @variable_name = literal_constant [ , ...n ] )
使用” OPTIMIZE FOR”这个查询指导，就能够让SQL Server做到这一点。这是SQL 2005以后的一个新功能。
drop proc NoSniff_QueryHint_OptimizeFor
go
create proc NoSniff_QueryHint_OptimizeFor (@i int) as
select count(b.SalesOrderID),sum(p.Weight)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID = @i
option (optimize for (@i = 75124))
go
Dbcc freeproccache
go
exec NoSniff_QueryHint_OptimizeFor 50000
go
exec NoSniff_QueryHint_OptimizeFor 75124
go

4. Plan Guild
	例如可以用下面的方法，在原来那个有parameter sniffing问题的存储过程”Sniff”上，解决sniffing问题。
EXEC sp_create_plan_guide 
    @name =  N'Guide1',
    @stmt = N'select count(b.SalesOrderID),sum(p.Weight)
from dbo.SalesOrderHeader_test a 
inner join dbo.SalesOrderDetail_test b
on a.SalesOrderID = b.SalesOrderID
inner join Production.Product p
on b.ProductID = p.ProductID
where a.SalesOrderID =@i',
    @type = N'OBJECT',
    @module_or_batch = N'Sniff',
    @params = NULL,
    @hints = N'OPTION (optimize for (@i = 75124))';
go
exec Sniff 50000
-- 使用了75124的Hash Match的Join方式（图13-38）
go

13.5.2 SQL Server Plan Guild（计划指南）
1. 对单个固定语句定义计划指南
假设有这么一张表格：
Use adventureworks
go
create Table table1 (
	name nvarchar(256),
	[id] int
)
Go
有下面这个不带参数的语句：（注意，它没有以回车符结束）
"insert into table1 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =2"
	缺省，这个查询将会使用Merge Join的方法。如果用户想要规定，这个Join必须使用Nested Loop，除了直接在查询里加Query Hint以外，使用计划指南也可以达到同样的效果。创建计划指南的语句应该是：
EXEC sp_create_plan_guide
@name=N'Guide1',
@stmt=N'insert into table1 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =2',
@type=N'SQL',
@module_or_batch=N'insert into table1 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =2',
@params=NULL,
@hints=N'OPTION(loop join)'
	在创建计划指南的时候，@stmt和@module_or_batch参数所带的字符串，必须和语句本身一模一样，不能少一个空格，也不能多一个回车。SQL Server在这里做的是精确匹配。
	计划指南创建完毕后，再运行这句话。
set statistics xml on 
go
exec sp_executesql 
N'insert into table1 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =2'
go
	在以XML格式输出的执行计划里，就能看到执行计划是根据计划指南生成的。（图13-47）
 
2. 对批处理里一个带有参数的语句定义计划指南
一般来讲，用户发过来的batch会不止一句话，而且语句里也会有参数。这个怎么写呢？假设下面这个批处理。
declare @id int
set @id = 2
DECLARE @Table table (
	name nvarchar(256),
	[id] int
)
insert into @table 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =@id
这里在@stmt参数里，还是带入语句本身。但是在@module_or_batch里，要带入整个batch的每一句话。但是语句的参数，不用写在@params里。
EXEC sp_create_plan_guide
@name=N'Guide2',
@stmt=N'insert into @table 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =@id',
@type=N'SQL',
@module_or_batch=N'declare @id int
set @id = 2
DECLARE @Table table (
	name nvarchar(256),
	[id] int
)
insert into @table 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =@id',
@params=NULL,
@hints=N'OPTION(loop join)'

3.  使用带参数的方式调用批处理语句，给其中一句指定计划指南。
用户也可以用sp_executesql的方法调用这句话。
exec sp_executesql N'DECLARE @Table table (
	name nvarchar(256),
	[id] int
)
insert into @table 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =@id',N'@id int',@id = 2
而这个时候，计划指南要这样写。
EXEC sp_create_plan_guide
@name=N'Guide3',
@stmt=N'insert into @table 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =@id',
@type=N'SQL',
@module_or_batch=N'DECLARE @Table table (
	name nvarchar(256),
	[id] int
)
insert into @table 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =@id',
@params=N'@id int',
@hints=N'OPTION(loop join)'
用batch的时候，要把整个batch都抄在sp_create_plan_guide后面，比较麻烦。如果是存储过程，就好办很多了。

4. 对一个存储过程里的一句语句定义计划指南
	假设存储过程是这样的。
create proc Demo_Plan (@id int)
as 
DECLARE @Table table (
	name nvarchar(256),
	[id] int
)
insert into @table 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =@id
go
	那么计划指南就可以这样定义。
EXEC sp_create_plan_guide
@name=N'Guide4',
@stmt=N'insert into @table 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =@id',
@type=N'Object',
@module_or_batch=N'Demo_Plan',
@params=NULL,
@hints=N'OPTION(loop join)'
	在上面这些例子里，用的都是Query Hint，并没有直接指定执行计划。能不能直接指定SQL Server在跑这句话的时候，就固定地使用某个执行计划呢？这个也是支持的。

5. 通过sp_create_plan_guide指定某个执行计划
	sp_create_plan_guide的@hints参数，在SQL 2008里可以直接带入一个XML格式的执行计划。（在SQL 2005的时候，要使用N'OPTION(use plan…)'的方法。）下面是一个例子。
	首先我们创建一个存储过程。里面Insert语句的Join，缺省会使用Merge Join的方式。
create proc TestPlan as
declare @id int
set @id = 2
DECLARE @Table table (
	name nvarchar(256),
	[id] int
)
insert into @table 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =@id
	然后我们搞一个使用Nested Loops的执行计划，把它作为这个存储过程里Insert语句的计划指南。
dbcc freeproccache
-- 清空所有缓存的执行计划
go
declare @id int
set @id = 2
DECLARE @Table table (
	name nvarchar(256),
	[id] int
)
insert into @table 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =@id
option (loop join)
--使用Query Hint运行语句，让SQL生成一个Nested Loops的执行计划
go
DECLARE @xml_showplan nvarchar(max)
SET @xml_showplan = (SELECT query_plan
    FROM sys.dm_exec_query_stats AS qs 
    CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) AS st
    CROSS APPLY sys.dm_exec_text_query_plan(qs.plan_handle, DEFAULT, DEFAULT) AS qp
    WHERE st.text LIKE N'declare @id int%'
    AND SUBSTRING(st.text, (qs.statement_start_offset/2) + 1,
                        ((CASE statement_end_offset 
                              WHEN -1 THEN DATALENGTH(st.text)
                              ELSE qs.statement_end_offset END 
                              - qs.statement_start_offset)/2) + 1)  
                        like 'insert into @table%'
-- 从缓存里把这个执行计划取出来
    );
EXEC sp_create_plan_guide
@name=N'Guide5',
@stmt=N'insert into @table 
select a.name, a.id from sysobjects a
inner join sysindexes b
on a.id = b.id
where b.indid =@id',
@type=N'Object',
@module_or_batch=N'TestPlan',
@params=NULL,
@hints=@xml_showplan
--使用执行计划的内容直接定义计划指南
Go
	以后再运行存储过程，就能够使用到Nested Loops的执行计划了。在SQL 2008的Trace里，新加入了两个事件：Performance – Plan Guide Successful和Performance – Plan Guide Unsuccessful。可以用来跟踪语句的执行有没有正确地使用计划指南。（图13-48）

	如果想要关闭，或者删除某个计划指南，可以调用sp_control_plan_guide系统存储过程。例如：
EXEC sp_control_plan_guide N'DROP', N'Guide3';
-- 删除Guide3这个计划指南
EXEC sp_control_plan_guide N'DISABLE ALL';
-- 关闭当前数据库里的所有计划指南

13.6.2 会在运行前改变值的变量
例如下面这个存储过程，@date是它带入的参数。SQL Server会根据参数的值，生成执行计划。
Create PROCEDURE GetRecentSales (@date datetime) AS
BEGIN
      SELECT sum(d.OrderQty)FROM SalesOrderHeader_test h, SalesOrderDetail_test d
      WHERE h.SalesOrderID = d.SalesOrderID
      AND h.OrderDate > @date
END
sp_recompile GetRecentSales
go
exec GetRecentSales null
--预估结果集很小，会使用Nested Loops
go
sp_recompile GetRecentSales
go
declare @date datetime
SET @date = dateadd(mm,-3,(SELECT MAX(OrderDATE) 
FROM SalesOrderHeader_test))
exec GetRecentSales @date
--预估结果集比较大，会使用Hash Match
go
	但是如果我们把存储过程改成下面这个样子：
Alter PROCEDURE GetRecentSales (@date datetime) AS
BEGIN
      IF @date IS NULL
            SET @date = dateadd(mm,-3,(SELECT MAX(OrderDATE) 
               FROM SalesOrderHeader_test))
--如果值是Null, 会带入一个新的日期
      SELECT sum(d.OrderQty)FROM SalesOrderHeader_test h, SalesOrderDetail_test d
      WHERE h.SalesOrderID = d.SalesOrderID
      AND h.OrderDate > @date
END

怎么来解决这个问题呢？当然，你可以在使用变量的语句后面加一个option (recompile)的query hint。这样当SQL Server运行到这句话的时候，会重编译可能会出问题的语句。在那个时候，就能够根据修改过的值生成更精确的执行计划了。
alter PROCEDURE GetRecentSales (@date datetime)  AS
BEGIN
      IF @date IS NULL
            SET @date = dateadd(mm,-3,(SELECT MAX(OrderDATE) 
               FROM SalesOrderHeader_test))
      SELECT sum(d.OrderQty)FROM SalesOrderHeader_test h, SalesOrderDetail_test d
      WHERE h.SalesOrderID = d.SalesOrderID
      AND h.OrderDate > @date
	  option (recompile)
END
	还有一种方法，是把可能出问题的语句单独做成一个子存储过程，让原来的存储过程调用子存储过程，而不是语句本身。例如：
Create PROCEDURE GetRecentSalesHelper (@date datetime)  AS
BEGIN
      SELECT sum(d.OrderQty) FROM SalesOrderHeader_test h, SalesOrderDetail_test d
      WHERE h.SalesOrderID = d.SalesOrderID
      AND h.OrderDate > @date
END
alter PROCEDURE GetRecentSales (@date datetime)  AS
BEGIN
      IF @date IS NULL
            SET @date = dateadd(mm,-3,(SELECT MAX(OrderDATE) 
                FROM SalesOrderHeader_test))
      EXEC GetRecentSalesHelper @date
END

13.6.3 临时表和表变量
	现在来做一个测试体会一下。
--表变量情形
declare @tmp Table (
ProductID int,
OrderQty int)
insert into @tmp
select ProductID, OrderQty
from dbo.SalesOrderDetail_test
where SalesOrderID = 75124
--语句会插入12万多条记录
select p.Name, p.color, sum(t.OrderQty)
from @tmp t
inner join Production.Product p
on t.ProductID = p.ProductID
group by p.Name, p.color
order by p.name
--含有12万条记录的表变量和另一张表作join
go

--临时表情形
create table #tmp (
ProductID int,
OrderQty int)
insert into #tmp
select ProductID, OrderQty
from dbo.SalesOrderDetail_test
where SalesOrderID = 75124
--语句会插入12万多条记录
select p.Name, p.color, sum(t.OrderQty)
from #tmp t
inner join Production.Product p
on t.ProductID = p.ProductID
group by p.Name, p.color
order by p.name
--含有12万条记录的表变量和另一张表作join
drop table #tmp
go

