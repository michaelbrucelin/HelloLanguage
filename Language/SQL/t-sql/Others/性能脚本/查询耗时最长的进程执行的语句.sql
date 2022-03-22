SELECT TOP 5
    sum(qs.total_worker_time)/1000 AS total_cpu_time,
    sum(qs.execution_count)/1000 AS total_execution_count,
    count(*) AS number_of_statements,
    qs.plan_handle, qs.sql_handle
FROM sys.dm_exec_query_stats qs
GROUP BY qs.plan_handle,qs.sql_handle
ORDER BY sum(qs.total_worker_time) DESC

select *
from sys.dm_exec_sql_text(0x02000000C509101AB3AC036DD4A1EEA593D5EB0249617D76)
