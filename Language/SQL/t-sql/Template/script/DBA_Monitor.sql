-- 一些性能监控脚本

--查询内存中的数据页面由哪些表格组成，各占多少？
--1、可以看出应用经常访问哪些表，有多大。
--2、如果以间隔很短的时间运行上面的脚本，前后返回的结果有很大的差异，说明sql server刚刚为新的数据做了paging，sql的缓冲区有压力，而在后面那次运行出现的新数据，就是刚刚page in进来的数据。
--3、在一条语句第一次执行前后各运行一遍上面的脚本，就可以知道这条语句要读入多少数据到内存里。
select db_name(b.database_id) as db,OBJECT_NAME(p.object_id) as [object_name],p.index_id,i.name as index_name,count(1) as buffer_count
from ecology.sys.allocation_units a
inner join ecology.sys.dm_os_buffer_descriptors b on a.allocation_unit_id = b.allocation_unit_id
inner join ecology.sys.partitions p on a.container_id = p.hobt_id
inner join ecology.sys.indexes as i on p.object_id = i.object_id and p.index_id = i.index_id
--inner join ecology.sys.sysindexes as i on p.object_id = i.id and p.index_id = i.indid
where b.database_id = db_id('ecology')
group by b.database_id,p.object_id, p.index_id, i.name
order by buffer_count desc

--执行计划都缓存了些什么，哪些比较占内存？
--查询各个对象各占了多少内存
select objtype, sum(convert(bigint,size_in_bytes)) as sum_size_in_bytes, count(bucketid) as cache_counts
from sys.dm_exec_cached_plans
group by objtype
--分析具体存储了哪些对象，最好把结果输出到一个文件里没因为这个结果在生产服务器可能会很大，输出到Management Studio中，对服务器资源会有争用
select usecounts, refcounts, size_in_bytes, cacheobjtype, objtype, text
from sys.dm_exec_cached_plans as cp
cross apply sys.dm_exec_sql_text(plan_handle)
order by objtype desc

--通过运行下面的查询得到每个文件的信息可以了解
--哪个文件经常要做读(num_of_reads/ num_of_bytes_read)
--哪个经常要做写(num_of_writes/ num_of_bytes_written)
--哪个文件的读写经常要等待(io_stall_read_ms/ io_stall_write_ms/ io_stall)
select db.name as [db_name],f.name as [file_name],f.filename as [file_fullname],
       i.num_of_reads  as [read_cnt], i.num_of_bytes_read    as [read_bytes], i.io_stall_read_ms/1000  as [read_time_sec],
       i.num_of_writes as [write_cnt],i.num_of_bytes_written as [write_bytes],i.io_stall_write_ms/1000 as [write_time_sec],
       i.io_stall, i.size_on_disk_bytes
from sys.databases as db
inner join sys.sysaltfiles as f on db.database_id = f.dbid
inner join sys.dm_io_virtual_file_stats(NULL, NULL) as i
on i.database_id = f.dbid and i.file_id = f.fileid

--动态管理视图sys.dm_io_pending_io_requests，可以告诉管理员当前SQL Server中每个处于挂起状态的I/O请求。
select db.name as [db_name],f.name as [file_name],f.filename as [file_fullname],
       io_stall,io_pending_ms_ticks,scheduler_address
from sys.dm_io_virtual_file_stats(NULL, NULL) as t1
inner join sys.dm_io_pending_io_requests as t2 on t1.file_handle = t2.io_handle
inner join sys.databases as db on t1.database_id = db.database_id
inner join sys.sysaltfiles as f on t1.file_id = f.fileid and t1.database_id = f.dbid

--SQL 2005和SQL 2008有个动态管理视图sys.dm_os_schedulers，可以反映当前每个scheduler的状态。
select scheduler_id,cpu_id,parent_node_id,
       current_tasks_count,runnable_tasks_count,
       current_workers_count,active_workers_count,work_queue_count
from sys.dm_os_schedulers

--使用DMV来分析SQL Server启动以来累计使用CPU资源最多的语句。例如下面的语句就可以列出前名。
;with highest_cpu_queries as(
select top (50) plan_handle,total_worker_time
from sys.dm_exec_query_stats
order by total_worker_time desc
)
select DB_NAME(q.dbid) as [db], OBJECT_NAME(q.objectid) as [object], q.number, q.encrypted, q.[text]
from highest_cpu_queries as a
cross apply sys.dm_exec_sql_text(a.plan_handle) as q
order by a.total_worker_time desc

--我们也可以找到最经常做重编译的存储过程。
select top (25) DB_NAME(dbid) as [db],OBJECT_NAME(objectid) as [object],
       sql_text.text,sql_handle,plan_generation_num,execution_count
from sys.dm_exec_query_stats a
cross apply sys.dm_exec_sql_text(sql_handle) as sql_text
where plan_generation_num >1
order by plan_generation_num desc
