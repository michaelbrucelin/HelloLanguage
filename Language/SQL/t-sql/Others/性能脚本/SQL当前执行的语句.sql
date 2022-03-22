SELECT
    es.session_id,
    database_name = DB_NAME(database_id),
    login_name,
    er.status,
    wait_type,
    individual_query = SUBSTRING (qt.text, er.statement_start_offset/2, (CASE WHEN er.statement_end_offset = -1 THEN LEN(CONVERT(NVARCHAR(MAX), qt.text)) * 2 ELSE er.statement_end_offset END - er.statement_start_offset)/2),
    parent_query = qt.text,
    program_name,
    host_name,
    nt_domain,
    start_time
FROM
    sys.dm_exec_requests er
    INNER JOIN sys.dm_exec_sessions es ON er.session_id = es.session_id
    CROSS APPLY sys.dm_exec_sql_text(er.sql_handle)as qt
WHERE es.session_id > 50 AND es.session_Id NOT IN (@@SPID)
ORDER BY 1, 2