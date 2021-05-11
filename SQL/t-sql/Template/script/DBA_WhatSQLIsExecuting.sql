-- Do not lock anything, and do not get held up by any locks.
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
-- What SQL Statements Are Currently Running?
select session_Id as spid, ecid, DB_NAME(b.dbid) as [database], hostname,
    DATEDIFF(SS,start_time,GETDATE()) as timespan,
    start_time, nt_username as [user], a.status as [status], wait_type as wait,
    SUBSTRING(c.text, a.statement_start_offset/2, (case when a.statement_end_offset = -1 
                                                        then LEN(CONVERT(NVARCHAR(MAX),c.text))*2
                                                        else a.statement_end_offset
                                                   end - a.statement_start_offset)/2) as [individual query],
    c.text as [parent query], program_name as program, nt_domain
from sys.dm_exec_requests as a
    inner join sys.sysprocesses as b on a.session_id = b.spid
cross apply sys.dm_exec_sql_text(a.sql_handle) as c
where session_Id > 50 and -- Ignore system spids.
    session_Id not in (@@SPID)
-- Ignore this current statement.
order by hostname asc, start_time asc
