-- http://technet.microsoft.com/en-us/sqlserver/bb671430.aspx
-- http://gallery.technet.microsoft.com/ScriptCenter/en-us/site/search?f%5B0%5D.Type=Tag&f%5B0%5D.Value=SQL%20Server%202005
use master
go
drop database MSCSSDMV
go
create database MSCSSDMV
go
use MSCSSDMV
go
--Use the following query to list all the schedulers 
--and look at the number of runnable tasks.
select  scheduler_id,  current_tasks_count,  runnable_tasks_count
into DMV_dm_os_schedulers
from sys.dm_os_schedulers
where scheduler_id < 255
go

/*
The query against sys.dm_exec_query_stats is an efficient way to determine which query is using the most cumulative CPU.
*/
select 
    highest_cpu_queries.*,q.dbid, 
    q.objectid, q.number, q.encrypted, q.[text]
into DMV_Top50_CPU_Commands
from 
    (select top 50 qs.*
    from sys.dm_exec_query_stats qs
    order by qs.total_worker_time desc) as highest_cpu_queries
    cross apply sys.dm_exec_sql_text(plan_handle) as q
order by highest_cpu_queries.total_worker_time desc
go

--Gives you the top 25 stored procedures that have been recompiled.

select top 25 sql_text.text, sql_handle, plan_generation_num,  execution_count,
    dbid,  objectid 
into DMV_Top25_Recompile_Commands
from sys.dm_exec_query_stats a
    cross apply sys.dm_exec_sql_text(sql_handle) as sql_text
where plan_generation_num >1
order by plan_generation_num desc
go

-- sys.dm_os_wait_stats 
select * 
into DMV_dm_os_wait_stats 
from 	sys.dm_os_wait_stats  
go

--Top 50 IO contributer.
select top 50 
    (total_logical_reads/execution_count) as avg_logical_reads,
    (total_logical_writes/execution_count) as avg_logical_writes,
    (total_physical_reads/execution_count) as avg_phys_reads,
     Execution_count, 
    statement_start_offset as stmt_start_offset, statement_end_offset as stmt_end_offset,
    sql_handle, 
substring(sql_text.text, (statement_start_offset/2), 
case 
when (statement_end_offset -statement_start_offset)/2 <=0 then 64000
else (statement_end_offset -statement_start_offset)/2
end) as exec_statement,  
sql_text.text,
    plan_handle, plan_text.*
into DMV_Top50_IO
from sys.dm_exec_query_stats  
cross apply sys.dm_exec_sql_text(sql_handle) as sql_text
cross apply sys.dm_exec_query_plan(plan_handle) as plan_text
order by 
 (total_logical_reads + total_logical_writes) /Execution_count Desc
go

--Returns current low-level I/O, locking, latching, and access method activity for each partition of a table or index in the database. 
SELECT * 
into DMV_dm_db_index_operational_stats
FROM sys.dm_db_index_operational_stats(NULL, NULL, NULL, NULL);
GO 

--Calculate Average Stalls per database file 
select database_id, file_id
	,io_stall_read_ms
	,num_of_reads
	,cast(io_stall_read_ms/(1.0+num_of_reads) as numeric(10,1)) as 'avg_read_stall_ms'
	,io_stall_write_ms
	,num_of_writes
	,cast(io_stall_write_ms/(1.0+num_of_writes) as numeric(10,1)) as 'avg_write_stall_ms'
	,io_stall_read_ms + io_stall_write_ms as io_stalls
	,num_of_reads + num_of_writes as total_io
	,cast((io_stall_read_ms+io_stall_write_ms)/(1.0+num_of_reads + num_of_writes) as numeric(10,1)) as 'avg_io_stall_ms'
into DVM_File_Average_Stalls	
from sys.dm_io_virtual_file_stats(null,null)
order by avg_io_stall_ms desc


-- Tempdb.
-- An overview query.

Select
    SUM (user_object_reserved_page_count)*8 as user_objects_kb,
    SUM (internal_object_reserved_page_count)*8 as internal_objects_kb,
    SUM (version_store_reserved_page_count)*8  as version_store_kb,
    SUM (unallocated_extent_page_count)*8 as freespace_kb
into DMV_Tempdb_Overall_Usage
From sys.dm_db_file_space_usage
Where database_id = 2
go

-- Determine tempdb space used by Task

SELECT t1.session_id,
(t1.internal_objects_alloc_page_count + task_alloc)
	as allocated,
(t1.internal_objects_dealloc_page_count + task_dealloc) as deallocated 
into DMV_Tempdb_Usage_By_Session
from sys.dm_db_session_space_usage as t1, 
(select session_id, 
 sum(internal_objects_alloc_page_count)
 	as task_alloc,
 sum (internal_objects_dealloc_page_count)
	as task_dealloc 
 from sys.dm_db_task_space_usage group by session_id) as t2
 where t1.session_id = t2.session_id
   and t2.session_id >50
 order by allocated DESC
go

-- The following DMV query can be used to get useful information about the index usage for all objects in all databases.
select * 
into DMV_dm_db_index_usage_stats
from sys.dm_db_index_usage_stats 
order by database_id, object_id, index_id
go

CREATE TABLE [dbo].[DMV_Buffer_Counts_By_Objects](
	[database_id] [int] NULL,
	[db] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[object_id] [int] NOT NULL,
	[index_id] [int] NOT NULL,
	[buffer_count] [int] NULL
) ON [PRIMARY]
go

USE [MSCSSDMV]
GO
/****** Object:  Table [dbo].[chenTable_Index_Access_Type]    Script Date: 01/18/2007 15:45:10 ******/

CREATE TABLE [dbo].[Table_Index_Access_Type](
	[database_id] [int] NULL,
	[db] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[object] [int] NOT NULL,
	[index_id] [int] NOT NULL,
	[user reads] [bigint] NULL,
	[system reads] [bigint] NULL,
	[user writes] [bigint] NOT NULL,
	[system writes] [bigint] NOT NULL
) ON [PRIMARY]
go

CREATE TABLE [dbo].[Table_Index_Access_Type_2](
	[database_id] [int] NULL,
	[db] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[object] [int] NOT NULL,
	[index_id] [int] NOT NULL,
	[usage_reads] [bigint] NULL,
	[operational_reads] [bigint] NULL,
	[range_scan_count] [bigint] NOT NULL,
	[singleton_lookup_count] [bigint] NOT NULL,
	[usage writes] [bigint] NOT NULL,
	[operational_leaf_writes] [bigint] NULL,
	[leaf_insert_count] [bigint] NOT NULL,
	[leaf_update_count] [bigint] NOT NULL,
	[leaf_delete_count] [bigint] NOT NULL,
	[operational_leaf_page_splits] [bigint] NOT NULL,
	[operational_nonleaf_writes] [bigint] NULL,
	[operational_nonleaf_page_splits] [bigint] NOT NULL
) ON [PRIMARY]

go
CREATE TABLE [dbo].[Table_Index_names](
	[database_id] [int] NULL,
	[db] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Object] [int] NOT NULL,
	[Index_Id] [smallint] NULL,
	[TableName] [sysname] COLLATE Latin1_General_CI_AS NOT NULL,
	[IndexName] [sysname] COLLATE Latin1_General_CI_AS NULL,
	[Rows] [int] NULL
) ON [PRIMARY]
go

declare @name nvarchar(100)
declare @cmd nvarchar(1000)
declare dbnames cursor for
select name from master.dbo.sysdatabases
open dbnames
fetch next from dbnames into @name
while @@fetch_status = 0
begin
set @cmd = 'insert into Table_Index_names select db_id(''' + @name + '''), '''+@name +''',
a.id as ObjectId, a.indid as IndexId, b.name as TableName, a.name as IndexName, a.rows as Rows from [' + @name + '].dbo.sysindexes a inner join [' + @name + '].dbo.sysobjects b on a.id = b.id'
exec (@cmd)


--- Determine the data pages by tables
set @cmd = 'insert into DMV_Buffer_Counts_By_Objects
select b.database_id, db=db_name(b.database_id)
		,p.object_id
		,p.index_id
		,buffer_count=count(*)
from ' + @name + '.sys.allocation_units a, '
+ @name +	'.sys.dm_os_buffer_descriptors b, '
+ @name	+	'.sys.partitions p
where a.allocation_unit_id = b.allocation_unit_id
and a.container_id = p.hobt_id
and b.database_id = db_id(''' + @name + ''')
group by b.database_id,p.object_id, p.index_id
order by b.database_id, buffer_count desc'
exec (@cmd)

-- Determine Index Cost Benefits
--- sys.dm_db_index_usage_stats

set @cmd =
'insert into Table_Index_Access_Type select db_id(''' + @name + '''), '''+@name +''',
''object'' = object_id,index_id '
+		',''user reads'' = user_seeks + user_scans + user_lookups '
+		',''system reads'' = system_seeks + system_scans + system_lookups '
+		',''user writes'' = user_updates '
+		',''system writes'' = system_updates '
+ 'from sys.dm_db_index_usage_stats '
+ 'where database_id = db_id (''' + @name + ''') '
+ 'order by ''user reads'' desc '
exec (@cmd)

set @cmd =
'insert into Table_Index_Access_Type_2 select db_id(''' + @name + '''), '''+@name +''',
 ''object''=o.object_id, o.index_id '+
		', ''usage_reads''=user_seeks + user_scans + user_lookups '+
		', ''operational_reads''=range_scan_count + singleton_lookup_count '+
		', range_scan_count '+
		', singleton_lookup_count '+
		', ''usage writes'' =  user_updates '+
		', ''operational_leaf_writes''=leaf_insert_count+leaf_update_count+ leaf_delete_count '+
		', leaf_insert_count,leaf_update_count,leaf_delete_count '+
		', ''operational_leaf_page_splits'' = leaf_allocation_count '+
		', ''operational_nonleaf_writes''=nonleaf_insert_count + nonleaf_update_count + nonleaf_delete_count '+
		', ''operational_nonleaf_page_splits'' = nonleaf_allocation_count '+
+ 'from sys.dm_db_index_operational_stats (db_id(''' + @name + '''),NULL,NULL,NULL) o '+
	',sys.dm_db_index_usage_stats u '+
'where u.database_id = db_id (''' + @name + ''') and
u.object_id = o.object_id and u.index_id = o.index_id '+
'order by operational_reads desc, operational_leaf_writes, operational_nonleaf_writes '
exec (@cmd)


fetch next from dbnames into @name
end
close dbnames
deallocate dbnames
go

-- Determine CPU Resources Required for Optimization
/*
Select * from sys.dm_exec_query_optimizer_info
where counter in ('optimizations','elapsed time','trivial plan','tables','insert stmt','update stmt','delete stmt')
*/

Select * 
into DMV_dm_exec_query_optimizer_info
from sys.dm_exec_query_optimizer_info
go

-- Retrieve Statements with the Highest Plan Re-Use Counts
SELECT TOP 100
        qs.sql_handle
		,qs.plan_handle
		,cp.cacheobjtype
		,cp.usecounts
		,cp.size_in_bytes  
		,qs.statement_start_offset
		,qs.statement_end_offset
		,qt.dbid
		,qt.objectid
		,qt.text
		,SUBSTRING(qt.text,qs.statement_start_offset/2, 
			(case when qs.statement_end_offset = -1 
			then len(convert(nvarchar(max), qt.text)) * 2 
			else qs.statement_end_offset end -qs.statement_start_offset)/2) 
		as statement
into DMV_Top100_Reuse_Plan		
FROM sys.dm_exec_query_stats qs
cross apply sys.dm_exec_sql_text(qs.sql_handle) as qt
inner join sys.dm_exec_cached_plans as cp on qs.plan_handle=cp.plan_handle
where cp.plan_handle=qs.plan_handle
--and qt.dbid = db_id()
ORDER BY [dbid],[Usecounts] DESC
go
--Retrieve Statements with the Lowest Plan Re-Use Counts
SELECT TOP 100
        cp.cacheobjtype
		,cp.usecounts
		,size=cp.size_in_bytes  
		,stmt_start=qs.statement_start_offset
		,stmt_end=qs.statement_end_offset
		,qt.dbid
		,qt.objectid
		,qt.text
		,SUBSTRING(qt.text,qs.statement_start_offset/2, 
			(case when qs.statement_end_offset = -1 
			then len(convert(nvarchar(max), qt.text)) * 2 
			else qs.statement_end_offset end -qs.statement_start_offset)/2) 
		as statement
		,qs.sql_handle
		,qs.plan_handle
into DMV_Top100_NoReuse_Plan
FROM sys.dm_exec_query_stats qs
cross apply sys.dm_exec_sql_text(qs.sql_handle) as qt
inner join sys.dm_exec_cached_plans as cp on qs.plan_handle=cp.plan_handle
where cp.plan_handle=qs.plan_handle
and qt.dbid is NULL
ORDER BY [usecounts],[statement] asc
go
-- Retrieve Parallel Statements With the Highest Worker Time
SELECT TOP 100 qs.total_worker_time,
			qs.total_elapsed_time,
            SUBSTRING(qt.text,qs.statement_start_offset/2, 
			(case when qs.statement_end_offset = -1 
			then len(convert(nvarchar(max), qt.text)) * 2 
			else qs.statement_end_offset end -qs.statement_start_offset)/2) 
		as query_text,
		qt.dbid, dbname=db_name(qt.dbid),
		qt.objectid,
		qs.sql_handle,
		qs.plan_handle
into DMV_HighCPU_Parallel_Statements		
FROM sys.dm_exec_query_stats qs
cross apply sys.dm_exec_sql_text(qs.sql_handle) as qt
where qs.total_worker_time > qs.total_elapsed_time
ORDER BY 
       qs.total_worker_time DESC
go
----------------------
--Indexes and Indexing
----------------------
-- Identify Missing Indexes
select d.*
		, s.avg_total_user_cost
		, s.avg_user_impact
		, s.last_user_seek
		,s.unique_compiles
Into DMV_Missing_Indexes		
from sys.dm_db_missing_index_group_stats s
		,sys.dm_db_missing_index_groups g
		,sys.dm_db_missing_index_details d
where s.group_handle = g.index_group_handle
and d.index_handle = g.index_handle
order by s.avg_user_impact desc

go

----------------------
--Ring Buffer
----------------------
DECLARE @runtime datetime
SET @runtime = GETDATE()
SELECT CONVERT (varchar(30), @runtime, 121) as runtime, 
  DATEADD (ms, ring.[timestamp] - sys.ms_ticks, GETDATE()) AS record_time, 
  ring.[timestamp] AS record_timestamp, sys.ms_ticks AS cur_timestamp, ring.* 
into DMV_dm_os_ring_buffers
FROM sys.dm_os_ring_buffers ring
CROSS JOIN sys.dm_os_sys_info sys

----------------------
---Determine memory usage by connection
----------------------
SELECT top 200
((granted_query_memory * 8192)/1024) As GrantedMemoryInKb, s3.*,
start_time,
(SELECT SUBSTRING(text,statement_start_offset/2,(CASE WHEN statement_end_offset = 
-1 then LEN(CONVERT(nvarchar(max), text)) * 2 ELSE statement_end_offset end 
-statement_start_offset)/2) FROM sys.dm_exec_sql_text(sql_handle)) AS query_text, 
SUBSTRING(text, 1, 200) as Text_header
into Memory_Usage_By_Connection
FROM 
sys.dm_exec_requests s1 
CROSS APPLY sys.dm_exec_sql_text(sql_handle) AS s2 
inner join sys.dm_exec_sessions  s3 on s1.session_id = s3.session_id
where granted_query_memory <> 0
order by granted_query_memory desc

backup database MSCSSDMV to disk = 'c:\MSCSSDMV.bak'
go
use master
go


