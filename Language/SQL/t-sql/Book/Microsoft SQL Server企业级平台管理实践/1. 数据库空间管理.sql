1.1	文件的分配方式及文件空间检查方法
--------------------sp_spaceused------------------------------
-- 不加任何参数，sp_spaceused返回当前数据库的空间使用情况
sp_spaceused
-- 使用表名作为参数，sp_spaceused返回指定表的空间使用情况
sp_spaceused "Person.Address"
go

1.1.1	数据文件分配
--------------------dbcc page------------------------------
--语法：DBCC Page(<db_id>, <file_id>, <page_id>, <format_id>)

-- db_id的获得
-- 返回所有数据库的ID信息
sp_helpdb
-- 返回当前数据库的ID
select DB_ID()
-- 返回指定名称数据库的ID
select DB_ID('AdventureWorks')


-- file_id的获得
sp_helpfile
-- 返回指定名称表的ID
select file_id('AdventureWorks_Data')

-- 查看某个page的信息

-- 先打开dbcc开关
dbcc traceon(3604)

-- 查看指定页面的信息
-- Metadata+SLOT+Memory dump
dbcc page(11,1,100,1) with TableResults
-- Metadata+Memory dump
dbcc page(11,1,100,2) with TableResults
-- Metadata+IAM
dbcc page(11,1,100,3) with TableResults


1.1.2 数据文件空间使用计算方法
-- 按照区得到数据库文件大小
dbcc showfilestats

-- 得到当前数据库所有表的数据页的情况
SELECT o.name ,
		 SUM (p.reserved_page_count) as reserved_page_count,
		 SUM (p.used_page_count) as used_page_count,
		 SUM (
			CASE
				WHEN (p.index_id < 2) THEN (p.in_row_data_page_count + p.lob_used_page_count + p.row_overflow_used_page_count)
				ELSE p.lob_used_page_count + p.row_overflow_used_page_count
			END
			) as DataPages,
		 SUM (
			CASE
				WHEN (p.index_id < 2) THEN row_count
				ELSE 0
			END
			) as rowCounts
FROM sys.dm_db_partition_stats p 
inner join sys.objects o on p.object_id = o.object_id
group by o.name

1.1.3	日志文件
-- 查看日志使用情况
dbcc sqlperf(logspace)

1.1.5 案例：通过脚本监视tempdb空间使用
1. 脚本1
-- 监视tempdb存储空间使用
-- 在连接B中，选择Query-Results To-Results to file
-- 然后运行如下脚本
use tempdb                                                               
-- 每隔1秒钟运行一次，直到用户手工终止脚本运行
while 1=1                                                                
begin                                                                    
select getdate()                                                         
-- 从文件级看tempdb使用情况
dbcc showfilestats                                                       
-- Query 1
-- 返回所有做过空间申请的session信息
Select 'Tempdb' as DB, getdate() as Time,                                                        
    SUM (user_object_reserved_page_count)*8 as user_objects_kb,          
    SUM (internal_object_reserved_page_count)*8 as internal_objects_kb,  
    SUM (version_store_reserved_page_count)*8  as version_store_kb,      
    SUM (unallocated_extent_page_count)*8 as freespace_kb                
From sys.dm_db_file_space_usage                                          
Where database_id = 2                                                    
-- Query 2
-- 这个管理视图能够反映当时tempdb空间的总体分配
SELECT t1.session_id,                                                    
t1.internal_objects_alloc_page_count,  t1.user_objects_alloc_page_count,
t1.internal_objects_dealloc_page_count , t1.user_objects_dealloc_page_count,
t3.*
from sys.dm_db_session_space_usage  t1 ,                                
-- 反映每个session累计空间申请
sys.dm_exec_sessions as t3 
-- 每个session的信息
where 
t1.session_id = t3.session_id 
and (t1.internal_objects_alloc_page_count>0 
or t1.user_objects_alloc_page_count >0
or t1.internal_objects_dealloc_page_count>0 
or t1.user_objects_dealloc_page_count>0)
-- Query 3
-- 返回正在运行并且做过空间申请的session正在运行的语句
SELECT t1.session_id,                                                    
st.text                                                         
from sys.dm_db_session_space_usage as t1,                                
sys.dm_exec_requests as t4                                               
CROSS APPLY sys.dm_exec_sql_text(t4.sql_handle) AS st                    
 where  t1.session_id = t4.session_id                                        
   and t1.session_id >50                                                 
and (t1.internal_objects_alloc_page_count>0 
or t1.user_objects_alloc_page_count >0
or t1.internal_objects_dealloc_page_count>0 
or t1.user_objects_dealloc_page_count>0)                                               
waitfor delay '0:0:1'                                                    
end
--脚本1结束                           

2. 脚本2
-- 在连接A中运行如下脚本
-- 以下连接会用不同的方式使用Tempdb
select @@spid
go
use adventureworks
go
select getdate()
go
select * into #mySalesOrderDetail
from Sales.SalesOrderDetail
-- 创建一个temp table
-- 这个操作应该会申请user objects page 
go
waitfor delay '0:0:2'
select getdate()
go
drop table #mySalesOrderDetail
-- 删除一个temp table
-- 这个操作后user object page数量应该会下降
go
waitfor delay '0:0:2'
select getdate()
go
select top 100000 * from
[Sales].[SalesOrderDetail]
INNER JOIN [Sales].[SalesOrderHeader] 
ON [Sales].[SalesOrderHeader] .[SalesOrderID] = [Sales].[SalesOrderHeader].[SalesOrderID];
-- 这里做了一个比较大的join. 
-- 应该会有internal objects的申请.
go
select getdate()
-- join 语句做完以后internal objects page数目应该下降
go
-- 脚本2结束

1.2	数据文件空间使用与管理
1.2.2	比较存储结构对空间使用影响
1。创建一个和[Sales].[SalesOrderDetail]同结构的表格，这个表格上没有一个index，所以它是一个堆。
USE [AdventureWorks]
GO
drop table [Sales].[SalesOrderDetail_hash]
GO
CREATE TABLE [Sales].[SalesOrderDetail_hash](
	[SalesOrderID] [int] NOT NULL,
	[SalesOrderDetailID] [int] ,
	[CarrierTrackingNumber] [nvarchar](25) NULL,
	[OrderQty] [smallint] NOT NULL,
	[ProductID] [int] NOT NULL,
	[SpecialOfferID] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[UnitPriceDiscount] [money] NOT NULL ,
	[LineTotal] numeric (38,6),
	[rowguid] [uniqueidentifier] ,
	[ModifiedDate] [datetime]
) ON [PRIMARY]
GO
insert into [Sales].[SalesOrderDetail_hash]
select * from [Sales].[SalesOrderDetail]
go
dbcc showcontig('[Sales].[SalesOrderDetail_hash]')
go

2。创建一个同样的，但是有clustered index的表格。所以这是一颗B树。
-- 对于B树的操作
USE [AdventureWorks]
GO
drop table [Sales].[SalesOrderDetail_C]
GO
CREATE TABLE [Sales].[SalesOrderDetail_C](
	[SalesOrderID] [int] NOT NULL,
	[SalesOrderDetailID] [int] ,
	[CarrierTrackingNumber] [nvarchar](25) NULL,
	[OrderQty] [smallint] NOT NULL,
	[ProductID] [int] NOT NULL,
	[SpecialOfferID] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[UnitPriceDiscount] [money] NOT NULL ,
	[LineTotal] numeric (38,6),
	[rowguid] [uniqueidentifier] ,
	[ModifiedDate] [datetime],
 CONSTRAINT [PK_SalesOrderDetailC_SalesOrderID_SalesOrderDetailID] PRIMARY KEY CLUSTERED 
(
	[SalesOrderID] ASC,
	[SalesOrderDetailID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
insert into [Sales].[SalesOrderDetail_C]
select * from [Sales].[SalesOrderDetail]
go
dbcc showcontig('[Sales].[SalesOrderDetail_C]')WITH ALL_INDEXES 
go

3。创建一个同样的，但是Primary Key建立在nonclustered index上的表格。所以它是一个堆加一个B树。
USE [AdventureWorks]
GO
drop table [Sales].[SalesOrderDetail_N]
GO
CREATE TABLE [Sales].[SalesOrderDetail_N](
	[SalesOrderID] [int] NOT NULL,
	[SalesOrderDetailID] [int] ,
	[CarrierTrackingNumber] [nvarchar](25) NULL,
	[OrderQty] [smallint] NOT NULL,
	[ProductID] [int] NOT NULL,
	[SpecialOfferID] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[UnitPriceDiscount] [money] NOT NULL ,
	[LineTotal] numeric (38,6),
	[rowguid] [uniqueidentifier] ,
	[ModifiedDate] [datetime],
 CONSTRAINT [PK_SalesOrderDetailN_SalesOrderID_SalesOrderDetailID] PRIMARY KEY nonclustered 
(
	[SalesOrderID] ASC,
	[SalesOrderDetailID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
insert into [Sales].[SalesOrderDetail_N]
select * from [Sales].[SalesOrderDetail]
go
dbcc showcontig('[Sales].[SalesOrderDetail_N]')WITH ALL_INDEXES 
go

1.2.3	Delete和truncate之间的区别
delete [Sales].[SalesOrderDetail_hash]
go
delete [Sales].[SalesOrderDetail_C]
go
delete [Sales].[SalesOrderDetail_N]
go

dbcc showcontig('[Sales].[SalesOrderDetail_C]')WITH ALL_INDEXES 
dbcc showcontig('[Sales].[SalesOrderDetail_N]')WITH ALL_INDEXES 
dbcc showcontig('[Sales].[SalesOrderDetail_hash]')WITH ALL_INDEXES 

1.2.4	为什么DBCC Shrinkfile会不起作用 
-- DBCC ShrinkFile
create database test_shrink
go
use test_shrink
go
create table show_extent
(a int,
b nvarchar(3900))
go
declare @i int
set @i = 1
while @i <=1000
begin
insert into show_extent values (1, REPLICATE ( N'a' ,3900 ))
insert into show_extent values (2, REPLICATE ( N'b' ,3900 ))
insert into show_extent values (3, REPLICATE ( N'c' ,3900 ))
insert into show_extent values (4, REPLICATE ( N'd' ,3900 ))
insert into show_extent values (5, REPLICATE ( N'e' ,3900 ))
insert into show_extent values (6, REPLICATE ( N'f' ,3900 ))
insert into show_extent values (7, REPLICATE ( N'g' ,3900 ))
insert into show_extent values (8, REPLICATE ( N'h' ,3900 ))
set @i = @i +1
end
dbcc showcontig('show_extent')
go

--现在我们删除每个区里面的7个页面，只保留a=5的这些记录。

delete show_extent where a <>5
go
sp_spaceused show_extent
go
dbcc showcontig('show_extent')
go

--面对这种情况怎么办呢？如果这个表有一个clustered index，那么我们可以通过重建索引的方式把页面重排一次。现在的这个表没有clustered index，那么我们为它建一个，也能达到同样的效果。
create clustered index show_I 
on show_extent (a)
go
dbcc showcontig('show_extent')
go

--这时候我们再去shrinkfile就有效果了。
dbcc shrinkfile (1, 40)

--我们还是以刚才的test_shrink数据库为例， 当我们删除掉出了5以外的其他数据以后，运行下面查询。
use test_shrink 
go 
drop table extentinfo
go
create table extentinfo 
( [file_id] smallint, 
page_id int, 
pg_alloc int, 
ext_size int, 
obj_id int, 
index_id int, 
partition_number int,
partition_id bigint,
iam_chain_type varchar(50),
pfs_bytes varbinary(10) ) 
go 
drop proc import_extentinfo
go
create procedure import_extentinfo 
as dbcc extentinfo('test_shrink') 
go 
insert extentinfo 
exec import_extentinfo 
go 
select [file_id],obj_id, index_id, partition_id, ext_size, 
'actual extent count'=count(*), 'actual page count'=sum(pg_alloc), 
'possible extent count'=ceiling(sum(pg_alloc)*1.0/ext_size), 
'possible extents / actual extents' = (ceiling(sum(pg_alloc)*1.00/ext_size)*100.00) / count(*) 
from extentinfo 
group by [file_id],obj_id, index_id,partition_id, ext_size 
having count(*)-ceiling(sum(pg_alloc)*1.0/ext_size) > 0 
order by partition_id, obj_id, index_id, [file_id]

1.3	日志文件不停增长
1.3.1 日志文件里到底有什么
--首先，我们在范例数据库AdventureWorks里面创建一个只有一个int类型字段的表格。然后将数据库日志文件清空。接着运行DBCC Log命令。找到这时日志文件的最后一条记录。
use adventureworks
go
create table a (a int)
go
checkpoint
go
backup log adventureworks with truncate_only
go
dbcc log(5,3)
-- 5是adventureworks数据库的编号，每个SQL Server可能不同
-- 可以用sp_helpdb来查到数据库编号
go
--接着，我们在表格里插入一条记录。
insert into a values (1)
go
dbcc log(5,3)
go

--我们再插一条记录。
insert into a values (100)
go
dbcc log(5,3)
go

--可以看到新的三条记录（图1-27）。新的记录有不同的LSN编号。
update a set a = 2
go

1.3.3 案例：日志增长原因定位
-- 检查日志现在使用情况和数据库状态
dbcc sqlperf(logspace)
go
select name, recovery_model_desc, log_reuse_wait,log_reuse_wait_desc from sys.databases
go


-- 检查最老的活动事务
dbcc opentran
go
SELECT st.text,t2.*                                                         
from 
sys.dm_exec_sessions as t2,
sys.dm_exec_connections as t1
CROSS APPLY sys.dm_exec_sql_text(t1.most_recent_sql_handle) AS st 
where  
t1.session_id = t2.session_id
and t1.session_id >50   
