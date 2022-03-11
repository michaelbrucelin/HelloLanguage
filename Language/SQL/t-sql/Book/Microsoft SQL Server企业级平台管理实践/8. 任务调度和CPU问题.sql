8.1.1 SQLOS的任务调度算法
--SQL 2005和SQL 2008有个动态管理视图sys.dm_os_schedulers，可以反映当前每个scheduler的状态。
SELECT
    scheduler_id,
    cpu_id,
    parent_node_id,
    current_tasks_count,
    runnable_tasks_count,
    current_workers_count,
    active_workers_count,
    work_queue_count
  FROM sys.dm_os_schedulers;

8.2 SQL CPU 100%问题
--使用DMV来分析SQL Server启动以来累计使用CPU资源最多的语句。例如下面的语句就可以列出前50名。
select 
    highest_cpu_queries.*,q.dbid, 
    q.objectid, q.number, q.encrypted, q.[text]
from 
    (select top 50 qs.*
    from sys.dm_exec_query_stats qs
    order by qs.total_worker_time desc) as highest_cpu_queries
    cross apply sys.dm_exec_sql_text(plan_handle) as q
order by highest_cpu_queries.total_worker_time desc
go

--我们也可以找到最经常做重编译的存储过程。
select top 25 sql_text.text, sql_handle, plan_generation_num,  execution_count,
    dbid,  objectid 
from sys.dm_exec_query_stats a
    cross apply sys.dm_exec_sql_text(sql_handle) as sql_text
where plan_generation_num >1
order by plan_generation_num desc
go

8.3 OLTP和Data Warehouse系统差别及常用性能阀值
8.3.1 OLTP系统
1. 数据库设计
建议查询1.1：
-- 返回最经常运行的100条语句
SELECT TOP 100
		cp.cacheobjtype
		,cp.usecounts
		,cp.size_in_bytes  
		,qs.statement_start_offset
		,qs.statement_end_offset
		,qt.dbid
		,qt.objectid
		,SUBSTRING(qt.text,qs.statement_start_offset/2, 
			(case when qs.statement_end_offset = -1 
			then len(convert(nvarchar(max), qt.text)) * 2 
			else qs.statement_end_offset end -qs.statement_start_offset)/2) 
		as statement
FROM sys.dm_exec_query_stats qs
cross apply sys.dm_exec_sql_text(qs.sql_handle) as qt
inner join sys.dm_exec_cached_plans as cp on qs.plan_handle=cp.plan_handle
where cp.plan_handle=qs.plan_handle
and cp.usecounts>4
ORDER BY [dbid],[Usecounts] DESC

建议查询1.2：
-- 返回最经常被修改的100个索引
-- 通过它们的Database_id, object_id, index_id和partition_number
-- 可以找到它们是哪个数据库上的哪个索引
SELECT top 100 * 
FROM sys.dm_db_index_operational_stats(NULL, NULL, NULL, NULL)
order by leaf_insert_count+leaf_delete_count+leaf_update_count desc
GO

建议查询1.3：
-- 返回做IO数目最多的50条语句以及它们的执行计划
select top 50 
    (total_logical_reads/execution_count) as avg_logical_reads,
    (total_logical_writes/execution_count) as avg_logical_writes,
    (total_physical_reads/execution_count) as avg_phys_reads,
     Execution_count, 
    statement_start_offset as stmt_start_offset, statement_end_offset as stmt_end_offset,
substring(sql_text.text, (statement_start_offset/2), 
case 
when (statement_end_offset -statement_start_offset)/2 <=0 then 64000
else (statement_end_offset -statement_start_offset)/2
end) as exec_statement,  
sql_text.text,
plan_text.*
from sys.dm_exec_query_stats  
cross apply sys.dm_exec_sql_text(sql_handle) as sql_text
cross apply sys.dm_exec_query_plan(plan_handle) as plan_text
order by 
 (total_logical_reads + total_logical_writes) /Execution_count Desc
go

2. CPU
建议查询2.1：
-- 计算signal wait占整wait时间的百分比
select convert(numeric(5,4),sum(signal_wait_time_ms)/sum(wait_time_ms)) 
from Sys.dm_os_wait_stats

计算方法2.1：
性能计数对象SQLServer:SQL Statistics下面有几个计数器，可以计算出大致的执行计划重用率。计算方法是：
Initial Compilations = SQL Compilations/sec – SQL Re-Compilations/sec
执行计划重用率= (Batch requests/sec – Initial Compilations/sec) / Batch requests/sec

建议查询2.2：
-- 计算'Cxpacket'占整wait时间的百分比
declare @Cxpacket bigint
declare @Sumwaits bigint
select @Cxpacket = wait_time_ms
from Sys.dm_os_wait_stats
where wait_type = 'Cxpacket'
select @Sumwaits = sum(wait_time_ms)
from Sys.dm_os_wait_stats
select convert(numeric(5,4),@Cxpacket/@Sumwaits)

5. 阻塞
建议查询5.1：
-- 查询当前数据库上所有用户表格在Row lock上发生阻塞的频率
declare @dbid int
select @dbid = db_id()
Select dbid=database_id, objectname=object_name(s.object_id)
, indexname=i.name, i.index_id	--, partition_number
, row_lock_count, row_lock_wait_count
, [block %]=cast (100.0 * row_lock_wait_count / (1 + row_lock_count) as numeric(15,2))
, row_lock_wait_in_ms
, [avg row lock waits in ms]=cast (1.0 * row_lock_wait_in_ms / (1 + row_lock_wait_count) as numeric(15,2))
from sys.dm_db_index_operational_stats (@dbid, NULL, NULL, NULL) s, 	sys.indexes i
where objectproperty(s.object_id,'IsUserTable') = 1
and i.object_id = s.object_id
and i.index_id = s.index_id
order by row_lock_wait_count desc

8.3.2 Data Warehouse系统
1. 数据库设计
建议查询1.2:
-- 返回当前数据库所有碎片率大于25%的索引
-- 运行本语句会扫描很多数据页面
-- 避免在系统负载比较高时运行
declare @dbid int
select @dbid = db_id()
SELECT * FROM sys.dm_db_index_physical_stats (@dbid, NULL, NULL, NULL, NULL)
where avg_fragmentation_in_percent>25
order by avg_fragmentation_in_percent desc
GO

建议查询1.3:
-- 当前数据库可能缺少的索引
select d.*
        , s.avg_total_user_cost
        , s.avg_user_impact
        , s.last_user_seek
        ,s.unique_compiles
from sys.dm_db_missing_index_group_stats s
        ,sys.dm_db_missing_index_groups g
        ,sys.dm_db_missing_index_details d
where s.group_handle = g.index_group_handle
and d.index_handle = g.index_handle
order by s.avg_user_impact desc
go
--- 推荐建索引的字段
declare @handle int
select @handle = d.index_handle
from sys.dm_db_missing_index_group_stats s
        ,sys.dm_db_missing_index_groups g
        ,sys.dm_db_missing_index_details d
where s.group_handle = g.index_group_handle
and d.index_handle = g.index_handle
select * 
from sys.dm_db_missing_index_columns(@handle)
order by column_id


