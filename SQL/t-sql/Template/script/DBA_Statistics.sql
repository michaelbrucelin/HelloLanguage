-- 一些统计查询，未整理

-- 历史占用CPU
SELECT TOP 20
    total_worker_time/execution_count AS avg_cpu_cost, plan_handle,
    execution_count,
    (SELECT SUBSTRING(text, statement_start_offset/2 + 1,
            (CASE WHEN statement_end_offset = -1
                  THEN LEN(CONVERT(nvarchar(max), text)) * 2
             ELSE statement_end_offset
             END - statement_start_offset)/2)
    FROM sys.dm_exec_sql_text(sql_handle)) AS query_text
FROM sys.dm_exec_query_stats
ORDER BY [avg_cpu_cost] DESC

-- 当前占用CPU
SELECT TOP 20
dest.[text] AS 'sql语句'
FROM sys.[dm_exec_requests] AS der
CROSS APPLY 
sys.[dm_exec_sql_text](der.[sql_handle]) AS dest
WHERE [session_id]>50
ORDER BY [cpu_time] DESC
