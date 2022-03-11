6.3.2 动态管理视图（DMV）
1.可以用下面的查询来检查SQL Server的内存使用情况。
select 
	type,
	sum(virtual_memory_reserved_kb) as [VM Reserved],
	sum(virtual_memory_committed_kb) as [VM Committed],
	sum(awe_allocated_kb) as [AWE Allocated],
	sum(shared_memory_reserved_kb) as [SM Reserved], 
	sum(shared_memory_committed_kb) as [SM Committed],
	sum(multi_pages_kb) as [MultiPage Allocator],
	sum(single_pages_kb) as [SinlgePage Allocator]
from 
	sys.dm_os_memory_clerks 
group by type
order by type

2.下面的这组语句，就可以打印出当前内存里缓存的所有页面的统计信息。
declare @name nvarchar(100)
declare @cmd nvarchar(1000)
declare dbnames cursor for
select name from master.dbo.sysdatabases
open dbnames
fetch next from dbnames into @name
while @@fetch_status = 0
begin
set @cmd = 'select b.database_id, db=db_name(b.database_id),p.object_id,p.index_id,buffer_count=count(*) from ' + @name + '.sys.allocation_units a, '
+ @name + '.sys.dm_os_buffer_descriptors b, ' + @name + '.sys.partitions p
where a.allocation_unit_id = b.allocation_unit_id
and a.container_id = p.hobt_id
and b.database_id = db_id(''' + @name + ''')
group by b.database_id,p.object_id, p.index_id
order by b.database_id, buffer_count desc'
exec (@cmd)
fetch next from dbnames into @name
end
close dbnames
deallocate dbnames
go

3. 在一条语句第一次执行前后各运行一遍上面的脚本，就能够知道这句话要读入多少数据到内存里。
例如如果运行下面的脚本：
dbcc dropcleanbuffers
go
----Copy the previous scripts here
Go
use adventureworks
go
select * from person.address
go
----Copy the previous scripts again here
Go

4. 用下面的查询可以得到各种对象各占了多少内存：
select objtype, sum(size_in_bytes) as sum_size_in_bytes, count(bucketid) as cache_counts
from sys.dm_exec_cached_plans
group by objtype

5. 如果想要分析具体存储了哪些对象，可以使用下面的语句。但是要注意把结果集输出到一个文件里，因为这个查询的结果在一个生产服务器上会很大的。如果要输出到Management Studio里，对运行这个查询的那台机器的资源会有争用，进而影响到同一台机器上的SQL Server运行。
SELECT usecounts, refcounts, size_in_bytes, cacheobjtype, objtype, text 
FROM sys.dm_exec_cached_plans cp
CROSS APPLY sys.dm_exec_sql_text(plan_handle) 
ORDER BY objtype DESC;
GO

6.4.3 使用DMV分析SQL Server启动以来做read最多的语句
1. 按照物理读的页面数排序，前50名。
SELECT TOP 50
qs.total_physical_reads,qs.execution_count,
        qs.total_physical_reads /qs.execution_count as [Avg IO],
            SUBSTRING(qt.text,qs.statement_start_offset/2, 
			(case when qs.statement_end_offset = -1 
			then len(convert(nvarchar(max), qt.text)) * 2 
			else qs.statement_end_offset end -qs.statement_start_offset)/2) 
		as query_text,
		qt.dbid, dbname=db_name(qt.dbid),
		qt.objectid,
		qs.sql_handle,
		qs.plan_handle
FROM sys.dm_exec_query_stats qs
cross apply sys.dm_exec_sql_text(qs.sql_handle) as qt
ORDER BY qs.total_physical_reads desc

2. 按照逻辑读的页面数排序，前50名。
SELECT TOP 50
qs.total_logical_reads,qs.execution_count,
        qs.total_logical_reads /qs.execution_count as [Avg IO],
            SUBSTRING(qt.text,qs.statement_start_offset/2, 
			(case when qs.statement_end_offset = -1 
			then len(convert(nvarchar(max), qt.text)) * 2 
			else qs.statement_end_offset end -qs.statement_start_offset)/2) 
		as query_text,
		qt.dbid, dbname=db_name(qt.dbid),
		qt.objectid,
		qs.sql_handle,
		qs.plan_handle
FROM sys.dm_exec_query_stats qs
cross apply sys.dm_exec_sql_text(qs.sql_handle) as qt
ORDER BY qs.total_logical_reads desc

3. 使用SQL Trace文件来分析某一段时间内做read最多的语句。
	例如现在在c:\sample目录下收集了一个问题时段的trace文件，叫A.trc。第一步要将里面所有的存储过程和批命令执行完成的记录保存到SQL Server里。
select * into Sample
from fn_trace_gettable('c:\sample\a.trc',default)
where eventclass in (10, 12)

语句执行完了以后，可以用下面的查询看看里面的数据长什么样。
Select top 1000 textdata, databaseId, HostName, ApplicationName, LoginName, SPID,
Starttime, EndTime, Duration, reads, writes, CPU 
from sample

a. 找到是哪台客户端服务器上的哪个应用发过来的语句，从整体上讲在数据库上引起的读最多。
select databaseId,HostName,ApplicationName, sum(reads)
from sample
group by databaseId,HostName,ApplicationName
order by sum(reads) desc

b. 按照作的reads从大到小排序，最大的1000个语句。
select top 1000 textdata, databaseId, HostName, ApplicationName, LoginName, SPID,
Starttime, EndTime, Duration, reads, writes, CPU 
from sample
order by reads desc

