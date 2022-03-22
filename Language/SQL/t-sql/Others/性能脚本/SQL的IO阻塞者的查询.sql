select blocking_session_id, wait_duration_ms, session_id
from sys.dm_os_waiting_tasks
where blocking_session_id is not null

--dbcc INPUTBUFFER(87)
