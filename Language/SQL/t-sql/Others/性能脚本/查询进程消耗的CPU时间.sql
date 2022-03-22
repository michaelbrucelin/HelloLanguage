--线程 ID、消耗CPU时间、等待资源类型
select session_id, cpu_time, wait_Type
from sys.dm_exec_requests
order by cpu_time desc

--dbcc inputbuffer(62)
--kill 641
