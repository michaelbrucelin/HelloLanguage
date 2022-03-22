SELECT execution_count, (total_elapsed_time / execution_count / 1000 ) avg_time, [text]
FROM sys.dm_exec_query_stats qs
CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) AS st
ORDER BY execution_count DESC