-- 查询数据库中锁的信息

-- 1. 检查数据库锁与阻塞的情况
select a.session_id as spid, blocking_session_id as blkBy, DB_NAME(database_id) as dbname, wait_type
       , LTRIM(STR(wait_time/1000/60))+'.'+
         LTRIM(STR(wait_time/1000%60))+'.'+
         LTRIM(STR(wait_time%1000)) as wait_time
       , command, d1.text as sqlText, d2.text as blkByTest, wait_resource
from sys.dm_exec_requests as a
inner join sys.dm_exec_connections as b on a.blocking_session_id = b.session_id
outer apply sys.dm_exec_sql_text(a.sql_handle) as d1
outer apply sys.dm_exec_sql_text(b.most_recent_sql_handle) as d2
where blocking_session_id > 0

-- 2. 检查数据库锁与阻塞的详细情况
declare @spidAndBlkBy table(spid int, blkBy int);
--找出阻塞的sessionId
insert into @spidAndBlkBy(spid, blkBy)
select session_id, blocking_session_id from sys.dm_exec_requests where blocking_session_id > 0

--查询阻塞的请求信息
select a.session_id as spid, blocking_session_id as blkBy, DB_NAME(database_id) as dbname, wait_type
       , LTRIM(STR(wait_time/1000/60))+'.'+
         LTRIM(STR(wait_time/1000%60))+'.'+
         LTRIM(STR(wait_time%1000)) as wait_time
       , command, d1.text as sqlText, d2.text as blkByTest, wait_resource
from sys.dm_exec_requests as a
inner join sys.dm_exec_connections as b on a.blocking_session_id = b.session_id
inner join @spidAndBlkBy c on a.session_id = c.spid and a.blocking_session_id = c.blkBy
outer apply sys.dm_exec_sql_text(a.sql_handle) as d1
outer apply sys.dm_exec_sql_text(b.most_recent_sql_handle) as d2

--查询阻塞的连接信息
select session_id as spid, connect_time, last_read, last_write, b.text
from sys.dm_exec_connections as a
outer apply sys.dm_exec_sql_text(a.most_recent_sql_handle) as b
where session_id in (select spid from @spidAndBlkBy union all select blkBy from @spidAndBlkBy)

--查询阻塞的session信息
select session_id as spid, login_time, host_name, program_name, login_name, nt_user_name
       ,last_request_start_time, last_request_end_time
from sys.dm_exec_sessions
where session_id in (select spid from @spidAndBlkBy union all select blkBy from @spidAndBlkBy)

--查询阻塞的锁的信息
select request_session_id as spid, resource_type as restype, resource_database_id as dbid, DB_NAME(resource_database_id) as dbname
       , resource_description as res, resource_associated_entity_id as resid
       , case when resource_associated_entity_id <= 2147483648
              then OBJECT_SCHEMA_NAME(resource_associated_entity_id,resource_database_id) + '.' +
                   OBJECT_NAME(resource_associated_entity_id,resource_database_id) end as objname
       , request_mode, request_status
from sys.dm_tran_locks
where request_session_id in(select spid from @spidAndBlkBy union all select blkBy from @spidAndBlkBy)
