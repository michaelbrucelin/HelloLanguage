use MSCSSDMV
go
--Use the following query to list all the schedulers 
--and look at the number of runnable tasks.
select  *  
from DMV_dm_os_schedulers
go
/*
The query against sys.dm_exec_query_stats 
is an efficient way to determine which query is using the most 
cumulative CPU.
*/
select * from DMV_Top50_CPU_Commands
go

--Gives you the top 25 stored procedures that have been recompiled.
select * from DMV_Top25_Recompile_Commands
go

-- sys.dm_os_wait_stats 
select * 
from DMV_dm_os_wait_stats
order by waiting_tasks_count desc
go

--Top 50 IO contributer.
select * from DMV_Top50_IO
go

--Returns current low-level I/O, locking, latching, and access method activity for each partition of a table or index in the database. 
-- over all
SELECT * 
from DMV_dm_db_index_operational_stats

-- for modifications
SELECT b.db, b.TableName, b.IndexName, a.* 
from DMV_dm_db_index_operational_stats a 
inner join [dbo].[Table_Index_names] b
on a.database_id = b.database_id
and a.object_id = b.object
and a.index_id = b.index_id
order by leaf_insert_count + leaf_delete_count + leaf_update_count desc
GO 

-- for blockings
SELECT b.db, b.TableName, b.IndexName, a.* 
from DMV_dm_db_index_operational_stats a 
inner join [dbo].[Table_Index_names] b
on a.database_id = b.database_id
and a.object_id = b.object
and a.index_id = b.index_id
order by row_lock_wait_in_ms + page_lock_wait_in_ms desc
GO 

-- For IO bottleneck
SELECT b.db, b.TableName, b.IndexName, a.* 
from DMV_dm_db_index_operational_stats a 
inner join [dbo].[Table_Index_names] b
on a.database_id = b.database_id
and a.object_id = b.object
and a.index_id = b.index_id
order by page_io_latch_wait_in_ms desc
GO 

--Calculate Average Stalls per database file 
select * from DVM_File_Average_Stalls	

-- Tempdb.
-- An overview query.
Select
    * from DMV_Tempdb_Overall_Usage
go

-- Determine tempdb space used by Task

SELECT * from DMV_Tempdb_Usage_By_Session
go

-- The following DMV query can be used to get useful information 
-- about the index usage for all objects in all databases.
select b.db, b.TableName, b.IndexName, a.* 
from DMV_dm_db_index_usage_stats a
inner join [dbo].[Table_Index_names] b
on a.database_id = b.database_id
and a.object_id = b.object
and a.index_id = b.index_id
order by user_seeks + user_scans + user_lookups + user_updates desc
go

-- Buffer pool allocated by objects
select b.db, b.TableName, b.IndexName, a.* 
from [dbo].[DMV_Buffer_Counts_By_Objects] a
inner join [dbo].[Table_Index_names] b
on a.database_id = b.database_id
and a.object_id = b.object
and a.index_id = b.index_id
order by buffer_count desc
go

-- Table and Index general access type
select * from [dbo].[Table_Index_Access_Type]
go

-- Table and Index access type in detail
select * from [dbo].[Table_Index_Access_Type_2]
go

-- All the index and tables in the SQL Server
select * from [dbo].[Table_Index_names]
go

-- Determine CPU Resources Required for Optimization
/*
Select * from sys.dm_exec_query_optimizer_info
where counter in ('optimizations','elapsed time','trivial plan','tables','insert stmt','update stmt','delete stmt')
*/

Select * 
from DMV_dm_exec_query_optimizer_info
order by occurrence desc
go

-- Retrieve Statements with the Highest Plan Re-Use Counts
SELECT * from DMV_Top100_Reuse_Plan		
go

--Retrieve Statements with the Lowest Plan Re-Use Counts
SELECT * from DMV_Top100_NoReuse_Plan
go

-- Retrieve Parallel Statements With the Highest Worker Time
SELECT * from DMV_HighCPU_Parallel_Statements		
go
----------------------
--Indexes and Indexing
----------------------
-- Identify Missing Indexes
select  b.db, b.TableName, b.IndexName, 
a.equality_columns, inequality_columns, a.included_columns,
a.statement, a.avg_total_user_cost, a.avg_user_impact 
from DMV_Missing_Indexes a
inner join [dbo].[Table_Index_names] b
on a.database_id = b.database_id
and a.object_id = b.object
go

----------------------
--Ring Buffer
----------------------
select * from DMV_dm_os_ring_buffers

SELECT a.*
FROM
(SELECT
      x.value('(//Record/@id)[1]', 'bigint') AS [Record Id],
      x.value('(//Record/@type)[1]', 'varchar(30)') AS [Type],
      x.value('(//Record/@time)[1]', 'bigint') AS [Time],
      x.value('(//Record/Scheduler/@address)[1]', 'varchar(30)') AS [Scheduler Address],
      x.value('(//Record/Scheduler/Action)[1]', 'varchar(30)') AS [Scheduler Action],
      x.value('(//Record/Scheduler/CPUTicks)[1]', 'bigint') AS [Scheduler CPUTicks],
      x.value('(//Record/Scheduler/TickCount)[1]', 'bigint') AS [Scheduler TickCount],
      x.value('(//Record/Scheduler/SourceWorker)[1]', 'varchar(30)') AS [Scheduler SourceWorker],
      x.value('(//Record/Scheduler/TargetWorker)[1]', 'varchar(30)') AS [Scheduler TargetWorker],
      x.value('(//Record/Scheduler/WorkerSignalTime)[1]', 'bigint') AS [Scheduler WorkerSignalTime],
      x.value('(//Record/Scheduler/DiskIOCompleted)[1]', 'bigint') AS [Scheduler DiskIOCompleted],
      x.value('(//Record/Scheduler/TimersExpired)[1]', 'bigint') AS [Scheduler TimersExpired]
FROM
      (SELECT CAST (record as xml)
      FROM DMV_dm_os_ring_buffers 
      WHERE ring_buffer_type = 'RING_BUFFER_SCHEDULER' ) AS R(x)) a
WHERE a.[Scheduler Action] = 'SCHEDULER_SWITCH_CONTEXT'
ORDER BY
      a.[Scheduler Address],
      a.[Time]

SELECT 
      a.[Scheduler Address] , a.[Scheduler Action], COUNT(*) as RingBufferEntryCount,
      MIN(a.y) as Min_Time , MAX(a.y) as Max_Time , 
      MIN(a.[Record Time]) as Min_Time_ms , MAX(a.[Record Time]) as Max_Time_ms
FROM
(SELECT y,
      x.value('(//Record/@id)[1]', 'bigint') AS [Record Id],
      x.value('(//Record/@type)[1]', 'varchar(30)') AS [Record Type],
      x.value('(//Record/@time)[1]', 'bigint') AS [Record Time],
      x.value('(//Record/Scheduler/@address)[1]', 'varchar(30)') AS [Scheduler Address],
      x.value('(//Record/Scheduler/Action)[1]', 'varchar(30)') AS [Scheduler Action]
FROM
      (SELECT CAST (record as xml),record_time
      FROM DMV_dm_os_ring_buffers
      WHERE ring_buffer_type = 'RING_BUFFER_SCHEDULER' ) AS R(x,y)) a
GROUP BY
      a.[Scheduler Address],
      a.[Scheduler Action]
ORDER BY
      a.[Scheduler Address],
      a.[Scheduler Action]

--SQLMemoryPagingError 
SELECT 
CONVERT (varchar(30), GETDATE(), 121) as runtime,
DATEADD (ms, a.[Record Time] - sys.ms_ticks, GETDATE()) AS Notification_time,  
 a.* ,
sys.ms_ticks AS [Current Time]
 FROM 
 (SELECT x.value('(//Record/ResourceMonitor/Notification)[1]', 'varchar(30)') AS [Notification_type], 
 x.value('(//Record/MemoryRecord/MemoryUtilization)[1]', 'int') AS [MemoryUtilization %], 
 x.value('(//Record/MemoryRecord/TotalPhysicalMemory)[1]', 'bigint') AS [TotalPhysicalMemory_KB], 
 x.value('(//Record/MemoryRecord/AvailablePhysicalMemory)[1]', 'bigint') AS [AvailablePhysicalMemory_KB], 
 x.value('(//Record/MemoryRecord/TotalPageFile)[1]', 'bigint') AS [TotalPageFile_KB], 
 x.value('(//Record/MemoryRecord/AvailablePageFile)[1]', 'bigint') AS [AvailablePageFile_KB], 
 x.value('(//Record/MemoryRecord/TotalVirtualAddressSpace)[1]', 'bigint') AS [TotalVirtualAddressSpace_KB], 
 x.value('(//Record/MemoryRecord/AvailableVirtualAddressSpace)[1]', 'bigint') AS [AvailableVirtualAddressSpace_KB], 
 x.value('(//Record/MemoryNode/@id)[1]', 'int') AS [Node Id], 
 x.value('(//Record/MemoryNode/ReservedMemory)[1]', 'bigint') AS [SQL_ReservedMemory_KB], 
 x.value('(//Record/MemoryNode/CommittedMemory)[1]', 'bigint') AS [SQL_CommittedMemory_KB], 
 x.value('(//Record/@id)[1]', 'bigint') AS [Record Id], 
 x.value('(//Record/@type)[1]', 'varchar(30)') AS [Type], 
 x.value('(//Record/ResourceMonitor/Indicators)[1]', 'int') AS [Indicators], 
 x.value('(//Record/@time)[1]', 'bigint') AS [Record Time]
 FROM (SELECT CAST (record as xml) FROM DMV_dm_os_ring_buffers 
 WHERE ring_buffer_type = 'RING_BUFFER_RESOURCE_MONITOR') AS R(x)) a 
CROSS JOIN sys.dm_os_sys_info sys
ORDER BY DATEADD (ms, a.[Record Time] - sys.ms_ticks, GETDATE())

----------------------
---Determine memory usage by running connection
----------------------
select * from Memory_Usage_By_Connection





